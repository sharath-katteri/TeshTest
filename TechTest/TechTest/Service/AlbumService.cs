using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TechTest.Model;

namespace TechTest.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly HttpClient _client;
        public AlbumService(HttpClient client)
        {
            _client = client;
        }
        public IEnumerable<Album> GetAll()
        {
            List<Album> albums = new List<Album>();
            try
            {
                HttpResponseMessage response = _client.GetAsync("albums").Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(dataObjects).ToList();
                }
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }           
            return albums;
        }

        public IEnumerable<Album> GetAlbumByUserID(int UserID)
        {
            List<Album> albums = new List<Album>();
            try
            {
                HttpResponseMessage response = _client.GetAsync(string.Format("users/{0}/albums", UserID)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(dataObjects).ToList();
                }
            }
            catch (Exception)
            {
                //TO DO: Log the Errors in Flatfile or DB
                throw;
            }            
            return albums;
        }
    }
}
