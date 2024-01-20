using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyAPITestProject.Model.XmlModel
{
    [XmlRoot(ElementName = "laptop")]
    public class Laptop
    {
        [XmlElement(ElementName = "BrandName")]
        public string BrandName { get; set; }
        [XmlElement(ElementName = "Features")]
        public Features Features { get; set; }
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "laptopName")]
        public string LaptopName { get; set; }
    }
}
