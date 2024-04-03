
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
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
    public string Create(Ingredient obj)
    {
        var verificar = GetAll().FirstOrDefault(x => x.Name.ToLower() == obj.Name.ToLower());
        string valor = "";
        if (verificar != null)
        {
            valor = "El ingrediente que intentas agregar ya existe en la base de datos";
            return valor;
        }
        _context.Ingredients.Add(obj);
        _context.SaveChanges();
        valor = "Ok";
        return valor;
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

    public List<Ingredient> AddIngre(List<int> obj)
    {
        var list = new List<Ingredient>();
        for (int i = 0; i < obj.Count; i++)
        {
            list.Add(GetById(obj[i]));
        }
        return list;
    }



    private IQueryable<Ingredient> GetQuery() => from query in _context.Ingredients select query;


}