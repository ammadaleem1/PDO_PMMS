<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SiteNoNavigation.Master" AutoEventWireup="true" CodeBehind="Schematics.aspx.cs" Inherits="chartDemo.GeneralPages.Schematics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<style type="text/css">

@media(min-width:768px) {
    #page-wrapper {
        position: inherit;
        margin: 0 0 0 250px;
        padding: 0px;
        border-left: 1px solid #e7e7e7;
        height:900px;
    }
}
.col-lg-12 {
    position: relative;
    min-height: 1px;
    padding-right: 0px;
    padding-left: 0px;
}
.row
{
    margin:0px;
}

</style>
<div class="col-lg-12">
<iframe src="http://148.151.135.7/indx/xhq.asp?showtree=yes&splitterposition=15" width="100%" height="1000px" style="height:1000px; border:0px;"></iframe>        
</div>
</asp:Content>
