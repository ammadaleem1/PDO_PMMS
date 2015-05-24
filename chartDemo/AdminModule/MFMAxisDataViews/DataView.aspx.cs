using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using chartDemo.DataSource;
using chartDemo.Helpers;

namespace chartDemo.AdminModule.MFMAxisDataViews
{
    public partial class DataView : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindAxisData();
        }

        void BindAxisData()
        {
            gvMFMAxisData.DataSource = SourceConnection.MFMAxisDatas.ToList();
            gvMFMAxisData.DataBind();
        }

        protected void gvMFMAxisData_RowCommand(object sender, GridCommandEventArgs e)
        {
            int dataId;
            switch (e.CommandName)
            {
                case "DeleteAxis":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    MFMAxisData data = SourceConnection.MFMAxisDatas.Where(x => x.Id.Equals(dataId)).First();
                    if (data != null)
                    {
                        SourceConnection.MFMAxisDatas.DeleteObject(data);
                        SourceConnection.SaveChanges();
                    }   
                    BindAxisData();
                    break;

                case "EditAxis":
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