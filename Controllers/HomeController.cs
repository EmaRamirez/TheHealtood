using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Storage;
using TheHealtood.Models;
using TheHealtood.Repository;
using TheHealtood.ViewModels;


namespace TheHealtood.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    

    public HomeController(IProductService productService)
    {

        this._productService = productService;
        
    }

    public IActionResult Index()
    {
        var List = _productService.GetAllProducts(" ").Take(5);
        List<HomeIndexViewModel> model = new List<HomeIndexViewModel>();
        foreach (var item in List)
        {
            var add = new HomeIndexViewModel
            {
                id = item.Id,
                name = item.Name,
                price = item.Price,
                ingredients = item.Ingredients,
                url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.gallery.Datos))
            };

            model.Add(add);

        }

        return View(model);
    }


    public IActionResult AllProducts()
    {
        var List = _productService.GetAllProducts(null);
        List<HomeAllProductsViewModel> model = new List<HomeAllProductsViewModel>();
        foreach (var item in List)
        {
            var add = new HomeAllProductsViewModel
            {
                id = item.Id,
                name = item.Name,
                price = item.Price,
                ingredients = item.Ingredients,
                url = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(item.gallery.Datos))
            };

            model.Add(add);

        }

        return View(model);
    }
    
   /* public IActionResult GetCarrito(int? id)
    {
        if (id == null)
        {
            var mostrar = _cartService.GetCart();
            if (mostrar is null)
            {
                var m = new Cart();
                return View(m);
            }
            return View(mostrar);
        }
        Cart ListAll = new Cart();

        if ((ListAll = _cartService.GetCart()) is null)
        {
            var product = _productService.GetById(id.Value);
            var listProd = new List<Products>();
            listProd.Add(product);
            var model = new Cart();
            model.ListProd = listProd;


            return View(_cartService.AddProduct(model));
        }
        var pro = _productService.GetById(id);

        ListAll.ListProd.Add(pro);
        var send = _cartService.UpdateCart(ListAll);
        return View(send);
    }
    public IActionResult PostCarrito(int id)
    {
        if (id == 1)
        {
            _cartService.DeleteCart();
            return RedirectToAction("Index");
        }
        return View();
    }

*/
}
