using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TracageAlmentaireWeb.BL.Components;

namespace Tracage.DAL
{
    public class RestClient<T>
    {
        //TODO: hasher le token avant 'envoi.   
        private readonly HttpClient _client;
        private const string Resturl = " https://a788fb5a.ngrok.io/api"; //TODO replace with real 
        private readonly string _resource;
        private readonly string key = "$*aT9L5$fsgg(10fV2ljv[CmlB.U)z";

        public RestClient(string resource)
        {
            _client = new HttpClient();
            this._resource = resource;
            string encryptedKey = KeyHasher.Hash(key);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("APIKey", encryptedKey);
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
            var uri = new Uri(Resturl + _resource + "/" + identifier + "/");
            try
            {
                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    T item = JsonConvert.DeserializeObject<T>(content);
                    return item;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    System.Diagnostics.Debug.WriteLine(response.StatusCode + response.ReasonPhrase + "\n->" + response.Content);
                    return default(T);
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new UnauthorizedAccessException("you are not allowed to access the resource");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("request failed");
                Console.WriteLine(e.StackTrace);
                return default(T);
            }

            throw new Exception("something went wrong");

        }

        public bool SaveItemAsync(T item)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl + _resource, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = _client.PostAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"item successfully saved.");
                    return true;
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                return false;
            }

        }

        public bool UpdateItemAsync(T item, string identifier)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl + "/update" + _resource + "/" + identifier, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = _client.PutAsync(uri, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }


                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return false;
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

        public bool DeleteItemAsync(object id)
        {
            try
            {
                var uri = new Uri(string.Format(Resturl + _resource, id));

                var response = _client.DeleteAsync(uri).Result;
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


        public async Task<IEnumerable<T>> GetItemsAsync(object identifier)
        {
            var uri = new Uri(Resturl + _resource + "/" + identifier + "/");
            try
            {
                //TODO gérer si le résultat est 404

                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<T> items = JsonConvert.DeserializeObject<List<T>>(content);
                    return items;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return default(List<T>);
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return default(List<T>);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("requets failed");
                Console.WriteLine(e.StackTrace);
                return default(List<T>);
            }

            throw new Exception("something went wrong but what ?");

        }


        //pour les besoins du mémoire
        public HttpResponseMessage GetByIdentifier(object identifier)
        {

            HttpClient httpClient = new HttpClient();
            var uri = new Uri(Resturl + _resource + "/" + identifier + "/");

            var response = httpClient.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            { 
                return response;
            }

            return new HttpResponseMessage(response.StatusCode);

        }

    }
}
