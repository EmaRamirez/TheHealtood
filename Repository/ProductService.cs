using Microsoft.EntityFrameworkCore;
using TheHealtood.Data;
using TheHealtood.Models;

namespace TheHealtood.Repository;

public class ProductService : IProductService
{

    private readonly TheHealtoodContext _context;
    

    public ProductService(TheHealtoodContext context)
    {
        this._context = context;
      
    }

    //TODO -- HACER VERIFICACIONES PARA VER QUE NO SE CARGUEN DATOS IGUALES
    public void Create(Products value)
    {
        _context.Products.Add(value);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
        _context.Products.Remove(GetById(id));
        _context.SaveChanges();
    }

    public List<Products> GetAllProducts(string Filter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(Filter))
        {
            query = query.Where(x => x.Name.Contains(Filter));
        }

        return query.Include(x => x.gallery).ToList();
    }

    public Products GetById(int id)
    {
        var detail = GetQuery().Include(x => x.gallery).FirstOrDefault(x => x.Id == id);
        return detail;

    }

    public void Update(int id, Products obj)
    {
        Delete(id);

        //  Create(obj);
    }

    private IQueryable<Products> GetQuery() => from query in _context.Products select query;

}