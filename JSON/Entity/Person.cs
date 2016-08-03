using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    /// <summary>
    /// Database entity
    /// </summary>
    public class Person
    {
        public string name { get; set; }
        public string email { get; set; }

        public Person(){}
        /*
        public override string ToString()
        {
            return   "name: "+ name +" emial:"+ email;
        }*/

    }
}
