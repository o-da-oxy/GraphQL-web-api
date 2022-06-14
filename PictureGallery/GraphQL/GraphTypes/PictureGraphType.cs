using PictureGallery.Data.Models;
using GraphQL.Types;

namespace PictureGallery.GraphQL.GraphTypes;

public sealed class PictureGraphType : ObjectGraphType<Picture> {
    public PictureGraphType() {
        Name = "picture";
        Field(p => p.PictureId);
        Field(p => p.Name);
        Field(p => p.Age);
        Field(p => p.AuthorId);
        Field(p => p.Author, nullable: false, type: typeof(AuthorGraphType))
            .Description("The author of this picture");
    }
}