using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
//using chartDemo.NibrasService;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using PISDK;
using System.Data.OracleClient;
using System.Configuration;

namespace chartDemo
{
    public partial class ChartDemo : System.Web.UI.Page
    {
        public class Pi
        {
            //public int id { get; set; }
            public DateTime time { get; set; }
            public string value { get; set; }
        }
        public class Points
        {
            private double xvalue;
            private double yvalue;
            private int quality;
            private int timestamp;

            public Points()
            {
            }

            public double XValue
            {
                get { return xvalue; }
                set { xvalue = value; }
            }

            public double YValue
            {
                get { return yvalue; }
                set { yvalue = value; }
            }

            public int Quality
            {
                get { return quality; }
                set { quality = value; }
            }

            public int Timestamp
            {
                get { return timestamp; }
                set { timestamp = value; }
            }
        }
        public class MFMPoint
        {
            public string MeterName { get; set; }
            public string MeasurementSection { get; set; }
            public int PointGas { get; set; }
            public int PointOil { get; set; }
            public int MFMPointsID { get; set; }
        }
        public class MFMGVF
        {
            public string MeterName { get; set; }
            public float GVF { get; set; }
            public int GVFID { get; set; }
        }
        public class TestSkidItem
        {
            public bool  IsDeleted {get;set;}
            public bool IsNew { get; set; }
            public string ItemName { get; set; }
            public string ItemType { get; set; }
            public string ParentName { get; set; }
            public string ParentType { get; set; }
            public int PortNo = 0;
            public string SkidName { get; set; }
        }
        public class TestDeviceInfoExtn
        {
            public string AreaName = "";
            public string ConnectionType = ""; 
            public bool InUse = false; 
            public string OPAsset = "";
            public string OPSubAsset = "";
            public string StationName = "";
            public string TestDeviceName = "";
            public string TestDeviceTemplateName = "";
            public Dictionary<string, string> PITags = new Dictionary<string, string>();
            public List<TestSkidItem> ConnectedDevices { get; set; }
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["DeviceName"]))
                        hdnDeviceName.Value = Request.QueryString["DeviceName"];
                    else
                        hdnDeviceName.Value = "25-QR-7225";
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                    //CalendarExtender1.SelectedDate = dt.AddDays(-1);
                    CalendarExtender1.SelectedDate = dt.AddHours(-3);
                    CalendarExtender2.SelectedDate = dt;
                    ddlHoursStart.SelectedValue = (dt.Hour - 3).ToString();
                    ddlMinutesStart.SelectedValue = dt.Minute.ToString();
                    ddlHoursEnd.SelectedValue = dt.Hour.ToString();
                    ddlMinutesEnd.SelectedValue = dt.Minute.ToString();
                    CreateChart(CalendarExtender1.SelectedDate.ToString(), CalendarExtender2.SelectedDate.ToString());
                    tdTitle.InnerHtml = "Operating Envelop For " + hdnDeviceName.Value;
                }
                if (IsPostBack)
                {
                    //test();
                    CalendarExtender1.SelectedDate = Convert.ToDateTime(Request.Form["txtStartDate"].ToString());
                    CalendarExtender2.SelectedDate = Convert.ToDateTime(Request.Form["txtEndDate"].ToString());
                    try
                    {
                        ddlHoursStart.SelectedValue = Convert.ToDateTime(Request.Form["txtStartDate"].ToString()).Hour.ToString();
                        ddlHoursEnd.SelectedValue = Convert.ToDateTime(Request.Form["txtEndDate"].ToString()).Hour.ToString();
                        ddlMinutesStart.SelectedValue = Convert.ToDateTime(Request.Form["txtStartDate"].ToString()).Minute.ToString();
                        ddlMinutesEnd.SelectedValue = Convert.ToDateTime(Request.Form["txtEndDate"].ToString()).Minute.ToString();
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception exc)
            {
 
            }
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            CreateChart(Request.Form["txtStartDate"].ToString(), Request.Form["txtEndDate"].ToString());
        }
        /// <summary>
        /// Plot the points in chart
        /// </summary>
        /// 
        public TestDeviceInfoExtn getTestDevice(string DeviceName)
        {
            DataSet dsDevice = new DataSet();
            ConnectionString conn = new ConnectionString();
            string connectionSql = conn.GetConnectionString().ToString();
            TestDeviceInfoExtn testDevice = new TestDeviceInfoExtn();
            dsDevice = SqlHelper.ExecuteDataset(connectionSql, "GetTestDeviceData", DeviceName);
            try
            {
                if (dsDevice != null && dsDevice.Tables.Count > 0 && dsDevice.Tables.Contains("Table") && dsDevice.Tables["Table"].Rows.Count>0)
                {
                    DataTable dt = dsDevice.Tables["Table"];
                    testDevice.AreaName = dt.Rows[0]["AreaName"].ToString();
                    testDevice.ConnectionType = dt.Rows[0]["ConnectionType"].ToString();
                    testDevice.InUse = bool.Parse(dt.Rows[0]["InUse"].ToString());
                    testDevice.OPAsset = dt.Rows[0]["OPAsset"].ToString();
                    testDevice.OPSubAsset = dt.Rows[0]["OPSubAsset"].ToString();
                    testDevice.StationName = dt.Rows[0]["StationName"].ToString();
                    testDevice.TestDeviceName = dt.Rows[0]["TestDeviceName"].ToString();
                    testDevice.TestDeviceTemplateName = dt.Rows[0]["TestDeviceTemplateName"].ToString();
                    if (dsDevice.Tables.Contains("Table1"))
                    {
                        List<TestSkidItem> skidItems = new List<TestSkidItem>();
                        DataTable dtConnectedDevices = dsDevice.Tables["Table1"];
                        for (int i = 0; i < dtConnectedDevices.Rows.Count; i++)
                        {
                            try
                            {
                                TestSkidItem item = new TestSkidItem();
                                item.IsDeleted = bool.Parse(dtConnectedDevices.Rows[0]["IsDeleted"].ToString());
                                item.IsNew = bool.Parse(dtConnectedDevices.Rows[0]["IsNew"].ToString());
                                item.ItemName = dtConnectedDevices.Rows[0]["ItemName"].ToString();
                                item.ItemType = dtConnectedDevices.Rows[0]["ItemType"].ToString();
                                item.ParentName = dtConnectedDevices.Rows[0]["ParentName"].ToString();
                                item.ParentType = dtConnectedDevices.Rows[0]["ParentType"].ToString();
                                item.PortNo = int.Parse(dtConnectedDevices.Rows[0]["PortNo"].ToString());
                                item.SkidName = dtConnectedDevices.Rows[0]["SkidName"].ToString();
                                skidItems.Add(item);
                            }
                            catch (Exception exc)
                            { }
                        }
                        testDevice.ConnectedDevices = skidItems;
                    }
                    if (dsDevice.Tables.Contains("Table2"))
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        DataTable dtPITags = dsDevice.Tables["Table2"];
                        for (int i = 0; i < dtPITags.Rows.Count; i++)
                        {
                            try
                            {
                                string key = dtPITags.Rows[i]["Tagkey"].ToString();
                                string value = dtPITags.Rows[i]["Value"].ToString();
                                dict.Add(key, value);
                            }
                            catch (Exception exc) { }
                        }
                        testDevice.PITags = dict;
                    }
                    return testDevice;

                }
            }
            catch (Exception exc)
            {
                testDevice = null;
            }
            return testDevice;
        }
        public void CreateChart(string StartDate,string EndDate)
        {

            string DeviceName = Request.QueryString["DeviceName"];// !string.IsNullOrEmpty(Request.QueryString["DeviceName"]) ? Request.QueryString["DeviceName"] : "";
            //NibrasService.WellTestServiceGatewayClient test = new WellTestServiceGatewayClient();
            //test.Close();
            try
            {
                //test = new WellTestServiceGatewayClient();
               // DataSet dsDevice = new DataSet(); ConnectionString conn = new ConnectionString();
               // string connectionSql = conn.GetConnectionString().ToString();
                //if (string.IsNullOrEmpty(DeviceName))
                  //  list = null;
               // else
                    //list = test.GetTestDevicesExtn("ALL").Where(x => x != null).ToList();
                    //list = test.GetTestDevicesInfo(new string[]{DeviceName}).Where(x => x != null).ToList();
                   // dsDevice = SqlHelper.ExecuteDataset(connectionSql, "GetMFMPointsForService", DeviceName);
                //List<TestDeviceInfoExtn> list = new List<TestDeviceInfoExtn>();
                //list[0].AreaName = ""; list[0].ConnectionType = ""; list[0].InUse = false; list[0].OPAsset = ""; list[0].OPSubAsset = ""; list[0].StationName = ""; list[0].TestDeviceName = ""; list[0].TestDeviceTemplateName = ""; list[0].PITags = new Dictionary<string, string>(); list[0].ConnectedDevices = null;
                //list[0].ConnectedDevices[0].IsDeleted = false; list[0].ConnectedDevices[0].IsNew = false; list[0].ConnectedDevices[0].ItemName = "";list[0].ConnectedDevices[0].ItemType = ""; list[0].ConnectedDevices[0].ParentName = ""; list[0].ConnectedDevices[0].ParentType = ""; list[0].ConnectedDevices[0].PortNo = 0; list[0].ConnectedDevices[0].SkidName = "";
                //list = list.Where(x => x.TestDeviceTemplateName.ToLower().Contains("haimo")).ToList();
                //TestDeviceInfoExtn testDeviceInfo = list.Where(x => x.TestDeviceName.ToLower() == DeviceName.ToLower()).FirstOrDefault();
                    TestDeviceInfoExtn testDeviceInfo = getTestDevice(DeviceName);
                Point[] ProposedList = null;
                Point[] SingleList = null;
                Point[] DoubleList = null;
                ConnectionString conn = new ConnectionString();
                string connectionSql = conn.GetConnectionString().ToString();
                #region axis
                DataTable dtAxisData = new DataTable();
                dtAxisData = SqlHelper.ExecuteDataset(connectionSql, "GetMFMAxisData", DeviceName).Tables[0];

                if (dtAxisData != null && dtAxisData.Rows.Count > 0)
                {
                    OpEnv.ChartAreas[0].AxisX.Minimum = int.Parse(dtAxisData.Select("Axis = 'x'").FirstOrDefault()["MinValue"].ToString());
                    OpEnv.ChartAreas[0].AxisX.Maximum = int.Parse(dtAxisData.Select("Axis = 'x'").FirstOrDefault()["MaxValue"].ToString());
                    OpEnv.ChartAreas[0].AxisX.IsLogarithmic = true;
                    OpEnv.ChartAreas[0].AxisX.LogarithmBase = int.Parse(dtAxisData.Select("Axis = 'x'").FirstOrDefault()["LogBase"].ToString());

                    OpEnv.ChartAreas[0].AxisY.Minimum = int.Parse(dtAxisData.Select("Axis = 'y'").FirstOrDefault()["MinValue"].ToString());
                    OpEnv.ChartAreas[0].AxisY.Maximum = int.Parse(dtAxisData.Select("Axis = 'y'").FirstOrDefault()["MaxValue"].ToString());
                    OpEnv.ChartAreas[0].AxisY.IsLogarithmic = true;
                    OpEnv.ChartAreas[0].AxisY.LogarithmBase = int.Parse(dtAxisData.Select("Axis = 'y'").FirstOrDefault()["LogBase"].ToString());
                }
                #endregion
                DataSet dsPoints = new DataSet();
                dsPoints = SqlHelper.ExecuteDataset(connectionSql, "GetMFMPointsForService", testDeviceInfo.TestDeviceName);
                DataSet dsGVF = new DataSet();
                dsGVF = SqlHelper.ExecuteDataset(connectionSql, "GetMFMGVFForService", testDeviceInfo.TestDeviceName);
                List<MFMPoint> MFMPoints = new List<MFMPoint>();
                List<MFMGVF> GVFList = new List<MFMGVF>();
                if (dsPoints != null && dsPoints.Tables.Count > 0 && dsPoints.Tables[0].Rows.Count > 0)
                {
                    MFMPoints = (from DataRow row in dsPoints.Tables[0].Rows

                                 select new MFMPoint
                                 {
                                     PointGas = int.Parse(row["PointGas"].ToString()),
                                     PointOil = int.Parse(row["PointOil"].ToString()),
                                     MeterName = row["MeterName"].ToString(),
                                     MeasurementSection = row["MeasurementSection"].ToString(),
                                     MFMPointsID = int.Parse(row["MFMPointsID"].ToString())

                                 }).ToList();
                }
                if (dsGVF != null && dsGVF.Tables.Count > 0 && dsGVF.Tables[0].Rows.Count > 0)
                {
                    GVFList = (from DataRow row in dsGVF.Tables[0].Rows

                               select new MFMGVF
                               {
                                   GVF = float.Parse(row["GVF"].ToString()),
                                   GVFID = int.Parse(row["GVFID"].ToString()),
                                   MeterName = row["MeterName"].ToString()

                               }).ToList();
                }
                if (MFMPoints != null && MFMPoints.Count > 0)
                {
                    List<MFMPoint> proposed = new List<MFMPoint>();
                    List<MFMPoint> singleVenturi = new List<MFMPoint>();
                    List<MFMPoint> doubleVenturi = new List<MFMPoint>();
                    proposed = MFMPoints.Where(x => x.MeasurementSection.ToLower() == "final" && x.MeterName == testDeviceInfo.TestDeviceName).ToList();
                    singleVenturi = MFMPoints.Where(x => x.MeasurementSection.ToLower() == "small_ventury" && x.MeterName == testDeviceInfo.TestDeviceName).ToList();
                    doubleVenturi = MFMPoints.Where(x => x.MeasurementSection.ToLower() == "large_ventury" && x.MeterName == testDeviceInfo.TestDeviceName).ToList();
                    if (proposed != null && proposed.Count > 0)
                    {
                        ProposedList = new Point[proposed.Count];
                        int i = 0;
                        foreach (MFMPoint data in proposed)
                        {
                            ProposedList[i].X = data.PointGas;
                            ProposedList[i].Y = data.PointOil;
                            OpEnv.Series[1].Points.AddXY(Convert.ToDouble(data.PointGas), Convert.ToDouble(data.PointOil));
                            i++;
                        }
                    }
                    if (singleVenturi != null && singleVenturi.Count > 0)
                    {
                        SingleList = new Point[singleVenturi.Count];
                        int i = 0;
                        foreach (MFMPoint data in singleVenturi)
                        {
                            SingleList[i].X = data.PointGas;
                            SingleList[i].Y = data.PointOil;
                            OpEnv.Series[2].Points.AddXY(Convert.ToDouble(data.PointGas), Convert.ToDouble(data.PointOil));
                            i++;
                        }
                    }
                    if (doubleVenturi != null && doubleVenturi.Count > 0)
                    {
                        DoubleList = new Point[doubleVenturi.Count];
                        int i = 0;
                        foreach (MFMPoint data in doubleVenturi)
                        {
                            DoubleList[i].X = data.PointGas;
                            DoubleList[i].Y = data.PointOil;
                            OpEnv.Series[3].Points.AddXY(Convert.ToDouble(data.PointGas), Convert.ToDouble(data.PointOil));
                            i++;
                        }
                    }
                    List<Pi> piLiquid = new List<Pi>();
                    List<Pi> piGVF = new List<Pi>();
                    string GVFTag = testDeviceInfo.PITags.Where(x=>x.Key.ToUpper()=="GVF").Select(y=>y.Value).FirstOrDefault();
                    string LiquidTag = testDeviceInfo.PITags.Where(x => x.Key.ToUpper() == "GROSS_FLOW").Select(y => y.Value).FirstOrDefault();
                    piLiquid = getPiData(LiquidTag, StartDate, EndDate);
                    piGVF = getPiData(GVFTag, StartDate, EndDate);
                    int insideCount = 0, outsideCount = 0;
                    if (piLiquid != null && piLiquid.Count > 0 && piGVF != null && piGVF.Count > 0)
                    {
                        makeValuesEqual(piLiquid, piGVF);
                        Dictionary<decimal, decimal> points = new Dictionary<decimal, decimal>();
                        foreach (Pi p in piGVF)
                        {
                            try
                            {
                                Decimal d = 0;
                                bool insidesingle = false;
                                if (Decimal.TryParse(p.value, out d))
                                {
                                    decimal GVFValue = Decimal.Parse(p.value);
                                    decimal LiquidValue = Decimal.Parse(piLiquid.Where(x => x.time == p.time).Select(y => y.value).FirstOrDefault());
                                    decimal GasValue = ((GVFValue / 100) * LiquidValue) / (1 - (GVFValue / 100));
                                    //points.Add(GasValue, LiquidValue);
                                    Point point = new Point();
                                    point.X = Convert.ToInt32(GasValue);
                                    point.Y = Convert.ToInt32(LiquidValue);
                                    OpEnv.Series[0].Points.AddXY(Convert.ToDouble(GasValue), Convert.ToDouble(LiquidValue));
                                    //if (PointInPolygon(point, ProposedList, SingleList, DoubleList))
                                    if (ProposedList != null && ProposedList.Length > 0)
                                    {
                                        insidesingle = true;
                                        if (PointInPolygon(point, DoubleList))
                                        {
                                            insideCount++;
                                        }
                                        else
                                            outsideCount++;
                                    }
                                    else if (SingleList != null && SingleList.Length > 0)
                                    {
                                        if (PointInPolygon(point, SingleList))
                                        {
                                            insidesingle = true;
                                            insideCount++;
                                        }
                                        else
                                            outsideCount++;
                                    }
                                    if (!insidesingle && DoubleList != null && DoubleList.Length > 0)
                                    {
                                        if (PointInPolygon(point, DoubleList))
                                        {
                                            insideCount++;
                                        }
                                        else
                                            outsideCount++;
                                    }
                                }
                            }
                            catch (Exception exc) { }
                        }
                    }

                    // Calculate inside/outside in Percentage.
                    double insidePercentage = insideCount * 100.0 / (insideCount + outsideCount);
                    double outsidePercentage = outsideCount * 100.0 / (insideCount + outsideCount);
                    chartMinMaxNumber.Series[0].Points[0].SetValueY(insideCount);
                    chartMinMaxNumber.Series[0].Points[1].SetValueY(outsideCount);
                    chartMinMaxPercent.Series[0].Points[0].SetValueY(insidePercentage);
                    chartMinMaxPercent.Series[0].Points[1].SetValueY(outsidePercentage);
                    lblInsideEnvelopNumber.Text = insideCount.ToString();
                    lblInsideEnvelopPercent.Text = insidePercentage.ToString("0.00") + " %";
                    lblOutsideEnvelopNumber.Text = outsideCount.ToString();
                    lblOutsideEnvelopPercent.Text = outsidePercentage.ToString("0.00") + " %";
                    //string hourText = (dtnTimeRange.SelectedItem.Text == "1") ? " Hour" : " Hours";
                    //lblTotTimePeriod.Text = dtnTimeRange.SelectedItem.Text + hourText;
                    //lblDate.Text = DateTime.Now.ToShortDateString();

                    #region GVF
                    // To show the line by percentage
                    //int[] intRange = { 5, 30, 50, 80, 90, 95, 99 };
                    int[] intRange = GVFList.Select(x => int.Parse(x.GVF.ToString())).ToArray();

                    ////int[] intRange = { 99 };
                     List<double> liquidPoints = new List<double>();
                     double min = OpEnv.ChartAreas[0].AxisY.Minimum;
                     double max = OpEnv.ChartAreas[0].AxisY.Maximum;
                     double logBase = OpEnv.ChartAreas[0].AxisY.LogarithmBase;
                     double temp = min;
                     liquidPoints.Add(min);
                     while (temp < max)
                     {
                         temp=temp*10;
                         liquidPoints.Add(temp);
                     }

                    //double[] liquidPoint = { 1, 10, 100, 1000, 10000 };
                    for (int i = 0; i < intRange.Length; i++)
                    {
                        Series newSeries = new Series();
                        //  newSeries.Name = "l1" + i.ToString();
                        newSeries.ChartType = SeriesChartType.Line;
                        var objFive = CalcAxisRange(intRange[i], liquidPoints.ToArray());
                        OpEnv.Series.Add(newSeries);
                        foreach (var data in objFive)
                        {
                            newSeries.Points.AddXY(Convert.ToDouble(data.XValue), Convert.ToDouble(data.YValue));
                        }
                        // new code need to uncomment
                        newSeries.Points[newSeries.Points.Count - 1].Label = intRange[i] + "%";
                       /* if (intRange[i] == 99)
                        {
                            newSeries.Points[3].Label = intRange[i] + "%";
                        }
                        else
                            newSeries.Points[4].Label = intRange[i] + "%";*/

                        // newSeries.Label = intRange[i] + "%";
                        newSeries.IsVisibleInLegend = false;
                        newSeries.Font = new Font("Callibri", 8, FontStyle.Regular, GraphicsUnit.Point, 0, true);
                        //newSeries.Color = Color.LightGray;
                        newSeries.Color = Color.Yellow;
                        newSeries["LabelStyle"] = "Right";
                    }
                    #endregion
                    #region Pressure Series
                    List<Pi> piPressure = new List<Pi>();
                    List<Pi> piTemperature = new List<Pi>();
                    List<Pi> piGrossFlow = new List<Pi>();
                    /*List<Pi> piFinalGVF = new List<Pi>();
                    List<Pi> piGasTotal = new List<Pi>();
                    List<Pi> piNetOilTotal = new List<Pi>();
                    List<Pi> piNetWaterTotal = new List<Pi>();*/
                    string PressureTag = testDeviceInfo.PITags.Where(x=>x.Key.ToUpper()=="Pressure(Avg)".ToUpper()).Select(y=>y.Value).FirstOrDefault();
                    PressureTag = PressureTag.ToLower().Replace("pressureaverage", "pressure");
                    piPressure = getPiData(PressureTag, StartDate, EndDate).OrderBy(x => x.time).ToList();
                    piTemperature = getPiData(PressureTag.Replace("pressure", "temp"), StartDate, EndDate).OrderBy(x => x.time).ToList();
                    piGrossFlow = getPiData(PressureTag.Replace("pressure", "grossflow"), StartDate, EndDate).OrderBy(x => x.time).ToList();
                    /*piFinalGVF = getPiData(PressureTag.Replace("pressure", "FinalGVF"), StartDate, EndDate);
                    piGasTotal = getPiData(PressureTag.Replace("pressure", "GasTotal"), StartDate, EndDate);
                    piNetOilTotal = getPiData(PressureTag.Replace("pressure", "NetOilTotal"), StartDate, EndDate);
                    piNetWaterTotal = getPiData(PressureTag.Replace("pressure", "NetWaterTotal"), StartDate, EndDate);*/
                    int PressureLimit = 5;
                    for (int i = 0; i < piPressure.Count; i++)
                    {
                        try
                        {
                            chartPressureTrend.Series[0].Points.AddXY(piPressure[i].time, double.Parse(piPressure[i].value));
                            chartPressureTrend.Series[1].Points.AddXY(piPressure[i].time, double.Parse(piPressure[i].value) - ((double.Parse(piPressure[i].value) / 100) * PressureLimit));
                            chartPressureTrend.Series[2].Points.AddXY(piPressure[i].time, double.Parse(piPressure[i].value) + ((double.Parse(piPressure[i].value) / 100) * PressureLimit));
                            if (double.Parse(piPressure[i].value) == double.Parse(piPressure[i].value) - ((double.Parse(piPressure[i].value) / 100) * PressureLimit))
                            {
 
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                    for (int i = 0; i < piTemperature.Count; i++)
                    {
                        try
                        {
                            chartTemperatureTrend.Series[0].Points.AddXY(piTemperature[i].time, double.Parse(piTemperature[i].value));
                        }
                        catch (Exception ex)
                        { }
                    }
                    decimal tempDecimal=0;
                    for (int i = 0; i < piGrossFlow.Count; i++)
                    {
                        try
                        {
                            if (decimal.TryParse(piGrossFlow[i].value, out tempDecimal))
                                chartGrossFlowTrend.Series[0].Points.AddXY(piGrossFlow[i].time, double.Parse(piGrossFlow[i].value));
                            else
                            { }
                        }
                        catch (Exception ex)
                        { }
                    }
                    /*for (int i = 0; i < piFinalGVF.Count; i++)
                    {
                        try
                        {
                            chartFinalGVF.Series[0].Points.AddXY(piFinalGVF[i].time, double.Parse(piFinalGVF[i].value));
                        }
                        catch (Exception ex)
                        { }
                    }
                    for (int i = 0; i < piGasTotal.Count; i++)
                    {
                        try
                        {
                            chartGasTotal.Series[0].Points.AddXY(piGasTotal[i].time, double.Parse(piGasTotal[i].value));
                        }
                        catch (Exception ex)
                        { }
                    }
                    for (int i = 0; i < piNetOilTotal.Count; i++)
                    {
                        try
                        {
                            chartNetOilTotal.Series[0].Points.AddXY(piNetOilTotal[i].time, double.Parse(piNetOilTotal[i].value));
                        }
                        catch (Exception ex)
                        { }
                    }
                    for (int i = 0; i < piNetWaterTotal.Count; i++)
                    {
                        try
                        {
                            chartNetWaterTotal.Series[0].Points.AddXY(piNetWaterTotal[i].time, double.Parse(piNetWaterTotal[i].value));
                        }
                        catch (Exception ex)
                        { }
                    }*/
                   // OracleConnection connOrac = new OracleConnection("Data Source=Oracle8i;Integrated Security=yes");

                    //chartPressureTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "Linear", chartPressureTrend.Series["PressureSeries"], chartPressureTrend.Series["TrendLine"]);
                    //chartPressureTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, chartPressureTrend.Series["PressureSeries"], chartPressureTrend.Series["TrendLine"]);
                    chartPressureTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartPressureTrend.Series["PressureSeries"], chartPressureTrend.Series["TrendLine"]);
                    chartTemperatureTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartTemperatureTrend.Series["PressureSeries"], chartTemperatureTrend.Series["TrendLine"]);
                    chartGrossFlowTrend.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGrossFlowTrend.Series["PressureSeries"], chartGrossFlowTrend.Series["TrendLine"]);
                    //chartGrossFlowTrend.ChartAreas[0].RecalculateAxesScale();
                    //chartGrossFlowTrend.DataManipulator.FinancialFormula(FinancialFormula.RateOfChange, "5", chartGrossFlowTrend.Series["PressureSeries"], chartGrossFlowTrend.Series["RateOfChange"]);
                    //chartGrossFlowTrend.ChartAreas[0].RecalculateAxesScale();
                    //chartPressureTrend.DataManipulator.FinancialFormula(FinancialFormula.Envelopes, "20,5", "PressureSeries", "EnvelopesMin,EnvelopesMax");
                    /*chartFinalGVF.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartFinalGVF.Series["PressureSeries"], chartFinalGVF.Series["TrendLine"]);
                    chartGasTotal.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartGasTotal.Series["PressureSeries"], chartGasTotal.Series["TrendLine"]);
                    chartNetOilTotal.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartNetOilTotal.Series["PressureSeries"], chartNetOilTotal.Series["TrendLine"]);
                    chartNetWaterTotal.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartNetWaterTotal.Series["PressureSeries"], chartNetWaterTotal.Series["TrendLine"]);*/
                    #endregion
                    //DataTable dt = ConnectAndQuery("A-2903");
                }










/*


                Point[] p = new Point[131];
                string xmlFile = Server.MapPath("\\Data\\GraphPoints.xml");
                XDocument document = XDocument.Load(xmlFile);

                // To bind Series 1 (Red line)
                var result = from element in document.Descendants("envelop") where element.Attribute("type").Value == "Proposed MPFM" select element;
                var polyPoint = from data in result.Descendants("point") select data;

                int inc = 0;
                foreach (var data in polyPoint)
                {
                    string x = data.Element("Gas").Value.Trim();
                    string y = data.Element("Liquid").Value.Trim();
                    OpEnv.Series[1].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                    p[inc].X = Convert.ToInt32(x);
                    p[inc].Y = Convert.ToInt32(y);
                    inc++;
                }

                // To bind Series 2 (Pink Line)
                var Point5Liquid = from element in document.Descendants("envelop") where element.Attribute("type").Value == "1.5 liquid" select element;
                var Point5LiquidPoint = from data in Point5Liquid.Descendants("point") select data;

                foreach (var data in Point5LiquidPoint)
                {
                    string x = data.Element("Gas").Value.Trim();
                    string y = data.Element("Liquid").Value.Trim();
                    OpEnv.Series[2].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                }

                // To bind Series 3 (Blue Line)
                var Point3Liquid = from element in document.Descendants("envelop") where element.Attribute("type").Value == "3 liquid" select element;
                var Point3LiquidPoint = from data in Point3Liquid.Descendants("point") select data;

                foreach (var data in Point3LiquidPoint)
                {
                    string x = data.Element("Gas").Value.Trim();
                    string y = data.Element("Liquid").Value.Trim();
                    OpEnv.Series[3].Points.AddXY(Convert.ToDouble(x), Convert.ToDouble(y));
                }

               

                // Get the blue dots from webservice.
                SampleData objclient = new SampleData();
                List<Points> objPoints = objclient.getSampleDatabyHours(int.Parse(dtnTimeRange.SelectedItem.Text));
                foreach (var data in objPoints)
                {
                    OpEnv.Series[0].Points.AddXY(Convert.ToDouble(data.XValue), Convert.ToDouble(data.YValue));
                }

                int insideCount = 0, outsideCount = 0;

                // To check dots is inside or outside
                foreach (var data in objPoints)
                {
                    Point objPoint = new Point();
                    objPoint.X = Convert.ToInt32(data.XValue);
                    objPoint.Y = Convert.ToInt32(data.YValue);
                    bool chk = ChartDemo.PointInPolygon(objPoint, p);
                    if (chk)
                        insideCount++;
                    else
                        outsideCount++;
                }

                // Calculate inside/outside in Percentage.
                double insidePercentage = insideCount * 100.0 / (insideCount + outsideCount);
                double outsidePercentage = outsideCount * 100.0 / (insideCount + outsideCount);

                lblInsideEnvelop.Text = insideCount.ToString();
                lblInsideEnvelopinPercentage.Text = insidePercentage.ToString("0.00") + " %";
                lblOutsideEnvelop.Text = outsideCount.ToString()+ "Mins";
                lblOutsideEnvelopinPercentage.Text = outsidePercentage.ToString("0.00") + " %";
                string hourText = (dtnTimeRange.SelectedItem.Text == "1") ? " Hour" : " Hours";
                lblTotTimePeriod.Text = dtnTimeRange.SelectedItem.Text + hourText;
                lblDate.Text = DateTime.Now.ToShortDateString();

                // To show the line by percentage
                int[] intRange = { 5, 30, 50, 80, 90, 95, 99 };

               ////int[] intRange = { 99 };

                for (int i = 0; i < intRange.Length; i++)
                {
                    Series newSeries = new Series();
                  //  newSeries.Name = "l1" + i.ToString();
                    newSeries.ChartType = SeriesChartType.Line;
                    var objFive = CalcAxisRange(intRange[i]);
                    OpEnv.Series.Add(newSeries);
                    foreach (var data in objFive)
                    {
                        newSeries.Points.AddXY(Convert.ToDouble(data.XValue), Convert.ToDouble(data.YValue));
                    }

                    if (intRange[i] == 99)
                    {
                        newSeries.Points[3].Label = intRange[i] + "%";
                    }
                    else
                        newSeries.Points[4].Label = intRange[i] + "%";
                    
                   // newSeries.Label = intRange[i] + "%";
                    newSeries.IsVisibleInLegend = false;
                    newSeries.Font = new Font("Callibri", 8, FontStyle.Regular, GraphicsUnit.Point, 0, true);
                    newSeries.Color = Color.LightGray;
                    newSeries["LabelStyle"] = "Right";
                }*/
            }
            catch (Exception err)
            {
                lblErr.Text = err.Message;
            }
        }
        protected List<Pi> getPiData(string tagName, string StartDate, string EndDate)
        {
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;
            TimeSpan span = new TimeSpan(0, 5, 0);
            //PISDK.Server srv=new PISDK.Server();
            PISDK.PISDK sdk = new PISDK.PISDK();
            //PISDK.Server srv = sdk.Servers["mus-as-126.corp.pdo.om"];
            //srv.Open("UID=upoa;PWD=upoa");
            string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
            string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
            Server srv = sdk.Servers[piServer];
            srv.Open(piCredentials);
            // PISDK.PointAttributes att = srv.AttributeSets["ANZ.78"];
            string nameConcat = "";
            int i = 0;
            PISDK.PIPoints myPoints = srv.PIPoints;

           // PIValue v = myPoints["sd"].Data.Snapshot;

            PointList list = srv.GetPoints("tag = '*" + tagName + "*'");
            int count = list.Count;
            PIData data = list[1].Data;
            PIValues values;
            List<string> stringValues = new List<string>();
            List<DateTime> timeValues = new List<DateTime>();
            //Dictionary<DateTime, string> points = new Dictionary<DateTime, string>();
            List<Pi> piData = new List<Pi>();
            try
            {
                //value = data.ArcValue(DateTime.Now.AddHours(-2), RetrievalTypeConstants.rtAtOrAfter);
                //values = data.RecordedValues(DateTime.Now.AddHours(-24), DateTime.Now);
                DateTime DateTimeStart = new DateTime();
                DateTimeStart = Convert.ToDateTime(StartDate);
                DateTime DateTimeEnd = new DateTime();
                DateTimeEnd = Convert.ToDateTime(EndDate);
                if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]))
                {
                    TimeSpan timeSpan = new TimeSpan(int.Parse(ddlHoursStart.SelectedValue), int.Parse(ddlMinutesStart.SelectedValue), 0);
                    DateTimeStart.Add(timeSpan);
                    //DateTimeStart.AddHours(int.Parse(ddlHoursStart.SelectedValue));
                    //DateTimeStart.AddMinutes(int.Parse(ddlMinutesStart.SelectedValue));
                    DateTimeEnd.AddHours(int.Parse(ddlHoursEnd.SelectedValue));
                    DateTimeEnd.AddMinutes(int.Parse(ddlMinutesEnd.SelectedValue));
                }
                values = data.RecordedValues(DateTimeStart, DateTimeEnd);
                foreach (PIValue value in values)
                {
                    try
                    {
                        if (value.Value.GetType().IsCOMObject)
                        {
                            stringValues.Add((value.Value as DigitalState).Name.ToString());
                            PITimeServer.PITime pt = value.TimeStamp;
                            //DateTime a = pt.LocalDate;
                            //points.Add(value.Value, value.TimeStamp.LocalDate);
                        }
                        else
                        {

                            stringValues.Add((value.Value).ToString());
                            Pi p = new Pi();
                            p.time = value.TimeStamp.LocalDate;
                            p.value = Convert.ToString(value.Value);
                            piData.Add(p);
                            //points.Add(value.TimeStamp.LocalDate, (value.Value).ToString());
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
        static void makeValuesEqual(List<Pi> PiLiquid, List<Pi> PiGVF)
        {
            foreach (Pi p in PiLiquid)
            {
                if (PiGVF.Where(x => x.time == p.time).Count() == 0)
                {
                    Pi pi = new Pi();
                    pi.time = p.time;
                    pi.value = PiGVF.Where(x => x.time < p.time).OrderByDescending(y => y.time).Select(z => z.value).FirstOrDefault();
                    if (!string.IsNullOrEmpty(pi.value))
                        PiGVF.Add(pi);
                }
            }

            foreach (Pi p in PiGVF)
            {
                if (PiLiquid.Where(x => x.time == p.time).Count() == 0)
                {
                    Pi pi = new Pi();
                    pi.time = p.time;
                    pi.value = PiLiquid.Where(x => x.time < p.time).OrderByDescending(y => y.time).Select(z => z.value).FirstOrDefault();
                    if (!string.IsNullOrEmpty(pi.value))
                        PiLiquid.Add(pi);
                }
            }
        }
        /// <summary>
        /// Method to find out the graph range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public List<Points> CalcAxisRange(double range,double[] liquidPoint)
        {
           // List<double> liquidPoints = new List<double>();
            List<Points> objRangePoint = new List<Points>();
            //double[] liquidPoint = { 1, 10, 100, 1000, 10000 };
            
           /* for (int inc = 0; inc < liquidPoint.Length; inc++)
            {
                Points objPoint = new Points();
                double dt = (liquidPoint[inc] * (range / 100)) / (1 - (range / 100));
                if (dt > gasMax)
                {
                    objPoint.XValue = 100000;
                    objPoint.YValue = 5000;
                    objRangePoint.Add(objPoint);
                }
               
                    objPoint = new Points();
                    objPoint.XValue = dt;
                    objPoint.YValue = liquidPoint[inc];
                    objRangePoint.Add(objPoint);
               
            }*/
           // double[] liquidPoint = { 1, 10, 100, 1000, 10000 };
            double gasMax = OpEnv.ChartAreas[0].AxisX.Maximum;
            for (int inc = 0; inc < liquidPoint.Length; inc++)
            {
                try
                {
                    Points objPoint = new Points();
                    double dt = (liquidPoint[inc] * (range / 100)) / (1 - (range / 100));
                    if (dt > gasMax)
                    {
                        double liquid = (gasMax) * (1 - (range / 100)) / (range / 100);
                        objPoint.XValue = gasMax;
                        objPoint.YValue = liquid;
                        objRangePoint.Add(objPoint);
                        return objRangePoint;
                    }

                    objPoint = new Points();
                    objPoint.XValue = dt;
                    objPoint.YValue = liquidPoint[inc];
                    objRangePoint.Add(objPoint);
                }
                catch (Exception exc) { }
            }
            if (objRangePoint.Max(x => x.YValue) < liquidPoint.Max())
            {
                try
                {
                    double Gas = (liquidPoint.Max() * (range / 100)) / (1 - range / 100);
                    if (Gas > gasMax)
                    {
                        Points objPoint = new Points();
                        double liquid = (gasMax) * (1 - (range / 100)) / (range / 100);
                        objPoint.XValue = gasMax;
                        objPoint.YValue = liquid;
                        objRangePoint.Add(objPoint);
                        return objRangePoint;
                    }
                    else
                    {
                        Points objPoint = new Points();
                        objPoint.XValue = Gas;
                        objPoint.YValue = liquidPoint.Max();
                        objRangePoint.Add(objPoint);
                        return objRangePoint;
                    }
                }
                catch (Exception exc) { }
            }
            return objRangePoint;
        }

        /// <summary>
        /// Method to dropdown selection event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtnEnvelopNamechanged(object sender, EventArgs e)
        {
            //CreateChart();
        }

        /// <summary>
        /// Determines if the given point is inside the polygon
        /// </summary>
        static bool PointInPolygon(Point p, Point[] poly)
        {
            Point p1, p2;
            bool inside = false;

            if (poly.Length < 3)
            {
                return inside;
            }

            Point oldPoint = new Point(poly[poly.Length - 1].X, poly[poly.Length - 1].Y);

            for (int i = 0; i < poly.Length; i++)
            {
                Point newPoint = new Point(poly[i].X, poly[i].Y);

                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                   ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                {
                    inside = !inside;
                }

                oldPoint = newPoint;
            }
            return inside;
        }

        static bool PointInPolygon(Point p, Point[] poly, Point[] singleVenturi, Point[] doubleVenturi)
        {
            Point p1, p2;
            bool inside = false;
            #region proposed
            if (poly != null && poly.Length > 0)
            {
                if (poly.Length < 3)
                {
                    return inside;
                }

                Point oldPoint = new Point(poly[poly.Length - 1].X, poly[poly.Length - 1].Y);

                for (int i = 0; i < poly.Length; i++)
                {
                    Point newPoint = new Point(poly[i].X, poly[i].Y);

                    if (newPoint.X > oldPoint.X)
                    {
                        p1 = oldPoint;
                        p2 = newPoint;
                    }
                    else
                    {
                        p1 = newPoint;
                        p2 = oldPoint;
                    }

                    if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                       ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                    {
                        inside = !inside;
                    }

                    oldPoint = newPoint;
                }
            }
            #endregion
            #region single
            if (poly == null && singleVenturi != null && singleVenturi.Length > 0)
            {
                if (singleVenturi.Length < 3)
                {
                    return inside;
                }

                Point oldPoint = new Point(singleVenturi[singleVenturi.Length - 1].X, singleVenturi[singleVenturi.Length - 1].Y);

                for (int i = 0; i < singleVenturi.Length; i++)
                {
                    Point newPoint = new Point(singleVenturi[i].X, singleVenturi[i].Y);

                    if (newPoint.X > oldPoint.X)
                    {
                        p1 = oldPoint;
                        p2 = newPoint;
                    }
                    else
                    {
                        p1 = newPoint;
                        p2 = oldPoint;
                    }

                    if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                       ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                    {
                        inside = !inside;
                    }

                    oldPoint = newPoint;
                }
            }
            #endregion
            if (poly==null && inside==false && doubleVenturi != null && doubleVenturi.Length > 0)
            {
                if (doubleVenturi.Length < 3)
                {
                    return inside;
                }

                Point oldPoint = new Point(doubleVenturi[doubleVenturi.Length - 1].X, doubleVenturi[doubleVenturi.Length - 1].Y);

                for (int i = 0; i < doubleVenturi.Length; i++)
                {
                    Point newPoint = new Point(doubleVenturi[i].X, doubleVenturi[i].Y);

                    if (newPoint.X > oldPoint.X)
                    {
                        p1 = oldPoint;
                        p2 = newPoint;
                    }
                    else
                    {
                        p1 = newPoint;
                        p2 = oldPoint;
                    }

                    if ((newPoint.X < p.X) == (p.X <= oldPoint.X) &&
                       ((long)p.Y - (long)p1.Y) * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(p.X - p1.X))
                    {
                        inside = !inside;
                    }

                    oldPoint = newPoint;
                }
            }
            return inside;
        }

        /// <summary>
        /// Method to select the time range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dtnTimeRangeChanged(object sender, EventArgs e)
        {
            //CreateChart();
        }

        static private string GetOracleConnectionString()
        {
            return "Data Source=mus-n-s0163;Persist Security Info=True;" +
                   "User ID=WH_PMMS;Password=pmms;";
        }

        // This will open the connection and query the database
        static private DataTable ConnectAndQuery(string devicename)
        {
            string connectionString = GetOracleConnectionString();
            using (OracleConnection connection = new OracleConnection())
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection.ConnectionString = "Data Source=mus-n-s0163;Persist Security Info=True;" +
                   "User ID=WH_PMMS;Password=PMMS";
                    connection.Open();
                }
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                                  connection.ConnectionString);

                OracleCommand command = connection.CreateCommand();
                string sql = "SELECT * FROM v_conduit_test where separator_id='" + devicename + "'";
                command.CommandText = sql;

                DataSet ds = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(ds);
                return ds.Tables[0];
            }
        }

        protected void rbtnListWellTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UpdatePanel2.Visible = true;
            test();
            
        }
        void test()
        {
            //List<Pi> pi = getPiData("BAH.A-2903.FINALGVF", DateTime.Now.AddDays(-2).ToString(), DateTime.Now.ToString());
            //for (int i = 0; i < pi.Count; i++)
            //{
            //    chartWellData.Series[0].Points.AddXY(pi[i].time, double.Parse(pi[i].value));
            //}
            //chartWellData.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, "2,3,false,false", chartWellData.Series["PressureSeries"], chartWellData.Series["TrendLine"]);
        }
    }
}