using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using chartDemo.DataSource;
using chartDemo.Helpers;

namespace chartDemo.AdminModule.MFMPointsViews
{
    public partial class DataView : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPointsData();
        }

        void BindPointsData()
        {
            gvMFMPoints.DataSource = SourceConnection.MFMPoints.ToList();
            gvMFMPoints.DataBind();
        }

        protected void gvMFMPoints_RowCommand(object sender, GridCommandEventArgs e)
        {
            int dataId;
            switch (e.CommandName)
            {
                case "DeletePoint":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    MFMPoints data = SourceConnection.MFMPoints.Where(x => x.MFMPointsID.Equals(dataId)).First();
                    if (data != null)
                    {
                        SourceConnection.MFMPoints.DeleteObject(data);
                        SourceConnection.SaveChanges();
                    }   
                    BindPointsData();
                    break;

                case "EditPoint":
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