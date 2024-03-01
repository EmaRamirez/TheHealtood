namespace TheHealtood.Models;

public class ProductWithIngredients
{
    public ProductWithIngredients()
    {

    }
   
    public int IngredientId { get; set; }
    public int ProductId { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;
    public virtual Products Products { get; set; } = null!;
}