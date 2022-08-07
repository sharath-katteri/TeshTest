using System.Collections.Generic;
using TechTest.Model;

namespace TechTest.Service
{
    public interface IPhotoAlbumService
    {
        IEnumerable<UserPhotoAlbum> GetAll();
        IEnumerable<UserPhotoAlbum> GetByUserID(int UserID);
    }
}