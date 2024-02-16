
using System.ComponentModel.DataAnnotations;

namespace TheHealtood.Models;

public class Products
{
    public Products()
    {

    }
    public Products(string name, double price, int GalleryId)
    {
        this.Name = name;
        this.Price = price;
        this.GalleryId = GalleryId;
    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }

    public int GalleryId { get; set; }

    public virtual Gallery gallery { get; set; }

    public List<Ingredient> Ingredients { get; set; }

    
    //listado con la informacion nutricional


}