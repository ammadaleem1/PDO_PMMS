using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using chartDemo.DataSource;
using chartDemo.Helpers;

namespace chartDemo.AdminModule.MeterNoteCategoryViews
{
    public partial class DataView : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCatData();
        }

        void BindCatData()
        {
            gvNoteCategories.DataSource = SourceConnection.MeterNoteCategories.ToList();
            gvNoteCategories.DataBind();
        }

        protected void gvNoteCategories_RowCommand(object sender, GridCommandEventArgs e)
        {
            int dataId;
            switch (e.CommandName)
            {
                case "DeleteCat":
                    dataId = Convert.ToInt32(e.CommandArgument);
                    MeterNoteCategory data = SourceConnection.MeterNoteCategories.Where(x => x.Id.Equals(dataId)).First();
                    if (data != null)
                    {
                        SourceConnection.MeterNoteCategories.DeleteObject(data);
                        SourceConnection.SaveChanges();
                    }   
                    BindCatData();
                    break;

                case "EditCat":
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