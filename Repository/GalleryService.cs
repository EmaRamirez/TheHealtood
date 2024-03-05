using TheHealtood.Data;
using TheHealtood.Models;

namespace TheHealtood.Repository;

public class GalleryService : IGalleryService
{
    private readonly ApplicationDbContext _context;
    public GalleryService(ApplicationDbContext context)
    {
        this._context = context;
    }
    public Gallery Create(IFormFile obj)
    {
        if (obj == null)
        {
            return null;
        }
        var name = Path.GetFileNameWithoutExtension(obj.FileName);//NOMBRE
        var extension = Path.GetExtension(obj.FileName);//EXTENSION

        MemoryStream ms = new MemoryStream();

        byte[] datos = new byte[0];

        while (datos.Length == 0)
        {
            obj.CopyToAsync(ms);


            datos = ms.ToArray();//DATOS
        }
        if (Verification(datos) == false)
        {
            var galeria = new Gallery
            {
                Name = name,
                Extension = extension,
                Datos = datos
            };

            _context.Gallery.Add(galeria);
            _context.SaveChanges();
            return galeria;
        }
        else
        {
            return _context.Gallery.First(x => x.Datos == datos);
        }


    }

    public void Delete(int id)
    {
        var detail = _context.Gallery.FirstOrDefault(x => x.GalleryId == id);
        _context.Gallery.Remove(detail);
        //_context.SaveChanges();
    }

    private bool Verification(byte[] datos)
    {
        bool veri = _context.Gallery.ToList().Any(x => x.Datos == datos);
        return veri;
    }
}