using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using chartDemo.NibrasService;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using PISDK;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web;
//using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using System.IO;
using System.Web.UI;
using System.Web;
using System.Text;
using System.Web.UI.HtmlControls;

namespace chartDemo
{
   
    public partial class DeviceDetails : System.Web.UI.Page
    {
        DataTable CreateScaterChartDataTable(DataTable dt)
        {
            DataTable dtScaterChart = new DataTable();
            dtScaterChart.Columns.AddRange(new DataColumn[] { new DataColumn("GVF"), new DataColumn("BSW"), new DataColumn("Oil") });
            double gvf, gasAtOC, gasOut, separatorPressure, separatorTemperature, liquid, oil, water, bsw = 0;
            decimal temp = 0;
            DateTime dtTemp = DateTime.Now;
            DateTime minDate = DateTime.Now;
            DateTime maxDate = DateTime.Now.AddDays(-1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dtScaterChart.NewRow();
                gasOut = string.IsNullOrEmpty(dt.Rows[i]["GAS_OUT"].ToString()) || !decimal.TryParse(dt.Rows[i]["GAS_OUT"].ToString(), out temp) || double.Parse(dt.Rows[i]["GAS_OUT"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["GAS_OUT"].ToString());
                separatorPressure = string.IsNullOrEmpty(dt.Rows[i]["Separator_Pressure"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Pressure"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Pressure"].ToString()) <= 0 ? 202.6 : double.Parse(dt.Rows[i]["Separator_Pressure"].ToString());
                separatorTemperature = string.IsNullOrEmpty(dt.Rows[i]["Separator_Temperature"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Temperature"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) <= 0 ? 35 + 273.16 : double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) + 273.16;
                oil = string.IsNullOrEmpty(dt.Rows[i]["OIL"].ToString()) || !decimal.TryParse(dt.Rows[i]["OIL"].ToString(), out temp) || double.Parse(dt.Rows[i]["OIL"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["OIL"].ToString());
                water = string.IsNullOrEmpty(dt.Rows[i]["WATER"].ToString()) || !decimal.TryParse(dt.Rows[i]["WATER"].ToString(), out temp) || double.Parse(dt.Rows[i]["WATER"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["WATER"].ToString());
                liquid = oil + water;
                gasAtOC = (gasOut * 101.3 * separatorTemperature) / ((15 + 273.16) * separatorPressure);
                gvf = (gasAtOC / (gasAtOC + liquid)) * 100;
                bsw = string.IsNullOrEmpty(dt.Rows[i]["BSW"].ToString()) ? 0 : double.Parse(dt.Rows[i]["BSW"].ToString());
                if (decimal.TryParse(bsw.ToString(), out temp) && decimal.TryParse(oil.ToString(), out temp) && decimal.TryParse(gvf.ToString(), out temp) && bsw <= 100)
                {
                    dr["GVF"] = gvf;
                    dr["BSW"] = bsw;
                    dr["Oil"] = oil;
                    dtScaterChart.Rows.Add(dr);
                }

            }
            return dtScaterChart;
        }
        DataTable CreateChartDataTable(DataTable dt, string chartType)
        {
            DataTable dtChart = new DataTable();
            dtChart.Columns.AddRange(new DataColumn[] { new DataColumn("Value"), new DataColumn("DateTime") });
            double gvf, gasAtOC, gasOut, separatorPressure, separatorTemperature, liquid, oil, water, bsw = 0;
            decimal temp = 0;
            DateTime dtTemp = DateTime.Now;
            DateTime minDate = DateTime.Now;
            DateTime maxDate = DateTime.Now.AddDays(-1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drChart = dtChart.NewRow();
                gasOut = string.IsNullOrEmpty(dt.Rows[i]["GAS_OUT"].ToString()) || !decimal.TryParse(dt.Rows[i]["GAS_OUT"].ToString(), out temp) || double.Parse(dt.Rows[i]["GAS_OUT"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["GAS_OUT"].ToString());
                separatorPressure = string.IsNullOrEmpty(dt.Rows[i]["Separator_Pressure"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Pressure"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Pressure"].ToString()) <= 0 ? 202.6 : double.Parse(dt.Rows[i]["Separator_Pressure"].ToString());
                separatorTemperature = string.IsNullOrEmpty(dt.Rows[i]["Separator_Temperature"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Temperature"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) <= 0 ? 35 + 273.16 : double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) + 273.16;
                oil = string.IsNullOrEmpty(dt.Rows[i]["OIL"].ToString()) || !decimal.TryParse(dt.Rows[i]["OIL"].ToString(), out temp) || double.Parse(dt.Rows[i]["OIL"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["OIL"].ToString());
                water = string.IsNullOrEmpty(dt.Rows[i]["WATER"].ToString()) || !decimal.TryParse(dt.Rows[i]["WATER"].ToString(), out temp) || double.Parse(dt.Rows[i]["WATER"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["WATER"].ToString());
                liquid = oil + water;
                gasAtOC = (gasOut * 101.3 * separatorTemperature) / ((15 + 273.16) * separatorPressure);
                gvf = (gasAtOC / (gasAtOC + liquid)) * 100;
                bsw = string.IsNullOrEmpty(dt.Rows[i]["BSW"].ToString()) ? 0 : double.Parse(dt.Rows[i]["BSW"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[i]["start_date"].ToString()) && DateTime.TryParse(dt.Rows[i]["start_date"].ToString(), out dtTemp))
                {
                    if (i == 0)
                    {
                        minDate = dtTemp;
                        maxDate = dtTemp;
                    }
                    if (dtTemp < minDate)
                        minDate = dtTemp;
                    if (dtTemp > maxDate)
                        maxDate = dtTemp;
                    drChart["DateTime"] = dtTemp.Date;
                    if (chartType == "gvf")
                        drChart["Value"] = gvf;
                    else if (chartType == "oil")
                        drChart["Value"] = oil;
                    else if (chartType == "bsw")
                        drChart["Value"] = bsw;
                    else if (chartType == "gas")
                        drChart["Value"] = gasOut;
                    dtChart.Rows.Add(drChart);
                }
            }
            return dtChart;
        }
        protected void lnk_Click1(object sender, EventArgs e)
        {
            export();   
        }
        protected void btnPIChart_Click(object sender, EventArgs e)//aggregatePI
        {
            //Button btn = (Button)sender;
            switch (chartType.Value)
            {
                /*case "aggregatePI":
                    exportChart("PIAggregate", "aggregatePI");
                    break;*/
                case "actualPI":
                    exportChart("PIActual", "actualPI");
                    break;
                case "actualScater":
                    exportChart("ScaterActual", "actualScater");
                    break;
                case "aggregateScater":
                    exportChart("ScaterAggregate", "aggregateScater");
                    break;
                case "actualGVF":
                    exportChart("GVFActual", "actualGVF");
                    break;
                case "aggregateGVF":
                    exportChart("GVFAggregate", "aggregateGVF");
                    break;
                case "actualOil":
                    exportChart("OilActual", "actualOil");
                    break;
                case "aggregateOil":
                    exportChart("OilAggregate", "aggregateOil");
                    break;
                case "actualBSW":
                    exportChart("BSWActual", "actualBSW");
                    break;
                case "aggregateBSW":
                    exportChart("BSWAggregate", "aggregateBSW");
                    break;
                case "actualGas":
                    exportChart("GasActual", "actualGas");
                    break;
                case "aggregateGas":
                    exportChart("GasAggregate", "aggregateGas");
                    break;
                case "monthly":
                    exportChart("ConduitDevice", "monthly");
                    break;
            }
        }
        public void export()
        {
            gvWellTestDataRad.ExportSettings.IgnorePaging = true;
            gvWellTestDataRad.ExportSettings.ExportOnlyData = true;
            gvWellTestDataRad.ExportSettings.OpenInNewWindow = true;
            gvWellTestDataRad.MasterTableView.ExportToExcel();
        }
        public void exportChart(string fileName, string chartDatasource)
        {
            switch (chartDatasource)
            {
                /*case "aggregatePI":
                    gvExport.DataSource = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), "", "");
                    gvExport.DataBind();
                    break;*/
                case "actualPI":
                    gvExport.DataSource = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), "", "");
                    gvExport.DataBind();
                    break;
                case "actualScater":
                    gvExport.DataSource = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
                case "aggregateScater":
                    DataTable dtScater = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateScaterChartDataTable(dtScater);
                    gvExport.DataBind();
                    break;
                case "actualGVF":
                    gvExport.DataSource = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
                case "aggregateGVF":
                    DataTable dtGVF = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtGVF,"gvf");
                    gvExport.DataBind();
                    break;
                case "actualOil":
                    gvExport.DataSource = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
                case "aggregateOil":
                    DataTable dtOil = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtOil, "oil");
                    gvExport.DataBind();
                    break;
                case "actualBSW":
                    gvExport.DataSource = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
                case "aggregateBSW":
                    DataTable dtBSW = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtBSW, "bsw");
                    gvExport.DataBind();
                    break;
                case "actualGas":
                    gvExport.DataSource = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
                case "aggregateGas":
                    DataTable dtGas = GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtGas, "gas");
                    gvExport.DataBind();
                    break;
                case "monthly":
                    gvExport.DataSource = GetConduitDeviceData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    break;
            }
            gvExport.ExportSettings.IgnorePaging = true;
            gvExport.ExportSettings.ExportOnlyData = true;
            gvExport.ExportSettings.OpenInNewWindow = true;
            gvExport.ExportSettings.FileName = fileName;
            gvExport.MasterTableView.ExportToExcel();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                //CalendarExtender1.SelectedDate = dt.AddDays(-1);
                //CalendarExtender2.SelectedDate = dt;
                try
                {
                    ucMechDetails.fillSAPData(Request.QueryString["DeviceName"]);
                    ucMechDetails.fillVerificationData(Request.QueryString["DeviceName"]);
                    BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), "", ""));
                    CreateScaterChart(GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), "", ""));
                }
                catch (Exception exc)
                {

                }
            }
            if (IsPostBack)
            {
                //test();
                if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                {
                    CalendarExtender1.SelectedDate = Convert.ToDateTime(Request.Form["txtStartDate"].ToString());
                    CalendarExtender2.SelectedDate = Convert.ToDateTime(Request.Form["txtEndDate"].ToString());
                }
                else
                {
                    CalendarExtender1.SelectedDate = null;
                    CalendarExtender2.SelectedDate = null;
                }
            }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        private DataTable ConnectAndQuery(string devicename, bool includeAbondoned,string startDate, string endDate)
        {
            if(String.IsNullOrEmpty(devicename))
                devicename="V-0516";
            string connectionString = GetOracleConnectionString();
            using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    try { connection.Close(); }
                    catch (Exception ex)
                    { }
                    connection.Open();

                    //Console.WriteLine("State: {0}", connection.State);
                    //Console.WriteLine("ConnectionString: {0}",
                    //                  connection.ConnectionString);

                    OracleCommand command = connection.CreateCommand();
                    string sqlDateFilter = (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"])) ? " and t.start_date >= '" + startDate + "' and t.end_date <= '" + endDate + "'" : "";
                    string sql = "select " +
"vct.separator_id,   vct.conduit_name," +
"count(*) TotalTests, " +
"CASE vc.actual_status " +
    "WHEN 'ABAN_01'    THEN 0    WHEN 'ABAN_02'    THEN 0    WHEN 'ABAN_03'    THEN 0    WHEN 'ABAN_04'    THEN 0    ELSE 1  END iconduitstatus," +
"sum(case when VALIDITY_STATUS='valid test' then 1 else 0 end) Valid, " +
"sum(case when VALIDITY_STATUS='invalid test' then 1 else 0 end) InValid," +
"sum(case when VALIDITY_STATUS='valid test' then 0 when VALIDITY_STATUS= 'invalid test' then 0 else 1 end) NotValidated, " +
"(select NVL(min(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minwater," +
"(select NVL(max(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxwater," +
"(select NVL(min(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minoil," +
"(select NVL(max(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxoil," +
"(select NVL(min(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minbsw," +
"(select NVL(max(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxbsw," +
"(select NVL(min(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") mingasout," +
"(select NVL(max(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxgasout " +
"FROM  V_CONDUIT_TEST VCT INNER JOIN V_CONDUIT VC ON   VCT.CONDUIT_NAME=VC.CONDUIT_NAME " +
"WHERE   VCT.SEPARATOR_ID IS NOT NULL and vct.separator_id='" + devicename + "' ";
                    if (!includeAbondoned)
                    {
                        sql += "and vc.actual_status not like '%ABAN_%' ";
                    }
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + endDate + "' ";
                    }
                    sql += "group by VCT.conduit_name, vct.separator_id, vc.actual_status order by 2";
                    command.CommandText = sql;

                    DataSet ds = new DataSet();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(ds);
                    connection.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                return null;
            }
        }
        private DataTable GetTestData(string devicename, bool includeAbondoned, string startDate, string endDate)
        {
            if(String.IsNullOrEmpty(devicename))
                devicename="V-0516";
            string connectionString = GetOracleConnectionString();
            using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    try { connection.Close(); }
                    catch (Exception ex)
                    { }
                    connection.Open();

                    //Console.WriteLine("State: {0}", connection.State);
                    //Console.WriteLine("ConnectionString: {0}",
                    //                  connection.ConnectionString);

                    OracleCommand command = connection.CreateCommand();
                    string sql = "select vct.* from v_conduit_test vct inner join v_conduit vc on VCT.CONDUIT_NAME=VC.CONDUIT_NAME where VCT.SEPARATOR_ID IS NOT NULL and vct.separator_id='" + devicename + "' and vct.validity_status='valid test' ";
                    if (!includeAbondoned)
                    {
                        sql += "and vc.actual_status not like '%ABAN_%' ";
                    }
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + endDate + "' ";
                    }
                    sql += "order by 2";
                    command.CommandText = sql;

                    DataSet ds = new DataSet();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(ds);
                    connection.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                return null;
            }
        }

        private DataTable GetConduitDeviceData(string devicename, bool includeAbondoned, string startDate, string endDate)
        {
            if (String.IsNullOrEmpty(devicename))
                devicename = "V-0516";
            string connectionString = GetOracleConnectionString();
            using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    try { connection.Close(); }
                    catch (Exception ex)
                    { }
                    connection.Open();

                    //Console.WriteLine("State: {0}", connection.State);
                    //Console.WriteLine("ConnectionString: {0}",
                    //                  connection.ConnectionString);

                    OracleCommand command = connection.CreateCommand();
                    string sql = "select count(*) total, extract(month from start_Date) AS monthname,extract(year from start_Date)as yearname from v_Conduit_test where separator_id='" + devicename + "' and validity_Status = 'valid test' ";
                    /*if (!includeAbondoned)
                    {
                        sql += "and vc.actual_status not like '%ABAN_%' ";
                    }*/
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and start_date >= '" + startDate + "' and end_date <= '" + endDate + "' ";
                    }
                    sql += " group by extract(month from start_date),extract(year from start_Date) order by 3";
                    //sql += "order by 2";
                    command.CommandText = sql;

                    DataSet ds = new DataSet();
                    OracleDataAdapter adapter = new OracleDataAdapter(command);
                    adapter.Fill(ds);
                    connection.Close();
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                return null;
            }
        }
        protected void BindOnlyGrid(DataTable dt)
        { gvWellTestDataRad.DataSource = dt; }
        protected void BindGridView(DataTable dt)
        {
            BindOnlyGrid(dt);
            double valid = 0;
            double invalid = 0;
            double notValidated = 0;
            double validPer = 0;
            double invalidPer = 0;
            double notValidatedPer = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                valid += int.Parse(dt.Rows[i]["Valid"].ToString());
                invalid += int.Parse(dt.Rows[i]["InValid"].ToString());
                notValidated += int.Parse(dt.Rows[i]["NotValidated"].ToString());
            }
            if (invalid != 0 || notValidated != 0)
                validPer = (valid / (valid +invalid + notValidated)) * 100;
            if (valid != 0 || notValidated != 0)
                invalidPer = (invalid / (valid + invalid + notValidated)) * 100;
            if (valid != 0 || invalid != 0)
                notValidatedPer = (notValidated / (valid + invalid + notValidated)) * 100;
            CreatePiChart(int.Parse(Math.Round(validPer).ToString()),int.Parse(Math.Round(invalidPer).ToString()),int.Parse(Math.Round(notValidatedPer).ToString()));
            fillMinMaxTable(dt);
            fillConduitDeviceData();
        }
        void fillMinMaxTable(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                #region bsw
                List<decimal> bswminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minbsw")).Distinct().ToList();
                minBSW.InnerHtml = bswminValues.Count > 0 ? bswminValues.Min().ToString() : "0";
                minNonBSW.InnerHtml = bswminValues.Count > 0 ? bswminValues.Where(x => x > 0).Min().ToString() : "0";
                maxBSW.InnerHtml = dt.Compute("max(maxbsw)", string.Empty).ToString();
                #endregion
                #region Gas
                List<decimal> GasminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minGasOut")).Distinct().ToList();
                minGas.InnerHtml = GasminValues.Min().ToString();
                minNonGas.InnerHtml = GasminValues.Where(x => x > 0).Min().ToString();
                maxGas.InnerHtml = dt.Compute("max(maxGasOut)", string.Empty).ToString();
                #endregion
                #region Oil
                List<decimal> OilminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minOil")).Distinct().ToList();
                minOil.InnerHtml = OilminValues.Min().ToString();
                minNonOil.InnerHtml = OilminValues.Where(x => x > 0).Min().ToString();
                maxOil.InnerHtml = dt.Compute("max(maxOil)", string.Empty).ToString();
                #endregion
                #region Water
                List<decimal> WaterminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minWater")).Distinct().ToList();
                minWater.InnerHtml = WaterminValues.Min().ToString();
                minNonWater.InnerHtml = WaterminValues.Where(x => x > 0).Min().ToString();
                maxWater.InnerHtml = dt.Compute("max(maxWater)", string.Empty).ToString();
                #endregion
            }
            else
            {
                minBSW.InnerHtml = minNonBSW.InnerHtml = maxBSW.InnerHtml = minGas.InnerHtml = minNonGas.InnerHtml = maxGas.InnerHtml = minOil.InnerHtml = minNonOil.InnerHtml = maxOil.InnerHtml = minWater.InnerHtml = minNonWater.InnerHtml = maxWater.InnerHtml = "";
            }

        }

        void fillConduitDeviceData()
        {
            DataTable dt = GetConduitDeviceData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dateTime = new DateTime(Convert.ToInt32(dt.Rows[i]["yearname"].ToString()),Convert.ToInt32(dt.Rows[i]["monthname"].ToString()),1);
                chartDeviceConduit.Series[0].Points.AddXY(dateTime.ToString("Y"), double.Parse(dt.Rows[i]["total"].ToString()));
            }
        }
        protected void RebindGrid(object sender, EventArgs e)
        {
            DataTable dt = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            BindGridView(dt);
            gvWellTestDataRad.Rebind();
            CreateScaterChart(GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                BindGridView(dt);
                gvWellTestDataRad.Rebind();
                CreateScaterChart(GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
            }
            catch (Exception exc)
            {
                
            }
        }
        protected void rbtnAbondonWell_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebindGrid(null, null);
        }

        private void CreatePiChart(int valid, int invalid, int notValidated)
        {
    Chart1.Series["Series1"].Points.AddY(valid);
    Chart1.Series["Series1"].Points[0].Color = System.Drawing.Color.Green;
    Chart1.Series["Series1"].Points[0].LegendText = "Valid";
    Chart1.Series["Series1"].Points.AddY(invalid);
    Chart1.Series["Series1"].Points[1].LegendText = "Invalid";
    Chart1.Series["Series1"].Points[1].Color = System.Drawing.Color.Red;
    Chart1.Series["Series1"].Points.AddY(notValidated);
    Chart1.Series["Series1"].Points[2].LegendText = "Not Validated";
Chart1.Series["Series1"]["PointWidth"] = "0.5";// Show data points labels
Chart1.Series["Series1"].IsValueShownAsLabel = true;// Set data points label style
Chart1.Series["Series1"]["PieLabelStyle"] = "Outside";
Chart1.Series["Series1"]["PieLineColor"] = "Orange";
Chart1.Series["Series1"]["PieLabelColor"] = "Orange";
Chart1.Series["Series1"]["BarLabelStyle"] = "Center";// Show chart as 3D
Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;// Draw chart as 3D Cylinder
Chart1.Series["Series1"]["DrawingStyle"] = "Cylinder";
        }
        void CreateScaterChart(DataTable dt)
        {
            double gvf, gasAtOC, gasOut, separatorPressure, separatorTemperature, liquid, oil, water, bsw=0;
            decimal temp = 0;
            DateTime dtTemp = DateTime.Now;
            DateTime minDate = DateTime.Now;
            DateTime maxDate = DateTime.Now.AddDays(-1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gasOut = string.IsNullOrEmpty(dt.Rows[i]["GAS_OUT"].ToString()) || !decimal.TryParse(dt.Rows[i]["GAS_OUT"].ToString(), out temp) || double.Parse(dt.Rows[i]["GAS_OUT"].ToString())<=0 ? 0 : double.Parse(dt.Rows[i]["GAS_OUT"].ToString());
                separatorPressure = string.IsNullOrEmpty(dt.Rows[i]["Separator_Pressure"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Pressure"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Pressure"].ToString()) <= 0 ? 202.6 : double.Parse(dt.Rows[i]["Separator_Pressure"].ToString());
                separatorTemperature = string.IsNullOrEmpty(dt.Rows[i]["Separator_Temperature"].ToString()) || !decimal.TryParse(dt.Rows[i]["Separator_Temperature"].ToString(), out temp) || double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) <= 0 ? 35 + 273.16 : double.Parse(dt.Rows[i]["Separator_Temperature"].ToString()) + 273.16;
                oil = string.IsNullOrEmpty(dt.Rows[i]["OIL"].ToString()) || !decimal.TryParse(dt.Rows[i]["OIL"].ToString(), out temp) || double.Parse(dt.Rows[i]["OIL"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["OIL"].ToString());
                water = string.IsNullOrEmpty(dt.Rows[i]["WATER"].ToString()) || !decimal.TryParse(dt.Rows[i]["WATER"].ToString(), out temp) || double.Parse(dt.Rows[i]["WATER"].ToString()) <= 0 ? 0 : double.Parse(dt.Rows[i]["WATER"].ToString());
                liquid = oil + water;
                gasAtOC = (gasOut * 101.3 * separatorTemperature) / ((15 + 273.16) * separatorPressure);
                gvf = (gasAtOC / (gasAtOC + liquid)) * 100;
                bsw = string.IsNullOrEmpty(dt.Rows[i]["BSW"].ToString()) ? 0 : double.Parse(dt.Rows[i]["BSW"].ToString());
                if (decimal.TryParse(bsw.ToString(), out temp) && decimal.TryParse(oil.ToString(), out temp) && decimal.TryParse(gvf.ToString(), out temp) && bsw<=100)
                {
                    scaterChart.Series[0].Points.AddXY(Math.Round(gvf), bsw);
                    scaterChart.Series[1].Points.AddXY(Math.Round(gvf), oil);
                }
                if (!string.IsNullOrEmpty(dt.Rows[i]["start_date"].ToString()) && DateTime.TryParse(dt.Rows[i]["start_date"].ToString(), out dtTemp))
                {
                    if (i == 0)
                    {
                        minDate = dtTemp;
                        maxDate = dtTemp;
                    }
                    if (dtTemp < minDate)
                        minDate = dtTemp;
                    if(dtTemp>maxDate)
                        maxDate=dtTemp;
                    chartGVFTrend.Series[0].Points.AddXY(dtTemp.Date, gvf);
                    chartOilTrend.Series[0].Points.AddXY(dtTemp.Date, oil);
                    chartBSWTrend.Series[0].Points.AddXY(dtTemp.Date, bsw);
                    /*if (decimal.TryParse(bsw.ToString(), out temp))
                        chart2.Series[0].Points.AddXY(dtTemp.Date, bsw);*/
                    chartGasOutTrend.Series[0].Points.AddXY(dtTemp, gasOut);
                }
 
            }
            /*chartGVFTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGVFTrend.Series["GVFSeries"], chartGVFTrend.Series["TrendLine"]);
            chartOilTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartOilTrend.Series["OilSeries"], chartOilTrend.Series["TrendLine"]);
            chartBSWTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartBSWTrend.Series["BSWSeries"], chartBSWTrend.Series["TrendLine"]);
            chartGasOutTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGasOutTrend.Series["GasOutSeries"], chartGasOutTrend.Series["TrendLine"]);*/
            try
            {
                chartGVFTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGVFTrend.Series["GVFSeries"], chartGVFTrend.Series["TrendLine"]);
                chartOilTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartOilTrend.Series["OilSeries"], chartOilTrend.Series["TrendLine"]);
                chartBSWTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartBSWTrend.Series["BSWSeries"], chartBSWTrend.Series["TrendLine"]);
                chartGasOutTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGasOutTrend.Series["GasOutSeries"], chartGasOutTrend.Series["TrendLine"]);
            }
            catch (Exception ex)
            {
                
            }
            //chart2.DataManipulator.FinancialFormula(FinancialFormula.RateOfChange, "10", chart2.Series["BSWSeries"], chart2.Series["TrendLine"]);
        }
        protected void gvWellTestDataRad_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
        }
    }
}