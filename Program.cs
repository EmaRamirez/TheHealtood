using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheHealtood.Data;
using TheHealtood.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TheHealtoodContext") ?? throw new InvalidOperationException("Connection string 'TheHealtoodContext' not found.");
builder.Services.AddDbContext<TheHealtoodContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>()
.AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TheHealtoodContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
