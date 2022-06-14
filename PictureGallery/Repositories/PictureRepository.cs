using Microsoft.EntityFrameworkCore;
using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public class PictureRepository : IPictureRepository
{
    private readonly GalleriesContext _context;

    public PictureRepository(GalleriesContext context)
    {
        _context = context;
    }

    public Picture GetPictureById(int id)
    {
        return _context.Pictures.FirstOrDefault(p => p.PictureId == id);
    }

    public IEnumerable<Picture> GetAllPictures()
    {
        return _context.Pictures;
    }

    public IEnumerable<Picture> GetPicturesByAuthorId(int authorId)
    {
        return _context.Pictures.Select(p => p).Where(p => p.AuthorId == authorId).ToList();
    }

    public IEnumerable<Picture> GetPicturesByGalleryId(int galleryId)
    {
        return _context.Pictures.Where(w => w.Author.Gallery.GalleryId == galleryId);
    }

    public Picture UpdatePicture(Picture picture)
    {
        if (picture.PictureId == null)
        {
            return null;
        }
        
        try
        {
            var newPicture = new Picture
            {
                PictureId = picture.PictureId,
                Age = picture.Age,
                Name = picture.Name,
                AuthorId = picture.AuthorId
            };
            _context.Update(newPicture);
            _context.SaveChanges();
                
            return newPicture;
        }
        catch (DbUpdateException)
        {
            if (!PictureExists((int) picture.PictureId))
            {
                return null;
            }
            return null;
        }
    }
    
    public Picture AddPicture(Picture picture)
    {
        var newPicture = _context.Add(new Picture
        {
            Age = picture.Age,
            Name = picture.Name,
            AuthorId = picture.AuthorId
        }).Entity;
        _context.SaveChanges();
        return newPicture;
    }

    public Picture DeletePicture(int id)
    {
        var picture = GetPictureById(id);
        if (picture == null)
        {
            return null;
        }

        _context.Pictures.Remove(picture);
        _context.SaveChanges();
            
        return picture;
    }
    
    private bool PictureExists(int id)
    {
        return _context.Pictures.Any(p => p.PictureId == id);
    }
}