using System.Collections.Generic;
using TechTest.Model;

namespace TechTest.Service
{
    public interface IPhotoService
    {
        IEnumerable<Photo> GetAll();
        IEnumerable<Photo> GetPhotoByAlbumID(int AlbumId);
    }
}