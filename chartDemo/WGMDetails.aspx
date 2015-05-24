<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WGMDetails.aspx.cs"
    Inherits="chartDemo.WGMDetails" Title="Device Details" %>

   <%-- <%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<link rel="stylesheet" href="jQuery/jquery-ui.css" />
<script src="JQuery/jquery.blockUI.js" type="text/javascript"></script>
<script src="jQuery/jquery-1.9.1.js" type="text/javascript"></script>
<script src="jQuery/jquery-ui.js" type="text/javascript"></script>--%>
<%--<link rel="stylesheet" href="Styles/ini.css"/>
<script type="text/javascript" src="Scripts/library.js"></script>
<script type="text/javascript" src="Scripts/ini.js"></script>--%>
 <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="JQuery/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="JQuery/jquery.contextMenu.js" type="text/javascript"></script>
    <title>Chart Demo</title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
            background-color: Gray;
        }
        .PropertyLabel
        {
            color: Red;
        }
        .PropertyTable
        {
            background-color: #d2d2d2;
            width: 800px;
        }
        .validators
        {
            color: Red;
            font-size: 12px;
        }
         .buttonClass
       {
           border-radius: 3px; border: 1px solid rgb(0, 0, 0); background-color: rgb(177, 206, 222); font-size: 12px; padding-bottom: 2px;
           }
       .textBoxClass
       {border:1px solid #000000;border-radius:5px;}
       .tble
       {border-collapse:collapse;} .tble td {border-right:1px solid #4B555E;border-bottom:1px solid #4B555E;}
       .bottomtd{border-left:1px solid #4B555E;border-top:1px solid #4B555E;}
       .lefttd{border-left:1px solid #4B555E;}
       .bottomtd{border-bottom:1px solid #4B555E;}
        .RadPicker_Default table {float:left;}
        .piChartClass{}
        .monthlyChartClass{}
        .gasProdClass{}
        .condProdClass{}
        .waterProdClass{}
        .wetGasProdClass{}
        .gasTotalClass{}
        .condTotalClass{}
        .waterTotalClass{}
        .wetGasTotalClass{}
      /*  #dvLoading
{
   background:#000 url(images/loader.gif) no-repeat center center;
   height: 100px;
   width: 100px;
   position: fixed;
   z-index: 1000;
   left: 50%;
   top: 50%;
   margin: -25px 0 0 -25px;
}*/
    </style>
    <script type="text/javascript" language="javascript">
    <asp:PlaceHolder runat="server">
        function clearDate() {
            document.getElementById('<%= txtStartDate.ClientID %>').value = '';
            document.getElementById('<%= txtEndDate.ClientID %>').value = '';
            return false;
        }
         $(document).ready(function () {
            $(".piChartClass").contextMenu({ menu: 'piMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".monthlyChartClass").contextMenu({ menu: 'monthlyMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".gasProdClass").contextMenu({ menu: 'gasProdMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".condProdClass").contextMenu({ menu: 'condProdMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".waterProdClass").contextMenu({ menu: 'waterProdMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".wetGasProdClass").contextMenu({ menu: 'wetGasProdMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".gasTotalClass").contextMenu({ menu: 'gasTotalMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".condTotalClass").contextMenu({ menu: 'condTotalMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".waterTotalClass").contextMenu({ menu: 'waterTotalMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".wetGasTotalClass").contextMenu({ menu: 'wetGasTotalMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
        });


         function contextMenuWork(action, el, pos) {
        var btn = document.getElementById('<%=btn.ClientID%>');
        var chartType = document.getElementById('<%= chartType.ClientID %>');
        switch (action) {

            case "aggregatePI":
                {chartType.value="aggregatePI";btn.click();}
            case "actualPI":
                {chartType.value="actualPI";btn.click();}
                                
            case "monthly" :
                {chartType.value="monthly";btn.click();}
                           
            case "actualGasProd":
                {chartType.value="actualGasProd";btn.click();}
            case "aggregateGasProd":
                {chartType.value="aggregateGasProd";btn.click();}

            case "actualGasTotal":
                {chartType.value="actualGasTotal";btn.click();}
            case "aggregateGasTotal":
                {chartType.value="aggregateGasTotal";btn.click();}

            case "actualCondProd":
                {chartType.value="actualCondProd";btn.click();}
            case "aggregateCondProd":
                {chartType.value="aggregateCondProd";btn.click();}

            case "actualCondTotal":
                {chartType.value="actualCondTotal";btn.click();}
            case "aggregateCondTotal":
                {chartType.value="aggregateCondTotal";btn.click();}

            case "actualWaterProd":
                {chartType.value="actualWaterProd";btn.click();}
            case "aggregateWaterProd":
                {chartType.value="aggregateWaterProd";btn.click();}

            case "actualWaterTotal":
                {chartType.value="actualWaterTotal";btn.click();}
            case "aggregateWaterTotal":
                {chartType.value="aggregateWaterTotal";btn.click();}

            case "actualWetGasProd":
                {chartType.value="actualWetGasProd";btn.click();}
            case "aggregateWetGasProd":
                {chartType.value="aggregateWetGasProd";btn.click();}

            case "actualWetGasTotal":
                {chartType.value="actualWetGasTotal";btn.click();}
            case "aggregateWetGasTotal":
                {chartType.value="aggregateWetGasTotal";btn.click();}
            }
        }
       </asp:PlaceHolder>


    </script>
    
    <script type="text/javascript" language="javascript">
       /* $(document).ready(function () {
            $('.txtTest').click(function () {
                alert("called");
                $.blockUI({ css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
                });

                setTimeout($.unblockUI, 2000);
            });
        }); */
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="chartType" runat="server" />
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvWellTestDataRad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvWellTestDataRad"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div style="margin:0 auto">
     <div id="box">
    <%--<img src="Images/loader.gif" id="Img1" />--%>
	</div>
    <div id="screen">
	
    <div>
    <table border="0" cellpadding="0" cellspacing="0" align="center">
    <tr><td valign="top" style="padding-right:10px">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                
                </td>
            </tr>
            <tr></tr>
            <tr>
                <td style="width:1400px!important">
                   
                </td>
            </tr>
            <tr>
            <td>
            <table>
                <!-------- region Inst Charts---------------->
                <tr>
                    <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGasInst" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="gasProdClass">
                    <Series>
                        <asp:Series Name="GasInstSeries" XValueType="DateTime"  YValueType="Double" ChartType="Line" ChartArea="MainChartArea" Color="Green" Legend="Pressure"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Gas Prod(MMSCMD)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartConInst" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="condProdClass">
                    <Series>
                        <asp:Series Name="ConInstSeries" XValueType="DateTime"  YValueType="Double" ChartType="Line" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Cond Prod(SM3/D)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartWaterInst" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="waterProdClass">
                    <Series>
                        <asp:Series Name="WaterInstSeries" XValueType="DateTime"  YValueType="Double" ChartType="Line" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Water Prod(MMSCMD)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartWetGasInst" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="wetGasProdClass">
                    <Series>
                        <asp:Series Name="WetGasInstSeries" XValueType="DateTime"  YValueType="Double" ChartType="Line" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" MarkerSize="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Wet Gas Prod(SM3/D)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                </tr>
                


                <!-------- region totl Charts----------------->
                <tr>
                    <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGasTot" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="gasTotalClass"> 
                    <Series>
                        <asp:Series Name="GasTotSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" Legend="Pressure"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Gas Totalizer(MSM3/D)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartConTot" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="condTotalClass">
                    <Series>
                        <asp:Series Name="ConTolSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Cond Totalizer(SM3)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartWaterTotal" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="waterTotalClass">
                    <Series>
                        <asp:Series Name="WaterTotSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Water Totalizer(SM3)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartWetGasTotal" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="wetGasTotalClass">
                    <Series>
                        <asp:Series Name="WetGasTotSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" MarkerSize="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Wet Gas Totalizer(MSM3/D)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                </tr>
                <tr height="15px"></tr>
                <tr ><td colspan="4" style="border:2px solid #000000">
                <table>
                <tr><td colspan="4">
                <table>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <table><tr><td>
                                <b>Start Date:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true" CssClass="textBoxClass"  />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" OnClientClick="return false;" runat="server" ImageUrl="~/Images/calendar.jpg"
                                    Height="20px" Width="30px" />
                            </td>
                            <td>
                                <ajax:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" 
                                    runat="server" PopupButtonID="ImageButton1" Format="dd-MMM-yy">
                                </ajax:CalendarExtender>
                            </td>
                            <td>
                                <b>End Date:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true" CssClass="textBoxClass"  />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" OnClientClick="return false;" runat="server" ImageUrl="~/Images/calendar.jpg"
                                    Height="20px" Width="30px" />
                            </td>
                            <td>
                                <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" 
                                    runat="server" PopupButtonID="ImageButton2" Format="dd-MMM-yy">
                                </ajax:CalendarExtender>
                            </td>
                            <td>
                                <input type="button" onclick="return clearDate()" value="Clear Date" class="buttonClass" />
                                <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Update Search" CssClass="txtTest buttonClass" />
                            </td>
                            </tr></table>
                            </td>
                       </tr>
                    </table>
                </td></tr>
                <tr >
                <td>
                <asp:Chart ID="Chart1" runat="server" Height="250px" Width="400px" CssClass="piChartClass">
                <Series><asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="true" LabelForeColor="Orange"></asp:Series></Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Black" Area3DStyle-Enable3D="true" ></asp:ChartArea>
                </ChartAreas>
                <Legends>
          <asp:Legend Docking="Top" DockedToChartArea="ChartArea1" InterlacedRows="false" IsDockedInsideChartArea="true" LegendStyle="Row" TableStyle="Wide" ForeColor="Orange"></asp:Legend>
      </Legends>
                </asp:Chart>
                </td>
                <td>
                <asp:Chart ID="chartDeviceConduit" runat="server" BackColor="#efefef" Height="250px" Width="400px" CssClass="monthlyChartClass">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td colspan="2"></td>
                </tr>
                <%--<tr><td align="center"><label><b><u>Valid/Invalid Tests(%)</u></b></label></td>
                <td align="center"><label><b><u>Oil & BSW vsGVF Scatter</u></b></label></td><td colspan="2"></td></tr>--%>
                <tr><td align="center"><label><b><u>Valid/Invalid Tests(%)</u></b></label></td>
                <td align="center"><label><b><u>Monthly Stats(well tests/month)</u></b></label></td><td colspan="2"></td></tr>
                </table>
                </td></tr>
                
                
                </table>
            </td>
             
            
            </tr>
               
        </table>
        </td>
        </tr></table>
    </div>
    </div></div>
    <%--<link rel="stylesheet" href="Styles/ini.css"/>
<script type="text/javascript" src="Scripts/library.js"></script>--%>
    <script type="text/javascript" language="javascript">
  <%--  $(function () {
    var pop = function () {
        $('#screen').css({ "display": "block", opacity: 0.7, "width": $(document).width(), "height": $(document).height(),"position":"relative","z-index":"999!important","overflow":"hidden" });
        $('#box').css({ "display": "block" }).click(function () {/* $(this).css("display", "none"); $('#screen').css("display", "none")*/ });
    }
    $('.txtTest').click(pop);
    $(window).resize(function () {
        $('#box').css("display") == 'block' ? pop.call($('.txtTest')) : "";
    });
});--%>
</script>
<ul id="gasProdMenu" class="contextMenu">
    <li ><a href="#aggregateGasProd">Export</a></li>		
    <%--<li><a href="#actualGasProd">Export Actual</a></li>	--%>
</ul>
<ul id="condProdMenu" class="contextMenu">
    <li ><a href="#aggregateCondProd">Export</a></li>		
    <%--<li><a href="#actualCondProd">Export Actual</a></li>	--%>
</ul>
<ul id="waterProdMenu" class="contextMenu">
    <li ><a href="#aggregateWaterProd">Export</a></li>		
    <%--<li><a href="#actualWaterProd">Export Actual</a></li>	--%>
</ul>
<ul id="wetGasProdMenu" class="contextMenu">
    <li ><a href="#aggregateWetGasProd">Export</a></li>		
    <%--<li><a href="#actualWetGasProd">Export Actual</a></li>	--%>
</ul>

<ul id="gasTotalMenu" class="contextMenu">
    <li ><a href="#aggregateGasTotal">Export</a></li>		
    <%--<li><a href="#actualGasTotal">Export Actual</a></li>	--%>
</ul>
<ul id="condTotalMenu" class="contextMenu">
    <li ><a href="#aggregateCondTotal">Export</a></li>		
    <%--<li><a href="#actualCondTotal">Export Actual</a></li>	--%>
</ul>
<ul id="waterTotalMenu" class="contextMenu">
    <li ><a href="#aggregateWaterTotal">Export</a></li>		
    <%--<li><a href="#actualWaterTotal">Export Actual</a></li>	--%>
</ul>
<ul id="wetGasTotalMenu" class="contextMenu">
    <li ><a href="#aggregateWetGasTotal">Export</a></li>		
    <%--<li><a href="#actualWetGasTotal">Export Actual</a></li>	--%>
</ul>

<ul id="piMenu" class="contextMenu">
    <li ><a href="#aggregatePI">Export Aggregate</a></li>		
    <li><a href="#actualPI">Export Actual</a></li>	
</ul>
<ul id="monthlyMenu" class="contextMenu">
<li><a href="#monthly">Export</a></li>
</ul>
<telerik:RadGrid runat="server" ID="gvExport" AutoGenerateColumns="true" ExportSettings-IgnorePaging="true" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-Format="ExcelML"></telerik:RadGrid>
    <asp:Button ID="btn" runat="server" Style="display: none" Text="Export" OnClick="btn_Click" />
    </form>
</body>
</html>
