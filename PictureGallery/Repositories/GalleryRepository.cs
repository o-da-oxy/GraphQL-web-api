using Microsoft.EntityFrameworkCore;
using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public class GalleryRepository : IGalleryRepository
{
    private readonly GalleriesContext _context;

    public GalleryRepository(GalleriesContext context)
    {
        _context = context;
    }

    public Gallery GetGalleryById(int id)
    {
        return _context.Galleries.FirstOrDefault(g => g.GalleryId == id);
    }

    public IEnumerable<Gallery> GetAllGalleries()
    {
        return _context.Galleries;
    }

    public Gallery UpdateGallery(Gallery gallery)
    {
        var authors = _context.Authors.Where(a => a.GalleryId == gallery.GalleryId);
        if (gallery.GalleryId == null)
        {
            return null;
        }
        
        try
        {
            var newGallery = new Gallery
            {
                GalleryId = gallery.GalleryId,
                Name = gallery.Name,
                Town = gallery.Town
            };
            _context.Update(newGallery);
            _context.SaveChanges();
                
            return newGallery;
        }
        catch (DbUpdateException)
        {
            if (!GalleryExists((int) gallery.GalleryId))
            {
                return null;
            }
            return null;
        }
    }

    public Gallery AddGallery(Gallery gallery)
    {
        var author = _context.Authors.FirstOrDefault(a => a.GalleryId == gallery.GalleryId);
        var newGallery = _context.Add(new Gallery
        {
            Name = gallery.Name,
            Town = gallery.Town
        }).Entity;
        _context.SaveChanges();
        return newGallery;
    }

    public Gallery DeleteGallery(int id)
    {
        var gallery = GetGalleryById(id);
        if (gallery == null)
        {
            return null;
        }

        _context.Galleries.Remove(gallery);
        _context.SaveChanges();
            
        return gallery;
    }
    
    private bool GalleryExists(int id)
    {
        return _context.Galleries.Any(g => g.GalleryId == id);
    }
}