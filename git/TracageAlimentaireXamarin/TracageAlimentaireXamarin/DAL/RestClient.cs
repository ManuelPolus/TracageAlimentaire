using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App2.DAL
{
    class RestClient<T>
    {
        private HttpClient client;
        private const string restUrl = "http://04335c06.ngrok.io/api/"; //TODO replace with real 
        private string resource;

        public RestClient(string resource)
        {
            client = new HttpClient();
            this.resource = resource;
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<T>> RefreshDataAsync()
        {
            List<T> items = new List<T>();
            var uri = new Uri(string.Format(restUrl + resource, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return items;
        }

        public async Task SaveItemAsync(T item)
        {

            var uri = new Uri(string.Format(restUrl + resource, string.Empty));

            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"item successfully saved.");

            }

        }

        public async Task DeleteItemAsync(string id, string resource)
        {
            var uri = new Uri(string.Format(restUrl + resource, id));

            var response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"item successfully deleted.");
            }
        }
    }

}
