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
using System.Collections;
using System.Text.RegularExpressions;
using NCalc;
using System.Configuration;

namespace chartDemo
{
    public partial class AddMaterialBalance : System.Web.UI.Page
    {
        public class PIAttributesClass
        {
            public string Descriptor { get; set; }
            public string EngUnits { get; set; }
            public string Instrumenttag { get; set; }
            public string PITag { get; set; }
            public string PointType { get; set; }
        }
        public class Pi
        {
            //public int id { get; set; }
            public DateTime time { get; set; }
            public string value { get; set; }
            public string tag { get; set; }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        public DataTable GetDataBaseTable()
        {
            string sql = "select mainclass,subclass1,subclass2,cluster,area,station,Mech_Eqpt_no,tag_no,Instrument_Type_Description,pitag from InstFuncHierarchy where pitag is not null";// vct.Validity_Status,vct.start_date,vct.end_date,vct.formation_gas,vct.gross,vct.oil,vct.water from v_conduit_test vct inner join v_conduit vc on VCT.CONDUIT_NAME=VC.CONDUIT_NAME where VCT.SEPARATOR_ID IS NOT NULL and vct.separator_id like '%' and vct.conduit_name = 'F018' and vct.validity_status='valid test' ";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["MaterialBalanceID"]))
                {
                    txtMaterialBalanceName.Enabled = false;
                    fillMaterialBalance();
                }
            }
        }
        void fillMaterialBalance()
        {
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteDataset(connectionSql, "GetMaterialBalance", int.Parse(Request.QueryString["MaterialBalanceID"])).Tables[0];
            if (dt.Rows.Count > 0)
            {
                txtInput.InnerText = dt.Rows[0]["InputEquation"].ToString().Replace("''","'") + " + ";
                txtOuput.InnerText = dt.Rows[0]["OutputEquation"].ToString().Replace("''", "'") + " + ";
                txtMaterialBalanceName.Text = dt.Rows[0]["MaterialBalanceName"].ToString();
                if (dt.Rows[0]["CreatedBy"].ToString().ToLower() != Context.User.Identity.Name.ToLower())
                {
                    btnInsertTags.Visible = false;
                    btnAddViewChart.Visible = false;
                }
            }
        }
        protected void RadGridInst_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetDataBaseTable();
        }
        protected void RadGridPI_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetPiData(txtTagName.Text);
        }
        protected void btnGetTags_Click(object sender, EventArgs e)
        {
            RadGridPI.DataSource = GetPiData(txtTagName.Text);
            RadGridPI.Rebind();
        }
        protected void SomethingChanged(object sender, EventArgs e)
        {

            //in this example this handler is used for both, Dropdownlist and RadiobuttonList
            var listControl = (ListControl)sender;
            var row = (Telerik.Web.UI.GridDataItem)listControl.NamingContainer;
            string pitag = row["pitag"].Text;
            var item = listControl.SelectedItem.Value;
            //string pitag = row.FindControl("pitag").ToString();
            if (item == "1")
            {
                txtOuput.InnerText = txtOuput.InnerText.Replace("('" + pitag + "') + ", "");
                txtInput.InnerText += "('" + pitag + "') + ";
            }
            else if(item == "2")
            {
                txtInput.InnerText = txtInput.InnerText.Replace("('" + pitag + "') + ", "");
                txtOuput.InnerText += "('" + pitag + "') + ";
            }
            //with FindControl on the row you could also find controls in other columns...
            
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
        protected void btnInsertTags_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }
        protected void btnAddViewChart_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
        void SaveData(bool viewChart)
        {
            try
            {
                ConnectionString conn = new ConnectionString();
                string connectionSql = conn.GetConnectionString().ToString();
                string user = Context.User.Identity.Name.ToString();
                string input = string.Empty;
                string output = string.Empty;
                if (!string.IsNullOrEmpty(txtInput.InnerText) && txtInput.InnerText.Length>3 && txtInput.InnerText.Substring(txtInput.InnerText.Length - 3) == " + ")
                    input = txtInput.InnerText.Substring(0, txtInput.InnerText.Length - 3);
                else
                    input = txtInput.InnerText;
                if (!string.IsNullOrEmpty(txtOuput.InnerText) && txtOuput.InnerText.Length>3 && txtOuput.InnerText.Substring(txtOuput.InnerText.Length - 3) == " + ")
                    output = txtOuput.InnerText.Substring(0, txtOuput.InnerText.Length - 3);
                else
                    output = txtOuput.InnerText;
                if (isExpressionValid(input) && isExpressionValid(output))
                {
                    int MaterialBalanceID = 0;
                    if (!string.IsNullOrEmpty(Request.QueryString["MaterialBalanceID"]))
                    {
                        MaterialBalanceID = int.Parse(Request.QueryString["MaterialBalanceID"]);
                    }
                    else
                    {
                        DataTable dt = SqlHelper.ExecuteDataset(connectionSql, "GetMaterialBalanceByName1", txtMaterialBalanceName.Text).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            lblStatus.ForeColor = Color.Red;
                            lblStatus.Text = "Material Balance already exists with this name.";
                            string script = string.Format("alert('{0}');", "Material Balance already exists with this name.");
                            if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                            {
                                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert", script, true /* addScriptTags */);
                            }
                            return;
                        }
                    }
                    int ID = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionSql, "InsertMaterialBalance", input.Replace("'", "''"), output.Replace("'", "''"), user, txtMaterialBalanceName.Text, MaterialBalanceID));
                    if (viewChart)
                        Response.Redirect("MaterialBalanceChart.aspx?MaterialBalanceID=" + ID.ToString());
                    else
                        Response.Redirect("MaterialBalance.aspx");
                    //lblStatus.ForeColor = Color.Black;
                    //lblStatus.Text = "Data saved successfully";
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Invalid expression.";
                    string script = string.Format("alert('{0}');", "Invalid Expression.");
                    if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert1"))
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert1", script, true /* addScriptTags */);
                    }
                }

            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblTitle.Text = "Error in saving data. Please try again later.";
            }
        }
        bool isExpressionValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;
            bool isValid = false;
            string[] tags = GetTags(value);
            foreach (string s in tags)
            {
                float currentvalue = GetCurrentValue(s);
                value = value.Replace("'" + s + "'", currentvalue.ToString());

            }
            Expression exp = new Expression(value);
            try
            {
                float eval = float.Parse(exp.Evaluate().ToString());
                isValid = true;
            }
            catch (Exception ex)
            {
                
            }
            return isValid;
        }
        List<PIAttributesClass> GetPiData(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                tagName = "*";
            List<PIAttributesClass> attributes = new List<PIAttributesClass>();
            if (tagName.Trim() != "*")
            {
                PISDK.PISDK sdk = new PISDK.PISDK();
                //Server srv = sdk.Servers["mus-as-126.corp.pdo.om"];
                //srv.Open("UID=upoa;PWD=upoa");
                string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
                string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
                Server srv = sdk.Servers[piServer];
                srv.Open(piCredentials);
                PIPoints myPoints = srv.PIPoints;
                PointList list = srv.GetPoints("tag = '" + tagName + "'");
                int count = list.Count > 100 ? 100 : list.Count;
                for (int i = 1; i <= count; i++)
                {
                    PIData data = list[i].Data;
                    try
                    {
                        attributes.Add(new PIAttributesClass { Descriptor = (list[i].PointAttributes["Descriptor"].Value).ToString(), EngUnits = (list[i].PointAttributes["EngUnits"].Value).ToString(), Instrumenttag = (list[i].PointAttributes["instrumenttag"].Value).ToString(), PITag = (list[i].PointAttributes["Tag"].Value).ToString(), PointType = (list[i].PointAttributes["pointtype"].Value).ToString() });
                    }
                    catch (Exception ex)
                    { }
                }
            }
            return attributes;
        }
    }
}