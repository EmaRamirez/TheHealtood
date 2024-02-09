using System.ComponentModel.DataAnnotations.Schema;

namespace TheHealtood.Models;

public class Gallery
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte[] archivo { get; set; }

    public string Extension { get; set; }
    [NotMapped]
    public virtual IFormFile image { get; set; }

    public virtual Products Product { get; set; }
}