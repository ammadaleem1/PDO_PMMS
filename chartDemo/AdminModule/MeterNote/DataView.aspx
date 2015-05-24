<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/PopUp.Master" AutoEventWireup="true" CodeBehind="DataView.aspx.cs" Inherits="chartDemo.AdminModule.MeterNote.DataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMeterNotes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMeterNotes" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Meter Notes</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
        <div class="col-lg-12" style="padding-bottom:10px;">
           <asp:Button ID="btnAdd" runat="server" Text="Add New Meter Note" 
                CssClass="buttongradient" onclick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;
           <a class="buttongradient" href="ImportData.aspx">Import Data</a>
           <br />
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-12">
<telerik:RadGrid ID="gvMeterNotes" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false"
OnItemCommand="gvMeterNotes_RowCommand" >
<MasterTableView DataKeyNames="Id" HeaderStyle-Font-Names="helvetica" Font-Names="helvetica"  HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Azure">
    <Columns>
    <telerik:GridBoundColumn DataField="Comment" HeaderText="Comments"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MeterNoteCategory.Category" HeaderText="Category"></telerik:GridBoundColumn>
    <telerik:GridTemplateColumn HeaderText="Actions" AllowFiltering="false">
        <ItemTemplate>
            <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" Text="Edit"
            CommandName="EditNote" CommandArgument='<%# Eval("Id") %>' /> &nbsp;/&nbsp; 
            <asp:LinkButton ID="btnDelete" ToolTip="Delete" runat="server" Text="Delete"
            OnClientClick="javascript:return confirm('Are you sure you want to delete this record?')"
            CommandName="DeleteNote" CommandArgument='<%# Eval("Id") %>' />
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
