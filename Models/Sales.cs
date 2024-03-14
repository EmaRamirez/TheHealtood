using Microsoft.AspNetCore.Identity;

namespace TheHealtood.Models;

public class Sales
{
    public int Id { get; set; }
    public string NroVoucher { get; set; }
    public DateOnly Date { get; set; }

    public double Total { get; set; }


    public virtual AspNetUsers User { get; set; }

    public virtual List<Products> Products { get; set; }

    public virtual List<DetailsProduct> ListProds { get; set; } = new List<DetailsProduct>();
}