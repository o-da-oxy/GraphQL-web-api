using Microsoft.EntityFrameworkCore;
using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly GalleriesContext _context;

    public AuthorRepository(GalleriesContext context)
    {
        _context = context;
    }

    public Author GetAuthorById(int id)
    {
        return _context.Authors.Select(a => a).Include(a => a.Gallery).FirstOrDefault(a => a.AuthorId == id);
    }

    public IEnumerable<Author> GetAllAuthors()
    {
        return _context.Authors;
    }
}