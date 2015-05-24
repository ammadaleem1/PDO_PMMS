using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using chartDemo.NibrasService;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Configuration;

namespace chartDemo
{
    public partial class MFMDetails : System.Web.UI.Page
    {
        #region not used
        //public class MFMDetailItems {
        //    public MFMBasicDetail mfmBasicDetail { get; set; }
        //    public List<VenturiDetails> venturiDetails { get; set; }
        //    public List<VortexDetails> vortexDetails { get; set; }
        //    public List<GammaDetails> gammaDetails { get; set; }
        //    public List<ValveDetails> valveDetails { get; set; }
        //    public List<GammaDetails> gammaDetails { get; set; }
        //    public List<TransmitterDetails> transmitterDetails { get; set; }
        //}
        //public class MFMBasicDetail 
        //{
        //    string TagNumber { get; set; }
        //    string PEFSNumber { get; set; }
        //    string Cluster { get; set; }
        //    string Area { get; set; }
        //    string YearCommissioned { get; set; }
        //    string Material { get; set; }
        //    string Size { get; set; }
        //    string Rating { get; set; }
        //    string MinFlowRate { get; set; }
        //    string MaxFlowRate { get; set; }
        //}
        //public class VenturiDetails
        //{
        //    string NumberOfVenturies { get; set; }
        //    string BetaRatio { get; set; }
        //    string Size { get; set; }
        //    string ThroatDiameter { get; set; }
        //}
        //public class VortexDetails
        //{
        //    string Make { get; set; }
        //    string Material { get; set; }
        //    string MinMeaureRange { get; set; }
        //    string MaxMeaureRange { get; set; }
        //}
        //public class GammaDetails
        //{
        //    string Probe { get; set; }
        //    string Output { get; set; }
        //    string LeakageDoes5 { get; set; }
        //    string LeakageDoes100 { get; set; }
        //    string HalfLife { get; set; }
        //    string SingleHalfLife { get; set; }
        //}
        //public class ValveDetails
        //{
        //    string Make { get; set; }
        //    string Model { get; set; }
        //    string FailPosition { get; set; }
        //    string ProcessConnection { get; set; }
        //    string BodyMaterial { get; set; }
        //    string TrimMaterial { get; set; }
        //}
        //public class TransmitterDetails
        //{
        //    string Make { get; set; }
        //    string Model { get; set; }
        //    string RangeMin { get; set; }
        //    string RangeMax { get; set; }
        //    string Unit { get; set; }
        //    string TransmitterType { get; set; }
        //}
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tagname = string.IsNullOrEmpty(Request.QueryString["TagName"]) ? "" : Request.QueryString["TagName"];
                ConnectAndQuery(tagname);
            }
        }
        void fillConduit()
        {
        }
        //private string GetOracleConnectionString()
        //{
        //    return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        //}
        private void ConnectAndQuery(string tagName)
        {
            try
            {
                tagName = string.IsNullOrEmpty(tagName) ? "25-QR-2006" : tagName;
                ConnectionString conn = new ConnectionString();
                string connectionSql = conn.GetConnectionString().ToString();
                DataSet ds = SqlHelper.ExecuteDataset(connectionSql, "GetMFMDetailsByTag", tagName);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dtBasicDetail = ds.Tables[0];
                    if (dtBasicDetail.Rows.Count > 0)
                    {
                        DataTable dt = SqlHelper.ExecuteDataset(connectionSql, "GetMFMPEFSByTag", dtBasicDetail.Rows[0]["MFM TAG No"].ToString()).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["ZIP"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["Folder Name"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["PEFS NAME"].ToString()))
                                //lnkPEFS.HRef = ConfigurationSettings.AppSettings["CadViewerPath"] + "?ID=" + dt.Rows[0]["ZIP"].ToString() + "/" + dt.Rows[0]["Folder Name"].ToString() + "/" + dt.Rows[0]["Actual PEF Name"].ToString() + ".dwg";
                                lnkPEFS.HRef = ConfigurationSettings.AppSettings["CadViewerPath"] + "?ID=" + dt.Rows[0]["ZIP"].ToString() + "/" +  dt.Rows[0]["Actual PEF Name"].ToString() + ".dwg";
                        }
                        txtTagNumber.Text = dtBasicDetail.Rows[0]["PMMS_TAG_NO"].ToString();
                        txtPEFSNumber.Text = dtBasicDetail.Rows[0]["PEFS_NO"].ToString();
                        txtClusterAndArea.Text = dtBasicDetail.Rows[0]["Cluster"].ToString() + "/" + dtBasicDetail.Rows[0]["Area"].ToString();
                        txtYearCommissioned.Text = dtBasicDetail.Rows[0]["MFM Commissioned"].ToString();
                        txtMaterial.Text = dtBasicDetail.Rows[0]["Material"].ToString();
                        txtSizeAndRating.Text = dtBasicDetail.Rows[0]["Meter Size"].ToString() + "/" + dtBasicDetail.Rows[0]["Class_Rating ANSI"].ToString();
                        txtMinAndMaxFlowRate.Text = dtBasicDetail.Rows[0]["Min Liquid_Flow_Range M3D"].ToString() + "/" + dtBasicDetail.Rows[0]["Max Liquid_Flow_Range M3D"].ToString();
                        txtMaxGVFAndWC.Text = dtBasicDetail.Rows[0]["MAX GVF_Flow_Range PCT"].ToString() + "/" + dtBasicDetail.Rows[0]["MAX WC_Flow_Range PCT"].ToString();
                        if (ds.Tables.Count > 1)
                        {
                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                string betaRatio = ""; string throatDiameter = "";
                                DataTable dtVenturiDetails = ds.Tables[1];
                                betaRatio = dtVenturiDetails.Rows.Count > 1 ? dtVenturiDetails.Rows[0]["Venturi_Beta ratio"].ToString() + "/" + dtVenturiDetails.Rows[1]["Venturi_Beta ratio"].ToString() : dtVenturiDetails.Rows[0]["Venturi_Beta ratio"].ToString();
                                throatDiameter = dtVenturiDetails.Rows.Count > 1 ? dtVenturiDetails.Rows[0]["Venturi_D mm"].ToString() + "/" + dtVenturiDetails.Rows[1]["Venturi_D mm"].ToString() : dtVenturiDetails.Rows[0]["Venturi_D mm"].ToString();
                                txtNumberOfVenturies.Text = dtBasicDetail.Rows[0]["No_Venturies"].ToString();
                                txtVentruiSize.Text = dtBasicDetail.Rows[0]["Large _Venturi_Size"].ToString() + "/" + dtBasicDetail.Rows[0]["SmalL_Venturi_Size"].ToString();
                                txtBetaRatio.Text = betaRatio;
                                txtThroatDiameter.Text = throatDiameter;
                            }
                        }
                        if (ds.Tables.Count > 2)
                        {
                            if (ds.Tables[2].Rows.Count > 0)
                            {
                                DataTable dtVortex = ds.Tables[2];
                                txtVortexMake.Text = dtVortex.Rows[0]["Make"].ToString();
                                txtVortexMaterial.Text = dtVortex.Rows[0]["Model"].ToString();
                                txtVortexRangeMax.Text = dtVortex.Rows[0]["MaxMeasure_Range(am3/d)"].ToString();
                                txtVortexRangeMin.Text = dtVortex.Rows[0]["MinMeasure_Range(am3/d)"].ToString();
                            }
                        }
                        if (ds.Tables.Count > 3)
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                DataTable dtGamma = ds.Tables[3];
                                txtGammaHalfLife.Text = dtGamma.Rows[0]["Half_Life"].ToString();
                                txtGammaLeak100.Text = dtGamma.Rows[0]["Leakeage_does100"].ToString();
                                txtGammaLeak5.Text = dtGamma.Rows[0]["Leakeage_does5"].ToString();
                                txtGammaOutput.Text = dtGamma.Rows[0]["Output"].ToString();
                                txtGammaProbe.Text = dtGamma.Rows[0]["Probe"].ToString();
                                txtGammaSingleHalfLife.Text = dtGamma.Rows[0]["SingleHalf_Life"].ToString();
                            }
                        }
                        if (ds.Tables.Count > 4)
                        {
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                DataTable dtValve = ds.Tables[4];
                                string make = ""; string model = ""; string failPosition = ""; string processConnection = ""; string bodyMaterial = ""; string trimMaterial = "";
                                foreach (DataRow dr in dtValve.Rows)
                                {
                                    make += !string.IsNullOrEmpty(dr["Mold"].ToString()) ? dr["Mold"].ToString() + "/" : "";
                                    model += !string.IsNullOrEmpty(dr["Model"].ToString()) ? dr["Model"].ToString() + "/" : "";
                                    failPosition += !string.IsNullOrEmpty(dr["Fail_Position"].ToString()) ? dr["Fail_Position"].ToString() + "/" : "";
                                    processConnection += !string.IsNullOrEmpty(dr["Process_Connection"].ToString()) ? dr["Process_Connection"].ToString() + "/" : "";
                                    bodyMaterial += !string.IsNullOrEmpty(dr["Body_Material"].ToString()) ? dr["Body_Material"].ToString() + "/" : "";
                                    trimMaterial += !string.IsNullOrEmpty(dr["Trim_Material"].ToString()) ? dr["Trim_Material"].ToString() + "/" : "";
                                }
                                make = string.IsNullOrEmpty(make) ? make : make.Substring(0, make.Length - 1);
                                model = string.IsNullOrEmpty(model) ? model : model.Substring(0, model.Length - 1);
                                failPosition = string.IsNullOrEmpty(failPosition) ? failPosition : failPosition.Substring(0, failPosition.Length - 1);
                                processConnection = string.IsNullOrEmpty(processConnection) ? processConnection : processConnection.Substring(0, processConnection.Length - 1);
                                bodyMaterial = string.IsNullOrEmpty(bodyMaterial) ? bodyMaterial : bodyMaterial.Substring(0, bodyMaterial.Length - 1);
                                trimMaterial = string.IsNullOrEmpty(trimMaterial) ? trimMaterial : trimMaterial.Substring(0, trimMaterial.Length - 1);
                                txtValveMake.Text = make;
                                txtValveModel.Text = model;
                                txtValveFailPosition.Text = failPosition;
                                txtValveProcConn.Text = processConnection;
                                txtValveBodyMaterial.Text = bodyMaterial;
                                txtValveTrimMaterial.Text = trimMaterial;
                            }
                        }
                        if (ds.Tables.Count > 5)
                        {
                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                DataTable dtTransmitter = ds.Tables[5];
                                DataRow[] drPressure = dtTransmitter.Select("[Type P DP T] = 'P'");
                                DataRow[] drDiffPressure = dtTransmitter.Select("[Type P DP T] = 'DP'");
                                DataRow[] drTemperature = dtTransmitter.Select("[Type P DP T] = 'T'");
                                if (drPressure != null)
                                {
                                    if (drPressure.Length < 2)
                                    {
                                        txtMakeP1.Text = drPressure[0]["Make"].ToString();
                                        txtModelP1.Text = drPressure[0]["Model"].ToString();
                                        txtMeasRangeMinP1.Text = drPressure[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxP1.Text = drPressure[0]["Max Mesurement_Range"].ToString();
                                        txtUnitP1.Text = drPressure[0]["Qty"].ToString();
                                        P2.Visible = false;
                                    }
                                    else
                                    {
                                        txtMakeP1.Text = drPressure[0]["Make"].ToString();
                                        txtModelP1.Text = drPressure[0]["Model"].ToString();
                                        txtMeasRangeMinP1.Text = drPressure[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxP1.Text = drPressure[0]["Max Mesurement_Range"].ToString();
                                        txtUnitP1.Text = drPressure[0]["Qty"].ToString();

                                        txtMakeP2.Text = drPressure[1]["Make"].ToString();
                                        txtModelP2.Text = drPressure[1]["Model"].ToString();
                                        txtMeasRangeMinP2.Text = drPressure[1]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxP2.Text = drPressure[1]["Max Mesurement_Range"].ToString();
                                        txtUnitP2.Text = drPressure[1]["Qty"].ToString();
                                    }
                                }
                                else
                                    P2.Visible = false;
                                if (drDiffPressure != null)
                                {
                                    if (drDiffPressure.Length < 2)
                                    {
                                        txtMakeDP1.Text = drDiffPressure[0]["Make"].ToString();
                                        txtModelDP1.Text = drDiffPressure[0]["Model"].ToString();
                                        txtMeasRangeMinDP1.Text = drDiffPressure[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxDP1.Text = drDiffPressure[0]["Max Mesurement_Range"].ToString();
                                        txtUnitDP1.Text = drDiffPressure[0]["Qty"].ToString();
                                        DP2.Visible = false;
                                    }
                                    else
                                    {
                                        txtMakeDP1.Text = drDiffPressure[0]["Make"].ToString();
                                        txtModelDP1.Text = drDiffPressure[0]["Model"].ToString();
                                        txtMeasRangeMinDP1.Text = drDiffPressure[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxDP1.Text = drDiffPressure[0]["Max Mesurement_Range"].ToString();
                                        txtUnitDP1.Text = drDiffPressure[0]["Qty"].ToString();

                                        txtMakeDP2.Text = drDiffPressure[1]["Make"].ToString();
                                        txtModelDP2.Text = drDiffPressure[1]["Model"].ToString();
                                        txtMeasRangeMinDP2.Text = drDiffPressure[1]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxDP2.Text = drDiffPressure[1]["Max Mesurement_Range"].ToString();
                                        txtUnitDP2.Text = drDiffPressure[1]["Qty"].ToString();
                                    }
                                }
                                else
                                    DP2.Visible = false;
                                if (drTemperature != null)
                                {
                                    if (drTemperature.Length < 2)
                                    {
                                        txtMakeT1.Text = drTemperature[0]["Make"].ToString();
                                        txtModelT1.Text = drTemperature[0]["Model"].ToString();
                                        txtMeasRangeMinT1.Text = drTemperature[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxT1.Text = drTemperature[0]["Max Mesurement_Range"].ToString();
                                        txtUnitT1.Text = drTemperature[0]["Qty"].ToString();
                                        T2.Visible = false;
                                    }
                                    else
                                    {
                                        txtMakeT1.Text = drTemperature[0]["Make"].ToString();
                                        txtModelT1.Text = drTemperature[0]["Model"].ToString();
                                        txtMeasRangeMinT1.Text = drTemperature[0]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxT1.Text = drTemperature[0]["Max Mesurement_Range"].ToString();
                                        txtUnitT1.Text = drTemperature[0]["Qty"].ToString();

                                        txtMakeT2.Text = drTemperature[1]["Make"].ToString();
                                        txtModelT2.Text = drTemperature[1]["Model"].ToString();
                                        txtMeasRangeMinT2.Text = drTemperature[1]["MinMesurement Range"].ToString();
                                        txtMeasRangeMaxT2.Text = drTemperature[1]["Max Mesurement_Range"].ToString();
                                        txtUnitT2.Text = drTemperature[1]["Qty"].ToString();
                                    }
                                }
                                else
                                    T2.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        string script = string.Format("alert('{0}');", "No Data To Display");
                        if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert", script, true /* addScriptTags */);
                        }
                    }
                }
                else
                {
                    string script = string.Format("alert('{0}');", "No Data To Display");
                    if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert1"))
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert1", script, true /* addScriptTags */);
                    }
                }
            }
            catch (Exception ex)
            {
                string script = string.Format("alert('{0}');", "No Data To Display");
                if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert2"))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert2", script, true /* addScriptTags */);
                }
            }
        }
    }
}