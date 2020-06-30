using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ViewModel.BusViewModel.MiddleModel
{
    public class header
    {
        [XmlElement(ElementName = "hdlSts")]
        public string hdlSts { get; set; }
    }
}
