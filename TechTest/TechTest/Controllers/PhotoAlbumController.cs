using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{
    [ApiController]
    public class PhotoAlbumController : ControllerBase
    {

        private readonly IPhotoAlbumService _photoAlbumService;

        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;
        }
        
        /// <summary>
        /// To retrieve the all the Albums and their respective Photos
        /// </summary>
        /// <returns></returns>
        [Route("api/PhotoAlbum")]
        [HttpGet]
        public IEnumerable<UserPhotoAlbum> GetPhotos()
        {
           return _photoAlbumService.GetAll();
        }

        /// <summary>
        /// To retrieve the Albums and their respective Photos By UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/PhotoAlbum/{userId}")]
        [HttpGet]
        public IEnumerable<UserPhotoAlbum> GetPhoto(int userId)
        {
           return _photoAlbumService.GetByUserID(userId);
        }
    }
}
