using System.ComponentModel.DataAnnotations.Schema;

namespace TheHealtood.Models;

[NotMapped]
public class Cart
{
    public int Id { get; set; }

    public virtual List<Products> ListProd { get; set; }
}