using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheHealtood.Models;
using TheHealtood.Repository;
using TheHealtood.ViewModels;



namespace TheHealtood.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _ProductServ;
    private readonly IGalleryService _GalleryServ;
    public ProductsController(IProductService ProductServ, IGalleryService GalleryServ)
    {
        this._ProductServ = ProductServ;
        this._GalleryServ = GalleryServ;
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
        return View();
    }
    [HttpPost]
    public IActionResult Create([FromForm] ProductsCreateViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var gallery = _GalleryServ.Create(obj.image);

        var prod = new Products(obj.Name, obj.Price, gallery.GalleryId);
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


        var model = new ProductsDetailViewModel(detail.Id, detail.Name, detail.Price, url);
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var details = _ProductServ.GetById(id);
        var model = new ProductsDetailViewModel(details.Id, details.Name, details.Price, details.gallery.Name);
        return View(model);
    }

    public IActionResult Edit([FromForm] ProductsDetailViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        //var product = new Products(obj.Name, obj.Price);
        // _ProductServ.Update(obj.Id, product);
        return RedirectToAction("Index");
    }

}

