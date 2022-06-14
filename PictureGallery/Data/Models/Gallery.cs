using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PictureGallery.Data.Models
{
    public partial class Gallery
    {
        public Gallery()
        {
            Authors = new HashSet<Author>();
        }

        public int GalleryId { get; set; }
        public string Name { get; set; } = null!;
        public string Town { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
