using TheHealtood.Models;

namespace TheHealtood.ViewModels;

public class ProductsIndexViewModel
{
    public List<Products> Products { get; set; } = new List<Products>();

    public string Filter { get; set; }
}