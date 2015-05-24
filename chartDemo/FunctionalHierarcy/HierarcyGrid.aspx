<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="HierarcyGrid.aspx.cs" Inherits="chartDemo.FunctionalHierarcy.HierarcyGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
<title>Functional Hierarcy</title>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvFunHierarcy">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvFunHierarcy" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Functional Hierarcy</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-12">
<telerik:RadGrid ID="gvFunHierarcy" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false" CssClass="chartClass" ExportSettings-ExportOnlyData="true" ExportSettings-OpenInNewWindow="true" ExportSettings-Excel-FileExtension="xls" ExportSettings-FileName="Instruments" ExportSettings-Excel-Format="ExcelML">
<MasterTableView DataKeyNames="sPITag">
    <Columns>
    <telerik:GridBoundColumn DataField="sInstrumentType" HeaderText="Instrument Type" UniqueName="sInstrumentType"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sMeasurementClass1" HeaderText="Secondary Function"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sMeasurementClass2" HeaderText="Teritary Function" UniqueName="sMeasurementClass2"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sProcessFunctionType" HeaderText="Process Type"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sMechanicalEquipment" HeaderText="Mechanical Eq" UniqueName="sMechanicalEquipment"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sService" HeaderText="Service"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sPITag" HeaderText="Instrument Tag" UniqueName="sPITag" ></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sCluster" HeaderText="Cluster"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sStation" HeaderText="Station"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="sTagNumber" HeaderText="TagNumber" UniqueName="sTagNumber"></telerik:GridBoundColumn>
    </Columns>
     <NoRecordsTemplate>
           <div style="text-align:center;">No records found.</div>  
    </NoRecordsTemplate>
</MasterTableView>
<ClientSettings>
    <ClientEvents OnRowClick="test"></ClientEvents>
</ClientSettings>
</telerik:RadGrid>
</div></div>
 <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Skin="Black" Transparency="50">
</telerik:RadAjaxLoadingPanel> --%>
 <ul id="Menu" class="contextMenu">
    <li ><a href="#Export">Export</a></li>	
</ul>
 <asp:Button ID="btn" runat="server" style="display:none" Text="Export" OnClick="btn_Click" />
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
      <script type="text/javascript" language="javascript">
          function test(sender, eventArgs) {
              var grid = sender;
              var gridSelectedItems = grid.get_selectedItems();
              var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
              var instag = MasterTable.getCellByColumnUniqueName(row, "sTagNumber").innerHTML;
              var pitag = MasterTable.getCellByColumnUniqueName(row, "sPITag").innerHTML;
              var device = MasterTable.getCellByColumnUniqueName(row, "sMechanicalEquipment").innerHTML;
              var instype = MasterTable.getCellByColumnUniqueName(row, "sInstrumentType").innerHTML;
              var tertiary = MasterTable.getCellByColumnUniqueName(row, "sMeasurementClass2").innerHTML;


              //window.open("IntermediateLinks.aspx?DeviceName=" + device + "&tagNumber=" + instag + "&pitag=" + pitag, "_blank", "toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=500, height=400");
              window.open("../IntermediateLinks.aspx?DeviceName=" + device + "&tagNumber=" + instag + "&pitag=" + pitag + "&instype="+instype + "&tertiary="+tertiary, "intermediate", "toolbar=no, scrollbars=no, resizable=no, top=100, left=300, width=300, height=250");
          }</script>
     <style type="text/css">
          .chartClass{}
     </style>
</asp:Content>
