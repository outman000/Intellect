using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class body
    {
        [XmlElement(ElementName = "qrCode")]
        public string qrCode { get; set; }
    }
}
