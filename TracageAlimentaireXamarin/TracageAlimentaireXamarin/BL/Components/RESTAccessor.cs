using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tracage.DAL;
using Tracage.Models;
using Xamarin.Android.Net;

namespace TracageAlimentaireXamarin.BL.Components
{
    public class RestAccessor<T> : IDataAccessor<T> where T : class
    {
        private readonly RestClient<T> _client;

        public object DataType { get; set; }

        public RestAccessor(object dataType)
        {
            this.DataType = dataType;
            _client = new RestClient<T>("/" + dataType.GetType().Name + "s");
        }

       
        public bool Save(object currentObject)
        {
            return _client.SaveItemAsync((T)currentObject);
        }

        public IEnumerable<T> GetAsList()
        { 
            return _client.GetDataAsync().Result;
        }

        public T GetByIdentifier(object identifier)
        {
           return _client.GetItemAsync(identifier).Result;
        }

        public IEnumerable<T> GetManyByIdentifier(object identifier)
        {
            return _client.GetItemsAsync(identifier).Result;
        }

        public bool Update(T objectToUpdate, string identifier)
        {
            return _client.UpdateItemAsync(objectToUpdate, identifier);
        }

        public bool DeleteByIdentifier(object identifier)
        {
            return _client.DeleteItemAsync(identifier);
        }

        public void DefineType(object o)
        {
            this.DataType = o;
        }

        //pour les besoins du mémoire 
        public T GetById(object identifier)
        {

            HttpResponseMessage message = _client.GetByIdentifier(identifier);

            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            if (message.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException("you shall not pass");
            }

            if (message.IsSuccessStatusCode)
            {
                var content = message.Content.ReadAsStringAsync().Result;
                T item = JsonConvert.DeserializeObject<T>(content);
                return item;
            }

            throw new Exception("Something else went wrong");
            
        }


    }
}
