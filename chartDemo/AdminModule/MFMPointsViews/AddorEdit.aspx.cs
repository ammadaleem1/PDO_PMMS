using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using chartDemo.Helpers;
using System.Data;

namespace chartDemo.AdminModule.MFMPointsViews
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
                MFMPoints points = SourceConnection.MFMPoints.Where(x => x.MFMPointsID.Equals(Id)).FirstOrDefault();
                FillDataForUpdate(points);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Id = (Update) ? StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString())) : 0;
            MFMPoints data = (!Update) ? new MFMPoints() : SourceConnection.MFMPoints.Where(x => x.MFMPointsID.Equals(Id)).First();
            data.PointGas = Convert.ToInt32(txtPointGas.Text);
            data.PointOil = Convert.ToInt32(txtPointOil.Text);
            data.MeasurementSection = txtMeasurementSection.Text;
            data.MeterName = txtMeterName.Text;

            if (!Update)
            {
                SourceConnection.MFMPoints.AddObject(data);
            }
            
            SourceConnection.SaveChanges();
            Response.Redirect("DataView.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataView.aspx");
        }


        void FillDataForUpdate(MFMPoints data)
        {
            txtMeterName.Text = data.MeterName;
            txtPointGas.Text = data.PointGas.ToString();
            txtPointOil.Text = data.PointOil.ToString();
            txtMeasurementSection.Text = data.MeasurementSection;
        }

    }
}