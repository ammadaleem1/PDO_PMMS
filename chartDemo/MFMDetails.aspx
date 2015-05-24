<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MFMDetails.aspx.cs" Inherits="chartDemo.MFMDetails"
    Title="Test Details" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="stylesheet" href="jQuery/jquery-ui.css" />
    <script src="jQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="jQuery/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>Chart Demo</title>
    <style type="text/css">
        body
        {
            font-family: Times New Roman;
            font-size:12px;
            background-color: #D3D3D3!important;
        }
        .PropertyLabel
        {
            color: Red;
        }
        .PropertyTable
        {
            background-color: #d2d2d2;
            width: 800px;
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
            border-bottom:1px solid #000000;
            border-top:none;
            border-left:none;
            border-right:none;
            background-color:#D3D3D3;
            /*border: 1px solid #000000;
            border-radius: 5px;*/
        }
         .textBoxClass2
        {
            border-bottom:1px solid #000000;
            border-top:none;
            border-left:none;
            border-right:none;
            width:70px;
            background-color:#D3D3D3;
            /*border: 1px solid #000000;
            border-radius: 5px;*/
        }
        .RadPicker_Default table
        {
            float: left;
        }
    </style>
    <script type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:650px;margin:0 auto;border:2px solid #000000;border-collapse:collapse">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:50%;vertical-align:top;border-bottom:2px solid #000000;border-collapse:collapse">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td style="width:330px">


                        <table><tr>
                        <td style="border-right:1px solid #000000;">
                            <table>
                            <tr><td> Tag Number:</td></tr><tr><td> PDO PEFS No:</td></tr><tr><td style="width:120px"> Cluster & Area:</td></tr>
                            <tr><td> Year Commissioned:</td></tr><tr><td> Material:</td></tr><tr><td> Size & Rating:</td></tr><tr><td> Min & Max Flow Rate:</td></tr><tr><td>Max GVF & WC</td></tr>
                            </table>
                        </td>
                        <td>
                        <table cellpadding="0" cellspacing="0">
                             <tr>
                            
                            <td><asp:TextBox ID="txtTagNumber" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                         <tr>
                            
                            <td><asp:TextBox ID="txtPEFSNumber" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                             <tr>
                            
                            <td style="width:200px"><asp:TextBox ID="txtClusterAndArea" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="txtYearCommissioned" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="txtMaterial" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="txtSizeAndRating" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="txtMinAndMaxFlowRate" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td><asp:TextBox ID="txtMaxGVFAndWC" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                            </table>
                        </td>
                        </tr></table>

                            





                        </td>
                        <td style="border-left:2px solid #000000;">
                        <a id="lnkPEFS" runat="server" target="_blank"><img src ="Images/006-QR-001-PID.png" height="150px" width="300px" /></a>
                        </td>
                        </tr>
                       
                    </table>
                </td>
                
            </tr>
            <tr>
                <td style="width:50%;vertical-align:top;border-bottom:2px solid #000000;border-collapse:collapse">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width:330px">
                                <table>
                        <tr>
                            <td colspan="2">
                                <b><u>Venturi Details</u></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:120px"> Number of Venturies:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtNumberOfVenturies" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td> Beta Ratio:</td>
                            <td style=""><asp:TextBox ID="txtBetaRatio" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                           
                        </tr></table>
                            </td>
                            <td style="border-left:1px solid #000000">
                                <table>
                                    <tr><td style="width:120px"> Size(Large/Small):</td>
                            <td><asp:TextBox ID="txtVentruiSize" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                    <tr> <td> Throat Diameter:</td>
                            <td><asp:TextBox ID="txtThroatDiameter" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                
            </tr>
            <tr>
                <td style="width:50%;vertical-align:top;border-bottom:2px solid #000000;border-collapse:collapse">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width:330px">
                                <table>
                                    <tr><td colspan="2">
                                <b><u>Vortex Details</u></b>
                            </td>
                                    </tr>
                                    
                        <tr>
                            <td style="width:120px"> Make:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtVortexMake" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td> Min Measure Range:</td>
                            <td style=""><asp:TextBox ID="txtVortexRangeMin" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                                </table>
                            </td>
                            <td style="border-left:1px solid #000000;">
                                <table>
                                    <tr><td style="width:120px"> Material:</td>
                            <td><asp:TextBox ID="txtVortexMaterial" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                    <tr><td> Max Measure Range:</td>
                            <td><asp:TextBox ID="txtVortexRangeMax" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                
            </tr>
            <tr>
                <td style="border-bottom:2px solid #000000;border-collapse:collapse">
                <table cellpadding="0" cellspacing="0"><tr><td style="width:330px">
                    <table>
                        <tr>
                            <td colspan="2">
                                <b><u>Gamma Details</u></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:120px"> Probe:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtGammaProbe" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                        <tr>
                            <td> Leakeage Does5:</td>
                            <td style=""><asp:TextBox ID="txtGammaLeak5" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                           
                        </tr>
                         <tr>
                            <td> Single Half Life:</td>
                            <td style=""><asp:TextBox ID="txtGammaSingleHalfLife" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                    </table>
                    </td>
                    <td style="border-left:1px solid #000000;">
                    <table>
                    <tr><td style="width:120px"> Output:</td>
                            <td><asp:TextBox ID="txtGammaOutput" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                    <tr> <td> Leakeage Does100:</td>
                            <td><asp:TextBox ID="txtGammaLeak100" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                            <tr><td> Half Life:</td>
                            <td><asp:TextBox ID="txtGammaHalfLife" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                            </table>
                    </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom:2px solid #000000;border-collapse:collapse">
                <table cellpadding="0" cellspacing="0"><tr><td style="width:330px">
                   <table>
                        <tr>
                            <td colspan="2">
                                <b><u>Valve Details</u></b>
                            </td>
                        </tr>
                       <tr>
                            <td style="width:120px"> Make:</td>
                            <td style="width:200px;"><asp:TextBox ID="txtValveMake" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                           
                        </tr>
                        <tr>
                            <td> Fail Position:</td>
                            <td style=""><asp:TextBox ID="txtValveFailPosition" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                           
                        </tr>
                        <tr>
                            <td> Body Material:</td>
                            <td style=""><asp:TextBox ID="txtValveBodyMaterial" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td>
                            
                        </tr>
                    </table>
                    </td>
                    <td style="border-left:1px solid #000000;">
                    <table>
                    <tr> <td style="width:120px"> Model:</td>
                            <td><asp:TextBox ID="txtValveModel" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                    <tr> <td> Process Connection:</td>
                            <td><asp:TextBox ID="txtValveProcConn" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                    <tr><td> Trim Material:</td>
                            <td><asp:TextBox ID="txtValveTrimMaterial" CssClass="textBoxClass" runat="server" ReadOnly="true"></asp:TextBox></td></tr>
                    </table>
                    </td>
                    </tr></table>
                </td>
            </tr>
            <tr>
                <td>
                   <table>
                        <tr>
                            <td>
                                <b><u>Transmitter Details</u></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td></td><td style="width:100px" align="center">Make</td><td style="width:100px" align="center">Model</td><td style="width:100px" align="center">Range Min</td><td style="width:100px" align="center">Range Max</td><td style="width:100px" align="center">Unit</td>
                                    </tr>
                                    <tr id="P1" runat="server">
                                        <td>Pressure1</td>
                                        <td align="right"><asp:TextBox ID="txtMakeP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                     <tr id="P2" runat="server">
                                        <td>Pressure2</td>
                                        <td align="right"><asp:TextBox ID="txtMakeP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                    <tr id="DP1" runat="server">
                                        <td>Diff Pressure1</td>
                                        <td align="right"><asp:TextBox ID="txtMakeDP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelDP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinDP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxDP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitDP1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                     <tr id="DP2" runat="server">
                                        <td>Diff Pressure2</td>
                                        <td align="right"><asp:TextBox ID="txtMakeDP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelDP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinDP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxDP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitDP2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                    <tr id="T1" runat="server">
                                        <td>Temperature1</td>
                                        <td align="right"><asp:TextBox ID="txtMakeT1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelT1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinT1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxT1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitT1" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                     <tr id="T2" runat="server">
                                        <td>Temperature2</td>
                                        <td align="right"><asp:TextBox ID="txtMakeT2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtModelT2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMinT2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtMeasRangeMaxT2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                        <td align="right"><asp:TextBox ID="txtUnitT2" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="width:120px"> Make (P/DP/T):</td>
                            <td style="width:200px"><asp:TextBox ID="txtMake" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                            <td style="width:120px"> Model (P/DP/T):</td>
                            <td><asp:TextBox ID="txtModel" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td> Min Measurement<br /> Range (P/DP/T):</td>
                            <td><asp:TextBox ID="txtMeasRangeMin" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                            <td> Max Measurement<br /> Range (P/DP/T):</td>
                            <td><asp:TextBox ID="txtMeasRangeMax" CssClass="textBoxClass2" runat="server" ReadOnly="true"></asp:TextBox></td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
