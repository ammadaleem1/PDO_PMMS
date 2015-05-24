<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminSite.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="chartDemo.AdminModule.MFMPointsViews.DataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMFMPoints">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMFMPoints" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">MFM Points</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
        <div class="col-lg-12" style="padding-bottom:10px;">
           <asp:Button ID="btnAdd" runat="server" Text="Add New MFM Point" 
                CssClass="btn btn-primary" onclick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;
           <a class="btn btn-primary" href="ImportData.aspx">Import Data</a>
           <br />
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-12">
<telerik:RadGrid ID="gvMFMPoints" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false"
OnItemCommand="gvMFMPoints_RowCommand">
<MasterTableView DataKeyNames="MFMPointsID" >
    <Columns>
    <telerik:GridBoundColumn DataField="MeterName" HeaderText="MeterName"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MeasurementSection" HeaderText="Measurement Section"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="PointGas" HeaderText="Point Gas"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="PointOil" HeaderText="Point Oil"></telerik:GridBoundColumn>
    <telerik:GridTemplateColumn HeaderText="Actions" AllowFiltering="false">
        <ItemTemplate>
            <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" Text="Edit"
            CommandName="EditPoint" CommandArgument='<%# Eval("MFMPointsID") %>' />
            <asp:LinkButton ID="btnDelete" ToolTip="Delete" runat="server" Text="Delete"
            OnClientClick="javascript:return confirm('Are you sure you want to delete this record?')"
            CommandName="DeletePoint" CommandArgument='<%# Eval("MFMPointsID") %>' />
        </ItemTemplate>
    </telerik:GridTemplateColumn>
    </Columns>
     <NoRecordsTemplate>
           <div style="text-align:center;">No records found.</div>
    </NoRecordsTemplate>
</MasterTableView>
</telerik:RadGrid>
</div></div>
 <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Transparency="50">
</telerik:RadAjaxLoadingPanel> 

</asp:Content>
