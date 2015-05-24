using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace chartDemo.Entities
{
    public class Log
    {
        public string Type { get; set; }
        public string FileName { get; set; }
        public string Datetime { get; set; }
        public string ErrorMessage { get; set; }
        public string SectionNumber { get; set; }
        public string CurrentStatus { get; set; }
    }

    [XmlRoot("Logs")]
    public class Logs
    {
        [XmlElement("Log")]
        public List<Log> LogList = new List<Log>();

    }
}