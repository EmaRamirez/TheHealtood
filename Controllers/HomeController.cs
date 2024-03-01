using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace TheHealtood.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
    //TODO : VER COMO HACER PARA EL CHECKBOX EN LA EDICION DE UN PLATO
}
