using TheHealtood.Models;

namespace TheHealtood.Repository;

public interface IProductService
{
    List<Products> GetAllProducts(string Filter);

    Products GetById(int id);

    void Create(Products value);

    void Update(int id, Products obj);

    void Delete(int id);
}