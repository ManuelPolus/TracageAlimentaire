using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tracage.DAL
{
    public class RestClient<T>
    {
        private readonly HttpClient _client;
        private const string Resturl = "https://7ae9ec9b.ngrok.io/api"; //TODO replace with real 
        private readonly string _resource;

        public RestClient(string resource)
        {
            _client = new HttpClient();
            this._resource = resource;
        }

        public async Task<IEnumerable<T>> GetDataAsync()
        {
            List<T> items = new List<T>();
            var uri = new Uri(string.Format(Resturl + _resource, string.Empty));
            var response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return items;
        }

        public async Task<T> GetItemAsync(object identifier)
        {
            var uri = new Uri(Resturl + _resource+"/"+ identifier+"/");
            try
            {
                //TODO gérer si le résultat est 404
                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    T item = JsonConvert.DeserializeObject<T>(content);
                    return item;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return default(T);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("requets failed");
                Console.WriteLine(e.StackTrace);
                return default(T);
            }

            throw new Exception("kys");

        }

        public async Task<bool> SaveItemAsync(T item)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl + _resource, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response =_client.PostAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"item successfully saved.");
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }

        }

        public async Task<bool> UpdateItemAsync(T item,string identifier)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl +"/update"+ _resource + "/"+identifier, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = _client.PutAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"item successfully saved.");
                    return true;
                }
               Console.WriteLine(response.StatusCode);
                return false;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }

        }



        public async Task<bool> DeleteItemAsync(object id)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl + _resource, id));

                var response =  _client.DeleteAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"item successfully deleted.");
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }

        }
        

    }

}
