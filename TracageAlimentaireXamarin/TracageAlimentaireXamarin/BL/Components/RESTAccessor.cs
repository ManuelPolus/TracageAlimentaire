using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tracage.DAL;
using Tracage.Models;

namespace TracageAlimentaireXamarin.BL.Components
{
    public class RestAccessor : IDataAccessor
    {
        private RestClient<object> _client;

        public object DataType { get; set; }

        public RestAccessor(object dataType)
        {
            this.DataType = dataType;
            _client = new RestClient<object>("/" + dataType.GetType() + "s");
        }

        public bool Save(object currentObject)
        {
            return _client.SaveItemAsync(currentObject).Result;
        }

        public IEnumerable<T> GetAsList<T>()
        {
            
            return (IEnumerable<T>) _client.GetDataAsync().Result;
        }

        public object GetByIdentifier<T>(T identifier)
        {
            return _client.GetItemAsync(identifier).Result;
        }

        public bool DeleteByIdentifier<T>(T identifier)
        {
            return _client.DeleteItemAsync(identifier).Result;
        }

        public void DefineType(object o)
        {
            this.DataType = o;
        }
    }
}
