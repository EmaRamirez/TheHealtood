using Microsoft.AspNetCore.Mvc;
using TheHealtood.Models;
using TheHealtood.Repository;
using TheHealtood.ViewModels;

namespace TheHealtood.Controllers;

public class IngredientsController : Controller
{
    private readonly IIngredientService _IngreServ;
    public IngredientsController(IIngredientService IngreServ)
    {
        this._IngreServ = IngreServ;
    }

    public IActionResult Index(string filter)
    {
        var listado = new List<Ingredient>();
        listado = _IngreServ.GetAll();
        if (!string.IsNullOrEmpty(filter))
        {
            listado = _IngreServ.GetAll(filter);
        }


        var model = new IngredientIndexViewModel()
        {
            Ingredientes = listado,
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(IngredientCreateViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var model = new Ingredient()
        {
            Name = obj.Name,
            FoodGroups = obj.foodGroups.ToString(),
            foodGroups = obj.foodGroups

        };
        _IngreServ.Create(model);

        return RedirectToAction("Index");
    }

}