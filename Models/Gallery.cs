using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheHealtood.Models;

public class Gallery
{
    [Key]
    [Column("id")]
    public int GalleryId { get; set; }

    public string Name { get; set; }

    public byte[] Datos { get; set; }

    public string Extension { get; set; }

    public virtual Products Product { get; set; }
}