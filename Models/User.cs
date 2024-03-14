using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheHealtood.Models;

public class AspNetUsers : IdentityUser
{
    public virtual List<Sales> ListSales { get; set; }
}

