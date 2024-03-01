
using System.ComponentModel.DataAnnotations;
using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public class ProductEditViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }
    [Display(Name = "Fotos")]
    public string? Url { get; set; }
    [Display(Name = "Listado de Ingredientes")]
    public List<Ingredient> listIngr { get; set; } = new List<Ingredient>();

    public IFormFile? image { get; set; }



}