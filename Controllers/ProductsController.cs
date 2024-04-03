using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheHealtood.Models;
using TheHealtood.Repository;
using TheHealtood.ViewModels;



namespace TheHealtood.Controllers;

public class ProductsController : Controller
{
    private readonly IIngredientService _IngreServ;
    private readonly IProductService _ProductServ;
    private readonly IGalleryService _GalleryServ;

    public ProductsController(IProductService ProductServ, IGalleryService GalleryServ, IIngredientService IngreServ)
    {
        this._ProductServ = ProductServ;
        this._GalleryServ = GalleryServ;
        this._IngreServ = IngreServ;

    }

    public IActionResult Index(string Filter)
    {
        var listado = _ProductServ.GetAllProducts(Filter);
        var model = new List<ProductsIndexViewModel>();
        foreach (var item in listado)
        {
            var url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.gallery.Datos));
            model.Add(
                new ProductsIndexViewModel(item.Id, item.Name, item.Price, url)
            );
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["ingredients"] = _IngreServ.GetAll() is null ? new List<Ingredient>() : new SelectList(_IngreServ.GetAll(), "Id", "Name");

        return View();
    }
    [HttpPost]
    public IActionResult Create([FromForm] ProductsCreateViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }

        var gallery = _GalleryServ.Create(obj.image);

        var ListIngre = _IngreServ.AddIngre(obj.IngredientsId);

        var prod = new Products(obj.Name, obj.Price, gallery.GalleryId, ListIngre);


        _ProductServ.Create(prod);
        return RedirectToAction("Index");

    }
    
    public IActionResult Delete(int id)
    {

        var Details = _ProductServ.GetById(id);
        _GalleryServ.Delete(Details.GalleryId);

        _ProductServ.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var detail = _ProductServ.GetById(id);

        var url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(detail.gallery.Datos));


        var model = new ProductsDetailViewModel(detail.Id, detail.Name, detail.Price, url, detail.Ingredients);
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var details = _ProductServ.GetById(id);
        var url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(details.gallery.Datos));

        var model = new ProductEditViewModel
        {
            Id = details.Id,
            Name = details.Name,
            Price = details.Price,
            Url = url,
            listIngr = _IngreServ.GetAll()
        };
        foreach (var item in model.listIngr)
        {
            if (item.ListProducts.Contains(details))
            {
                item.seleted = true;
            }
        }
        return View(model);
    }

    public IActionResult Edit([FromForm] ProductEditViewModel obj)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }
        var details = _ProductServ.GetById(obj.Id);

        var image = obj.image != null ? _GalleryServ.Create(obj.image) : details.gallery;

        var list = new List<Ingredient>();
        for (int i = 0; i < obj.listIngr.Count(); i++)
        {
            if (obj.listIngr[i].seleted == true)
            {
                list.Add(new Ingredient(obj.listIngr[i].Name, obj.listIngr[i].FoodGroups));
            }
        }

        var producEdit = new Products(obj.Id, obj.Name, obj.Price, image.GalleryId, list);


        _ProductServ.Update(producEdit);



        //TO DO: SE ENCOTRO EL PROBLEMA, CUANDO HAGO EL UPDATE, ME DUPLICA LOS DATOS DE LOS INGREDIENTES





        return RedirectToAction("Index");
    }

}

