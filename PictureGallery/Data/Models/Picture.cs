using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PictureGallery.Data.Models
{
    public partial class Picture
    {
        public int PictureId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
