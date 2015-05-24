<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDetails.aspx.cs"
    Inherits="chartDemo.TestDetails" Title="Test Details" %>

   <%-- <%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Interface" Assembly="obout_Interface" %>--%>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
    <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="jQuery/jquery-ui.css" />
<script src="jQuery/jquery-1.9.1.js" type="text/javascript"></script>
<script src="jQuery/jquery-ui.js" type="text/javascript"></script>
<link href="Styles/Site.css" rel="stylesheet" type="text/css" />
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
       .RadPicker_Default table {float:left;}
       .chartClass{}
    </style>
    <script type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">
    <asp:PlaceHolder runat="server">
        function test(sender, eventArgs) {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
    opener.document.getElementById('<%= Request["txtStartDate"] %>').value = MasterTable.getCellByColumnUniqueName(row, "start_date").innerHTML;
            opener.document.getElementById('<%= Request["txtEndDate"] %>').value = MasterTable.getCellByColumnUniqueName(row, "end_date").innerHTML;
            opener.testChildCall();
            self.close();
        } </asp:PlaceHolder>
    </script>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="JQuery/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="JQuery/jquery.contextMenu.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".chartClass").contextMenu({ menu: 'Menu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
        });
          <asp:PlaceHolder runat="server">
        function contextMenuWork(action, el, pos) {
        var btn = document.getElementById('<%=btn.ClientID%>');
        btn.click();
        }
         </asp:PlaceHolder>
     </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="true" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                Conduit Name:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlConduit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlConduit_SelectedIndexChanged" CssClass="textBoxClass">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
    <telerik:RadGrid runat="server" ID="gvWellTestDataRad" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGrid2_NeedDataSource" AutoGenerateColumns="false" CssClass="chartClass" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-FileExtension="xls" ExportSettings-FileName="Test Details" ExportSettings-Excel-Format="ExcelML">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Validity_Status" HeaderText="Validity Status" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="start_date" HeaderText="Start Date" FilterControlWidth="250px" PickerType="DatePicker" ></telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="end_date" HeaderText="End Date" FilterControlWidth="250px" PickerType="DatePicker" ></telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="Formation_Gas" HeaderText="Formation Gas(Sm3/d)" HeaderStyle-Width="100px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Gross" HeaderText="Gross(m3/d)" HeaderStyle-Width="100px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Oil" HeaderText="Oil(m3/d)" HeaderStyle-Width="100px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Water" HeaderText="Water(m3/d)" HeaderStyle-Width="100px" AllowFiltering="true" DataType="System.Decimal" DataFormatString="{0:###,###.##}"></telerik:GridBoundColumn>
                
            </Columns>
        </MasterTableView>
        <ClientSettings><ClientEvents OnRowClick="test"></ClientEvents></ClientSettings>
            
    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            
        </table>
    </div>
    <ul id="Menu" class="contextMenu">
    <li ><a href="#Export">Export</a></li>	
</ul>
 <asp:Button ID="btn" runat="server" style="display:none" Text="Export" OnClick="btn_Click" />
    </form>
</body>
</html>
