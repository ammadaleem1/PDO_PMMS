<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNavigation.ascx.cs" Inherits="chartDemo.Controls.LeftNavigation" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<style type="text/css">
.RadTreeView_WebBlue .rtIn
{
	margin-left: 1px;
	padding: 0px;
	text-decoration:none;
}

.RadTreeView_WebBlue .rtHover .rtIn, .RadTreeView_WebBlue .rtSelected .rtIn {
    background-position: 0 100%;
    background-repeat: repeat-x;
    border-style: solid;
    border-width: 1px;
    padding: 1px;
    background-color: #39A6FD!important;
}

.rtSelected .rtIn 
{
    background:none !important;
    background-position: 0 100%;
    background-repeat: repeat-x;
    border-style: solid;
    border-width: 0px;
    padding: 1px;
    background-color: #39A6FD!important;
}

.RadTreeView_WebBlue .rtSelected .rtIn 
{
    background:none !important;
    background-color: #39A6FD!important;
    border:0px;
    color: #fff;
}

.RadTreeView_WebBlue .rtHover .rtIn 
{
    background:none !important;
    border:0px;
}
</style>

<div class="navbar-default sidebar" role="navigation">

 <telerik:RadTreeView ID="rtvNavigation" runat="server" Width="100%" OnNodeClick="rtvNavigation_NodeClick" MultipleSelect="false" Font-Size="8" Font-Names="Arial">
    <NodeTemplate>
            <img src="../Assets/images/PDOLogo16x16.png" />
            <span><%# DataBinder.Eval(Container,"Text")%></span>
    </NodeTemplate>
</telerik:RadTreeView>

<!-- /.sidebar-collapse -->
</div>
