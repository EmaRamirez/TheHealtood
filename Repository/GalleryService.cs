using TheHealtood.Data;
using TheHealtood.Models;

namespace TheHealtood.Repository;

public class GalleryService : IGalleryService
{
    private readonly TheHealtoodContext _context;
    public GalleryService(TheHealtoodContext context)
    {
        this._context = context;
    }
    public Gallery Create(IFormFile obj)
    {
        var name = Path.GetFileNameWithoutExtension(obj.FileName);
        var extension = Path.GetExtension(obj.FileName);

        MemoryStream ms = new MemoryStream();

        byte[] datos = new byte[0];

        while (datos.Length == 0)
        {
            obj.CopyToAsync(ms);


            datos = ms.ToArray();
        }


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

    public void Delete(int id)
    {
        var detail = _context.Gallery.FirstOrDefault(x => x.GalleryId == id);
        _context.Gallery.Remove(detail);
        //_context.SaveChanges();
    }
}