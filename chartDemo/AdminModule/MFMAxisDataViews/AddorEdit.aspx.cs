using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using chartDemo.Helpers;
using System.Data;

namespace chartDemo.AdminModule.MFMAxisDataViews
{
    public partial class AddorEdit : PageBase
    {
        bool Update { get; set; }
        int Id;
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
        }

        void Initialize()
        {
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
            {
                Update = true;
                Id = StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString()));
                MFMAxisData report = SourceConnection.MFMAxisDatas.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                FillDataForUpdate(report);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Id = (Update) ? StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString())) : 0;
            MFMAxisData data = (!Update) ? new MFMAxisData() : SourceConnection.MFMAxisDatas.Where(x => x.Id.Equals(Id)).First();
            data.MaxValue = Convert.ToInt64(txtMaxValue.Text);
            data.MinValue = Convert.ToInt64(txtMinValue.Text);
            data.Axis = ddlAxis.SelectedValue;
            data.LogBase = Convert.ToInt32(txtLogBase.Text);
            data.MeterName = txtMeterName.Text;

            if (!Update)
            {
                SourceConnection.MFMAxisDatas.AddObject(data);
            }
            
            SourceConnection.SaveChanges();
            Response.Redirect("DataView.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataView.aspx");
        }


        void FillDataForUpdate(MFMAxisData data)
        {
            txtMeterName.Text = data.MeterName;
            txtMaxValue.Text = data.MaxValue.ToString();
            txtMinValue.Text = data.MinValue.ToString();
            txtLogBase.Text = data.LogBase.ToString();
            ddlAxis.SelectedValue = data.Axis.ToString();
        }

    }
}