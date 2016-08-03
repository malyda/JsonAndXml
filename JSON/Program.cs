using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using JSON;
using JSON.Database_Resources;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        { 
            viaParser();
         }


    public static void viaParser()
    {
        List<Car> lc = new List<Car>();
        for (int i = 0; i < 10; i++)
        {
            Car c = new Car();
            c.color = "black";
            c.numberOfWheels = i;
            lc.Add(c);
        }

        IDB db = new XMLDB();
        IParser parser = new XMLParser();

        db.write(parser.encode(lc));
            
        lc = parser.decode<List<Car>>(db.readAll());

        lc.ForEach(i => Console.Write("{0}\n", i));

        }

        public static void toAndFrom()
        {
            Person p = new Person();
            p.name = "asdasd";
            p.email = "asdasd@asdasd.cz";

            string json = JsonConvert.SerializeObject(p);
            Console.WriteLine(json);

            Person p2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(p2);
        }
    }
}
