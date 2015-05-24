<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelerikSample.aspx.cs" Inherits="chartDemo.TelerikSample" %>
 <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    <asp:PlaceHolder runat="server">
        function test(sender, eventArgs) {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
    var cell = MasterTable.getCellByColumnUniqueName(row, "Validity_Status");

            alert(cell.innerHTML);
        } </asp:PlaceHolder>
    </script>
    <style type="text/css">
        /*.RadPicker_Default input {width:100px!important;}
        .RadPicker_Default table {width:65%!important;float:left;}
        .rcTable {width:80% !important;}*/
        .RadPicker_Default table {float:left;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--<telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>
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
    <h3>Simple Data Binding:</h3>
    <%--<telerik:RadGrid runat="server" ID="RadGrid1" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnSortCommand="RadGrid1_SortCommand" OnPageIndexChanged="RadGrid1_PageIndexChanged" OnPageSizeChanged="RadGrid1_PageSizeChanged" Visible="false">
    </telerik:RadGrid>
    <br />
    <h3>Advanced Data Binding (using the NeedDataSource event):</h3>--%>
    <div style="width:1200px">
    <telerik:RadGrid runat="server" ID="RadGrid2" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGrid2_NeedDataSource" AutoGenerateColumns="false">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="Validity_Status" HeaderText="Validity Status" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn DataField="start_date" HeaderText="Start Date" FilterControlWidth="250px" PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="end_date" HeaderText="End Date" FilterControlWidth="250px" PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy}"></telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn DataField="Formation_Gas" HeaderText="Formation Gas" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Gross" HeaderText="Gross" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Oil" HeaderText="Oil" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Water" HeaderText="Water" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                
            </Columns>
        </MasterTableView>
        <ClientSettings><ClientEvents OnRowClick="test"></ClientEvents></ClientSettings>
            
    </telerik:RadGrid></div>
    </form>
</body>
</html>
