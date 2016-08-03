using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    interface IParser
    {
        string encode<T>(T p);
        T decode<T>(string json);
    }
}
