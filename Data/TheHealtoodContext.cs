using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TheHealtood.Models;

namespace TheHealtood.Data;

public class TheHealtoodContext : IdentityDbContext
{
    public TheHealtoodContext(DbContextOptions<TheHealtoodContext> options)
        : base(options)
    {
    }
    public DbSet<Products> Products { get; set; }
    public DbSet<Gallery> Gallery { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ProductWithIngredients> ProductWithIngredients { get; set; }
    public DbSet<Sales> Sales { get; set; }

    public DbSet<DetailsProduct> DetailsProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Products>()
        .HasOne(x => x.gallery)
        .WithOne(x => x.Product)
        .IsRequired();


        modelBuilder.Entity<Ingredient>()
        .HasMany(x => x.ListProducts)
        .WithMany(x => x.Ingredients)
        .UsingEntity<ProductWithIngredients>(
           x => x.HasOne(x => x.Products).WithMany(x => x.ProductWithIngredients).HasForeignKey(x => x.ProductId).HasPrincipalKey(x => x.Id),
           m => m.HasOne(x => x.Ingredient).WithMany(x => x.ProductWithIngredients).HasForeignKey(x => x.IngredientId).HasPrincipalKey(x => x.Id)
           );

        modelBuilder.Entity<Products>()
        .HasMany(x => x.Sales)
        .WithMany(x => x.Products)
        .UsingEntity<DetailsProduct>(
        x => x.HasOne(x => x.Sales).WithMany(x => x.ListProds).HasForeignKey(x => x.SalesId).HasPrincipalKey(x => x.Id),
        y => y.HasOne(y => y.Products).WithMany(y => y.DetailsProduct).HasForeignKey(y => y.ProductId).HasPrincipalKey(y => y.Id)
        );

        modelBuilder.Entity<Sales>()
        .HasOne(x => x.User)
        .WithMany(x => x.ListSales)
        .IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}

