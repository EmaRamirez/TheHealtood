using Microsoft.AspNetCore.Mvc.Rendering;
using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public sealed class IngredientIndexViewModel
{
    public List<Ingredient> Ingredientes { get; set; }

    public string Filter { get; set; }
}