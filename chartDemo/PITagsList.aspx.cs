using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.OracleClient;
using Microsoft.ApplicationBlocks.Data;
using PISDK;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NCalc;
using chartDemo.XHQService;

namespace chartDemo
{
    public partial class PITagsList : System.Web.UI.Page
    {
        
        public void Page_Load(object sender, System.EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["TagName"]))
                        hdnTag.Value = Request.QueryString["TagName"];
                    else
                        hdnTag.Value = "52-QR-1103";
                   gvTags.DataSource = bindGrid();
                   gvTags.DataBind();
                }
            }
            catch (Exception exc)
            {
                lblErr.Text = exc.Message;
            }
        }
        protected void gvTags_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = bindGrid();
        }
        DataTable bindGrid()
        {
            string sql = "select * from InstrumentTag_PiTag where Tag_Number ='" + hdnTag.Value + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            return SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
           // gvTags.DataSource = dt;
            //gvTags.DataBind();
        }
    }
}
