<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WellDetails.aspx.cs" Inherits="chartDemo.WellDetails"
    Title="Well Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            border-radius: 3px;
            border: 1px solid rgb(0, 0, 0);
            background-color: rgb(177, 206, 222);
            font-size: 12px;
            padding-bottom: 2px;
        }
        .textBoxClass
        {
            border: 1px solid #000000;
            border-radius: 5px;
        }
        .RadPicker_Default table
        {
            float: left;
        }
        .rcTable
        {
            width: 120px !important;
        }
        .deviceClass
        {
        }
        .wellClass
        {
        }
        .piChartClass{}
        .monthlyChartClass{}
        .scaterChartClass{}
          .gvfChartClass{}
        .oilChartClass{}
        .bswChartClass{}
        .gasChartClass{}
    </style>
    <script type="text/javascript" language="javascript">
    <asp:PlaceHolder runat="server">
        function clearDate() {
            document.getElementById('<%= txtStartDate.ClientID %>').value = '';
            document.getElementById('<%= txtEndDate.ClientID %>').value = '';
            return false;
        }
       
        function test(sender, eventArgs) {
                }
                function test(sender, eventArgs) {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
    var separator = MasterTable.getCellByColumnUniqueName(row, "separator_id").innerHTML;
    var startDate = MasterTable.getCellByColumnUniqueName(row,"start_date").innerHTML;
    var endDate = MasterTable.getCellByColumnUniqueName(row,"end_date").innerHTML;
   

    window.open("TagHistogram.aspx?DeviceName="+separator,"_blank","toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1300, height=900");
    }
                </asp:PlaceHolder>
                function openPopupWindow(a)
                {
                window.open("TagHistogram.aspx?DeviceName="+a,"_blank","toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1300, height=900");
                }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".deviceClass").contextMenu({ menu: 'deviceMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".wellClass").contextMenu({ menu: 'wellMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".piChartClass").contextMenu({ menu: 'piMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".monthlyChartClass").contextMenu({ menu: 'monthlyMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
             $(".scaterChartClass").contextMenu({ menu: 'scaterMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
              $(".gvfChartClass").contextMenu({ menu: 'gvfMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
              $(".oilChartClass").contextMenu({ menu: 'oilMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
               $(".bswChartClass").contextMenu({ menu: 'bswMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
                $(".gasChartClass").contextMenu({ menu: 'gasMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
        });
          <asp:PlaceHolder runat="server">
        function contextMenuWork(action, el, pos) {
        var btn = document.getElementById('<%=btn.ClientID%>');
        var chartType = document.getElementById('<%= chartType.ClientID %>');
        switch (action) {

            case "deviceExport":
                {chartType.value="deviceExport";btn.click();}
            case "wellExport":
                {chartType.value="wellExport";btn.click();}

            case "actualPI":
                {chartType.value="actualPI";btn.click();}
            case "aggregatePI":
                {chartType.value="aggregatePI";btn.click();}
                case "monthly":
                {chartType.value="monthly";btn.click();}
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
            }
        }
         </asp:PlaceHolder>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="chartType" runat="server" />
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All"
        EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvWellTestDeviceDataRad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvWellTestDeviceDataRad"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvWellTestDataRad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvWellTestDataRad"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hdnDeviceName" runat="server" Value="%" />
    <div style="margin: 0px auto; width: 1700px;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="padding-right: 10px; width: 1250px">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="padding-left: 10px">
                                <label>
                                    Well Name:</label><asp:Label ID="lblWellName" runat="server" Style="padding-left: 5px;
                                        font-weight: bold"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td align="left" style="padding-left: 10px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <b>Start Date:</b>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true" CssClass="textBoxClass" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ImageButton1" OnClientClick="return false;" runat="server" ImageUrl="~/Images/calendar.jpg"
                                                            Height="20px" Width="30px" />
                                                    </td>
                                                    <td>
                                                        <ajax:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" runat="server"
                                                            PopupButtonID="ImageButton1" Format="dd-MMM-yy">
                                                        </ajax:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <b>End Date:</b>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true" CssClass="textBoxClass" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="ImageButton2" OnClientClick="return false;" runat="server" ImageUrl="~/Images/calendar.jpg"
                                                            Height="20px" Width="30px" />
                                                    </td>
                                                    <td>
                                                        <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" runat="server"
                                                            PopupButtonID="ImageButton2" Format="dd-MMM-yy">
                                                        </ajax:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <input type="button" class="buttonClass" onclick="return clearDate()" value="Clear Date" />
                                                        <asp:Button ID="btnCalculate" CssClass="buttonClass txtTest" runat="server" OnClick="btnCalculate_Click"
                                                            Text="Update Search" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-left: 10px;">
                                <asp:Label ID="lblDevice" Text="Select Device:" runat="server" Font-Bold="true"></asp:Label>
                                <asp:DropDownList ID="ddlDeviceName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDeviceName_SelectedIndexChanged"
                                    CssClass="textBoxClass">
                                    <asp:ListItem Text="All" Value="%" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 150px; vertical-align: top">
                                <telerik:RadGrid runat="server" ID="gvWellTestDeviceDataRad" AllowPaging="True" AllowSorting="true"
                                    AllowFilteringByColumn="false" OnNeedDataSource="RadGrid1_NeedDataSource" AutoGenerateColumns="false"
                                    CssClass="deviceClass" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true"
                                    ExportSettings-Excel-FileExtension="xls" ExportSettings-FileName="Device Details"
                                    ExportSettings-Excel-Format="ExcelML">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="separator_id" HeaderText="Device" HeaderStyle-Width="100px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TotalTests" HeaderText="Total Test" HeaderStyle-Width="80px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Valid" HeaderText="Valid" HeaderStyle-Width="60px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="InValid" HeaderText="InValid" HeaderStyle-Width="60px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NotValidated" HeaderText="Not Validated" HeaderStyle-Width="100px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="minbsw" HeaderText="Min BSW(%)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="maxbsw" HeaderText="Max BSW(%)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="minoil" HeaderText="Min Oil(m3/d)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="maxoil" HeaderText="Max Oil(m3/d)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="mingasout" HeaderText="Min Gas(Sm3/d)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="maxgasout" HeaderText="Max Gas(Sm3/d)" HeaderStyle-Width="100px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="minwater" HeaderText="Min Water(m3/d)" HeaderStyle-Width="110px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="maxwater" HeaderText="Max Water(m3/d)" HeaderStyle-Width="110px"
                                                DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <ClientEvents OnRowClick="test"></ClientEvents>
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </td>
                            <td style="width: 200px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="wellClass">
                                <telerik:RadGrid runat="server" ID="gvWellTestDataRad" AllowPaging="True" AllowSorting="true"
                                    AllowFilteringByColumn="true" OnNeedDataSource="RadGrid2_NeedDataSource" AutoGenerateColumns="false"
                                    OnItemCommand="gvWellTestDataRad_ItemCommand"  ExportSettings-ExportOnlyData="true"
                                    ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-FileExtension="xls"
                                    ExportSettings-FileName="Well Details" ExportSettings-Excel-Format="ExcelML">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="separator_id" HeaderText="Separator" HeaderStyle-Width="130px"
                                                AllowFiltering="true" UniqueName="separator_id" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Validity_Status" HeaderText="Validity Status"
                                                HeaderStyle-Width="130px" AllowFiltering="true">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn DataField="start_date" HeaderText="Start Date" FilterControlWidth="150px"
                                                PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy hh:mm}" UniqueName="start_date">
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridDateTimeColumn DataField="end_date" HeaderText="End Date" FilterControlWidth="150px"
                                                PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy hh:mm}" UniqueName="end_date">
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn DataField="Gross" HeaderText="Gross(m3/d)" HeaderStyle-Width="130px"
                                                AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Oil" HeaderText="Oil(m3/d)" HeaderStyle-Width="130px"
                                                AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Water" HeaderText="Water(m3/d)" HeaderStyle-Width="130px"
                                                AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Formation_Gas" HeaderText="Formation Gas(Sm3/d)"
                                                HeaderStyle-Width="130px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Lift_Gas" HeaderText="Lift Gas(Sm3/d)" HeaderStyle-Width="130px"
                                                AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Separator_Pressure" HeaderText="Separator Pressure(KPa)"
                                                HeaderStyle-Width="130px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="Details" ItemStyle-Width="150px"
                                                CommandName="Details" Text="Details" HeaderText="View Details" HeaderStyle-Width="150px">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                            <td style="width: 235px">
                            </td>
                        </tr>
                        <tr height="90px">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 300px; border: 1px solid #000000">
                                                <asp:Chart ID="Chart1" runat="server" Height="300px" Width="300px" CssClass="piChartClass">
                                                    <Series>
                                                        <asp:Series Name="Series1" ChartType="Pie" IsValueShownAsLabel="true" LabelForeColor="Orange">
                                                        </asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="ChartArea1" BackColor="Black" Area3DStyle-Enable3D="true">
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                    <Legends>
                                                        <asp:Legend Docking="Top" DockedToChartArea="ChartArea1" InterlacedRows="false" IsDockedInsideChartArea="true"
                                                            LegendStyle="Row" TableStyle="Wide" ForeColor="Orange">
                                                        </asp:Legend>
                                                    </Legends>
                                                </asp:Chart>
                                            </td>
                                            <td style="width: 450px; border: 1px solid #000000" align="left">
                                                <asp:Chart ID="chartDeviceConduit" runat="server" BackColor="#efefef" Height="300px"
                                                    Width="450px" CssClass="monthlyChartClass">
                                                    <Series>
                                                        <asp:Series Name="OilSeries" XValueType="DateTime" YValueType="Double" ChartType="Column"
                                                            ChartArea="MainChartArea" Color="Green">
                                                        </asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                                            <AxisX Title="Monthly Stats" TitleFont="Callibri, 11px, style=UnderLine">
                                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                                <MajorGrid LineColor="LightPink" />
                                                            </AxisX>
                                                            <AxisY>
                                                                <MajorGrid LineColor="LightPink" />
                                                            </AxisY>
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                </asp:Chart>
                                            </td>
                                            <td style="border: 1px solid #000000; padding-left: 5px;">
                                                <asp:Chart ID="scaterChart" runat="server" Height="300" Width="450" CssClass="scaterChartClass">
                                                    <Series>
                                                        <asp:Series Name="BSW" ChartType="Point" XValueType="Double" YValueType="Double"
                                                            YAxisType="Primary" ChartArea="MainChartArea">
                                                        </asp:Series>
                                                        <asp:Series Name="Oil" ChartType="Point" XValueType="Double" YValueType="Double"
                                                            YAxisType="Secondary" ChartArea="MainChartArea">
                                                        </asp:Series>
                                                    </Series>
                                                    <ChartAreas>
                                                        <asp:ChartArea Name="MainChartArea">
                                                            <AxisX Title="GVF" TitleAlignment="Center" TitleFont="Callibri, 12px, style=UnderLine">
                                                            </AxisX>
                                                            <AxisY Title="BSW(%)" TitleAlignment="Center" TitleFont="Callibri, 12px, style=UnderLine">
                                                            </AxisY>
                                                            <AxisY2 Title="Oil(m3/day)" TitleAlignment="Center" TitleFont="Callibri, 12px, style=UnderLine">
                                                            </AxisY2>
                                                        </asp:ChartArea>
                                                    </ChartAreas>
                                                    <Legends>
                                                        <asp:Legend Docking="Bottom" InterlacedRows="false" Alignment="Center" IsDockedInsideChartArea="true"
                                                            LegendStyle="Row" TableStyle="Wide" ForeColor="Black">
                                                        </asp:Legend>
                                                    </Legends>
                                                </asp:Chart>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                    </table>
                </td>
                <td valign="top" style="width: 450px;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="border: 1px solid #000000;">
                                <asp:Chart ID="chartGVFTrend" runat="server" BackColor="#efefef" Height="225px" Width="450px" CssClass="gvfChartClass">
                                    <Series>
                                        <asp:Series Name="GVFSeries" XValueType="DateTime" YValueType="Double" ChartType="Column"
                                            ChartArea="MainChartArea" Color="Green" Legend="Pressure">
                                        </asp:Series>
                                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX Title="GVF(%)" TitleFont="Callibri, 12px, style=UnderLine">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisX>
                                            <AxisY>
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                        <tr height="15px">
                        </tr>
                        <tr>
                            <td align="left" style="border: 1px solid #000000;">
                                <asp:Chart ID="chartOilTrend" runat="server" BackColor="#efefef" Height="225px" Width="450px" CssClass="oilChartClass">
                                    <Series>
                                        <asp:Series Name="OilSeries" XValueType="DateTime" YValueType="Double" ChartType="Column"
                                            ChartArea="MainChartArea" Color="Green">
                                        </asp:Series>
                                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX Title="Oil(m3/day)" TitleFont="Callibri, 12px, style=UnderLine">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisX>
                                            <AxisY>
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                        <tr height="15px">
                        </tr>
                        <tr>
                            <td align="left" style="border: 1px solid #000000;">
                                <asp:Chart ID="chartBSWTrend" runat="server" BackColor="#efefef" Height="225px" Width="450px" CssClass="bswChartClass">
                                    <Series>
                                        <asp:Series Name="BSWSeries" XValueType="DateTime" YValueType="Double" ChartType="Column"
                                            ChartArea="MainChartArea" Color="Green">
                                        </asp:Series>
                                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX Title="BSW(%)" TitleFont="Callibri, 12px, style=UnderLine">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisX>
                                            <AxisY>
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                        <tr height="12px">
                        </tr>
                        <tr>
                            <td align="left" style="border: 1px solid #000000;">
                                <asp:Chart ID="chartGasOutTrend" runat="server" BackColor="#efefef" Height="225px"
                                    Width="450px" CssClass="gasChartClass">
                                    <Series>
                                        <asp:Series Name="GasOutSeries" XValueType="DateTime" YValueType="Double" ChartType="Column"
                                            ChartArea="MainChartArea" Color="Green">
                                        </asp:Series>
                                        <asp:Series BorderWidth="1" Name="TrendLine" ChartType="Line" Color="Red" MarkerSize="2">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX Title="Gas(sm3/day)" TitleFont="Callibri, 12px, style=UnderLine">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisX>
                                            <AxisY>
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <ul id="deviceMenu" class="contextMenu">
        <li><a href="#deviceExport">Export</a></li></ul>
    <ul id="wellMenu" class="contextMenu">
        <li><a href="#wellExport">Export</a></li></ul>
    <ul id="piMenu" class="contextMenu">
        <li><a href="#aggregatePI">Export Aggregate</a></li><li><a href="#actualPI">Export Actual</a></li>
    </ul>
    <ul id="monthlyMenu" class="contextMenu">
<li><a href="#monthly">Export</a></li>
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
  <telerik:RadGrid runat="server" ID="gvExport" AutoGenerateColumns="true" ExportSettings-IgnorePaging="true" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-Format="ExcelML"></telerik:RadGrid>
    <asp:Button ID="btn" runat="server" Style="display: none" Text="Export" OnClick="btn_Click" />
    </form>
</body>
</html>
