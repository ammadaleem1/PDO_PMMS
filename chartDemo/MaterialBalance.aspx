<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialBalance.aspx.cs" Inherits="chartDemo.MaterialBalance" %>
 <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function test(sender, eventArgs) {
            var grid = sender;
            var gridSelectedItems = grid.get_selectedItems();
            var MasterTable = grid.get_masterTableView(); 
            var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
            var MaterialBalanceID = MasterTable.getCellByColumnUniqueName(row, "MaterialBalanceID").innerHTML;
            window.location.href = "AddMaterialBalance.aspx?MaterialBalanceID=" + MaterialBalanceID;
        }
        function AddMaterialBalance() {
            window.location.href = "AddMaterialBalance.aspx";
        }
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
   <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridInst">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridInst"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridPI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridPI"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadGrid Width="1000px" runat="server" ID="gvMaterialBalance" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="gvMaterialBalance_NeedDataSource" AutoGenerateColumns="false" OnDeleteCommand="gvMaterialBalance_DeleteCommand" OnItemDataBound="gvMaterialBalance_ItemDataBound" CssClass="chartClass" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-FileExtension="xls" ExportSettings-FileName="MaterialBalance" ExportSettings-Excel-Format="ExcelML" >
        <MasterTableView DataKeyNames="MaterialBalanceID" >
            <Columns>
            <telerik:GridBoundColumn DataField="InputEquation" HeaderText="InputEquation" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="OutputEquation" HeaderText="OutputEquation" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MaterialBalanceID" HeaderText="ID" HeaderStyle-Width="60px" AllowFiltering="false"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MaterialBalanceName" HeaderText="Material Balance" HeaderStyle-Width="200px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CreatedBy" HeaderText="Created By" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModifiedBy" HeaderText="Modified By" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Input Result" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="lblInputResult" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Output Result" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Label ID="lblOutputResult" runat="server" Text="0"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridDateTimeColumn DataField="CreatedDate" HeaderText="Created Date" FilterControlWidth="150px" PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="false"></telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn DataField="ModifiedDate" HeaderText="Modified Date" FilterControlWidth="150px" PickerType="DatePicker" DataFormatString="{0:dd/MM/yyyy}" AllowFiltering="false"></telerik:GridDateTimeColumn>
                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="Delete" CommandName="Delete" ConfirmDialogType="RadWindow" ConfirmText="Delete Record?" Text="Delete" HeaderText="Action"></telerik:GridButtonColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings><ClientEvents OnRowClick="test"></ClientEvents></ClientSettings>
            
    </telerik:RadGrid><br />
    <input type="button" value="Add Material Balance" onclick="AddMaterialBalance()" />
    <ul id="Menu" class="contextMenu">
    <li ><a href="#Export">Export</a></li>	
</ul>
 <asp:Button ID="btn" runat="server" style="display:none" Text="Export" OnClick="btn_Click" />
    </form>
</body>
</html>
