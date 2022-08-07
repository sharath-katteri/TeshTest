using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTest.Model;

namespace TechTest.Service
{
    public class UserPhotoAlbumService : IPhotoAlbumService 
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;
        public UserPhotoAlbumService(IPhotoService photoService, IAlbumService albumService)
        {
            _photoService = photoService;
            _albumService = albumService;
        }
        public IEnumerable<UserPhotoAlbum> GetAll()
        {
            IEnumerable<Photo> photos = null;
            IEnumerable<Album> albums = null;
            List<UserPhotoAlbum> AlbumCollection = new List<UserPhotoAlbum>();

            try
            {
                Task T1 = Task.Factory.StartNew(() =>{ photos = _photoService.GetAll(); });
                Task T2 = Task.Factory.StartNew(() =>{ albums = _albumService.GetAll();  });
                Task.WaitAll(T1, T2);

                foreach (Album album in albums)
                {
                    List<Photo> photo = photos.Where(x => x.AlbumId == album.Id).ToList();
                    AlbumCollection.Add(new UserPhotoAlbum { AlbumId = album.Id, Title = album.Title, UserId = album.UserId, Photos = photo });
                }
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }
            
            return AlbumCollection;
        }

        public IEnumerable<UserPhotoAlbum> GetByUserID(int UserID)
        {
            IEnumerable<Album> album = _albumService.GetAlbumByUserID(UserID);
            List<UserPhotoAlbum> AlbumCollection = new List<UserPhotoAlbum>();
            try
            {
                Parallel.ForEach(album, alb => {
                    List<Photo> photos = _photoService.GetPhotoByAlbumID(alb.Id).ToList();
                    AlbumCollection.Add(new UserPhotoAlbum { AlbumId = alb.Id, Title = alb.Title, UserId = alb.UserId, Photos = photos });
                });
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }            
            
            return AlbumCollection.OrderBy(x => x.AlbumId).ToList(); 
        }
    }
}
