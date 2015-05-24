<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IntermediateLinks.aspx.cs"
    Inherits="chartDemo.IntermediateLinks" Title="Operating Envelope" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        
    </script>
    <style type="text/css">
        body
        {
            font-family: Calibri;
        }
        .PropertyLabel
        {
            color: Red;
        }
        .PropertyTable
        {
            background-color: #d2d2d2;
            width: 1000px;
        }
        .validators
        {
            color: Red;
            font-size: 12px;
        }
        .buttonClass
        {
            border-radius: 3px;
            border: 1px solid rgb(0, 0, 0);
            background-color: rgb(177, 206, 222);
            font-size: 12px;
            padding-bottom: 2px;
        }
        .textBoxClass
        {
            border: 1px solid #000000;
            border-radius: 5px;
        }
        .RadPicker_Default table
        {
            float: left;
        }
        .chartClass
        {
        }
    </style>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
   <%-- <script src="JQuery/jquery-1.2.6.min.js" type="text/javascript"></script>
    <script src="JQuery/jquery.contextMenu.js" type="text/javascript"></script>--%>
    
</head>
<body style="margin-left:80px;margin-top:20px;background-color:#F5F5F5">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdnPiTag" runat="server" />
    <asp:HiddenField ID="hdnInstTag" runat="server" />
    <asp:HiddenField ID="hdnDevice" runat="server" />
    <div style="width: 1350px; margin: 0 auto">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="padding-right: 45px; width: 800px;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="1">
                                    <tr>
                                        <td><asp:HyperLink ID="hlDataSheet" runat="server" Text="Data Sheet" Target="_blank" Font-Bold="true"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlOperatingEnvelope" runat="server" Text="Operating Envelope"  Target="_blank" Font-Bold="true"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlPEFS" runat="server" Text="PEFS" Target="_blank"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlStandardDrawings" runat="server" Text="Standard Drawings" Target="_blank"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlWiring" runat="server" Text="Wiring Termination" Target="_blank"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlSAPDetails" runat="server" Text="SAP Details" Target="_blank"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlDevicePopup" runat="server" Text="Device Popup" Target="_blank" Font-Bold="true"></asp:HyperLink></td>
                                    </tr>
                                    <tr>
                                        <td><asp:HyperLink ID="hlMeterNote" runat="server" Text="Meter Note" Target="_blank" Font-Bold="true"></asp:HyperLink></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
