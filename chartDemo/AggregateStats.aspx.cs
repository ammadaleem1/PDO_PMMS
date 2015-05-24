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
using Telerik.Web.UI;
using Telerik.Charting;
using chartDemo.Controls;

namespace chartDemo
{
    public partial class AggregateStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            LeftNavigation control = (LeftNavigation)this.Master.FindControl("ucNavigation");
            int level = control.Level;
            string menuName = control.MenuText;

            hdnValue.Value = menuName;
            hdnNode.Value = level.ToString();
        }
        protected void ddlMainClass_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart1.Series.Clear();
        }
        protected void ddlSubClass1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart2.Series.Clear();
        }
        protected void ddlSubClass2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart3.Series.Clear();
        }
        protected void ddlInstrumentType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart4.Series.Clear();
        }
        protected void ddlProcessFunction_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart5.Series.Clear();
        }
        protected void ddlService_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            RadChart6.Series.Clear();
        }
        protected void HideLabels(RadChart radChart)
        {
            foreach (ChartSeries series in radChart.Series)
            {
                series.Appearance.LabelAppearance.Visible = false;
            }
        }

        protected void RadChart1_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart1);
        }
        protected void RadChart2_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart2);
        }
        protected void RadChart3_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart3);
        }
        protected void RadChart4_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart4);
        }
        protected void RadChart5_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart5);
        }
        protected void RadChart6_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart6);
        }
        protected void RadChart7_DataBound(object sender, EventArgs e)
        {
            HideLabels(RadChart7);
        }
        protected void RadTreeView1_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
 
        }
        //protected void RadTreeView1_NodeDataBound(object sender, RadTreeNodeEventArgs e)
        //{
        //    e.Node.Text = Server.HtmlEncode(e.Node.Text);
        //}
    }
}