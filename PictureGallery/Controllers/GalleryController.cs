using Microsoft.AspNetCore.Mvc;
using PictureGallery.Data.Models;
using PictureGallery.Repositories;

namespace PictureGallery.Controllers;

[ApiController]
[Route("[controller]")]
public class GalleryController : ControllerBase
{
    private readonly IGalleryRepository _galleryRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPictureRepository _pictureRepository;

    public GalleryController(IGalleryRepository galleryRepository, IAuthorRepository authorRepository, IPictureRepository pictureRepository)
    {
        _galleryRepository = galleryRepository;
        _authorRepository = authorRepository;
        _pictureRepository = pictureRepository;
    }

    [HttpGet("gallery/{id}")]
    public async Task<IActionResult> GetGallery(int id)
    {
        try
        {
            var gallery = _galleryRepository.GetGalleryById(id);
            if (gallery != null)
            {
                return Ok(gallery);
            }
            return Ok("Gallery is not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("galleries")]
    public async Task<IActionResult> GetAllGalleries()
    {
        try
        {
            var galleries = _galleryRepository.GetAllGalleries();
            if (galleries != null)
            {
                return Ok(galleries);
            }
            return Ok("Galleries are not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("author/{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        try
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author != null)
            {
                return Ok(author);
            }
            return Ok("Author is not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("authors")]
    public async Task<IActionResult> GetAllAuthors()
    {
        try
        {
            var authors = _authorRepository.GetAllAuthors();
            if (authors != null)
            {
                return Ok(authors);
            }
            return Ok("Authors are not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("picture/{id}")]
    public async Task<IActionResult> GetPicture(int id)
    {
        try
        {
            var picture = _pictureRepository.GetPictureById(id);
            if (picture != null)
            {
                return Ok(picture);
            }
            return Ok("Picture is not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("pictures")]
    public async Task<IActionResult> GetAllPictures()
    {
        try
        {
            var pictures = _pictureRepository.GetAllPictures();
            if (pictures != null)
            {
                return Ok(pictures);
            }
            return Ok("Pictures are not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("picturesByAuthor/{authorId}")]
    public async Task<IActionResult> GetPicturesByAuthorId(int authorId)
    {
        try
        {
            var pictures = _pictureRepository.GetPicturesByAuthorId(authorId);
            if (pictures != null)
            {
                return Ok(pictures);
            }
            return Ok("Pictures are not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("picturesByGallery/{galleryId}")]
    public async Task<IActionResult> GetPicturesByGalleryId(int galleryId)
    {
        try
        {
            var pictures = _pictureRepository.GetPicturesByGalleryId(galleryId);
            if (pictures != null)
            {
                return Ok(pictures);
            }
            return Ok("Pictures are not found");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("gallery/{id}")]
    public IActionResult UpdateGallery(Gallery gallery)
    {
        var newGallery = _galleryRepository.UpdateGallery(gallery);
        return Ok(newGallery);
    }
    
    [HttpPost("gallery/{id}")]
    public async Task<IActionResult> AddGallery(Gallery gallery)
    {
        var newGallery = _galleryRepository.AddGallery(gallery);
        return Created($"/api/gallery/{newGallery.GalleryId}", newGallery);
    }
    
    [HttpDelete("gallery/{id}")]
    public Gallery DeleteGallery(int id)
    {
        return _galleryRepository.DeleteGallery(id);
    }
}