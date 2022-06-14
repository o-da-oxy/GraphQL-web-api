using GraphQL;
using GraphQL.Types;
using PictureGallery.Data.Models;
using PictureGallery.GraphQL.GraphTypes;
using PictureGallery.Repositories;

namespace PictureGallery.GraphQL.Mutations;

public class GalleryMutation : ObjectGraphType
{
    private readonly IGalleryRepository _galleryRepository;

    public GalleryMutation(IGalleryRepository galleryRepository)
    {
        _galleryRepository = galleryRepository;
        
        Field<GalleryGraphType>(
            "deleteGallery",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id"}
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return _galleryRepository.DeleteGallery(id);
            }
        );
        Field<GalleryGraphType>(
            "createGallery",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "town"}
            ),
            resolve: context =>
            {
                var name = context.GetArgument<string>("name");
                var town = context.GetArgument<string>("town");

                var gallery = new Gallery
                {
                    Name = name,
                    Town = town
                };
                return _galleryRepository.AddGallery(gallery);
            }
        );
        Field<GalleryGraphType>(
            "updateGallery",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name"},
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "town"}
            ),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                var name = context.GetArgument<string>("name");
                var town = context.GetArgument<string>("town");

                var gallery = new Gallery
                {
                    GalleryId = id,
                    Name = name,
                    Town = town
                };
                return _galleryRepository.UpdateGallery(gallery);
            }
        );
    }
}