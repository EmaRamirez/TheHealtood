using TheHealtood.Models;

namespace TheHealtood.Repository;

public interface IProductService
{
    List<Products> GetAllProducts();

    Products GetById(int id);

    void Create(Products obj);

    void Update(Products obj);

    void Delete(int id);
}