namespace TheHealtood.Models;

public class Cart
{
    public int Id { get; set; }

    public virtual List<Products> ListProd { get; set; }
}