using TheHealtood.Models;

namespace TheHealtood.Repository;

public interface IIngredientService
{
    void Create(Ingredient obj);

    Ingredient GetById(int id);

    List<Ingredient> GetAll();
    List<Ingredient> GetAll(string filter);

    void Update(Ingredient obj);

    void Delete(int id);
    List<Ingredient> AddIngre(List<int> obj);
}