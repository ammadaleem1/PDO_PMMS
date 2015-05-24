<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="TemplatePdoAspx.Controls.Header" %>

        <div class="navbar-header" style="width:15%;">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.html" style="padding:0px; width:100%;"><asp:Image ImageUrl="~/Assets/images/PDO_Logo_main.png" runat="server" width="100%" height="95%" /></a>
        </div>
        <div style="float:left; margin-top:10px; text-align:center; width:70%;"><asp:HyperLink runat="server" CssClass="buttongradient" NavigateUrl="~/GeneralPages/Schematics.aspx" Text="Schematics" />&nbsp;&nbsp;&nbsp;<asp:HyperLink runat="server" CssClass="buttongradient"  NavigateUrl="~/FunctionalHierarcy/HierarcyGrid.aspx" Text="&nbsp;&nbsp;&nbsp;PMMS&nbsp;&nbsp;&nbsp;" /></div>
        <!-- /.navbar-header -->
        <section id="login" style="float:right; width:15%;">
            <a  class="username" style="padding-top:15px" href="../AdminModule/MFMAxisDataViews/DataView.aspx"><label style="padding-top:15px">Admin Module</label></a>
        </section>
        <!-- /.navbar-top-links -->
