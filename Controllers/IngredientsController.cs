using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
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

        for (var i = 0; i < listado.Count(); i++)
        {
            if (listado[i].ListProducts.Count() == 0)
            {
                listado[i].ListProducts.Add(new Products(0, "No hay menu con este ingrediente", 0, 1));
            }
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
        var aviso = new IngredientCreateViewModel();
        return View(aviso);
    }

    [HttpPost]
    public IActionResult Create(IngredientCreateViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var model = new Ingredient(obj.Name, obj.foodGroups.ToString());

        string msj = _IngreServ.Create(model);

        if (msj == "Ok")
        {
            return RedirectToAction("Index");
        }
        var aviso = new IngredientCreateViewModel();
        aviso.msj = msj;
        return View("Create",aviso);


    }

    public IActionResult Delete(int id)
    {
        _IngreServ.Delete(id);
        return RedirectToAction("Index");
    }
}