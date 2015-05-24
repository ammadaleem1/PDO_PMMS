using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using chartDemo.DataSource;
using chartDemo.Helpers;

namespace chartDemo.AdminModule.MFMGVFViews
{
    public partial class DataView : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGVFData();
        }

        void BindGVFData()
        {
            gvMFMGVF.DataSource = SourceConnection.MFMGVFs.ToList();
            gvMFMGVF.DataBind();
        }

        protected void gvMFMGVF_RowCommand(object sender, GridCommandEventArgs e)
        {
            int dataId;
            switch (e.CommandName)
            {
                case "DeleteGVF":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    MFMGVF data = SourceConnection.MFMGVFs.Where(x => x.GVFID.Equals(dataId)).First();
                    if (data != null)
                    {
                        SourceConnection.MFMGVFs.DeleteObject(data);
                        SourceConnection.SaveChanges();
                    }   
                    BindGVFData();
                    break;

                case "EditGVF":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("AddorEdit.aspx?Id=" + StringHelper.Encrypt(dataId.ToString()));
                    break;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("addoredit.aspx");
        }
    }
}