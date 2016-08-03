using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class JSONParser : IParser
    {
        public JSONParser(){
        }

        public string encode<T>(T p)
        {
            return JsonConvert.SerializeObject(p);
        }

        public T decode<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
