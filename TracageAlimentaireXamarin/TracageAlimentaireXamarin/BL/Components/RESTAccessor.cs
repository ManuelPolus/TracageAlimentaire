using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tracage.DAL;
using Tracage.Models;

namespace TracageAlimentaireXamarin.BL.Components
{
    public class RestAccessor<T> : IDataAccessor<T> where T : class
    {
        private RestClient<T> _client;

        public object DataType { get; set; }

        public RestAccessor(object dataType)
        {
            this.DataType = dataType;
            _client = new RestClient<T>("/" + dataType.GetType().Name + "s");
        }

        public bool Update(T objectToUpdate, string identifier)
        {
            return _client.UpdateItemAsync(objectToUpdate,identifier).Result;
        }
        

        public bool Save(object currentObject)
        {
            return _client.SaveItemAsync((T)currentObject).Result;
        }

        public IEnumerable<T> GetAsList()
        {
            
            return (IEnumerable<T>) _client.GetDataAsync().Result;
        }

        public T GetByIdentifier(object identifier)
        {
           return _client.GetItemAsync(identifier).Result;
        }

        public bool DeleteByIdentifier(object identifier)
        {
            return _client.DeleteItemAsync(identifier).Result;
        }

        public void DefineType(object o)
        {
            this.DataType = o;
        }
    }
}
