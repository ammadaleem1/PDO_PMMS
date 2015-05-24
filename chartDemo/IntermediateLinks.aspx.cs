using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.OracleClient;
using Microsoft.ApplicationBlocks.Data;
using PISDK;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NCalc;
using chartDemo.XHQService;
using System.Web;

namespace chartDemo
{
    public partial class IntermediateLinks : System.Web.UI.Page
    {
        
        public void Page_Load(object sender, System.EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["pitag"]))
                        hdnPiTag.Value = Request.QueryString["pitag"];
                    else
                        hdnPiTag.Value = "FAH.FHC.53FQR013.DACA.PV";
                    if (!string.IsNullOrEmpty(Request.QueryString["DeviceName"]))
                        hdnDevice.Value = Request.QueryString["DeviceName"];
                    else
                        hdnDevice.Value = "V-0516";
                    if (!string.IsNullOrEmpty(Request.QueryString["tagNumber"]))
                        hdnInstTag.Value = Request.QueryString["tagNumber"];
                    else
                        hdnInstTag.Value = "10-QI-0202";
                    setUrls();
                }
            }
            catch (Exception exc)
            {
                lblErr.Text = exc.Message;
            }
        }
        void setUrls()
        {
            hlDevicePopup.NavigateUrl = "DeviceDetails.aspx?DeviceName=" + hdnDevice.Value;
            if (!string.IsNullOrEmpty(Request.QueryString["tertiary"]) && Request.QueryString["tertiary"] == "MPFM")
                hlOperatingEnvelope.NavigateUrl = "ChartDemo.aspx?DeviceName=" + hdnDevice.Value;
            else
                hlOperatingEnvelope.NavigateUrl = "OperatingEnvelop.aspx?TagName=" + hdnPiTag.Value;
            if (!string.IsNullOrEmpty(Request.QueryString["instype"]))
            {
                switch (Request.QueryString["instype"])
                {
                    case "Flow Element - Electromagnetic":
                        hlDataSheet.NavigateUrl = "GeneralPages/MagneticDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Orifice":
                        hlDataSheet.NavigateUrl = "GeneralPages/OrificeDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Cone":
                        hlDataSheet.NavigateUrl = "GeneralPages/VConeDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Venturi Tube":
                        hlDataSheet.NavigateUrl = "GeneralPages/VenturiDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Venturi Tube WGM":
                        hlDataSheet.NavigateUrl = "GeneralPages/WGMeterDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Ultrasonic":
                        hlDataSheet.NavigateUrl = "GeneralPages/UltraSonicDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    case "Flow Element - Coriolis":
                        hlDataSheet.NavigateUrl = "GeneralPages/CoriolisDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                    default:
                        hlDataSheet.NavigateUrl = "GeneralPages/MagneticDataSheet.aspx?TagNumber=" + hdnInstTag.Value;
                        break;
                }
            }
            hlMeterNote.NavigateUrl = "~/AdminModule/MeterNote/DataView.aspx?TagNumber=" + hdnInstTag.Value;
        }
    }
}
