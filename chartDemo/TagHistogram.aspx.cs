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
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Globalization;

namespace chartDemo
{
    public partial class TagHistogram : System.Web.UI.Page
    {
        public class Pi
        {
            //public int id { get; set; }
            public DateTime time { get; set; }
            public string value { get; set; }
            public string tag { get; set; }
        }
        public class PIAttributesClass
        {
            public string Descriptor { get; set; }
            public string EngUnits { get; set; }
            public string Instrumenttag { get; set; }
            public string PITag { get; set; }
            public string PointType { get; set; }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        public void ShowChart()
        {
            string InstrumentTag = string.Empty;
            if (!string.IsNullOrEmpty(Request.QueryString["DeviceName"]))
                InstrumentTag = ddlInstrumnet.SelectedValue;
            else if (!string.IsNullOrEmpty(Request.QueryString["TagNumber"]))
                InstrumentTag = Request.QueryString["TagNumber"];
            else
                InstrumentTag = "95-FIC-0379";
            string sql = "select * from InstFuncHierarchy where Tag_No ='" + InstrumentTag +"'";
             ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            string PITag = "";
            if (dt.Rows.Count > 0)
            {
                PITag = dt.Rows[0]["PITag"].ToString();
                txtInstType.Text = dt.Rows[0]["Service"].ToString();
                if (!string.IsNullOrEmpty(PITag))
                {
                    DateTime startdate, enddate = new DateTime();
                    if (string.IsNullOrEmpty(Request.Form["txtStartDate"]))
                    {
                        startdate = CalendarExtender1.SelectedDate.Value;
                    }
                    else
                    {
                        startdate = DateTime.Parse(Request.Form["txtStartDate"]);
                        startdate = startdate.AddHours(int.Parse(ddlHoursStart.SelectedValue));
                        startdate = startdate.AddMinutes(int.Parse(ddlMinutesStart.SelectedValue));
                    }
                    if (string.IsNullOrEmpty(Request.Form["txtEndDate"]))
                    {
                        enddate = CalendarExtender2.SelectedDate.Value;
                    }
                    else
                    {
                        enddate = DateTime.Parse(Request.Form["txtEndDate"]);
                        enddate = enddate.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                        enddate = enddate.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
                    }
                    string unit = "";
                    List<Pi> PIData = getPiData(PITag, startdate, enddate, out unit);
                    showPITrend(PITag, startdate, enddate);
                    if (PIData != null && PIData.Count > 0)
                    {
                        List<decimal> distArray = new List<decimal>();
                        decimal[] ScoreArray = PIData.Select(x => decimal.Parse(x.value)).ToArray<decimal>();
                        decimal[] distinctvalues = ScoreArray.Distinct().OrderBy(x => x).ToArray();
                        Dictionary<decimal, int> seriesArray = new Dictionary<decimal, int>();
                        //Finds distinct values and orders them in ascending order.
                        decimal min = ScoreArray.Min(); decimal max = ScoreArray.Max();
                        decimal diff = ((max - min) / 10);
                        decimal current = min;
                        for (int i = 0; i < 10; i++)
                        {
                            distArray.Add(current);
                            decimal count = ScoreArray.Where(x => x >= distArray[i] && x <= (distArray[i] + diff)).Count();
                            decimal countPercent = (count / ScoreArray.Count()) * 100;
                            int value = (int)Math.Round(distArray[i]);
                            chartFrequency.Series[0].Points.AddXY(value, (int)Math.Round(countPercent));
                            current = current + diff;
                            //chartFrequency.Series[1].Points.AddXY(value, (int)Math.Round(countPercent));
                        }
                        chartFrequency.ChartAreas[0].AxisX.Minimum = Convert.ToDouble((int)Math.Round(min));
                        chartFrequency.ChartAreas[0].AxisX.Maximum = Convert.ToDouble((int)Math.Round(max));
                        chartFrequency.ChartAreas[0].AxisX.Title = "Value(" + unit + ")";
                        if (unit.ToLower() == "m3/d" || 1 == 1)
                        {
                            string sqlDiameter = "select * from Instrument_Spec_Data_Stage_1 where Tag_No ='" + InstrumentTag + "'";
                            DataTable dtDiameter = SqlHelper.ExecuteQuery(connectionSql, sqlDiameter).Tables[0];
                            string diameter = "";
                            if (dtDiameter.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dtDiameter.Rows[0]["Pipe Id"].ToString()))
                                    diameter = dtDiameter.Rows[0]["Pipe Id"].ToString();
                                else if (!string.IsNullOrEmpty(dtDiameter.Rows[0]["Line Size"].ToString()))
                                    diameter = dtDiameter.Rows[0]["Line Size"].ToString();
                                else if (!string.IsNullOrEmpty(dtDiameter.Rows[0]["Line Size"].ToString()))
                                    diameter = dtDiameter.Rows[0]["Line Size"].ToString();
                                double dDiameter = 0;
                                if (!string.IsNullOrEmpty(diameter) && double.TryParse(diameter, out dDiameter))
                                {
                                    List<double> velocities = new List<double>();
                                    List<double> reynoldNumbers = new List<double>();
                                    foreach (Pi pi in PIData)
                                    {
                                        double denominator = 0;
                                        dDiameter = dDiameter / 0.0254;
                                        denominator = (dDiameter) / 2;
                                        denominator = denominator * denominator;
                                        denominator = denominator * (3.14);
                                        double velocity = (double.Parse(pi.value) / denominator) / (24 * 60 * 60);
                                        chartVelocity.Series[0].Points.AddXY(pi.time, (int)Math.Round(velocity));
                                        velocities.Add(velocity);
                                        double density = 0; double viscosity = 0;
                                        if (string.IsNullOrEmpty(dtDiameter.Rows[0]["Viscosity Min"].ToString()) || !double.TryParse(dtDiameter.Rows[0]["Viscosity Min"].ToString(), out viscosity))
                                        {
                                            switch (dtDiameter.Rows[0]["fluid"].ToString())
                                            {
                                                case "OIL":
                                                    viscosity = 5;
                                                    break;
                                                case "WATER":
                                                    viscosity = 1;
                                                    break;
                                                case "Gas":
                                                    viscosity = 0.01;
                                                    break;
                                            }
                                        }
                                        else
                                            viscosity = double.Parse(dtDiameter.Rows[0]["Viscosity Min"].ToString());
                                        if (string.IsNullOrEmpty(dtDiameter.Rows[0]["Operating Density Norm"].ToString()) || !double.TryParse(dtDiameter.Rows[0]["Operating Density Norm"].ToString(), out density))
                                        {
                                            switch (dtDiameter.Rows[0]["fluid"].ToString())
                                            {
                                                case "OIL":
                                                    density = 890;
                                                    break;
                                                case "WATER":
                                                    density = 1000;
                                                    break;
                                                case "Gas":
                                                    density = 30;
                                                    break;
                                            }
                                        }
                                        else
                                            density = double.Parse(dtDiameter.Rows[0]["Operating Density Norm"].ToString());
                                        if (viscosity != 0)
                                        {
                                            double reynoldNumber = ((density) * (velocity) * (dDiameter)) / viscosity;
                                            chartReynoldNumber.Series[0].Points.AddXY(pi.time, (int)Math.Round(reynoldNumber));
                                            reynoldNumbers.Add(reynoldNumber);

                                        }
                                    }
                                    /* if (velocities.Count > 0)
                                     {
                                         chartVelocity.ChartAreas[0].AxisY.Minimum = (int)velocities.Min()-10;
                                         chartVelocity.ChartAreas[0].AxisY.Maximum = (int)velocities.Max()+10;
                                     }
                                     if (reynoldNumbers.Count > 0)
                                     {
                                         chartReynoldNumber.ChartAreas[0].AxisY.Minimum = (int)reynoldNumbers.Min()-10;
                                         chartReynoldNumber.ChartAreas[0].AxisY.Maximum = (int)reynoldNumbers.Max()+10;
                                     }*/
                                }
                                else
                                    showMessage("Diameter not defined for the instrument.");
                            }
                            else
                                showMessage("Diameter not defined for the instrument.");
                        }
                        else
                            showMessage("Unit must be in m3/d.");
                    }
                    //else chartFrequency.DataSource = null;
                    
                }
            }
        }
        public void showPITrend(string PITag, DateTime startDate, DateTime endDate)
        {
            string temp = "";
            List<Pi> PiList = getPiData(PITag, startDate, endDate, out temp);
            foreach (Pi pi in PiList)
            {
                chartTrend.Series[0].Points.AddXY(pi.time, pi.value);
            }
        }
        public void showMessage(string cleanMessage)
        {
            string script = string.Format("alert('{0}');", cleanMessage);
            if (this.Page != null && !this.Page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
        public void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                //CalendarExtender1.SelectedDate = dt.AddDays(-1);
                if (Session["StartDate"] != null)
                {
                    DateTime dtStart = DateTime.ParseExact(Session["StartDate"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    CalendarExtender1.SelectedDate = dtStart;
                    ddlHoursStart.SelectedValue = dtStart.Hour.ToString();
                    ddlMinutesStart.SelectedValue = dtStart.Minute.ToString();
                }
                else
                {
                    CalendarExtender1.SelectedDate = dt.AddHours(-8);
                    ddlHoursStart.SelectedValue = (dt.Hour - 8).ToString();
                    ddlMinutesStart.SelectedValue = dt.Minute.ToString();
                }
                if (Session["EndDate"] != null)
                {
                    DateTime dtEnd = DateTime.ParseExact(Session["EndDate"].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    CalendarExtender2.SelectedDate = dtEnd;
                    ddlHoursEnd.SelectedValue = dtEnd.Hour.ToString();
                    ddlMinutesEnd.SelectedValue = dtEnd.Minute.ToString();
                }
                else
                {
                    CalendarExtender2.SelectedDate = dt;
                    ddlHoursEnd.SelectedValue = dt.Hour.ToString();
                    ddlMinutesEnd.SelectedValue = dt.Minute.ToString();
                }
                if (!string.IsNullOrEmpty(Request.QueryString["DeviceName"]))
                {
                    trInstrument.Visible = true;
                    bindInstruments(Request.QueryString["DeviceName"]);

                }
                ShowChart();
            }
            if (IsPostBack)
            {
                CalendarExtender1.SelectedDate = Convert.ToDateTime(Request.Form["txtStartDate"].ToString());
                CalendarExtender2.SelectedDate = Convert.ToDateTime(Request.Form["txtEndDate"].ToString());
            }
        }
        List<Pi> getPiData(string tagName, DateTime StartDate, DateTime EndDate, out string unit)
        {
            ////DateTime startTime = DateTime.Now.AddSeconds(-1);
            ////DateTime endTime = DateTime.Now;
            ////TimeSpan span = new TimeSpan(0, 5, 0);
            PISDK.PISDK sdk = new PISDK.PISDK();
            //PISDK.Server srv = sdk.Servers["mus-as-126.corp.pdo.om"];
            //srv.Open("UID=upoa;PWD=upoa");
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
                ////DateTime DateTimeStart = new DateTime();
                ////DateTimeStart = Convert.ToDateTime(StartDate);
                ////DateTime DateTimeEnd = new DateTime();
                ////DateTimeEnd = Convert.ToDateTime(EndDate);
                ////if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]))
                ////{
                ////    TimeSpan timeSpan = new TimeSpan(int.Parse(ddlHoursStart.SelectedValue), int.Parse(ddlMinutesStart.SelectedValue), 0);
                ////    DateTimeStart.Add(timeSpan);
                ////    DateTimeEnd.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                ////    DateTimeEnd.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
                ////}
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
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            ShowChart();
        }
        private void bindInstruments(string DeviceName)
        {
            string sql = "select Tag_No from InstFuncHierarchy where Mech_Eqpt_no='" + DeviceName + "'";
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            ddlInstrumnet.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem item = new ListItem(dt.Rows[i]["Tag_No"].ToString(), dt.Rows[i]["Tag_No"].ToString());
                ddlInstrumnet.Items.Add(item);
            }
        }
        protected void ddlInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChart();
        }
    }
}
