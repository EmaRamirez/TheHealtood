
using System.ComponentModel.DataAnnotations;

namespace TheHealtood.Models;

public class Products
{
    public Products()
    {

    }
    public Products(int id)
    {
        this.Id = id;
    }

    public Products(int id, string name, double price, int GalleryId) : this(id)
    {
        this.Name = name;
        this.Price = price;
        this.GalleryId = GalleryId;

    }
    public Products(string name, double price, int GalleryId)
    {
        this.Name = name;
        this.Price = price;
        this.GalleryId = GalleryId;

    }
    public Products(int id, string name, double price, int GalleryId, List<Ingredient> ingre) : this(id, name, price, GalleryId)
    {
        this.Ingredients = ingre;

    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public double Price { get; set; }

    public int GalleryId { get; set; }

    public virtual Gallery gallery { get; set; }

    public int? CartId { get; set; }
    public virtual Cart Cart { get; set; }

    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public virtual List<ProductWithIngredients> ProductWithIngredients { get; set; } = new List<ProductWithIngredients>();





}