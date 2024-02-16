
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using TheHealtood.Data;
using TheHealtood.Models;
using TheHealtood.Utils;

namespace TheHealtood.Repository;

public class IngredientService : IIngredientService
{

    private readonly TheHealtoodContext _context;

    public IngredientService(TheHealtoodContext context)
    {
        this._context = context;
    }
    public void Create(Ingredient obj)
    {
        _context.Ingredients.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var delete = GetById(id);
        _context.Ingredients.Remove(delete);
        _context.SaveChanges();
    }

    public List<Ingredient> GetAll() => GetQuery().Include(x => x.ListProducts).ToList();
    public List<Ingredient> GetAll(string filter)
    {
        if (filter is null)
        {
            return GetAll();

        }
        return GetAll().Where(x => x.FoodGroups == filter).ToList();
    }


    public Ingredient GetById(int id) => GetQuery().Include(x => x.ListProducts).FirstOrDefault(x => x.Id == id);


    public void Update(Ingredient obj)
    {
        Delete(obj.Id);
        Create(obj);
    }

    private IQueryable<Ingredient> GetQuery() => from query in _context.Ingredients select query;


}