using System.ComponentModel.DataAnnotations;
using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public class ProductsIndexViewModel
{

    public ProductsIndexViewModel()
    {

    }
    public ProductsIndexViewModel(int id, string name, double price, string url)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Url = url;
    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }
    [Display(Name = "Imagen")]
    public string Url { get; set; }


    public string Filter { get; set; }


}