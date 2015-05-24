<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" MasterPageFile="~/MasterPages/SiteNoNavigation.Master" Inherits="chartDemo.GeneralPages.LandingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<style type="text/css">
#page-wrapper {
    padding: 0px;
    min-height: 568px;
    background-color: #fff;
}

@media(min-width:768px) {
    #page-wrapper {
        position: inherit;
        margin: 0 0 0 250px;
        padding: 0px;
        border-left: 1px solid #e7e7e7;
    }
}
.col-lg-12 {
    position: relative;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 0px;
}
</style>
<div class="col-lg-12">
        <img src="../Assets/images/Banner.jpg" width="100%" height="500px"/>
</div>
        <!-- /.col-lg-12 -->
<div class="col-lg-12" style="margin:0px;">
    <div style="background-color:Green; min-height:350px;">
        <h1 style="color:#fff; padding-left:40px; padding-top:50px; margin:0px!important;">PMMS Introduction:</h1>
        <p style="color:#fff; padding:0px 40px 50px 40px; font:14px verdana; line-height:40px;">
            The PMMS Solution is intended to serve Production Engineers community within PDO to reliably monitor the health and performance of various types of Production meters.
            PMMS shall be a single window tool into several corporate databases to facilitate production measurement work processes.
            The present information required to effectively manage the above business process is scattered across several databases, documents and drawings, procedures, codes and standards.
            PMMS intends to bridge this divide by connecting to various data sources and bringing in the correlated and contextualized data for Meters.
        </p>
    </div>
        <!-- /.col-lg-12 -->
</div>
</asp:Content>
