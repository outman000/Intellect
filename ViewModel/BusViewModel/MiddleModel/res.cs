using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ViewModel.BusViewModel.MiddleModel
{
    [XmlRoot(ElementName = "res")]
    public class res
    {
        [XmlElement(ElementName = "header")]
        public header header { get; set; }

        [XmlElement(ElementName = "body")]
        public body body { get; set; }
    }
}
