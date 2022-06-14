using GraphQL.Types;
using PictureGallery.Data.Models;

namespace PictureGallery.GraphQL.GraphTypes;

public sealed class GalleryGraphType : ObjectGraphType<Gallery> {
    public GalleryGraphType() {
        Name = "gallery";
        Field(g => g.GalleryId);
        Field(g => g.Name).Description("The name of the gallery");
        Field(g => g.Town);
    }
}