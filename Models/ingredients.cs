using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheHealtood.Utils;

namespace TheHealtood.Models;

public class Ingredient
{
    public Ingredient()
    {

    }
    public Ingredient(string name, string FoodGroups)
    {
        this.Name = name;
        this.FoodGroups = FoodGroups;

    }
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [NotMapped]
    public FoodGroups foodGroups { get; set; }
    [Display(Name = "Tipo de Alimento")]
    public string FoodGroups { get; set; }

    [NotMapped]
    public bool seleted { get; set; } = false;
    [Display(Name = "Menus con estos ingredientes")]
    public virtual List<Products> ListProducts { get; set; } = new List<Products>();
    public virtual List<ProductWithIngredients> ProductWithIngredients { get; set; } = new List<ProductWithIngredients>();



}