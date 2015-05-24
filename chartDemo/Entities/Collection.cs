using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace chartDemo.Entities
{
    [Serializable()]
    [XmlRoot("COLLECTION")]
    public class COLLECTION
    {
        public string SOLUTIONHOST { get; set; }
        public string XHQVERS { get; set; }
        public string ROOT { get; set; }
        public string NAME { get; set; }
        public string COMPONENT { get; set; }
        public string TIMESTAMP { get; set; }
        public string QUALITY { get; set; }
        public string QUALITY_SHORT { get; set; }
        public string COUNT { get; set; }
    }

    [XmlRoot("COLLECTIONS")]
    public class COLLECTIONS
    {
        [XmlElement("COLLECTION")]
        public List<COLLECTION> CollectionList = new List<COLLECTION>();

    }
}