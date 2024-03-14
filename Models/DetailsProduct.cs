namespace TheHealtood.Models;

public class DetailsProduct
{
    public int SalesId { get; set; }
    public int ProductId { get; set; }

    public virtual Sales Sales { get; set; }
    public Products Products { get; set; }
    
}