using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TheHealtood.Models;
using TheHealtood.Repository;
using TheHealtood.ViewModels;


namespace TheHealtood.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return null;
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


    public IActionResult GetCarrito(int id)
    {
        var listProd = new List<int>();
        listProd.Add(id);
        return View();
    }
    public IActionResult PostCarrito(List<int> obj)
    {
        return View();
    }
}
