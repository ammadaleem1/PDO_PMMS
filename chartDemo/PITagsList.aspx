<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PITagsList.aspx.cs"
    Inherits="chartDemo.PITagsList" Title="Operating Envelope" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        
    </script>
    <style type="text/css">
        body
        {
            font-family: Calibri;
        }
        .PropertyLabel
        {
            color: Red;
        }
        .PropertyTable
        {
            background-color: #d2d2d2;
            width: 1000px;
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
        .chartClass
        {
        }
    </style>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function test(sender, eventArgs) {
            var grid = sender;
            var gridSelectedItems = grid.get_selectedItems();
            var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
            var TagName = MasterTable.getCellByColumnUniqueName(row, "PI_Tag No").innerHTML;
            window.open("OperatingEnvelop.aspx?TagName=" + TagName, "_blank", "toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1300, height=900");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnTag" runat="server" />
    <telerik:RadScriptManager ID="ScriptManager" runat="server"></telerik:RadScriptManager>
    <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvPITags">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvPITags"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div style="width: 1350px; margin: 0 auto">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="padding-right: 45px; width: 800px;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid runat="server" ID="gvTags" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="false"
        OnNeedDataSource="gvTags_NeedDataSource" AutoGenerateColumns="false" >
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="PI_Tag No" HeaderText="PI Tags" HeaderStyle-Width="180px" AllowFiltering="false"></telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings><ClientEvents OnRowClick="test"></ClientEvents></ClientSettings>
            
    </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
