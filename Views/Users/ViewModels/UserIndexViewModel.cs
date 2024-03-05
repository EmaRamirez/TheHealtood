using System.ComponentModel.DataAnnotations;

namespace TheHealtood.ViewModels;

public class UserIndexViewModel
{

    public UserIndexViewModel(){

    }
    [Display(Name = "Nombre")]
    public string Username { get; set; }
    
    
}
