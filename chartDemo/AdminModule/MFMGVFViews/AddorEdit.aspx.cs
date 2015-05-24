using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using chartDemo.DataSource;
using chartDemo.Helpers;
using System.Data;

namespace chartDemo.AdminModule.MFMGVFViews
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
                MFMGVF gvf = SourceConnection.MFMGVFs.Where(x => x.GVFID.Equals(Id)).FirstOrDefault();
                FillDataForUpdate(gvf);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Id = (Update) ? StringHelper.TryParse(StringHelper.Decrypt(Request.QueryString["Id"].ToString())) : 0 ;
            MFMGVF data = (!Update) ? new MFMGVF() : SourceConnection.MFMGVFs.Where(x => x.GVFID.Equals(Id)).First();
            data.GVF = Convert.ToDouble(txtGVF.Text);
            data.MeterName = txtMeterName.Text;

            if (!Update)
            {
                SourceConnection.MFMGVFs.AddObject(data);
            }
            
            SourceConnection.SaveChanges();
            Response.Redirect("DataView.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataView.aspx");
        }


        void FillDataForUpdate(MFMGVF data)
        {
            txtMeterName.Text = data.MeterName;
            txtGVF.Text = data.GVF.ToString();
        }

    }
}