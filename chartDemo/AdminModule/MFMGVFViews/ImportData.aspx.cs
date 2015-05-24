using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using chartDemo.Helpers;
using chartDemo.DataSource;

namespace chartDemo.AdminModule.MFMGVFViews
{
    public partial class ImportData : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if ((txtFilePath.HasFile))
            {
                DataSet ds = ReadExcelFile();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SourceConnection.MFMGVFs.AddObject(new MFMGVF() { GVF = Convert.ToDouble(dr["GVF"].ToString()), MeterName = dr["MeterName"].ToString() });
                    }
                    SourceConnection.SaveChanges();
                }

                lblMessage.Text = "Data successfully Imported! Total Records:" + ds.Tables[0].Rows.Count;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;

            }
            else
            {
                lblMessage.Text = "Please select an excel file first";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        private DataSet ReadExcelFile()
        {

            string strFileName = DateTime.Now.ToString("ddMMyyyy_HHmmss");
            string strFileType = System.IO.Path.GetExtension(txtFilePath.FileName).ToString().ToLower();

            //Check file type
            if (strFileType == ".xls" || strFileType == ".xlsx")
            {
                txtFilePath.SaveAs(Server.MapPath("~/UploadedExcel/" + strFileName + strFileType));
            }
            else
            {
                lblMessage.Text = "Only excel files allowed";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return null;
            }

            string strNewPath = Server.MapPath("~/UploadedExcel/" + strFileName + strFileType);

            return ExcelHelper.ReadData(strNewPath);
        }
    }
}