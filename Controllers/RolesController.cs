using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheHealtood.ViewModels;

namespace TheHealtood.Controllers;
[Authorize(Roles ="Administrador")]
public class RolesController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;


    public RolesController(RoleManager<IdentityRole> roleManager)
    {
        this._roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }
    [Authorize(Roles = "Administrador")]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(RoleCreateViewModel rol)
    {
        if (String.IsNullOrEmpty(rol.RoleName))
        {
            return View();
        }
        var role = new IdentityRole(rol.RoleName);
        _roleManager.CreateAsync(role);
        return RedirectToAction("Index");
    }
}