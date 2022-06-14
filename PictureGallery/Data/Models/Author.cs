

namespace PictureGallery.Data.Models
{
    public partial class Author
    {
        public Author()
        {
            Pictures = new HashSet<Picture>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public int GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; } = null!;
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
