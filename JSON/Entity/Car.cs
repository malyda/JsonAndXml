using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JSON
{
    [Serializable]
    public class  Car
    {
        public Car()
        {

        }

        public Car(int numberOfWheels, string color)
        {
            this.numberOfWheels = numberOfWheels;
            this.color = color;
        }
        [XmlAttribute("numberOfWheels")]
        public int numberOfWheels { get; set; }
        [XmlAttribute("color")]
        public string color { get; set; }

        public override string ToString()
        {
            return "numberOfWheels: " + numberOfWheels + " color: " + color;
        }
    }

}
