using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using chartDemo.NibrasService;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using PISDK;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace chartDemo
{
    public partial class TestDetails : System.Web.UI.Page
    {

        protected void btn_Click(object sender, EventArgs e)
        {
            gvWellTestDataRad.ExportSettings.IgnorePaging = true;
            gvWellTestDataRad.ExportSettings.ExportOnlyData = true;
            gvWellTestDataRad.ExportSettings.OpenInNewWindow = true;
            gvWellTestDataRad.MasterTableView.ExportToExcel();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    fillConduit();
                }
                catch (Exception exc)
                {
                    
                }
            }
        }
        void fillConduit()
        {
            DataTable dt = ConnectAndQuery(Request.QueryString["DeviceName"]);
            Dictionary<string,string> ls = new Dictionary<string,string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ls.Where(x => x.Key == dt.Rows[i]["CONDUIT_NAME"].ToString()).Count() == 0)
                    ls.Add(dt.Rows[i]["CONDUIT_NAME"].ToString(), dt.Rows[i]["CONDUIT_NAME"].ToString());
            }
            ddlConduit.DataSource = ls.OrderBy(x => x.Key).ToList();
            ddlConduit.DataTextField = "key";
            ddlConduit.DataValueField = "value";
            ddlConduit.DataBind();
            if (ddlConduit.Items.Count > 0)
            {
                ddlConduit.Items[0].Selected = true;
                BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
            }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        private DataTable ConnectAndQuery(string devicename)
        {
            devicename = string.IsNullOrEmpty(devicename) ? "V-0516" : devicename;
            string connectionString = GetOracleConnectionString();
            using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    try { connection.Close(); }
                    catch (Exception ex)
                    { }
                    connection.Open();
                    OracleCommand command = connection.CreateCommand();
                    string sql = "SELECT * FROM v_conduit_test where separator_id='" + devicename + "' and conduit_name like '%"+ddlConduit.SelectedValue+"%' and rownum<100";
                    command.CommandText = sql;
                    DataSet ds = new DataSet();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(ds);
                    connection.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                return null;
            }
        }
        protected void ddlConduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
            
        }
        protected void BindGridView(DataTable dt)
        {
            dt.DefaultView.Sort = "start_date";
            dt = dt.DefaultView.ToTable();
            gvWellTestDataRad.DataSource = dt;
            gvWellTestDataRad.DataBind();
        }
        protected void RebindGrid(object sender, EventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
        }

        protected void gvWellTestDataRad_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
        }

        protected void gvWellTestDataRad_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
        }

        protected void gvWellTestDataRad_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"]));
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = ConnectAndQuery(Request.QueryString["DeviceName"]);
        }
    }
}