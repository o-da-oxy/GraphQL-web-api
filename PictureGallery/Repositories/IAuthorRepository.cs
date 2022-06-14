using PictureGallery.Data.Models;

namespace PictureGallery.Repositories;

public interface IAuthorRepository
{
    public Author GetAuthorById(int id);
    public IEnumerable<Author> GetAllAuthors();
}