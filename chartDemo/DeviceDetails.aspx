<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeviceDetails.aspx.cs"
    Inherits="chartDemo.DeviceDetails" Title="Device Details" %>

   <%-- <%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/Controls/MechanicalDetails.ascx" TagName="MechDetails" TagPrefix="uc1" %>
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
   <%-- <script src="JQuery/jquery.simplemodal-1.1.1.js" type="text/javascript"></script>--%>
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
        .scaterChartClass{}
        .gvfChartClass{}
        .oilChartClass{}
        .bswChartClass{}
        .gasChartClass{}
        .monthlyChartClass{}
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
       </asp:PlaceHolder>
//        function Grid1_Select(sender, records) {
//                var record = records[0];
//                var url = record.conduit_name;
//                //location.href = url;
//                //alert(url);
//                window.open("welldetails.aspx?WellName="+url,"_blank","toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1300, height=900");
//                }
function test(sender, eventArgs) {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
    var conduitName = MasterTable.getCellByColumnUniqueName(row, "conduit_name").innerHTML;
    window.open("welldetails.aspx?WellName="+conduitName,"_blank","toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1300, height=900");
    }
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(".piChartClass").contextMenu({ menu: 'piMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".scaterChartClass").contextMenu({ menu: 'scaterMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
             $(".gvfChartClass").contextMenu({ menu: 'gvfMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
              $(".oilChartClass").contextMenu({ menu: 'oilMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
               $(".bswChartClass").contextMenu({ menu: 'bswMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
                $(".gasChartClass").contextMenu({ menu: 'gasMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
                $(".monthlyChartClass").contextMenu({ menu: 'monthlyMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
        });
          <asp:PlaceHolder runat="server">
        function contextMenuWork(action, el, pos) {
        var btn = document.getElementById('<%=btnPIChart.ClientID%>');
        var chartType = document.getElementById('<%= chartType.ClientID %>');
        switch (action) {

            case "aggregatePI":
                {chartType.value="aggregatePI";btn.click();}
            case "actualPI":
                {chartType.value="actualPI";btn.click();}

            case "actualScater":
                {chartType.value="actualScater";btn.click();}
            case "aggregateScater":
                {chartType.value="aggregateScater";btn.click();}

            case "actualGVF":
                {chartType.value="actualGVF";btn.click();}
            case "aggregateGVF":
                {chartType.value="aggregateGVF";btn.click();}

            case "actualOil":
                {chartType.value="actualOil";btn.click();}
            case "aggregateOil":
                {chartType.value="aggregateOil";btn.click();}

            case "actualBSW":
                {chartType.value="actualBSW";btn.click();}
            case "aggregateBSW":
                {chartType.value="aggregateBSW";btn.click();}

            case "actualGas":
                {chartType.value="actualGas";btn.click();}
            case "aggregateGas":
                {chartType.value="aggregateGas";btn.click();}
            case "monthly" :
                {chartType.value="monthly";btn.click();}
            }
        }
         </asp:PlaceHolder>
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:HiddenField ID="chartType" runat="server" />
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <%--<telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
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
    <table border="0" cellpadding="0" cellspacing="0"><tr><td valign="top" style="padding-right:10px">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr><td>
        <uc1:MechDetails ID="ucMechDetails" runat="server"></uc1:MechDetails>
        </td></tr>
            <tr>
                <td>
                <table><tr><td>
                    <table>
                        <tr>
                            <%--<td>
                                <asp:Label ID="lblConduit" Text="Select Conduit" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlConduit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConduit_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>--%>
                            <td>
                             <asp:RadioButtonList ID="rbtnAbondonWell" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbtnAbondonWell_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Include Abandoned Well" Value="true" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exclude Abandoned Well" Value="false"></asp:ListItem>
                             </asp:RadioButtonList>
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
                    </td>
                    <%--<td>
                        <table border="0" width="695px" class="tble" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bottomtd"></td><td class="bottomtd"><b>Min</b></td><td class="bottomtd"><b>Min(Non Zero)</b></td><td class="bottomtd" style="border-right:2px solid"><b>Max</b></td>  <td class="bottomtd"></td><td class="bottomtd"><b>Min</b></td><td class="bottomtd"><b>Min(Non Zero)</b></td><td class="bottomtd"><b>Max</b></td>
                            </tr>
                            <tr>
                                <td class="lefttd"><b>BSW(%)</b></td>
                                <td id="minBSW" runat="server">0</td>
                                <td id="minNonBSW" runat="server">0</td>
                                <td id="maxBSW" runat="server" style="border-right:2px solid">0</td>

                                  <td><b>Oil(m3/day)</b></td>
                                  <td id="minOil" runat="server">0</td>
                                  <td id="minNonOil" runat="server">0</td>
                                  <td id="maxOil" runat="server">0</td>
                            </tr>
                            <tr>
                            <td class="lefttd"><b>Water(m3/day)</b></td>
                                <td id="minWater" runat="server">0</td>
                                <td id="minNonWater" runat="server">0</td>
                                <td id="maxWater" runat="server" style="border-right:2px solid">0</td>

                                  <td><b>Gas(sm3/day)</b></td>
                                  <td id="minGas" runat="server">0</td>
                                  <td id="minNonGas" runat="server">0</td>
                                  <td id="maxGas" runat="server">0</td>
                            </tr>
                        </table>
                    </td>--%>
                    <td>
                        <table border="0" width="330" class="tble" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bottomtd"></td><td class="bottomtd"><b>Min</b></td><td class="bottomtd"><b>Min(Non Zero)</b></td><td class="bottomtd"><b>Max</b></td>
                            </tr>
                            <tr>
                                <td class="lefttd"><b>BSW(%)</b></td>
                                <td id="minBSW" runat="server">0</td>
                                <td id="minNonBSW" runat="server">0</td>
                                <td id="maxBSW" runat="server" >0</td>
                            </tr>
                            <tr>
                            <td class="lefttd"><b>Water(m3/day)</b></td>
                                <td id="minWater" runat="server">0</td>
                                <td id="minNonWater" runat="server">0</td>
                                <td id="maxWater" runat="server">0</td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="0" width="330" class="tble" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bottomtd"></td><td class="bottomtd"><b>Min</b></td><td class="bottomtd"><b>Min(Non Zero)</b></td><td class="bottomtd"><b>Max</b></td>
                            </tr>
                            <tr>
                                  <td class="lefttd"><b>Oil(m3/day)</b></td>
                                  <td id="minOil" runat="server">0</td>
                                  <td id="minNonOil" runat="server">0</td>
                                  <td id="maxOil" runat="server">0</td>
                            </tr>
                            <tr>

                                  <td class="lefttd"><b>Gas(sm3/day)</b></td>
                                  <td id="minGas" runat="server">0</td>
                                  <td id="minNonGas" runat="server">0</td>
                                  <td id="maxGas" runat="server">0</td>
                            </tr>
                        </table>
                    </td>
                    
                    </tr></table>
                </td>
            </tr>
            <tr></tr>
            <tr><td align="left" style="width:1400px!important;">
            <asp:Button ID="lnk1" runat="server" Text="Export to Excel" OnClick="lnk_Click1"/>
            </td></tr>
            <tr>
                <td style="width:1400px!important">
                   <%-- <obout:Grid ID="gvWellTestData" runat="server" CallbackMode="true" Serialize="true"
        AllowFiltering="false" FolderStyle="Styles/premiere_blue" AutoGenerateColumns="false"
        ShowLoadingMessage="false" AllowAddingRecords="false" OnRebind="RebindGrid" AllowPaging="true" AllowPageSizeSelection="false" PageSize="10" >
        <ClientSideEvents OnClientSelect="Grid1_Select" ExposeSender="true" />
        <Columns>
            <obout:Column DataField="conduit_name" HeaderText="Conduit" runat="server" Width="108px" />
            <obout:Column DataField="TotalTests" HeaderText="Total Tests" Width="108" runat="server" />
            <obout:Column DataField="Valid" HeaderText="Valid" Width="108" runat="server" />
            <obout:Column ID="Column4" DataField="InValid" HeaderText="InValid" Width="108"  runat="server" />
            <obout:Column ID="Column5" DataField="NotValidated" HeaderText="Not Validated" Width="108"  runat="server" />
            <obout:Column ID="Column6" DataField="minbsw" HeaderText="Min BSW" Width="108"  runat="server" />
                <obout:Column ID="Column7" DataField="maxbsw" HeaderText="Max BSW" Width="108"  runat="server" />
                <obout:Column ID="Column1" DataField="minoil" HeaderText="Min Oil" Width="108"  runat="server" />
                <obout:Column ID="Column2" DataField="maxoil" HeaderText="Max Oil" Width="108"  runat="server" />
                <obout:Column ID="Column3" DataField="mingasout" HeaderText="Min Gas" Width="108"  runat="server" />
                <obout:Column ID="Column8" DataField="maxgasout" HeaderText="Max Gas" Width="108"  runat="server" />
                <obout:Column ID="Column9" DataField="minwater" HeaderText="Min Water" Width="108"  runat="server" />
                <obout:Column ID="Column10" DataField="maxwater" HeaderText="Max Water" Width="108"  runat="server" />
        </Columns>
    </obout:Grid>--%>
            
   <%-- <telerik:RadGrid runat="server" ID="gvWellTestDataRad" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGrid2_NeedDataSource" AutoGenerateColumns="false" OnExcelMLWorkBookCreated="RadGrid1_ExcelMLWorkBookCreated" ExportSettings-Excel-Format="ExcelML" ExportSettings-Excel-FileExtension="xlsx" ExportSettings-FileName="GridData" ExportSettings-IgnorePaging="true" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true">--%>
         <telerik:RadGrid runat="server" ID="gvWellTestDataRad" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGrid2_NeedDataSource" AutoGenerateColumns="false"  ExportSettings-FileName="GridData" ExportSettings-IgnorePaging="true"  ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Csv-FileExtension="xls">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="conduit_name" HeaderText="Conduit" HeaderStyle-Width="80px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TotalTests" HeaderText="Total Tests" HeaderStyle-Width="80px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Valid" HeaderText="Valid" HeaderStyle-Width="80px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="InValid" HeaderText="InValid" HeaderStyle-Width="80px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NotValidated" HeaderText="Not Validated" HeaderStyle-Width="80px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="minbsw" HeaderText="Min BSW(%)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="maxbsw" HeaderText="Max BSW(%)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="minoil" HeaderText="Min Oil(m3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="maxoil" HeaderText="Max Oil(m3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="mingasout" HeaderText="Min Gas(Sm3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="maxgasout" HeaderText="Max Gas(Sm3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="minwater" HeaderText="Min Water(m3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="maxwater" HeaderText="Max Water(m3/d)" HeaderStyle-Width="80px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                
            </Columns>
        </MasterTableView>
        <ClientSettings><ClientEvents OnRowClick="test"></ClientEvents></ClientSettings>
            
    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
            <td>
            <table>
            <%--<tr>--%>
            <%--<td style="width:300px;border:1px solid #000000">
                <asp:Chart ID="Chart1" runat="server" Height="300px" Width="275px" >
                <Series><asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="true" LabelForeColor="Orange"></asp:Series></Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Black" Area3DStyle-Enable3D="true" ></asp:ChartArea>
                </ChartAreas>
                <Legends>
          <asp:Legend Docking="Top" DockedToChartArea="ChartArea1" InterlacedRows="false" IsDockedInsideChartArea="true" LegendStyle="Row" TableStyle="Wide" ForeColor="Orange"></asp:Legend>
      </Legends>
                </asp:Chart></td>--%>
                <%--<td style="width:240px;border:1px solid #000000" align="left">
                    <table><tr>
                    <td style="width:70px"></td><td style="width:70px">Min</td><td style="width:70px">Min(Non Zero)</td><td style="width:70px">Max</td></tr>
                    <tr><td style="width:70px">BS&W</td><td style="width:70px" id="minBSW" runat="server">0</td><td style="width:70px"  id="minNonBSW" runat="server">1</td><td style="width:70px" id="maxBSW" runat="server">10</td></tr>
                    <tr><td style="width:70px">Gas</td><td style="width:70px" id="minGas" runat="server">0</td><td style="width:70px"  id="minNonGas" runat="server">1</td><td style="width:70px" id="maxGas" runat="server">10</td></tr>
                    <tr><td style="width:70px">Water</td><td style="width:70px" id="minWater" runat="server">0</td><td style="width:70px"  id="minNonWater" runat="server">1</td><td style="width:70px" id="maxWater" runat="server">10</td></tr>
                    <tr><td style="width:70px">Oil</td><td style="width:70px" id="minOil" runat="server">0</td><td style="width:70px"  id="minNonOil" runat="server">1</td><td style="width:70px" id="maxOil" runat="server">10</td></tr>
                    </table>
                    

                </td>--%>
                <%--<td style="border:1px solid #000000">
                <asp:Chart ID="scaterChart" runat="server" Height="300" Width="350">
                <Series>
                <asp:Series Name="BSW" ChartType="Point" XValueType="Double" YValueType="Double" YAxisType="Primary" ChartArea="MainChartArea"></asp:Series>
                <asp:Series Name="Oil" ChartType="Point" XValueType="Double" YValueType="Double" YAxisType="Secondary" ChartArea="MainChartArea"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="MainChartArea"><AxisX Title="GVF" TitleAlignment="Center"></AxisX><AxisY Title="BSW" TitleAlignment="Center"></AxisY><AxisY2 Title="Oil" TitleAlignment="Center"></AxisY2></asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Docking="Bottom" InterlacedRows="false" Alignment="Center" IsDockedInsideChartArea="true" LegendStyle="Row" TableStyle="Wide" ForeColor="Black"></asp:Legend>
                </Legends>
                </asp:Chart>
                </td>--%>
                <%-- <td style="border:1px solid #000000">
                   <asp:Chart ID="chartDeviceConduit" runat="server" BackColor="#efefef" Height="300px" Width="500px">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Monthly Stats" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>--%>
               <%-- </tr>--%>
                
                
                
                
                
                
                <tr>
                    <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGVFTrend" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="gvfChartClass">
                    <Series>
                        <asp:Series Name="GVFSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" Legend="Pressure"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="GVF(%)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartOilTrend" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="oilChartClass">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Oil(m3/day)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartBSWTrend" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="bswChartClass">
                    <Series>
                        <asp:Series Name="BSWSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="BSW(%)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                <td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGasOutTrend" runat="server" BackColor="#efefef" Height="250px" Width="345px" CssClass="gasChartClass">
                    <Series>
                        <asp:Series Name="GasOutSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" MarkerSize="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Gas(sm3/day)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
                </tr>
                
                
                
                
                </table>
            </td>
             
            
            </tr>
               
        </table>
        </td>
        <td valign="bottom">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
            <td style="border-color:1px solid #000000">
                <%--<table><tr>
                    <td style="width:70px"></td><td style="width:70px">Min</td><td style="width:70px">Min(Non Zero)</td><td style="width:70px">Max</td></tr>
                    <tr><td style="width:70px">BS&W</td><td style="width:70px" id="minBSW" runat="server">0</td><td style="width:70px"  id="minNonBSW" runat="server">1</td><td style="width:70px" id="maxBSW" runat="server">10</td></tr>
                    <tr><td style="width:70px">Gas</td><td style="width:70px" id="minGas" runat="server">0</td><td style="width:70px"  id="minNonGas" runat="server">1</td><td style="width:70px" id="maxGas" runat="server">10</td></tr>
                    <tr><td style="width:70px">Water</td><td style="width:70px" id="minWater" runat="server">0</td><td style="width:70px"  id="minNonWater" runat="server">1</td><td style="width:70px" id="maxWater" runat="server">10</td></tr>
                    <tr><td style="width:70px">Oil</td><td style="width:70px" id="minOil" runat="server">0</td><td style="width:70px"  id="minNonOil" runat="server">1</td><td style="width:70px" id="maxOil" runat="server">10</td></tr>
                    </table>--%>
            </td>
            <%--<td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGVFTrend" runat="server" BackColor="#efefef" Height="200px" Width="500px">
                    <Series>
                        <asp:Series Name="GVFSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" Legend="Pressure"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="GVF Chart" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>--%>
            </tr>
            <tr height="10px"></tr>
            <tr>
            <td style="border-bottom-color:1px solid #000000">
                
                    <asp:Chart ID="Chart1" runat="server" Height="200px" Width="400px" CssClass="piChartClass" >
                <Series><asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="true" LabelForeColor="Orange"></asp:Series></Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="Black" Area3DStyle-Enable3D="true" ></asp:ChartArea>
                </ChartAreas>
                <Legends>
          <asp:Legend Docking="Top" DockedToChartArea="ChartArea1" InterlacedRows="false" IsDockedInsideChartArea="true" LegendStyle="Row" TableStyle="Wide" ForeColor="Orange"></asp:Legend>
      </Legends>
                </asp:Chart>
            </td>
            <%--<td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartOilTrend" runat="server" BackColor="#efefef" Height="200px" Width="500px">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Oil Chart" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>--%>
            </tr>
            <tr><td align="center"><label><b><u>Valid/Invalid Tests(%)</u></b></label></td></tr>
            <tr height="25px"></tr>
            <tr>
            <%--<td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartBSWTrend" runat="server" BackColor="#efefef" Height="200px" Width="500px">
                    <Series>
                        <asp:Series Name="BSWSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="BSW Chart" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>--%>
                <td style="border:1px solid #000000">
                    <asp:Chart ID="scaterChart" runat="server" Height="200" Width="400" CssClass="scaterChartClass">
                <Series>
                <asp:Series Name="BSW" ChartType="Point" XValueType="Double" YValueType="Double" YAxisType="Primary" ChartArea="MainChartArea"></asp:Series>
                <asp:Series Name="Oil" ChartType="Point" XValueType="Double" YValueType="Double" YAxisType="Secondary" ChartArea="MainChartArea"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="MainChartArea"><AxisX Title="GVF" TitleAlignment="Center"></AxisX><AxisY Title="BSW(%)" TitleAlignment="Center"></AxisY><AxisY2 Title="Oil(m3/day)" TitleAlignment="Center"></AxisY2></asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend Docking="Bottom" InterlacedRows="false" Alignment="Center" IsDockedInsideChartArea="true" LegendStyle="Row" TableStyle="Wide" ForeColor="Black"></asp:Legend>
                </Legends>
                </asp:Chart>
                </td>
            </tr>
            <tr><td align="center"><label><b><u>Oil & BSW vsGVF Scatter</u></b></label></td></tr>
            <tr height="30px"></tr>
            <tr>
            <td style="border:1px solid #000000">
                 <asp:Chart ID="chartDeviceConduit" runat="server" BackColor="#efefef" Height="200px" Width="400px" CssClass="monthlyChartClass">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Monthly Stats(well tests/month)" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <%--<td align="left" style="border:1px solid #000000">
                <asp:Chart ID="chartGasOutTrend" runat="server" BackColor="#efefef" Height="200px" Width="500px">
                    <Series>
                        <asp:Series Name="GasOutSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" MarkerSize="2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Gas Out Chart" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>--%>
            </tr>
            <%--<tr>
                <td align="left">
                    <asp:Chart ID="chartDeviceConduit" runat="server" BackColor="#efefef" Height="300px" Width="500px">
                    <Series>
                        <asp:Series Name="OilSeries" XValueType="DateTime"  YValueType="Double" ChartType="Column" ChartArea="MainChartArea" Color="Green" ></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="Monthly Stats" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
            </tr>--%>
            <%--<tr>
            <td align="left">
                <asp:Chart ID="chart2" runat="server" BackColor="#efefef" Height="300px" Width="500px">
                    <Series>
                        <asp:Series Name="BSWSeries" XValueType="DateTime"  YValueType="Double" ChartType="Point" ChartArea="MainChartArea" Color="Green" MarkerSize="1"></asp:Series>
                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Orange" MarkerSize="5"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="MainChartArea" BackColor="Black"><AxisX Title="BSW Chart" TitleFont="Callibri, 12px, style=UnderLine"><LabelStyle Format="dd/MM/yyyy\\nhh:mm"  /><MajorGrid LineColor="LightPink" /></AxisX><AxisY><MajorGrid LineColor="LightPink" /></AxisY></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                </td>
            </tr>--%>
            </table>
        </td>
        </tr></table>
    </div>
    </div></div>
 <ul id="piMenu" class="contextMenu">
    <li ><a href="#aggregatePI">Export Aggregate</a></li>		
    <li><a href="#actualPI">Export Actual</a></li>	
</ul>
 <ul id="scaterMenu" class="contextMenu">
    <li ><a href="#aggregateScater">Export Aggregate</a></li>		
    <li><a href="#actualScater">Export Actual</a></li>	
</ul>
<ul id="gvfMenu" class="contextMenu">
    <li ><a href="#aggregateGVF">Export Aggregate</a></li>		
    <li><a href="#actualGVF">Export Actual</a></li>	
</ul>
<ul id="oilMenu" class="contextMenu">
    <li ><a href="#aggregateOil">Export Aggregate</a></li>		
    <li><a href="#actualOil">Export Actual</a></li>	
</ul>
<ul id="bswMenu" class="contextMenu">
    <li ><a href="#aggregateBSW">Export Aggregate</a></li>		
    <li><a href="#actualBSW">Export Actual</a></li>	
</ul>
<ul id="gasMenu" class="contextMenu">
    <li ><a href="#aggregateGas">Export Aggregate</a></li>		
    <li><a href="#actualGas">Export Actual</a></li>	
</ul>
<ul id="monthlyMenu" class="contextMenu">
<li><a href="#monthly">Export</a></li>
</ul>
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
     <telerik:RadGrid runat="server" ID="gvExport" AutoGenerateColumns="true"></telerik:RadGrid>
     <asp:Button ID="btnPIChart" runat="server" style="display:none" Text="Export Chart" OnClick="btnPIChart_Click" />
    </form>
</body>
</html>
