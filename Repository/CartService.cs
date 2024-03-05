using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheHealtood.Data;
using TheHealtood.Models;

namespace TheHealtood.Repository;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    public CartService(ApplicationDbContext context)
    {
        this._context = context;
    }
    public Cart AddProduct(Cart obj)
    {
        _context.Cart.Add(obj);
        _context.SaveChanges();
        return obj;
    }

    public Cart GetCart()
    {
        var obtener = _context.Cart.Include(x => x.ListProd).FirstOrDefault();
        return obtener;
    }

    public List<Cart> GetAll()
    {
        return _context.Cart.Include(x => x.ListProd).ToList();
    }

    public Cart UpdateCart(Cart value)
    {
        _context.Cart.Update(value);
        _context.SaveChanges();
        return _context.Cart.First();
    }

    public void DeleteCart()
    {
        var borrar = GetCart();
        _context.Cart.Remove(borrar);
        _context.SaveChanges();

    }
}