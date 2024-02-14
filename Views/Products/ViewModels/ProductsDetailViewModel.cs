using System.ComponentModel.DataAnnotations;

namespace TheHealtood.ViewModels;

public class ProductsDetailViewModel
{
    public ProductsDetailViewModel() { }
    public ProductsDetailViewModel(int id)
    {
        this.Id = id;
    }
    public ProductsDetailViewModel(int id, string name, double price, string url) : this(id)
    {
        this.Name = name;
        this.Price = price;
        this.Url = url;

    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }
    [Display(Name = "Foto")]
    public string Url { get; set; }

}