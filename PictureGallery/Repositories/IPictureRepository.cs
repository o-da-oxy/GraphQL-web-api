using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public interface IPictureRepository
{
    Picture GetPictureById(int id);
    IEnumerable<Picture> GetAllPictures();
    IEnumerable<Picture> GetPicturesByAuthorId(int id);
    IEnumerable<Picture> GetPicturesByGalleryId(int galleryId);
    Picture UpdatePicture(Picture picture);
    Picture AddPicture(Picture picture);
    Picture DeletePicture(int id);
}