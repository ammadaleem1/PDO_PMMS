using System;
using System.Collections.Generic;
using System.Web.Services;

namespace chartDemo
{
    /// <summary>
    /// Summary description for SampleData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SampleData : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        // Create sample data by hours
        public List<Points> getSampleDatabyHours(int hours)
        {
            List<Points> objSamples = new List<Points>();
            Random rndXvalue=new Random();
            Random rndYvalue = new Random();
            for (int inc = 1; inc <= hours * 60; inc++)
            {
                Points objPoints = new Points();
                objPoints.Timestamp = inc;
                objPoints.XValue = rndXvalue.Next(15000);
                objPoints.YValue = rndXvalue.Next(1000);
                objSamples.Add(objPoints);
            }
            return objSamples;
        }
    }
}
