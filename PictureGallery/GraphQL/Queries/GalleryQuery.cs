using GraphQL;
using GraphQL.Types;
using PictureGallery.Data.Models;
using PictureGallery.GraphQL.GraphTypes;
using PictureGallery.Repositories;

namespace PictureGallery.GraphQL.Queries;

public class GalleryQuery : ObjectGraphType
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IGalleryRepository _galleryRepository;
    private readonly IPictureRepository _pictureRepository;

    public GalleryQuery(IAuthorRepository authorRepository, IGalleryRepository galleryRepository, IPictureRepository pictureRepository)
    {
        _authorRepository = authorRepository;
        _galleryRepository = galleryRepository;
        _pictureRepository = pictureRepository;
        
        Field<ListGraphType<GalleryGraphType>>("galleries", "Query to retrieve all Galleries",
            resolve: GetAllGalleries);
        
        Field<GalleryGraphType>("gallery", "Query to retrieve a specific Gallery",
            new QueryArguments(MakeNonNullIntegerArgument("id", "The id of the Gallery")),
            resolve: GetGalleryById);
        
        Field<ListGraphType<PictureGraphType>>("pictures", "Query to retrieve all Pictures",
            resolve: GetAllPictures);
        
        Field<PictureGraphType>("picture", "Query to retrieve a specific Picture",
            new QueryArguments(MakeNonNullIntegerArgument("id", "The id of the Picture")),
            resolve: GetPictureById);
        
        Field<ListGraphType<PictureGraphType>>("picturesByAuthorId", "Query to retrieve a specific Picture",
            new QueryArguments(MakeNonNullIntegerArgument("authorId", "The id of the Author")),
            resolve: GetPictureByAuthorId);
        
        Field<ListGraphType<AuthorGraphType>>("authors", "Query to retrieve all Authors",
            resolve: GetAllAuthors);
        
        Field<AuthorGraphType>("author", "Query to retrieve a specific Author",
            new QueryArguments(MakeNonNullIntegerArgument("id", "The id of the Author")),
            resolve: GetAuthorById);
    }

    private object? GetAllAuthors(IResolveFieldContext<object?> context)
    {
        return _authorRepository.GetAllAuthors();
    }

    private object? GetAuthorById(IResolveFieldContext<object?> context)
    {
        var id = context.GetArgument<int>("id");
        return _authorRepository.GetAuthorById(id);
    }
    
    private object? GetPictureByAuthorId(IResolveFieldContext<object?> context)
    {
        var authorId = context.GetArgument<int>("authorId");
        return _pictureRepository.GetPicturesByAuthorId(authorId);
    }

    private object? GetPictureById(IResolveFieldContext<object?> context)
    {
        var id = context.GetArgument<int>("id");
        return _pictureRepository.GetPictureById(id);
    }

    private object? GetAllPictures(IResolveFieldContext<object?> context)
    {
        return _pictureRepository.GetAllPictures();
    }

    private object? GetGalleryById(IResolveFieldContext<object> context)
    {
        var id = context.GetArgument<int>("id");
        return _galleryRepository.GetGalleryById(id);
    }

    private object? GetAllGalleries(IResolveFieldContext<object?> context) => 
        _galleryRepository.GetAllGalleries();

    private QueryArgument MakeNonNullIntegerArgument(string name, string description) {
        return new QueryArgument<NonNullGraphType<IntGraphType>> {
            Name = name, Description = description
        };
    }
}