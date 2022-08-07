using System.Collections.Generic;
using TechTest.Model;

namespace TechTest.Service
{
    public interface IAlbumService
    {
        IEnumerable<Album> GetAll();
        IEnumerable<Album> GetAlbumByUserID(int UserID);
    }
}