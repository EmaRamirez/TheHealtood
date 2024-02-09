using Microsoft.EntityFrameworkCore;
using TheHealtood.Models;

namespace TheHealtood.Data;

public class TheHealtoodContext : DbContext
{
    public TheHealtoodContext(DbContextOptions<TheHealtoodContext> options) : base(options)
    {

    }
    public DbSet<Products> Products { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}