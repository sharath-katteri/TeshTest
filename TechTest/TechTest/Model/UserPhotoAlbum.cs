using System.Collections.Generic;

namespace TechTest.Model
{
    public class UserPhotoAlbum
    {
        public int  UserId { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
