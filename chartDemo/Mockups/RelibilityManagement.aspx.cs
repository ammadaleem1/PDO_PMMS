using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chartDemo.Mockups
{
    public partial class RelibilityManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("MeterName"), new DataColumn("Date",typeof(DateTime)), new DataColumn("Status") });
            DataRow dr = dt.NewRow();
            dr["ID"] = "1";
            dr["MeterName"] = "ABC";
            dr["Date"] = DateTime.Now;
            dr["Status"] = "Active";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "2";
            dr["MeterName"] = "ABC";
            dr["Date"] = DateTime.Now;
            dr["Status"] = "Fail";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "3";
            dr["MeterName"] = "ABC";
            dr["Date"] = DateTime.Now;
            dr["Status"] = "Active";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "4";
            dr["MeterName"] = "ABC";
            dr["Date"] = DateTime.Now;
            dr["Status"] = "Fail";
            dt.Rows.Add(dr);

            dt.AcceptChanges();

            gvRelData.DataSource = dt;
            gvRelData.DataBind();
        }

        public string DisplayStatus(string status)
        {
            if (Eval("Status").Equals("Active"))
            { return "<button type='button' class='btn btn-success'><i class='fa fa-check'></i></button>"; }
            else { return "<button type='button' class='btn btn-danger'><i class='fa fa-times'></i></button>"; }
        }
    }
}