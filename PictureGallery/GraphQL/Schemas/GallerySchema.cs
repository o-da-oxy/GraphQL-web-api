using GraphQL.Types;
using PictureGallery.GraphQL.Mutations;
using PictureGallery.GraphQL.Queries;
using PictureGallery.Repositories;

namespace PictureGallery.GraphQL.Schemas;

public class GallerySchema : Schema {
    public GallerySchema(IPictureRepository picture, IAuthorRepository author, IGalleryRepository gallery)
    {
        Query = new GalleryQuery(author, gallery, picture);
        Mutation = new GalleryMutation(gallery);
    }
}