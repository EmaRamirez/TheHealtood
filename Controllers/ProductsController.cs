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
    public ProductsController(IProductService ProductServ)
    {
        this._ProductServ = ProductServ;
    }

    public IActionResult Index(string Filter)
    {
        var model = new ProductsIndexViewModel();
        model.Products = _ProductServ.GetAllProducts(Filter);
        return View(model);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create([FromForm] ProductsCreateViewModel Obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var product = new Products(Obj.Name, Obj.Price);
        _ProductServ.Create(product);
        return RedirectToAction("Index");

    }

    public IActionResult Delete(int id)
    {
        _ProductServ.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var detail = _ProductServ.GetById(id);
        var model = new ProductsDetailViewModel(detail.Id, detail.Name, detail.Price);
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var details = _ProductServ.GetById(id);
        var model = new ProductsDetailViewModel(details.Id, details.Name, details.Price);
        return View(model);
    }

    public IActionResult Edit([FromForm] ProductsDetailViewModel obj)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var product = new Products(obj.Name, obj.Price);
        _ProductServ.Update(obj.Id, product);
        return RedirectToAction("Index");
    }
}