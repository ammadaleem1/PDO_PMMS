<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminSite.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="chartDemo.AdminModule.MFMGVFViews.DataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMFMGVF">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMFMGVF" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">MFM GVF Data</h1>
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
<telerik:RadGrid ID="gvMFMGVF" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false"
OnItemCommand="gvMFMGVF_RowCommand" >
<MasterTableView DataKeyNames="GVFID" HeaderStyle-Font-Names="helvetica" Font-Names="helvetica"  HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Azure">
    <Columns>
    <telerik:GridBoundColumn DataField="MeterName" HeaderText="Meter Name"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="GVF" HeaderText="GVF"></telerik:GridBoundColumn>
    <telerik:GridTemplateColumn HeaderText="Actions" AllowFiltering="false">
        <ItemTemplate>
            <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" Text="Edit"
            CommandName="EditGVF" CommandArgument='<%# Eval("GVFID") %>' /> &nbsp;/&nbsp; 
            <asp:LinkButton ID="btnDelete" ToolTip="Delete" runat="server" Text="Delete"
            OnClientClick="javascript:return confirm('Are you sure you want to delete this record?')"
            CommandName="DeleteGVF" CommandArgument='<%# Eval("GVFID") %>' />
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
