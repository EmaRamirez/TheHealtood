using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public class ProductsDetailViewModel
{
    public ProductsDetailViewModel() { }
    public ProductsDetailViewModel(int id)
    {
        this.Id = id;
    }
    public ProductsDetailViewModel(int id, string name, double price, string url, List<Ingredient> ingre) : this(id)
    {
        this.Name = name;
        this.Price = price;
        this.Url = url;
        this.ingredients = ingre;

    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }
    [Display(Name = "Foto")]
    public string Url { get; set; }
    [Display(Name = "Listado de Ingredientes")]
    public List<Ingredient> ingredients { get; set; } = new List<Ingredient>();



}