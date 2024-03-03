using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public class HomeAllProductsViewModel
{
    public int id { get; set; }

    public string name { get; set; }

    public double price { get; set; }

    public string url { get; set; }

    public List<Ingredient> ingredients { get; set; } = null!;



}