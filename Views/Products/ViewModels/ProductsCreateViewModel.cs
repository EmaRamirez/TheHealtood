using System.ComponentModel.DataAnnotations;
using TheHealtood.Models;


namespace TheHealtood.ViewModels;

public class ProductsCreateViewModel
{

    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }
    [Display(Name = "Ingredientes")]
    public List<Ingredient> Ingredients { get; set; }

    public IFormFile image { get; set; }
}

