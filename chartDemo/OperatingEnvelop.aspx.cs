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

namespace chartDemo
{
    public partial class OperatingEnvelop : System.Web.UI.Page
    {
        XhqServiceClient client = new XhqServiceClient();
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
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        public void Page_Load(object sender, System.EventArgs e)
        {
            try//col1[1][0]
            {
                /*string columns = "sAreaName,sCluster,sDirectorate,sMainClass,sMeasurementClass1,sMeasurementClass2,sMechanicalEquipment,sPITag,sProcessFunctionType,sService,sStation,sTagNumber,sDrawingNumber,sWellName";

                string[][] col1 = client.GetCollectionDataFilter("localhost", "::PDO_InstrumentsMain", columns, "", "", client.GetCollectionCount("localhost", "::PDO_InstrumentsMain", ""));
                DataTable dt1 = new DataTable();
                for (int i = 0; i < columns.Split(',').Length; i++)
                {
                    dt1.Columns.Add(columns.Split(',')[i]);
                }
                for (int i = 0; i < col1[0].Length; i++)
                {
                    DataRow dr = dt1.NewRow();
                    for (int j = 0; j < 14; j++)
                    {
                        dr[j] = col1[j][i];
                    }
                    dt1.Rows.Add(dr);
                }*/
                
                if (!IsPostBack)
                {
                    int inside = 0; int outsideLH = 0; int excursionTimeLH = 0; int outsideLLHH = 0; int excursionTimeLLHH = 0;
                    if (!string.IsNullOrEmpty(Request.QueryString["TagName"]))
                        hdnPITag.Value = Request.QueryString["TagName"];
                    else
                        hdnPITag.Value = "FAH.FHC.53FQR013.DACA.PV";
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                    CalendarExtender1.SelectedDate = dt.AddHours(-3);
                    CalendarExtender2.SelectedDate = dt;
                    ddlHoursStart.SelectedValue = (dt.Hour - 3).ToString();
                    ddlMinutesStart.SelectedValue = dt.Minute.ToString();
                    ddlHoursEnd.SelectedValue = dt.Hour.ToString();
                    ddlMinutesEnd.SelectedValue = dt.Minute.ToString();
                    List<Pi> piList = getPiData(hdnPITag.Value, CalendarExtender1.SelectedDate.ToString(), CalendarExtender2.SelectedDate.ToString());
                    string[][] col = client.GetCollectionDataFilter("localhost", "::OE_InstrumentLimits", "rMeasMinFR,rMeasMaxFR,rLoLo,rHiHi", "sPiTag='" + hdnPITag.Value + "'", "", 1);
                    for (int i=0;i<piList.Count; i++)
                    {
                        operatingEnvelop.Series[0].Points.AddXY(piList[i].time, piList[i].value);
                        if (col != null && col[0].Length > 0)
                        {
                            hdnLoLimit.Value = string.IsNullOrEmpty(col[0][0]) ? "0" : col[0][0];
                            hdnHiLimit.Value = string.IsNullOrEmpty(col[1][0]) ? "0" : col[1][0];
                            hdnLoLoLimit.Value = string.IsNullOrEmpty(col[2][0]) ? "0" : col[2][0];
                            hdnHiHiLimit.Value = string.IsNullOrEmpty(col[3][0]) ? "0" : col[3][0];
                            operatingEnvelop.Series[1].Points.AddXY(piList[i].time, hdnLoLimit.Value);
                            operatingEnvelop.Series[2].Points.AddXY(piList[i].time, hdnHiLimit.Value);
                            if (!string.IsNullOrEmpty(col[2][0]))
                                operatingEnvelop.Series[3].Points.AddXY(piList[i].time, hdnLoLoLimit.Value);

                            if (!string.IsNullOrEmpty(col[3][0]))
                            operatingEnvelop.Series[4].Points.AddXY(piList[i].time, hdnHiHiLimit.Value);
                            double pivalue = 0;

                            #region hihi yes lolo yes
                            if (hdnLoLoLimit.Value != "0" && hdnHiHiLimit.Value != "0")
                            {
                                double.TryParse(piList[i].value, out pivalue);
                                #region hi yes lo yes
                                if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi yes lo no
                                else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi no lo yes
                                else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            #region hihi yes lolo no
                            if (hdnLoLoLimit.Value == "0" && hdnHiHiLimit.Value != "0")
                            {
                                double.TryParse(piList[i].value, out pivalue);
                                #region hi yes lo yes
                                if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi yes lo no
                                else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi no lo yes
                                else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                                {
                                    if (pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            #region hihi no lolo yes
                            if (hdnLoLoLimit.Value != "0" && hdnHiHiLimit.Value == "0")
                            {
                                double.TryParse(piList[i].value, out pivalue);
                                #region hi yes lo yes
                                if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi yes lo no
                                else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region hi no lo yes
                                else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                                {
                                    if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                        inside++;
                                    else
                                    {
                                        if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                        {
                                            outsideLH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLH += span.Seconds;
                                            }
                                        }
                                        else
                                        {
                                            outsideLLHH++;
                                            if (i > 0)
                                            {
                                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                                excursionTimeLLHH += span.Seconds;
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            #endregion

                            #region hihi no lolo no
                            if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                            {
                                double.TryParse(piList[i].value, out pivalue);
                                if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                    inside++;
                                else
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                            }
                            else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                            {
                                if (pivalue <= double.Parse(hdnHiLimit.Value))
                                    inside++;
                                else
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                            }
                            else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                            {
                                if (pivalue >= double.Parse(hdnLoLimit.Value))
                                    inside++;
                                else
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    lblInsideEnvelopPercent.Text = (inside == 0 && outsideLH == 0) ? "0" : (inside * 1.0 / ((inside + outsideLH) * 1.0) * 100).ToString("#.00");
                    lblOutsideEnvelopPercentHL.Text = (inside == 0 && outsideLH == 0) ? "0" : (outsideLH * 1.0 / ((inside + outsideLH) * 1.0) * 100).ToString("#.00");
                    lblOutsideEnvelopNumberHL.Text = outsideLH.ToString();
                    lblOutsideEnvelopPercentHHLL.Text = (inside == 0 && outsideLLHH == 0) ? "0" : (outsideLLHH * 1.0 / ((inside + outsideLLHH) * 1.0) * 100).ToString("#.00");
                    lblOutsideEnvelopNumberHHLL.Text = outsideLLHH.ToString();
                    lblTotTimePeriod.Text = (excursionTimeLH / 60) >= 1 ? (excursionTimeLH / 60).ToString() + " min " + (excursionTimeLH % 60).ToString() + " sec" : (excursionTimeLH % 60).ToString() + " sec";
                    lblInsideEnvelopNumber.Text = inside.ToString();
                    tdTitle.InnerHtml = "Operating Envelop For " + hdnPITag.Value;
                }
                if (IsPostBack)
                {
                    lblErr.Text = "";
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
                    { lblErr.Text = ex.Message; }
                }
            }
            catch (Exception exc)
            {
                client.Close();
            }
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int inside = 0; int outsideLH = 0; int excursionTimeLH = 0; int outsideLLHH = 0; int excursionTimeLLHH = 0;
                List<Pi> piList = getPiData(hdnPITag.Value, Request.Form["txtStartDate"].ToString(), Request.Form["txtEndDate"].ToString());
                for (int i = 0; i < piList.Count; i++)
                {
                    operatingEnvelop.Series[0].Points.AddXY(piList[i].time, piList[i].value);
                    if(!string.IsNullOrEmpty(hdnLoLimit.Value))
                        operatingEnvelop.Series[1].Points.AddXY(piList[i].time, hdnLoLimit.Value);
                    if(!string.IsNullOrEmpty(hdnHiLimit.Value))
                        operatingEnvelop.Series[2].Points.AddXY(piList[i].time, hdnHiLimit.Value);
                    double pivalue = 0;
                    //if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                    //{
                    //    double.TryParse(piList[i].value, out pivalue);
                    //    if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                    //        inside++;
                    //    else
                    //    {
                    //        outside++;
                    //        if (i > 0)
                    //        {
                    //            TimeSpan span = piList[i].time - piList[i - 1].time;
                    //            excursionTime += span.Seconds;
                    //        }
                    //    }
                    //}
                    //else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                    //{
                    //    if (pivalue <= double.Parse(hdnHiLimit.Value))
                    //        inside++;
                    //    else
                    //    {
                    //        outside++;
                    //        if (i > 0)
                    //        {
                    //            TimeSpan span = piList[i].time - piList[i - 1].time;
                    //            excursionTime += span.Seconds;
                    //        }
                    //    }
                    //}



                    #region hihi yes lolo yes
                    if (hdnLoLoLimit.Value != "0" && hdnHiHiLimit.Value != "0")
                    {
                        double.TryParse(piList[i].value, out pivalue);
                        #region hi yes lo yes
                        if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi yes lo no
                        else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi no lo yes
                        else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region hihi yes lolo no
                    if (hdnLoLoLimit.Value == "0" && hdnHiHiLimit.Value != "0")
                    {
                        double.TryParse(piList[i].value, out pivalue);
                        #region hi yes lo yes
                        if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi yes lo no
                        else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi no lo yes
                        else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                        {
                            if (pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue < double.Parse(hdnHiHiLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region hihi no lolo yes
                    if (hdnLoLoLimit.Value != "0" && hdnHiHiLimit.Value == "0")
                    {
                        double.TryParse(piList[i].value, out pivalue);
                        #region hi yes lo yes
                        if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value)) || (pivalue <= double.Parse(hdnLoLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi yes lo no
                        else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                        #region hi no lo yes
                        else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                        {
                            if (pivalue >= double.Parse(hdnLoLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                                inside++;
                            else
                            {
                                if ((pivalue >= double.Parse(hdnHiLimit.Value) && pivalue >= double.Parse(hdnLoLoLimit.Value)))
                                {
                                    outsideLH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLH += span.Seconds;
                                    }
                                }
                                else
                                {
                                    outsideLLHH++;
                                    if (i > 0)
                                    {
                                        TimeSpan span = piList[i].time - piList[i - 1].time;
                                        excursionTimeLLHH += span.Seconds;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion

                    #region hihi no lolo no
                    if (hdnLoLimit.Value != "0" && hdnHiLimit.Value != "0")
                    {
                        double.TryParse(piList[i].value, out pivalue);
                        if (pivalue >= double.Parse(hdnLoLimit.Value) && pivalue <= double.Parse(hdnHiLimit.Value))
                            inside++;
                        else
                        {
                            outsideLH++;
                            if (i > 0)
                            {
                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                excursionTimeLH += span.Seconds;
                            }
                        }
                    }
                    else if (hdnLoLimit.Value == "0" && hdnHiLimit.Value != "0")
                    {
                        if (pivalue <= double.Parse(hdnHiLimit.Value))
                            inside++;
                        else
                        {
                            outsideLH++;
                            if (i > 0)
                            {
                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                excursionTimeLH += span.Seconds;
                            }
                        }
                    }
                    else if (hdnLoLimit.Value != "0" && hdnHiLimit.Value == "0")
                    {
                        if (pivalue >= double.Parse(hdnLoLimit.Value))
                            inside++;
                        else
                        {
                            outsideLH++;
                            if (i > 0)
                            {
                                TimeSpan span = piList[i].time - piList[i - 1].time;
                                excursionTimeLH += span.Seconds;
                            }
                        }
                    }
                    #endregion
                }
                lblInsideEnvelopPercent.Text = (inside == 0 && outsideLH == 0) ? "0" : (inside * 1.0 / ((inside + outsideLH) * 1.0) * 100).ToString("#.00");
                lblOutsideEnvelopPercentHL.Text = (inside == 0 && outsideLH == 0) ? "0" : (outsideLH * 1.0 / ((inside + outsideLH) * 1.0) * 100).ToString("#.00");
                lblOutsideEnvelopNumberHL.Text = outsideLH.ToString();
                lblOutsideEnvelopPercentHHLL.Text = (inside == 0 && outsideLLHH == 0) ? "0" : (outsideLLHH * 1.0 / ((inside + outsideLLHH) * 1.0) * 100).ToString("#.00");
                lblOutsideEnvelopNumberHHLL.Text = outsideLLHH.ToString();
                lblTotTimePeriod.Text = (excursionTimeLH / 60) >= 1 ? (excursionTimeLH / 60).ToString() + " min " + (excursionTimeLH % 60).ToString() + " sec" : (excursionTimeLH % 60).ToString() + " sec";
                lblInsideEnvelopNumber.Text = inside.ToString();
            }
            catch (Exception ex)
            { lblErr.Text = ex.Message; }
        }
        protected List<Pi> getPiData(string tagName, string StartDate, string EndDate)
        {
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;
            TimeSpan span = new TimeSpan(0, 5, 0);
            PISDK.PISDK sdk = new PISDK.PISDK();
            string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
            string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
            Server srv = sdk.Servers[piServer];
            srv.Open(piCredentials);
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
                DateTime DateTimeStart = new DateTime();
                DateTimeStart = Convert.ToDateTime(StartDate);
                DateTime DateTimeEnd = new DateTime();
                DateTimeEnd = Convert.ToDateTime(EndDate);
                if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]))
                {
                    TimeSpan timeSpan = new TimeSpan(int.Parse(ddlHoursStart.SelectedValue), int.Parse(ddlMinutesStart.SelectedValue), 0);
                    DateTimeStart.Add(timeSpan);
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
                        }
                        else
                        {

                            stringValues.Add((value.Value).ToString());
                            Pi p = new Pi();
                            p.time = value.TimeStamp.LocalDate;
                            p.value = Convert.ToString(value.Value);
                            piData.Add(p);
                        }

                    }
                    catch (Exception ex)
                    { 
                    }
                }
            }
            catch (Exception ex)
            { }
            return piData;
        }
        float GetCurrentValue(string tagname)
        {
            float currentvalue = 0;
            PISDK.PISDK sdk = new PISDK.PISDK();
            string piServer = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PIServer"]) ? "mus-as-126.corp.pdo.om" : ConfigurationSettings.AppSettings["PIServer"];
            string piCredentials = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["PICredentials"]) ? "UID=upoa;PWD=upoa" : ConfigurationSettings.AppSettings["PICredentials"];
            Server srv = sdk.Servers[piServer];
            srv.Open(piCredentials);
            PISDK.PIPoints myPoints = srv.PIPoints;
            try
            {
                PIValue value = myPoints[tagname].Data.Snapshot;
                currentvalue = value.Value;
            }
            catch (Exception ex)
            { }
            return currentvalue;
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
        float GetExpressionValue(string value)
        {
            float eval = 0;
            string[] tags = GetTags(value);
            foreach (string s in tags)
            {
                float currentvalue = GetCurrentValue(s);
                value = value.Replace("'" + s + "'", currentvalue.ToString());

            }
            Expression exp = new Expression(value);
            try
            {
                 eval = float.Parse(exp.Evaluate().ToString());
                
            }
            catch (Exception ex)
            {

            }
            return eval;
        }
    }
}
