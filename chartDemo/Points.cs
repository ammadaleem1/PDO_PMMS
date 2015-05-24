using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chartDemo
{
    public class Points
    {
        private double xvalue;
        private double yvalue;
        private int quality;
        private int timestamp;

        public Points()
        {
        }

        public double XValue
        {
            get { return xvalue; }
            set { xvalue = value; }
        }

        public double YValue
        {
            get { return yvalue; }
            set { yvalue = value; }
        }

        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public int Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
    }
}