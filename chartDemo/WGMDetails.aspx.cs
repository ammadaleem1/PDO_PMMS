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
using System.Configuration;
using chartDemo.XHQService;

namespace chartDemo
{
   
    public partial class WGMDetails : System.Web.UI.Page
    {
        public string deviceName { get { return string.IsNullOrEmpty(Request.QueryString["DeviceName"]) ? "KAU001" : Request.QueryString["DeviceName"]; } set { } }
        public class Pi
        {
            //public int id { get; set; }
            public DateTime time { get; set; }
            public string value { get; set; }
            public string tag { get; set; }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            DateTime dtStart = !string.IsNullOrEmpty(Request.Form["txtStartDate"]) ? Convert.ToDateTime(Request.Form["txtStartDate"]) : DateTime.Now.AddMonths(-1);
            DateTime dtEnd = !string.IsNullOrEmpty(Request.Form["txtEndDate"]) ? Convert.ToDateTime(Request.Form["txtEndDate"]) : DateTime.Now;
            switch (chartType.Value)
            {
                case "actualPI":
                    gvExport.DataSource = ConnectAndQuery(deviceName, true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "PIActual";
                    break;
                case "aggregatePI":
                    gvExport.DataSource = getPIChartAggregateData();
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "PIChartAggregate";
                    break;
                case "monthly":
                    gvExport.DataSource = GetConduitDeviceData(Request.QueryString["DeviceName"], true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "MonthlyStats";
                    break;
                case "aggregateGasProd":
                    gvExport.DataSource = getPITrendInst(getPITag("gasProd"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "GasProd";
                    break;
                case "aggregateCondProd":
                    gvExport.DataSource = getPITrendInst(getPITag("condProd"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "CondProd";
                    break;
                case "aggregateWaterProd":
                    gvExport.DataSource = getPITrendInst(getPITag("waterProd"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "WaterProd";
                    break;
                case "aggregateWetGasProd":
                    gvExport.DataSource = getPITrendInst(getPITag("wetGasProd"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "WetGasProd";
                    break;
                case "aggregateGasTotal":
                    gvExport.DataSource = getPITrendInst(getPITag("gasTotal"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "GasTotal";
                    break;
                case "aggregateCondTotal":
                    gvExport.DataSource = getPITrendInst(getPITag("condTotal"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "CondTotal";
                    break;
                case "aggregateWaterTotal":
                    gvExport.DataSource = getPITrendInst(getPITag("waterTotal"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "WaterTotal";
                    break;
                case "aggregateWetGasTotal":
                    gvExport.DataSource = getPITrendInst(getPITag("wetGasTotal"), dtStart, dtEnd);
                    gvExport.DataBind();
                    gvExport.ExportSettings.FileName = "WetGasTotal";
                    break;
            }
            gvExport.ExportSettings.IgnorePaging = true;
            gvExport.ExportSettings.ExportOnlyData = true;
            gvExport.ExportSettings.OpenInNewWindow = true;
            gvExport.MasterTableView.ExportToExcel();
        }
        DataTable getPIChartAggregateData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("Valid"), new DataColumn("InValid"), new DataColumn("NotValidated") });
            DataTable dtPiChart = ConnectAndQuery(deviceName, true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
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
        DataTable getPITrendInst(string PITag, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("DateTime"), new DataColumn("Value") });
            string temp = "";
            List<Pi> PiList = getPiData(PITag, startDate, endDate, out temp);
            foreach (Pi pi in PiList)
            {
                DataRow dr = dt.NewRow();
                dr["DateTime"] = pi.time.ToString();
                dr["Value"] = pi.value.ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        string getPITag(string key)
        {
            string piTag = "";
            string sql = "select * from WGMPITags where Well_No ='" + deviceName + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            DataRow dr = dt.NewRow();
            if (dt.Rows.Count > 0)
            {
                switch (key)
                {
                    case "gasProd":
                        dr = dt.Select("Key='DGIFLOW'").FirstOrDefault();
                        break;
                    case "condProd":
                        dr = dt.Select("Key='CONDIFLOW'").FirstOrDefault();
                        break;
                    case "waterProd":
                        dr = dt.Select("Key='WTRIFLOW'").FirstOrDefault();
                        break;
                    case "wetGasProd":
                        dr = dt.Select("Key='WGIFLOW'").FirstOrDefault();
                        break;
                    case "gasTotal":
                        dr = dt.Select("Key='DGQFLOW'").FirstOrDefault();
                        break;
                    case "condTotal":
                        dr = dt.Select("Key='CONDQFLOW'").FirstOrDefault();
                        break;
                    case "waterTotal":
                        dr = dt.Select("Key='WTRQFLOW'").FirstOrDefault();
                        break;
                    case "wetGasTotal":
                        dr = dt.Select("Key='WGQFLOW'").FirstOrDefault();
                        break;
                }
                if (dr != null)
                    piTag = dr["PI_Tag"].ToString();
            }
            return piTag;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                //string deviceName = string.IsNullOrEmpty(Request.QueryString["DeviceName"]) ? "KAU001" : Request.QueryString["DeviceName"];
                //CalendarExtender1.SelectedDate = dt.AddDays(-1);
                //CalendarExtender2.SelectedDate = dt;
                try
                {
                    BindGridView(ConnectAndQuery(deviceName, true, "", ""),deviceName);
                    CreateScaterChart(GetTestData(deviceName, true, "", ""));
                    CreateTrends(deviceName);
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
        private void CreateTrends(string deviceName)
        {
            DateTime startdate, enddate = new DateTime();
            startdate = DateTime.Now.AddMonths(-1);
            //startdate = DateTime.Now.AddDays(-7);
            enddate = DateTime.Now;
            string sql = "select * from WGMPITags where Well_No ='" + deviceName + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                #region instantaneous
                #region GasProd
                string GasProdTag = "";
                DataRow drGasProd = dt.Select("Key='DGIFLOW'").FirstOrDefault();
                if (drGasProd != null)
                    GasProdTag = drGasProd["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(GasProdTag))
                {
                    showPITrendInst(GasProdTag, startdate, enddate, "DGIFLOW");
                }
                #endregion
                #region ConProd
                string ConProdTag = "";
                DataRow drConProd = dt.Select("Key='CONDIFLOW'").FirstOrDefault();
                if (drConProd != null)
                    ConProdTag = drConProd["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(ConProdTag))
                {
                    showPITrendInst(ConProdTag, startdate, enddate, "CONDIFLOW");
                }
                #endregion
                #region WaterProd
                string WaterProdTag = "";
                DataRow drWaterProd = dt.Select("Key='WTRIFLOW'").FirstOrDefault();
                if (drWaterProd != null)
                    WaterProdTag = drWaterProd["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(WaterProdTag))
                {
                    showPITrendInst(WaterProdTag, startdate, enddate, "WTRIFLOW");
                }
                #endregion
                #region WetGasProd
                string WetGasProdTag = "";
                DataRow drWetGasProd = dt.Select("Key='WGIFLOW'").FirstOrDefault();
                if (drWetGasProd != null)
                    WetGasProdTag = drWetGasProd["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(WetGasProdTag))
                {
                    showPITrendInst(WetGasProdTag, startdate, enddate, "WGIFLOW");
                }
                #endregion

                #endregion
                #region totalizers
                #region GasTotal
                string GasTotalTag = "";
                DataRow drGasTotal = dt.Select("Key='DGQFLOW'").FirstOrDefault();
                if (drGasTotal != null)
                    GasTotalTag = drGasTotal["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(GasTotalTag))
                {
                    showPITrendTotal(GasTotalTag, startdate, enddate, "DGQFLOW");
                }
                #endregion
                #region ConTotal
                string ConTotalTag = "";
                DataRow drConTotal = dt.Select("Key='CONDQFLOW'").FirstOrDefault();
                if (drConTotal != null)
                    ConTotalTag = drConTotal["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(ConTotalTag))
                {
                    showPITrendTotal(ConTotalTag, startdate, enddate, "CONDQFLOW");
                }
                #endregion
                #region WaterTotal
                string WaterTotalTag = "";
                DataRow drWaterTotal = dt.Select("Key='WTRQFLOW'").FirstOrDefault();
                if (drWaterTotal != null)
                    WaterTotalTag = drWaterTotal["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(WaterTotalTag))
                {
                    showPITrendTotal(WaterTotalTag, startdate, enddate, "WTRQFLOW");
                }
                #endregion
                #region WetGasTotal
                string WetGasTotalTag = "";
                DataRow drWetGasTotal = dt.Select("Key='WGQFLOW'").FirstOrDefault();
                if (drWetGasTotal != null)
                    WetGasTotalTag = drWetGasTotal["PI_Tag"].ToString();
                if (!string.IsNullOrEmpty(WetGasTotalTag))
                {
                    showPITrendTotal(WetGasTotalTag, startdate, enddate, "WGQFLOW");
                }
                #endregion

                #endregion
            }
        }
        public void showPITrendInst(string PITag, DateTime startDate, DateTime endDate,string key)
        {
            string temp = "";
            List<Pi> PiList = getPiData(PITag, startDate, endDate, out temp);
            foreach (Pi pi in PiList)
            {
                switch(key)
                {
                    case "DGIFLOW":
                        {
                            chartGasInst.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "CONDIFLOW":
                        {
                            chartConInst.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "WTRIFLOW":
                        {
                            chartWaterInst.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "WGIFLOW":
                        {
                            chartWetGasInst.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "DGQFLOW":
                        {
                            chartGasTot.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "CONDQFLOW":
                        {
                            chartConTot.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "WTRQFLOW":
                        {
                            chartWaterTotal.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    case "WGQFLOW":
                        {
                            chartWetGasTotal.Series[0].Points.AddXY(pi.time, pi.value);
                            break;
                        }
                    default:
                        { break; }
                }
            }
        }
        public void showPITrendTotal(string PITag, DateTime startDate, DateTime endDate, string key)
        {
            string temp = "";
            List<Pi> PiList = getPiData(PITag, startDate, endDate, out temp);
            //PiList = PiList.GroupBy(date => date.time.Date)
            //          .Select(grp => grp.Max(date => date.time.TimeOfDay)).ToList<Pi>();
            //PiList.GroupBy(dt => dt.time).Select(g => g.Max());
            PiList = PiList.GroupBy(x => x.time.Date)
        .Select(group => group.Where(x => x.time.Hour > 14 && !string.IsNullOrEmpty(x.time.ToString()) && x != null)
                              .FirstOrDefault()).ToList();//.OrderBy(y=>y.time).ToList();
            //PiList = PiList.RemoveAll(PiList.Select(x => !string.IsNullOrEmpty(x.time.ToString())).ToList());
            //PiList = PiList.Remove(x => string.IsNullOrEmpty(x.time.ToString()));
            PiList = PiList.Where(x => x != null).ToList();
            try
            {
                foreach (Pi pi in PiList)
                {
                    switch (key)
                    {
                        case "DGIFLOW":
                            {
                                chartGasInst.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "CONDIFLOW":
                            {
                                chartConInst.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "WTRIFLOW":
                            {
                                chartWaterInst.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "WGIFLOW":
                            {
                                chartWetGasInst.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "DGQFLOW":
                            {
                                chartGasTot.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "CONDQFLOW":
                            {
                                chartConTot.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "WTRQFLOW":
                            {
                                chartWaterTotal.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        case "WGQFLOW":
                            {
                                chartWetGasTotal.Series[0].Points.AddXY(pi.time, pi.value);
                                break;
                            }
                        default:
                            { break; }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        List<Pi> getPiData(string tagName, DateTime StartDate, DateTime EndDate, out string unit)
        {
            PISDK.PISDK sdk = new PISDK.PISDK();
            string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
            string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
            Server srv = sdk.Servers[piServer];
            srv.Open(piCredentials);
            string nameConcat = "";
            int i = 0;
            PISDK.PIPoints myPoints = srv.PIPoints;
            PointList list = srv.GetPoints("tag = '*" + tagName + "*'");
            int count = list.Count;
            PIData data = list[1].Data;
            unit = list[1].PointAttributes["EngUnits"].Value.ToString();
            PIValues values;
            List<string> stringValues = new List<string>();
            List<DateTime> timeValues = new List<DateTime>();
            List<Pi> piData = new List<Pi>();
            try
            {
                values = data.RecordedValues(StartDate, EndDate);
                foreach (PIValue value in values)
                {
                    try
                    {
                        if (value.Value.GetType().IsCOMObject)
                        {
                            stringValues.Add((value.Value as DigitalState).Name.ToString());
                            PITimeServer.PITime pt = value.TimeStamp;
                        }
                        else
                        {

                            stringValues.Add((value.Value).ToString());
                            Pi p = new Pi();
                            p.time = value.TimeStamp.LocalDate;
                            p.value = Convert.ToString(value.Value);
                            p.tag = tagName;
                            piData.Add(p);
                        }

                    }
                    catch (Exception ex)
                    { //throw ex; 
                    }
                }
            }
            catch (Exception ex)
            { }
            return piData;
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
"vct.conduit_name," +
"count(*) TotalTests, " +
"CASE vc.actual_status " +
    "WHEN 'ABAN_01'    THEN 0    WHEN 'ABAN_02'    THEN 0    WHEN 'ABAN_03'    THEN 0    WHEN 'ABAN_04'    THEN 0    ELSE 1  END iconduitstatus," +
"sum(case when VALIDITY_STATUS='valid test' then 1 else 0 end) Valid, " +
"sum(case when VALIDITY_STATUS='invalid test' then 1 else 0 end) InValid," +
"sum(case when VALIDITY_STATUS='valid test' then 0 when VALIDITY_STATUS= 'invalid test' then 0 else 1 end) NotValidated " +
//"(select NVL(min(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minwater," +
//"(select NVL(max(water),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxwater," +
//"(select NVL(min(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minoil," +
//"(select NVL(max(oil),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxoil," +
//"(select NVL(min(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") minbsw," +
//"(select NVL(max(bsw),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxbsw," +
//"(select NVL(min(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") mingasout," +
//"(select NVL(max(gas_out),0) from V_Conduit_Test t where t.separator_id=vct.separator_id and t.conduit_name=vct.conduit_name  and t.validity_status = 'valid test'" + sqlDateFilter + ") maxgasout " +
"FROM  V_CONDUIT_TEST VCT INNER JOIN V_CONDUIT VC ON   VCT.CONDUIT_NAME=VC.CONDUIT_NAME " +
"WHERE formation_gas is not null and formation_gas > 0 and vct.conduit_name='" + devicename + "' ";
                    if (!includeAbondoned)
                    {
                        sql += "and vc.actual_status not like '%ABAN_%' ";
                    }
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and vct.start_date >= '" + startDate + "' and vct.start_date <= '" + endDate + "' ";
                        //sql += "and vct.start_date >= '" + startDate + "'";
                    }
                    sql += "group by VCT.conduit_name, vc.actual_status order by 2";
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
                        sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + startDate + "' ";
                        //sql += "and vct.start_date >= '" + startDate + "' ";
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
                    string sql = "select count(*) total, extract(month from start_Date) AS monthname,extract(year from start_Date)as yearname from v_Conduit_test where conduit_name='" + devicename + "' and validity_Status = 'valid test' and formation_gas is not null and formation_gas > 0 ";
                    /*if (!includeAbondoned)
                    {
                        sql += "and vc.actual_status not like '%ABAN_%' ";
                    }*/
                    if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        sql += "and start_date >= '" + startDate + "' and start_date <= '" + endDate + "' ";
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
        { //gvWellTestDataRad.DataSource = dt; 
        }
        protected void BindGridView(DataTable dt, string deviceName)
        {
            //BindOnlyGrid(dt);
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
            if (invalid != 0 || notValidated != 0 || valid != 0)
                validPer = (valid / (valid +invalid + notValidated)) * 100;
            if (valid != 0 || notValidated != 0 || invalid != 0)
                invalidPer = (invalid / (valid + invalid + notValidated)) * 100;
            if (valid != 0 || invalid != 0 || notValidated != 0)
                notValidatedPer = (notValidated / (valid + invalid + notValidated)) * 100;
            CreatePiChart(int.Parse(Math.Round(validPer).ToString()),int.Parse(Math.Round(invalidPer).ToString()),int.Parse(Math.Round(notValidatedPer).ToString()));
            //fillMinMaxTable(dt);
            fillConduitDeviceData(deviceName);
        }
        void fillMinMaxTable(DataTable dt)
        {
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    #region bsw
            //    List<decimal> bswminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minbsw")).Distinct().ToList();
            //    minBSW.InnerHtml = bswminValues.Count > 0 ? bswminValues.Min().ToString() : "0";
            //    minNonBSW.InnerHtml = bswminValues.Count > 0 ? bswminValues.Where(x => x > 0).Min().ToString() : "0";
            //    maxBSW.InnerHtml = dt.Compute("max(maxbsw)", string.Empty).ToString();
            //    #endregion
            //    #region Gas
            //    List<decimal> GasminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minGasOut")).Distinct().ToList();
            //    minGas.InnerHtml = GasminValues.Min().ToString();
            //    minNonGas.InnerHtml = GasminValues.Where(x => x > 0).Min().ToString();
            //    maxGas.InnerHtml = dt.Compute("max(maxGasOut)", string.Empty).ToString();
            //    #endregion
            //    #region Oil
            //    List<decimal> OilminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minOil")).Distinct().ToList();
            //    minOil.InnerHtml = OilminValues.Min().ToString();
            //    minNonOil.InnerHtml = OilminValues.Where(x => x > 0).Min().ToString();
            //    maxOil.InnerHtml = dt.Compute("max(maxOil)", string.Empty).ToString();
            //    #endregion
            //    #region Water
            //    List<decimal> WaterminValues = dt.AsEnumerable().Select(al => al.Field<decimal>("minWater")).Distinct().ToList();
            //    minWater.InnerHtml = WaterminValues.Min().ToString();
            //    minNonWater.InnerHtml = WaterminValues.Where(x => x > 0).Min().ToString();
            //    maxWater.InnerHtml = dt.Compute("max(maxWater)", string.Empty).ToString();
            //    #endregion
            //}
            //else
            //{
            //    minBSW.InnerHtml = minNonBSW.InnerHtml = maxBSW.InnerHtml = minGas.InnerHtml = minNonGas.InnerHtml = maxGas.InnerHtml = minOil.InnerHtml = minNonOil.InnerHtml = maxOil.InnerHtml = minWater.InnerHtml = minNonWater.InnerHtml = maxWater.InnerHtml = "";
            //}

        }

        void fillConduitDeviceData(string deviceName)
        {
            DataTable dt = GetConduitDeviceData(deviceName, true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime dateTime = new DateTime(Convert.ToInt32(dt.Rows[i]["yearname"].ToString()),Convert.ToInt32(dt.Rows[i]["monthname"].ToString()),1);
                chartDeviceConduit.Series[0].Points.AddXY(dateTime.ToString("Y"), double.Parse(dt.Rows[i]["total"].ToString()));
            }
        }
        protected void RebindGrid(object sender, EventArgs e)
        {
           /* DataTable dt = ConnectAndQuery(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
            BindGridView(dt);
           // gvWellTestDataRad.Rebind();
            CreateScaterChart(GetTestData(Request.QueryString["DeviceName"], bool.Parse(rbtnAbondonWell.SelectedValue), Request.Form["txtStartDate"], Request.Form["txtEndDate"]));*/
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //string deviceName = string.IsNullOrEmpty(Request.QueryString["DeviceName"]) ? "KAU001" : Request.QueryString["DeviceName"];
                DataTable dt = ConnectAndQuery(deviceName, true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
                BindGridView(dt, deviceName);
                //CreateScaterChart(GetTestData(deviceName, true, "", ""));
                CreateTrends(deviceName);
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
           
 
            
            /*chartGVFTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGVFTrend.Series["GVFSeries"], chartGVFTrend.Series["TrendLine"]);
            chartOilTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartOilTrend.Series["OilSeries"], chartOilTrend.Series["TrendLine"]);
            chartBSWTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartBSWTrend.Series["BSWSeries"], chartBSWTrend.Series["TrendLine"]);
            chartGasOutTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2," + (maxDate - minDate).Days + ",false,false", chartGasOutTrend.Series["GasOutSeries"], chartGasOutTrend.Series["TrendLine"]);*/
            try
            {
               /* chartGVFTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGVFTrend.Series["GVFSeries"], chartGVFTrend.Series["TrendLine"]);
                chartOilTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartOilTrend.Series["OilSeries"], chartOilTrend.Series["TrendLine"]);
                chartBSWTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartBSWTrend.Series["BSWSeries"], chartBSWTrend.Series["TrendLine"]);
                chartGasOutTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGasOutTrend.Series["GasOutSeries"], chartGasOutTrend.Series["TrendLine"]);*/
            }
            catch (Exception ex)
            {
                
            }
            //chart2.DataManipulator.FinancialFormula(FinancialFormula.RateOfChange, "10", chart2.Series["BSWSeries"], chart2.Series["TrendLine"]);
        }
       /* protected void gvWellTestDataRad_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }

        protected void gvWellTestDataRad_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            BindGridView(ConnectAndQuery(Request.QueryString["DeviceName"], true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]));
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = ConnectAndQuery(Request.QueryString["DeviceName"], true, Request.Form["txtStartDate"], Request.Form["txtEndDate"]);
        }*/
    }
}