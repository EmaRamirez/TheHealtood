
using System.ComponentModel.DataAnnotations;

namespace TheHealtood.Models;

public class Products
{
    public Products()
    {

    }
    public Products(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }

    public virtual Gallery gallery { get; set; }

    //listado de ingredientes
    //listado con la informacion nutricional


}