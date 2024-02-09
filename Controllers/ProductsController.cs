using Microsoft.AspNetCore.Mvc;

namespace TheHealtood.Controllers;

public class ProductsController : Controller
{
    public ProductsController()
    {

    }

    public IActionResult Index(string Filter)
    {

        return View();
    }
}