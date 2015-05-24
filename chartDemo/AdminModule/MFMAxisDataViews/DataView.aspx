<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminSite.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="chartDemo.AdminModule.MFMAxisDataViews.DataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMFMAxisData">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMFMAxisData" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">MFM Axis Data</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
        <div class="col-lg-12" style="padding-bottom:10px;">
           <asp:Button ID="btnAdd" runat="server" Text="Add New MFM Axis" 
                CssClass="buttongradient" onclick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;
           <a class="buttongradient" href="ImportData.aspx">Import Data</a>
           <br />
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-12">
<telerik:RadGrid ID="gvMFMAxisData" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false"
OnItemCommand="gvMFMAxisData_RowCommand">
<MasterTableView DataKeyNames="Id" >
    <Columns>
    <telerik:GridBoundColumn DataField="MeterName" HeaderText="MeterName"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MinValue" HeaderText="Min Value"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MaxValue" HeaderText="Max Value"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="LogBase" HeaderText="Log Base"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="Axis" HeaderText="Axis"></telerik:GridBoundColumn>
    <telerik:GridTemplateColumn HeaderText="Actions" AllowFiltering="false">
        <ItemTemplate>
            <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" Text="Edit"
            CommandName="EditAxis" CommandArgument='<%# Eval("id") %>' />
            <asp:LinkButton ID="btnDelete" ToolTip="Delete" runat="server" Text="Delete"
            OnClientClick="javascript:return confirm('Are you sure you want to delete this record?')"
            CommandName="DeleteAxis" CommandArgument='<%# Eval("id") %>' />
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
