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

namespace chartDemo
{
    public partial class MaterialBalance : System.Web.UI.Page
    {
        public class PIAttributesClass
        {
            public string Descriptor { get; set; }
            public string EngUnits { get; set; }
            public string Instrumenttag { get; set; }
            public string PITag { get; set; }
            public string PointType { get; set; }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            gvMaterialBalance.ExportSettings.IgnorePaging = true;
            gvMaterialBalance.ExportSettings.ExportOnlyData = true;
            gvMaterialBalance.ExportSettings.OpenInNewWindow = true;
            gvMaterialBalance.MasterTableView.ExportToExcel();
        }
        public DataTable GetDataBaseTable()
        {
            string sql = "select * from MaterialBalance order by CreatedDate desc";
             ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            return dt;
        }
        protected void gvMaterialBalance_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetDataBaseTable();
        }
        public void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void gvMaterialBalance_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                LinkButton deleteButton = (LinkButton)item["Delete"].Controls[0];//.FindControl("");
                if (item["CreatedBy"].Text != Context.User.Identity.Name)
                {
                    deleteButton.Visible = false;
                }
                string input = item["InputEquation"].Text.Replace("''", "'");
                string output = item["OutputEquation"].Text.Replace("''", "'");
                Label lblinput = (Label)item.FindControl("lblInputResult");
                lblinput.Text = GetExpressionValue(input).ToString();
                Label lbloutput = (Label)item.FindControl("lblOutputResult");
                lbloutput.Text = GetExpressionValue(output).ToString();
            }
        } 
        protected void gvMaterialBalance_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            // using columnuniquename
            //string str1 = item["Name"].Text;
            // using DataKey
            int ID = int.Parse(item.GetDataKeyValue("MaterialBalanceID").ToString());
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            SqlHelper.ExecuteNonQuery(connectionSql, "DeleteMaterialBalance", ID);
            gvMaterialBalance.Rebind();
        }
        float GetCurrentValue(string tagname)
        {
            float currentvalue = 0;
            PISDK.PISDK sdk = new PISDK.PISDK();
            //PISDK.Server srv = sdk.Servers["mus-as-126.corp.pdo.om"];
            //srv.Open("UID=upoa;PWD=upoa");
            string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
            string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
            Server srv = sdk.Servers[piServer];
            srv.Open(piCredentials);
            PISDK.PIPoints myPoints = srv.PIPoints;
            try
            {
                PIValue value = myPoints[tagname].Data.Snapshot;
                currentvalue = value.Value;
            }
            catch (Exception ex)
            { }
            return currentvalue;
        }
        string[] GetTags(string val)
        {
            MatchCollection match = Regex.Matches(val, @"'(.*?)'");
            string[] arr = new string[match.Count];
            for (int i = 0; i < match.Count; i++)
            {
                arr[i] = match[i].Groups[1].Value;
            }
            return arr;
        }
        float GetExpressionValue(string value)
        {
            float eval = 0;
            string[] tags = GetTags(value);
            foreach (string s in tags)
            {
                float currentvalue = GetCurrentValue(s);
                value = value.Replace("'" + s + "'", currentvalue.ToString());

            }
            Expression exp = new Expression(value);
            try
            {
                 eval = float.Parse(exp.Evaluate().ToString());
                
            }
            catch (Exception ex)
            {

            }
            return eval;
        }
    }
}
