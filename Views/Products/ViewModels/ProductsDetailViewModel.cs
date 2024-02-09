using System.ComponentModel.DataAnnotations;

namespace TheHealtood.ViewModels;

public class ProductsDetailViewModel
{
    public ProductsDetailViewModel() { }
    public ProductsDetailViewModel(int id)
    {
        this.Id = id;
    }
    public ProductsDetailViewModel(int id, string name, double price) : this(id)
    {
        this.Name = name;
        this.Price = price;
    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }

}