using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public interface IGalleryRepository
{
    public Gallery GetGalleryById(int id);
    public IEnumerable<Gallery> GetAllGalleries();
    Gallery UpdateGallery(Gallery gallery);
    Gallery AddGallery(Gallery gallery);
    Gallery DeleteGallery(int id);
}