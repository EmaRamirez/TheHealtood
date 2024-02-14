using TheHealtood.Models;

namespace TheHealtood.Repository;

public interface IGalleryService
{
    Gallery Create(IFormFile obj);

    void Delete(int id);
}