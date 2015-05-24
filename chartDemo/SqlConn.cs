using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace chartDemo
{
    public class ConnectionString
    {
        static ConnectionString()
        {
            try
            {
                connection = ConfigurationSettings.AppSettings["PDOConnection"].ToString();

            }
            catch (Exception e)
            {
                connection = "Data Source=173.204.98.115;Initial Catalog=iAgentSolutionsTest1;Persist Security Info=True;User ID=sa;Password=709iAgent123";
            }
        }
        static private string connection;

        public SqlConnection GetSqlConnection()
        {
            SqlConnection Cn = null;
            try
            {
                Cn = new SqlConnection(connection);
                Cn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Cn;
        }



        public static string Connection
        {
            get
            {
                try
                {
                    if (connection.Length < 0)
                    {
                    }
                }
                catch (Exception ex)
                {
                    connection = "Data Source=173.204.98.115;Initial Catalog=iAgentSolutionsTest1;Persist Security Info=True;User ID=sa;Password=709iAgent123";
                    //connection = sec.Decrypt("Data Source=iAgentserver;Initial Catalog=iAgentSolutionsTest1;Persist Security Info=True;User ID=sa;Password=iAgent123");
                }
                return connection;
            }
        }





        public string GetConnectionString()
        {
            try
            {
                if (connection.Length < 0)
                {
                }
            }
            catch (Exception ex)
            {
                connection = "Data Source=173.204.98.115;Initial Catalog=iAgentSolutionsTest1;Persist Security Info=True;User ID=sa;Password=709iAgent123";
                //connection = sec.Decrypt("Data Source=iAgentserver;Initial Catalog=iAgentSolutionsTest1;Persist Security Info=True;User ID=sa;Password=iAgent123");
            }
            return connection;
        }

    }
}