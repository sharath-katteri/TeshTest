using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TechTest.Model;

namespace TechTest.Service
{
    public class PhotoService : IPhotoService
    {
        private readonly HttpClient _client;
        public PhotoService(HttpClient client)
        {
            _client = client;
        }
       public IEnumerable<Photo> GetAll()
        {    
            List<Photo> photos = new List<Photo>();
            try
            {
                HttpResponseMessage response = _client.GetAsync("photos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(dataObjects).ToList();
                }
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }            
            return photos;
        }

        public IEnumerable<Photo> GetPhotoByAlbumID(int AlbumId)
        {            
            List<Photo> photos = new List<Photo>();
            try
            {
                HttpResponseMessage response = _client.GetAsync(string.Format("albums/{0}/photos", AlbumId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    photos = JsonConvert.DeserializeObject<IEnumerable<Photo>>(dataObjects).ToList();
                }
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }            
            return photos;
        }
    }
}
