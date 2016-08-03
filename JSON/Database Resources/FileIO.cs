using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    class FileIO
    { 
    
        public FileIO()
        {

        }


        public string readAll(string path)
        {
            string jsonFrom;
            using (StreamReader r = new StreamReader(path))
            {
                jsonFrom = r.ReadToEnd();
            }
            return jsonFrom;
        }

        public bool write(string path, string jsonTo)
        {
            using (StreamWriter r = new StreamWriter(path))
            {
                r.Write(jsonTo);
            }
            return true;
        }
    }
}
