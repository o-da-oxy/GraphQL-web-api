using GraphQL.Types;
using PictureGallery.Data.Models;

namespace PictureGallery.GraphQL.GraphTypes;

public sealed class AuthorGraphType : ObjectGraphType<Author> {
    public AuthorGraphType() {
        Name = "author";
        Field(a => a.AuthorId);
        Field(a => a.Name);
        Field(a => a.GalleryId);
        Field(a => a.Gallery, type: typeof(GalleryGraphType))
            .Description("The gallery of this author");
    }
}