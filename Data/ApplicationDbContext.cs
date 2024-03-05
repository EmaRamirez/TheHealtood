using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheHealtood.Models;

namespace TheHealtood.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Products> Products { get; set; }
    public DbSet<Gallery> Gallery { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<ProductWithIngredients> ProductWithIngredients { get; set; }

    public DbSet<Cart> Cart { get; set; }
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
        .HasOne(x => x.Cart)
        .WithMany(x => x.ListProd)
        .IsRequired(false)
        .OnDelete(DeleteBehavior.NoAction);

base.OnModelCreating(modelBuilder);
    }
}

