using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheHealtood.ViewModels;

public class UserEditViewModel
{
    public UserEditViewModel() { }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public SelectList Roles { get; set; }
}