using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechTest.Model;
using TechTest.Service;

namespace TechTest.Controllers
{
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// To retrieve All the Albums
        /// </summary>
        /// <returns></returns>
        [Route("api/Albums")]
        [HttpGet]
        public IEnumerable<Album> GetAlbums()
        {
            return _albumService.GetAll();
        }

        /// <summary>
        /// To retrieve the Albums by UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[Route("api/GetAlbumByUserId/{userId}")]
        //[HttpGet]
        //public IEnumerable<Album> GetAlbumByUserId(int userId)
        //{
        //    return _albumService.GetAlbumByUserID(userId);
        //}
    }
}
