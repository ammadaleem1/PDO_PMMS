<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminSite.Master" AutoEventWireup="true" CodeBehind="CollectionMonitoringDashboard.aspx.cs" Inherits="chartDemo.MonitoringDashboards.CollectionMonitoringDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvCollections">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvCollections" LoadingPanelID="RadAjaxLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
</telerik:RadAjaxManager>
<div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-info fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:LinkButton ID="lnkTotal" runat="server" CssClass="dashlink" onclick="lnkTotal_Click" ></asp:LinkButton></div>
                                    <div class="medium">No. of Collections</div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-check-square fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:LinkButton ID="lnkGood" runat="server" CssClass="dashlink" onclick="lnkGood_Click" ></asp:LinkButton></div>
                                    <div class="medium">Goods</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-times-circle fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:LinkButton ID="lnkBad" runat="server" CssClass="dashlink" onclick="lnkBad_Click" ></asp:LinkButton></div>
                                    <div class="medium">Bads</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-warning fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge"><asp:LinkButton ID="lnkUnCertain" runat="server" CssClass="dashlink" onclick="lnkUnCertain_Click" ></asp:LinkButton></div>
                                    <div class="medium">UnCertain</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</div>
<div class="row">
<div class="col-lg-12">
<telerik:RadGrid ID="gvCollections" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true" AutoGenerateColumns="false"
OnItemCommand="gvCollections_RowCommand" >
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
</div>
</div>

</asp:Content>
