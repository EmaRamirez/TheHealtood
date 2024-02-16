using System.ComponentModel.DataAnnotations;
using TheHealtood.Utils;

namespace TheHealtood.ViewModels;

public class IngredientCreateViewModel
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }

    public FoodGroups foodGroups { get; set; }
}