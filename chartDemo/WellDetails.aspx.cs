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

namespace chartDemo
{

    public partial class WellDetails : System.Web.UI.Page
    {
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
        protected void btn_Click(object sender, EventArgs e)//aggregatePI
        {
            //Button btn = (Button)sender;
            switch (chartType.Value)
            {
                case "deviceExport":
                    gvWellTestDeviceDataRad.ExportSettings.IgnorePaging = true;
                    gvWellTestDeviceDataRad.ExportSettings.ExportOnlyData = true;
                    gvWellTestDeviceDataRad.ExportSettings.OpenInNewWindow = true;
                    gvWellTestDeviceDataRad.MasterTableView.ExportToExcel();
                    break;
                case "wellExport":
                    gvWellTestDataRad.ExportSettings.IgnorePaging = true;
                    gvWellTestDataRad.ExportSettings.ExportOnlyData = true;
                    gvWellTestDataRad.ExportSettings.OpenInNewWindow = true;
                    gvWellTestDataRad.MasterTableView.ExportToExcel();
                    break;
                case "actualPI":
                    gvExport.DataSource = GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    export("PIChartActual");
                    break;
                case "aggregatePI":
                    gvExport.DataSource = getPIChartAggregateData();
                    gvExport.DataBind();
                    export("PIChartAggregate");
                    break;
                case "monthly":
                    gvExport.DataSource = GetConduitDeviceData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    export("MonthlyStats");
                    break;
                case "actualScater":
                    gvExport.DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    export("ScaterActual");
                    break;
                case "aggregateScater":
                    gvExport.DataSource = CreateScaterChartDataTable(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
                    gvExport.DataBind();
                    export("ScaterAggregate");
                    break;
                case "actualGVF":
                    gvExport.DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    export("GVFActual");
                    break;
                case "aggregateGVF":
                    DataTable dtGVF = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtGVF,"gvf");
                    gvExport.DataBind();
                    export("GVFAggregate");
                    break;
                case "actualOil":
                    gvExport.DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "OilActual";
                    gvExport.MasterTableView.ExportToExcel();
                    break;
                case "aggregateOil":
                    DataTable dtOil = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtOil,"oil");
                    gvExport.DataBind();
                    export("OilAggregate");
                    break;
                case "actualBSW":
                    gvExport.DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "BSWActual";
                    gvExport.MasterTableView.ExportToExcel();
                    break;
                case "aggregateBSW":
                    DataTable dtBSW = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtBSW,"bsw");
                    gvExport.DataBind();
                    export("BSWAggregate");
                    break;
                case "actualGas":
                    gvExport.DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "GasActual";
                    gvExport.MasterTableView.ExportToExcel();
                    break;
                case "aggregateGas":
                    DataTable dtGas = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataSource = CreateChartDataTable(dtGas,"gas");
                    gvExport.DataBind();
                    export("GasAggregate");
                    break;
            }
        }
        void export(string fileName)
        {
            gvExport.ExportSettings.IgnorePaging = true;
            gvExport.ExportSettings.ExportOnlyData = true;
            gvExport.ExportSettings.OpenInNewWindow = true;
            gvExport.ExportSettings.FileName = fileName;
            gvExport.MasterTableView.ExportToExcel();
        }
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
        DataTable getPIChartAggregateData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Valid"), new DataColumn("InValid"), new DataColumn("NotValidated") });
            DataTable dtPiChart = GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            double valid = 0; double invalid = 0; double notValidated = 0;
            for (int i = 0; i < dtPiChart.Rows.Count; i++)
            {
                valid += int.Parse(dtPiChart.Rows[i]["Valid"].ToString());
                invalid += int.Parse(dtPiChart.Rows[i]["InValid"].ToString());
                notValidated += int.Parse(dtPiChart.Rows[i]["NotValidated"].ToString());
            }
            DataRow dr = dt.NewRow();
            dr["Valid"] = valid; dr["InValid"] = invalid; dr["NotValidated"] = notValidated;
            dt.Rows.Add(dr);
            return dt;
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
                    DataTable dt2 = GetWellDataDeviceWise(Request.QueryString["WellName"], "", "");
                    BindGridViewWellDevice(dt2, dt2);
                    BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], "", ""));
                    /*CreateScaterChart(GetWellTestData(Request.QueryString["WellName"], "", ""));*/
                    fillConduitDeviceData("%");
                    lblWellName.Text = Request.QueryString["WellName"];
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
        protected void ddlDeviceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
            BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
            fillConduitDeviceData(ddlDeviceName.SelectedValue);
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        private DataTable GetWellDataDeviceWise(string wellname, string startDate, string endDate)
        {
            if(string.IsNullOrEmpty(wellname))
                wellname = "F315";
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
                    string sql = "select " +
"vct.separator_id,   vct.conduit_name," +
"count(*) TotalTests, " +
"CASE vc.actual_status " +
    "WHEN 'ABAN_01'    THEN 0    WHEN 'ABAN_02'    THEN 0    WHEN 'ABAN_03'    THEN 0    WHEN 'ABAN_04'    THEN 0    ELSE 1  END iconduitstatus," +
"sum(case when VALIDITY_STATUS='valid test' then 1 else 0 end) Valid, " +
"sum(case when VALIDITY_STATUS='invalid test' then 1 else 0 end) InValid," +
"sum(case when VALIDITY_STATUS='valid test' then 0 when VALIDITY_STATUS= 'invalid test' then 0 else 1 end) NotValidated, " +
"(select NVL(min(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minwater," +
"(select NVL(max(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxwater," +
"(select NVL(min(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minoil," +
"(select NVL(max(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxoil," +
"(select NVL(min(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minbsw," +
"(select NVL(max(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxbsw," +
"(select NVL(min(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') mingasout," +
"(select NVL(max(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxgasout " +
"FROM  V_CONDUIT_TEST VCT INNER JOIN V_CONDUIT VC ON   VCT.CONDUIT_NAME=VC.CONDUIT_NAME " +
"WHERE   VCT.SEPARATOR_ID IS NOT NULL and vct.conduit_name='" + wellname + "' ";
                    //if (!includeAbondoned)
                    //{
                    //    sql += "and vc.actual_status not like '%ABAN_%' ";
                    //}
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
        private DataTable GetPiChartData(string wellname, string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(wellname))
                wellname = "F315";
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
                    string sql = "select " +
"vct.separator_id,   vct.conduit_name," +
"count(*) TotalTests, " +
"CASE vc.actual_status " +
    "WHEN 'ABAN_01'    THEN 0    WHEN 'ABAN_02'    THEN 0    WHEN 'ABAN_03'    THEN 0    WHEN 'ABAN_04'    THEN 0    ELSE 1  END iconduitstatus," +
"sum(case when VALIDITY_STATUS='valid test' then 1 else 0 end) Valid, " +
"sum(case when VALIDITY_STATUS='invalid test' then 1 else 0 end) InValid," +
"sum(case when VALIDITY_STATUS='valid test' then 0 when VALIDITY_STATUS= 'invalid test' then 0 else 1 end) NotValidated, " +
"(select NVL(min(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minwater," +
"(select NVL(max(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxwater," +
"(select NVL(min(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minoil," +
"(select NVL(max(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxoil," +
"(select NVL(min(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') minbsw," +
"(select NVL(max(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxbsw," +
"(select NVL(min(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') mingasout," +
"(select NVL(max(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test') maxgasout " +
"FROM  V_CONDUIT_TEST VCT INNER JOIN V_CONDUIT VC ON   VCT.CONDUIT_NAME=VC.CONDUIT_NAME " +
"WHERE   VCT.SEPARATOR_ID IS NOT NULL and vct.conduit_name='" + wellname + "' ";
                    //if (!includeAbondoned)
                    //{
                    //    sql += "and vc.actual_status not like '%ABAN_%' ";
                    //}
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + endDate + "' ";
                    }
                    if (ddlDeviceName.SelectedValue != "%")
                        sql += "and vct.separator_id='" + ddlDeviceName.SelectedValue + "' ";
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
        private DataTable GetWellTestData(string devicename, string wellname, string startDate, string endDate)
        {
            if(string.IsNullOrEmpty(devicename))
                devicename="%";
            if (string.IsNullOrEmpty(wellname))
                wellname = "F315";
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
                    string sql = "select vct.separator_id,NVL(vct.water,0) as notNullWater,NVL(vct.oil,0) as notNullOil,NVL(vct.bsw,0) as notNullBSW,NVL(vct.gas_out,0) as notNullGasOut,vct.* from v_conduit_test vct inner join v_conduit vc on VCT.CONDUIT_NAME=VC.CONDUIT_NAME where VCT.SEPARATOR_ID IS NOT NULL and vct.separator_id like '" + devicename + "' and vct.conduit_name = '" + wellname + "' and vct.validity_status='valid test' ";
                    //if (!includeAbondoned)
                    //{
                    //    sql += "and vc.actual_status not like '%ABAN_%' ";
                    //}
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + endDate + "' ";
                    }
                    sql += " order by start_date";
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

        private DataTable GetConduitDeviceData(string devicename, string wellname, string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(devicename))
                devicename = "%";
            if (string.IsNullOrEmpty(wellname))
                wellname = "F315";
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
                    string sql = "select count(*) total, extract(month from start_Date) AS monthname,extract(year from start_Date)as yearname from v_Conduit_test where separator_id like '" + devicename + "' and conduit_name = '" + wellname +"' and validity_Status = 'valid test' ";
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
        void BindOnlyDeviceGridView(DataTable dt)
        { gvWellTestDeviceDataRad.DataSource = dt; gvWellTestDeviceDataRad.Rebind(); }
        protected void BindGridViewWellDevice(DataTable dt, DataTable dtPiChart)
        {
            //DataTable dt = getViewState();
            BindOnlyDeviceGridView(dt);
            if (ddlDeviceName.Items.Count < 2)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddlDeviceName.Items.Add(new ListItem(dt.Rows[i]["Separator_ID"].ToString(), dt.Rows[i]["Separator_ID"].ToString()));
                }
            }
            //ddlDeviceName.Items.Clear();
            //ddlDeviceName.DataSource = dt;
            //ddlDeviceName.DataTextField = "Separator_ID";
            //ddlDeviceName.DataValueField = "Separator_ID";
            //ddlDeviceName.DataBind();
            //ddlDeviceName.Items.Insert(0, new ListItem("%", "All"));


            double valid = 0;
            double invalid = 0;
            double notValidated = 0;
            double validPer = 0;
            double invalidPer = 0;
            double notValidatedPer = 0;
            for (int i = 0; i < dtPiChart.Rows.Count; i++)
            {
                valid += int.Parse(dtPiChart.Rows[i]["Valid"].ToString());
                invalid += int.Parse(dtPiChart.Rows[i]["InValid"].ToString());
                notValidated += int.Parse(dtPiChart.Rows[i]["NotValidated"].ToString());
            }
            if (invalid != 0 || notValidated != 0 || valid != 0)
            {
                validPer = (valid / (valid + invalid + notValidated)) * 100;
                invalidPer = (invalid / (valid + invalid + notValidated)) * 100;
                notValidatedPer = (notValidated / (valid + invalid + notValidated)) * 100;
            }
            CreatePiChart(int.Parse(Math.Round(validPer).ToString()),int.Parse(Math.Round(invalidPer).ToString()),int.Parse(Math.Round(notValidatedPer).ToString()));


          /*  fillMinMaxTable(dt);
            fillConduitDeviceData();*/
        }
        void BindOnlyTestGridView(DataTable dt)
        { gvWellTestDataRad.DataSource = dt; gvWellTestDataRad.Rebind(); }
        protected void BindGridViewWellTest(DataTable dt)
        {
            //DataTable dt = getViewState();
            BindOnlyTestGridView(dt);
            //double valid = 0;
            //double invalid = 0;
            //double notValidated = 0;
            //double validPer = 0;
            //double invalidPer = 0;
            //double notValidatedPer = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    valid += int.Parse(dt.Rows[i]["Valid"].ToString());
            //    invalid += int.Parse(dt.Rows[i]["InValid"].ToString());
            //    notValidated += int.Parse(dt.Rows[i]["NotValidated"].ToString());
            //}
            //if (invalid != 0 || notValidated != 0)
            //    validPer = (valid / (valid + invalid + notValidated)) * 100;
            //if (valid != 0 || notValidated != 0)
            //    invalidPer = (invalid / (valid + invalid + notValidated)) * 100;
            //if (valid != 0 || invalid != 0)
            //    notValidatedPer = (notValidated / (valid + invalid + notValidated)) * 100;
            //CreatePiChart(int.Parse(Math.Round(validPer).ToString()), int.Parse(Math.Round(invalidPer).ToString()), int.Parse(Math.Round(notValidatedPer).ToString()));
            fillMinMaxTable(dt);
            CreateScaterChart(dt);
        }
        void fillMinMaxTable(DataTable dt)
        {
           /* if (dt != null && dt.Rows.Count > 0)
            {
                #region bsw
                List<decimal> bswValues = dt.AsEnumerable().Select(al => al.Field<decimal>("notNullbsw")).Distinct().ToList();
                minBSW.InnerHtml = bswValues.Count > 0 ? bswValues.Min().ToString() : "0";
                minNonBSW.InnerHtml = bswValues.Count > 0 ? bswValues.Where(x => x > 0).Min().ToString() : "0";
                maxBSW.InnerHtml = bswValues.Max().ToString();
                #endregion
                #region Gas
                List<decimal> GasValues = dt.AsEnumerable().Select(al => al.Field<decimal>("notNullgasout")).Distinct().ToList();
                minGas.InnerHtml = GasValues.Min().ToString();
                minNonGas.InnerHtml = GasValues.Where(x => x > 0).Min().ToString();
                maxGas.InnerHtml = GasValues.Max().ToString();
                #endregion
                #region Oil
                List<decimal> OilValues = dt.AsEnumerable().Select(al => al.Field<decimal>("notNulloil")).Distinct().ToList();
                minOil.InnerHtml = OilValues.Min().ToString();
                minNonOil.InnerHtml = OilValues.Where(x => x > 0).Min().ToString();
                maxOil.InnerHtml = OilValues.Max().ToString();
                #endregion
                #region Water
                List<decimal> WaterValues = dt.AsEnumerable().Select(al => al.Field<decimal>("notNullWater")).Distinct().ToList();
                minWater.InnerHtml = WaterValues.Min().ToString();
                minNonWater.InnerHtml = WaterValues.Where(x => x > 0).Min().ToString();
                maxWater.InnerHtml = WaterValues.Max().ToString();
                #endregion
            }
            */
        }

        void fillConduitDeviceData(string devicename)
        {
            DataTable dt = GetConduitDeviceData(devicename, Request.QueryString["WellName"],  Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dateTime = new DateTime(Convert.ToInt32(dt.Rows[i]["yearname"].ToString()),Convert.ToInt32(dt.Rows[i]["monthname"].ToString()),1);
                chartDeviceConduit.Series[0].Points.AddXY(dateTime.ToString("Y"), double.Parse(dt.Rows[i]["total"].ToString()));
            }
            #region Pi Chart
            //double valid = 0;
            //double invalid = 0;
            //double notValidated = 0;
            //double validPer = 0;
            //double invalidPer = 0;
            //double notValidatedPer = 0;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    valid += int.Parse(dt.Rows[i]["Valid"].ToString());
            //    invalid += int.Parse(dt.Rows[i]["InValid"].ToString());
            //    notValidated += int.Parse(dt.Rows[i]["NotValidated"].ToString());
            //}
            //if (invalid != 0 || notValidated != 0)
            //    validPer = (valid / (valid + invalid + notValidated)) * 100;
            //if (valid != 0 || notValidated != 0)
            //    invalidPer = (invalid / (valid + invalid + notValidated)) * 100;
            //if (valid != 0 || invalid != 0)
            //    notValidatedPer = (notValidated / (valid + invalid + notValidated)) * 100;
            //CreatePiChart(int.Parse(Math.Round(validPer).ToString()), int.Parse(Math.Round(invalidPer).ToString()), int.Parse(Math.Round(notValidatedPer).ToString()));
            #endregion
        }
        protected void RebindGrid(object sender, EventArgs e)
        {

            BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
            CreateScaterChart(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"],  Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            /*DataTable dt = GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            BindGridViewWellDevice(dt);
            CreateScaterChart(GetWellTestData(hdnDeviceName.Value, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));*/
            try
            {
                BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
                BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
                fillConduitDeviceData(ddlDeviceName.SelectedValue);
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
            dt.DefaultView.Sort = "start_date";
            dt = dt.DefaultView.ToTable();
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
                //if (!string.IsNullOrEmpty(dt.Rows[i]["start_date"].ToString()) && DateTime.TryParse(dt.Rows[i]["start_date"].ToString(), out dtTemp))
                //{
                    if (i == 0)
                    {
                        minDate = dtTemp;
                        maxDate = dtTemp;
                    }
                    if (dtTemp < minDate)
                        minDate = dtTemp;
                    if(dtTemp>maxDate)
                        maxDate=dtTemp;
                    chartGVFTrend.Series[0].Points.AddXY(dt.Rows[i]["start_date"].ToString(), gvf);
                    chartOilTrend.Series[0].Points.AddXY(dt.Rows[i]["start_date"].ToString(), oil);
                    chartBSWTrend.Series[0].Points.AddXY(dt.Rows[i]["start_date"].ToString(), bsw);
                    /*if (decimal.TryParse(bsw.ToString(), out temp))
                        chart2.Series[0].Points.AddXY(dtTemp.Date, bsw);*/
                    chartGasOutTrend.Series[0].Points.AddXY(dt.Rows[i]["start_date"].ToString(), gasOut);
                //}
 
            }
            if (chartGVFTrend.Series["GVFSeries"].Points.Count > 2)
                chartGVFTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGVFTrend.Series["GVFSeries"], chartGVFTrend.Series["TrendLine"]);
            if (chartOilTrend.Series["OilSeries"].Points.Count > 2)
                chartOilTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartOilTrend.Series["OilSeries"], chartOilTrend.Series["TrendLine"]);
            if (chartBSWTrend.Series["BSWSeries"].Points.Count > 2)
                chartBSWTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartBSWTrend.Series["BSWSeries"], chartBSWTrend.Series["TrendLine"]);
            if (chartGasOutTrend.Series["GasOutSeries"].Points.Count > 2)
                chartGasOutTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGasOutTrend.Series["GasOutSeries"], chartGasOutTrend.Series["TrendLine"]);
            //chart2.DataManipulator.FinancialFormula(FinancialFormula.RateOfChange, "10", chart2.Series["BSWSeries"], chart2.Series["TrendLine"]);
        }
        protected void gvWellTestDeviceDataRad_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDeviceDataRad_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDeviceDataRad_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            BindGridViewWellDevice(GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]), GetPiChartData(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetWellDataDeviceWise(Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
        }


        protected void gvWellTestDataRad_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            BindGridViewWellTest(GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetWellTestData(ddlDeviceName.SelectedValue, Request.QueryString["WellName"], Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
        }
        protected void gvWellTestDataRad_ItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            //int ID = int.Parse(item.GetDataKeyValue("MaterialBalanceID").ToString());
            if (item != null)
            {
                Session["StartDate"] = item["start_date"].Text;
                Session["EndDate"] = item["end_date"].Text;
                openPopupWindow(item["separator_id"].Text);
            }
            gvWellTestDataRad.Rebind();
        }
        public void openPopupWindow(string devicename)
        {
            //string script = "openPopupWindow('" + devicename + "');";
            //if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert"))
            //{
           //     this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert", script, true /* addScriptTags */);
           // }
            RadAjaxManager1.ResponseScripts.Add("openPopupWindow('" + devicename + "');");
        }
    }
}