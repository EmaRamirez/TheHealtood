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
    public void Create(Products obj)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Products> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Products GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Products obj)
    {
        throw new NotImplementedException();
    }
}