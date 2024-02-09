using System.ComponentModel.DataAnnotations;

namespace TheHealtood.ViewModels;

public class ProductsCreateViewModel
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }
}
