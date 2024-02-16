using Microsoft.EntityFrameworkCore;
using TheHealtood.Models;

namespace TheHealtood.Data;

public class TheHealtoodContext : DbContext
{
    public TheHealtoodContext(DbContextOptions<TheHealtoodContext> options) : base(options)
    {

    }
    public DbSet<Products> Products { get; set; }
    public DbSet<Gallery> Gallery { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>()
        .HasOne(x => x.gallery)
        .WithOne(x => x.Product)
        .IsRequired();

        modelBuilder.Entity<Products>()
        .HasMany(x => x.Ingredients)
        .WithMany(x => x.ListProducts)
        .UsingEntity("ProductsWithIngredients");

    }
}