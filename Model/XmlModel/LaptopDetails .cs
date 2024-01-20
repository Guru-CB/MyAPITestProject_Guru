using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyAPITestProject.Model.XmlModel
{
    [XmlRoot(ElementName = "laptopDetails")]
    public class LaptopDetails
    {
        [XmlElement(ElementName = "laptop")]
        public Laptop Laptop { get; set; }
    }
}
