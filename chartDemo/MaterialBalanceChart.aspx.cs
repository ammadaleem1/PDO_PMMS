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
using System.Collections;
using System.Text.RegularExpressions;
using NCalc;
using System.Configuration;

namespace chartDemo
{
    public partial class MaterialBalanceChart : System.Web.UI.Page
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
        public DataTable GetDataBaseTable()
        {
            string sql = "select * from MaterialBalance order by CreatedDate desc";
             ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteQuery(connectionSql, sql).Tables[0];
            return dt;
        }
        public void Page_LoadComplete(object sender, System.EventArgs e)
        {
            fillMaterialBalance();
            //CreateChart();
        }
        public void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                //CalendarExtender1.SelectedDate = dt.AddDays(-1);
                CalendarExtender1.SelectedDate = dt.AddHours(-3);
                CalendarExtender2.SelectedDate = dt;
                ddlHoursStart.SelectedValue = (dt.Hour - 3).ToString();
                ddlMinutesStart.SelectedValue = dt.Minute.ToString();
                ddlHoursEnd.SelectedValue = dt.Hour.ToString();
                ddlMinutesEnd.SelectedValue = dt.Minute.ToString();
            }
            if (IsPostBack)
            {
                CalendarExtender1.SelectedDate = Convert.ToDateTime(Request.Form["txtStartDate"].ToString());
                CalendarExtender2.SelectedDate = Convert.ToDateTime(Request.Form["txtEndDate"].ToString());
            }
        }
        void fillMaterialBalance()
        {
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            DataTable dt = SqlHelper.ExecuteDataset(connectionSql, "GetMaterialBalance", int.Parse(Request.QueryString["MaterialBalanceID"])).Tables[0];
            if (dt.Rows.Count > 0)
            {
                hdnInput.Value = dt.Rows[0]["InputEquation"].ToString().Replace("''", "'");// +" + ";
                hdnOutput.Value = dt.Rows[0]["OutputEquation"].ToString().Replace("''", "'");// +" + ";
                //txtMaterialBalanceName.Text = dt.Rows[0]["MaterialBalanceName"].ToString();
               // if (dt.Rows[0]["CreatedBy"].ToString() != Context.User.Identity.Name)
                //    btnInsertTags.Visible = false;
                CreateChartSeries(hdnInput.Value, 0);
                CreateChartSeries(hdnOutput.Value, 1);
            }
        }
        string[] GetTags(string val)
        {
            MatchCollection match = Regex.Matches(val, @"'(.*?)'");
            string[] arr = new string[match.Count];
            for (int i = 0; i < match.Count; i++)
            {
                arr[i] = match[i].Groups[1].Value;
            }
            return arr;
        }
        List<Pi> getPiData(string tagName, DateTime StartDate, DateTime EndDate)
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
        }
        void makeValuesEqual(List<Pi> PiLiquid, List<Pi> PiGVF)
        {
            if (PiLiquid.Count == 0 || PiGVF.Count == 0)
                return;
            for(int i = 0; i< PiLiquid.Count;i++)
                //            foreach (Pi p in PiLiquid.ToList())
            {
                if (PiGVF.Where(x => x.time == PiLiquid[i].time).Count() == 0)
                {
                    Pi pi = new Pi();
                    pi.time = PiLiquid[i].time;
                    pi.value = PiGVF.Where(x => x.time < PiLiquid[i].time).OrderByDescending(y => y.time).Select(z => z.value).FirstOrDefault();
                    pi.tag = PiGVF[i].tag;
                    if (!string.IsNullOrEmpty(pi.value))
                        PiGVF.Add(pi);
                    else
                        PiLiquid.Remove(PiLiquid[i]);
                }
            }
            for (int i = 0; i < PiGVF.Count; i++)
            //foreach (Pi p in PiGVF.ToList())
            {
                if (PiLiquid.Where(x => x.time == PiGVF[i].time).Count() == 0)
                {
                    Pi pi = new Pi();
                    pi.time = PiGVF[i].time;
                    pi.value = PiLiquid.Where(x => x.time < PiGVF[i].time).OrderByDescending(y => y.time).Select(z => z.value).FirstOrDefault();
                    pi.tag = PiLiquid[i].tag;
                    if (!string.IsNullOrEmpty(pi.value))
                        PiLiquid.Add(pi);
                    PiGVF.Remove(PiGVF[i]);
                }
            }
        }
        void CreateChart()
        {
            //hdnInput.Value = Request["txtInput"];
            string[] inputtags = GetTags(hdnInput.Value).Distinct().ToArray();
            List<Pi> PiData = new List<Pi>();
            //List<Pi> aggregate = new List<Pi>();
            List<Pi>[] arrList = new List<Pi>[inputtags.Length];
            int i = 0;
            DateTime startdate,enddate=new DateTime();
            if (string.IsNullOrEmpty(Request.Form["txtStartDate"]))
            {
                startdate = CalendarExtender1.SelectedDate.Value;
                //startdate.AddHours(int.Parse(ddlHoursStart.SelectedValue));
                //startdate.AddMinutes(int.Parse(ddlMinutesStart.SelectedValue));
            }
            else
            {
                startdate = DateTime.Parse( Request.Form["txtStartDate"]);
                startdate.AddHours(int.Parse(ddlHoursStart.SelectedValue));
                startdate.AddMinutes(int.Parse(ddlMinutesStart.SelectedValue));
            }
            if (string.IsNullOrEmpty(Request.Form["txtEndDate"]))
            {
                enddate = CalendarExtender2.SelectedDate.Value;
                //enddate.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                //enddate.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
            }
            else
            {
                enddate = DateTime.Parse(Request.Form["txtEndDate"]);
                enddate.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                enddate.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
            }
            foreach (string s in inputtags)
            {
                PiData = (getPiData(s, startdate,enddate));
                arrList[i] = PiData;
                i++;
            }
            for (int j = 0; j < arrList.Length; j++)
            {
                for (int k = j + 1; k < arrList.Length; k++)
                {
                    makeValuesEqual(arrList[j], arrList[k]);
                }
            }
            DateTime[] time = arrList[0].Select(x => x.time).Distinct().OrderBy(x=>x).ToArray();
            foreach (DateTime t in time)
            {
                float eval = 0;
                string temp = hdnInput.Value;
                //foreach (string s in inputtags)
                //{
                //    List<Pi> tempPI = arrList.Select(x => x.Where(y => y.tag == s)).FirstOrDefault().ToList();
                //    temp = temp.Replace("'" + s + "'", tempPI.Where(x => x.time == t).Select(y => y.value).FirstOrDefault());
                //    //aggregate.Add(new Pi { time = t, value = eval.ToString() });
                //}
                for (int j = 0; j < inputtags.Length;j++ )
                {
                    List<Pi> tempPI = arrList[j];//.Where(x => x.tag == inputtags[j]).ToList();
                    int count = tempPI.Where(x => x.time == t).Count();
                    string tempvalue = tempPI.Where(x => x.time == t).Select(y => y.value).FirstOrDefault();
                    temp = temp.Replace("'" + inputtags[j] + "'", tempvalue);
                    //aggregate.Add(new Pi { time = t, value = eval.ToString() });
                }
                Expression exp = new Expression(temp);
                try
                {
                    eval = float.Parse(exp.Evaluate().ToString());
                }
                catch (Exception ex)
                {

                }
                if (eval != 0)
                    chartMaterialBalance.Series[0].Points.AddXY(t, eval);
            }
        }
        void CreateChartSeries(string value,int seriesNumber)
        {
            if (string.IsNullOrEmpty(value))
                return;
            //string[] inputtags = GetTags(hdnInput.Value).Distinct().ToArray();
            string[] tags = GetTags(value).Distinct().ToArray();
            List<Pi> PiData = new List<Pi>();
            List<Pi>[] arrList = new List<Pi>[tags.Length];
            int i = 0;
            DateTime startdate, enddate = new DateTime();
            if (string.IsNullOrEmpty(Request.Form["txtStartDate"]))
            {
                startdate = CalendarExtender1.SelectedDate.Value;
                //startdate = startdate.AddHours(int.Parse(ddlHoursStart.SelectedValue));
                //startdate = startdate.AddMinutes(int.Parse(ddlMinutesStart.SelectedValue));
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
                //enddate = enddate.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                //enddate = enddate.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
            }
            else
            {
                enddate = enddate = DateTime.Parse(Request.Form["txtEndDate"]);
                enddate = enddate.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                enddate = enddate.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
            }
            foreach (string s in tags)
            {
                PiData = (getPiData(s, startdate, enddate));
                arrList[i] = PiData;
                i++;
            }
            for (int j = 0; j < arrList.Length; j++)
            {
                for (int k = j + 1; k < arrList.Length; k++)
                {
                    makeValuesEqual(arrList[j], arrList[k]);
                }
            }
            if (arrList.Length > 0)
            {
                DateTime[] time = arrList[0].Select(x => x.time).Distinct().OrderBy(x => x).ToArray();
                foreach (DateTime t in time)
                {
                    float eval = 0;
                    string temp = value;
                    for (int j = 0; j < tags.Length; j++)
                    {
                        List<Pi> tempPI = arrList[j];//.Where(x => x.tag == inputtags[j]).ToList();
                        int count = tempPI.Where(x => x.time == t).Count();
                        string tempvalue = tempPI.Where(x => x.time == t).Select(y => y.value).FirstOrDefault();
                        temp = temp.Replace("'" + tags[j] + "'", tempvalue);
                        temp = temp.Replace("()", "0");
                        //aggregate.Add(new Pi { time = t, value = eval.ToString() });
                    }
                    Expression exp = new Expression(temp);
                    try
                    {
                        eval = float.Parse(exp.Evaluate().ToString());
                    }
                    catch (Exception ex)
                    {

                    }
                    if (eval != 0)
                        chartMaterialBalance.Series[seriesNumber].Points.AddXY(t, eval);
                }
            }
        }
    }
}
