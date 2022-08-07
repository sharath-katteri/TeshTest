using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{

    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// To retrieve All Photos
        /// </summary>
        /// <returns></returns>
        [Route("api/Photos")]
        [HttpGet]
        public IEnumerable<Photo> GetPhotos()
        {
            return _photoService.GetAll();
        }

        /// <summary>
        /// To retrieve Photos by AlbumID
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        //[Route("api/Photo/{albumId}")]
        //[HttpGet]
        //public IEnumerable<Photo> GetPhotoByAlbumID(int albumId)
        //{
        //    return _photoService.GetPhotoByAlbumID(albumId);
        //}
    }
}
