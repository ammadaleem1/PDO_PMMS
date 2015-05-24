using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using chartDemo.DataSource;
using chartDemo.Helpers;

namespace chartDemo.AdminModule.MeterNote
{
    public partial class DataView : PageBase
    {
        string meterNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tagnumber"] != null)
            {
                meterNumber = Request.QueryString["tagnumber"].ToString();
            }
            BindNoteData();
        }

        void BindNoteData()
        {
            gvMeterNotes.DataSource = (!string.IsNullOrEmpty(meterNumber)) ? SourceConnection.MeterNotes.Where(x => x.MeterNumber.Equals(meterNumber)).ToList() : SourceConnection.MeterNotes.ToList();
            gvMeterNotes.DataBind();
        }

        protected void gvMeterNotes_RowCommand(object sender, GridCommandEventArgs e)
        {
            int dataId;
            switch (e.CommandName)
            {
                case "DeleteNote":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    DataSource.MeterNote data = SourceConnection.MeterNotes.Where(x => x.Id.Equals(dataId)).First();
                    if (data != null)
                    {
                        SourceConnection.MeterNotes.DeleteObject(data);
                        SourceConnection.SaveChanges();
                    }
                    BindNoteData();
                    break;

                case "EditNote":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("AddorEdit.aspx?meter=" + meterNumber + "&Id=" + StringHelper.Encrypt(dataId.ToString()));
                    break;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
             Response.Redirect("addoredit.aspx?meter="+meterNumber);
        }
    }
}