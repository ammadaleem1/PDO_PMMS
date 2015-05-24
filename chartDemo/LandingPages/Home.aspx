<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="chartDemo.LandingPages.Home" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/Controls/TestDevice.ascx" TagPrefix="uc1" TagName="TestDevice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div class="row">
<div class="col-lg-12">
<uc1:TestDevice ID="ucTestDevice" runat="Server" DeviceName="vortex"></uc1:TestDevice>
</div></div>
</asp:Content>
