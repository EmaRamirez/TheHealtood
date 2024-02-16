using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheHealtood.Utils;

namespace TheHealtood.Models;

public class Ingredient
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [NotMapped]
    public FoodGroups foodGroups { get; set; }
    [Display(Name = "Tipo de Alimento")]
    public string FoodGroups { get; set; }

    public List<Products> ListProducts { get; set; }

}