
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
    public Products(string name, double price, int GalleryId,List<Ingredient> ingre)
    {
        this.Name = name;
        this.Price = price;
        this.GalleryId = GalleryId;
        this.Ingredients = ingre;

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
    //USO ESTA LISTA DE SALES PARA PODER HACER UNA RELACION MUCHO A MUCHOS CON EL MODELO DE VENTAS
    public virtual List<Sales> Sales { get; set; } = new List<Sales>();

    public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public virtual List<ProductWithIngredients> ProductWithIngredients { get; set; } = new List<ProductWithIngredients>();
    // TABLA INTERMEDIA ENTRE SALES Y PRODUCTOS
    public virtual List<DetailsProduct> DetailsProduct { get; set; } = new List<DetailsProduct>();





}