using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using chartDemo.DataSource;

namespace chartDemo
{
    public class PageBase : System.Web.UI.Page
    {
        public PMMSConnection SourceConnection;

        public PageBase()
        {
            SourceConnection = new PMMSConnection();
        }
       
    }

}