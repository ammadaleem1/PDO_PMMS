using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using chartDemo.Helpers;
using System.Data;

namespace chartDemo.AdminModule.MeterNote
{
    public partial class AddorEdit : PageBase
    {
        bool Update { get; set; }
        int Id;
        string meterNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initialize();
            }
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
                Update = true;
            else
                Update = false;
            if (Request.QueryString["meter"] != null)
            {
                meterNumber = Request.QueryString["meter"].ToString();
            }
        }

        void Initialize()
        {
            BindCategories();
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
            {
                Update = true;
                Id = StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString()));
                DataSource.MeterNote note = SourceConnection.MeterNotes.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                FillDataForUpdate(note);
            }
        }

        void BindCategories()
        {
            List<MeterNoteCategory> list = SourceConnection.MeterNoteCategories.ToList();
            ddlCategory.DataSource = list;
            ddlCategory.DataTextField = "Category";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("---Select---", "-1"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Id = (Update) ? StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString())) : 0 ;
            DataSource.MeterNote data = (!Update) ? new DataSource.MeterNote() : SourceConnection.MeterNotes.Where(x => x.Id.Equals(Id)).First();
            data.Comment = txtComment.Text;
            data.CategoryId = StringHelper.TryParse(ddlCategory.SelectedValue);
            
            if (!Update)
            {
                data.MeterNumber = meterNumber;
                SourceConnection.MeterNotes.AddObject(data);
            }
            
            SourceConnection.SaveChanges();
            Response.Redirect("DataView.aspx?tagnumber=" + meterNumber);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataView.aspx?tagnumber=" + meterNumber);
        }

        void FillDataForUpdate(DataSource.MeterNote data)
        {
            txtComment.Text = data.Comment;
            ddlCategory.SelectedValue = data.CategoryId.ToString();
        }

    }
}