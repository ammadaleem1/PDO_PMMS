using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using Telerik.Web.UI;

namespace chartDemo.Controls
{
    public partial class MechanicalDetails : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void fillSAPData(string deviceName)
        {
            string sql = "select * from v_sapdata where [Mechanical_Equipment] ='" + deviceName + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            gvSAPData.DataSource = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            gvSAPData.DataBind();
        }

        public void fillVerificationData(string deviceName)
        {
            string sql = "select * from IntegrityDefinitions where [Mech_Eqpt_no] ='" + deviceName + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            gvVerification.DataSource = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            gvVerification.DataBind();
        }
        
    }
}