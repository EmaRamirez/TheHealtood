using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheHealtood.ViewModels;

namespace TheHealtood.Controllers;
[Authorize(Roles = "Administrador")]
public class UsersController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var users = _userManager.Users;


        var model = new List<UserIndexViewModel>();
        foreach (var item in users)
        {
            var add = new UserIndexViewModel();
            add.Username = item.UserName ?? string.Empty;
            model.Add(add);
        }
        return View(model);
    }
    public async Task<IActionResult> Edit(string userId)
    {
        var details = await _userManager.FindByIdAsync(userId);


        var model = new UserEditViewModel();
        model.UserName = details.UserName ?? string.Empty;
        model.Email = details.Email ?? string.Empty;
        model.Roles = new SelectList(_roleManager.Roles.ToList(), "Name");

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel obj)
    {
        var user = await _userManager.FindByNameAsync(obj.UserName);

        await _userManager.AddToRoleAsync(user, obj.Role);
        return RedirectToAction("Index");
    }


}