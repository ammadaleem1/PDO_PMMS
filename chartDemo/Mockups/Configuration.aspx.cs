using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace chartDemo.Mockups
{
    public partial class Configuration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("FileName"), new DataColumn("UploadedDate", typeof(DateTime)), new DataColumn("UploadedBy")});
            DataRow dr = dt.NewRow();
            dr["ID"] = "1";
            dr["FileName"] = "Upload1.xlsx";
            dr["UploadedDate"] = DateTime.Now;
            dr["UploadedBy"] = "Ammad";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "1";
            dr["FileName"] = "Upload1.xlsx";
            dr["UploadedDate"] = DateTime.Now;
            dr["UploadedBy"] = "Ammad";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "1";
            dr["FileName"] = "Upload1.xlsx";
            dr["UploadedDate"] = DateTime.Now;
            dr["UploadedBy"] = "Ammad";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["ID"] = "1";
            dr["FileName"] = "Upload1.xlsx";
            dr["UploadedDate"] = DateTime.Now;
            dr["UploadedBy"] = "Furqan";
            dt.Rows.Add(dr);

            dt.AcceptChanges();

            gvRelData.DataSource = dt;
            gvRelData.DataBind();
        }

       
    }
}