<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TagHistogram.aspx.cs" Inherits="chartDemo.TagHistogram" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            border: 1px solid #000000;
            border-radius: 5px;
        }
        .RadPicker_Default table
        {
            float: left;
        }
    </style>
    <script type="text/javascript" language="javascript">
     <asp:PlaceHolder runat="server">
        function validateDate() {
            document.getElementById('lblError').style.display = "none";
            document.getElementById('lblHoursStart').style.display = "none";
            document.getElementById('lblHoursEnd').style.display = "none";
            document.getElementById('lblMinutesStart').style.display = "none";
            document.getElementById('lblMinutesEnd').style.display = "none";
            var check = true;
            if (document.getElementById('<%= ddlHoursStart.ClientID %>').value == '') {
                document.getElementById('lblHoursStart').style.display = "block";
                check = false;
            }
            if (document.getElementById('<%= ddlHoursEnd.ClientID %>').value == '') {
                document.getElementById('lblHoursEnd').style.display = "block";
                check = false;
            }
            if (document.getElementById('<%= ddlMinutesStart.ClientID %>').value == '') {
                document.getElementById('lblMinutesStart').style.display = "block";
                check = false;
            }
            if (document.getElementById('<%= ddlMinutesEnd.ClientID %>').value == '') {
                document.getElementById('lblMinutesEnd').style.display = "block";
                check = false;
            }
            try {
                var startDate = new Date(document.getElementById('<%= txtStartDate.ClientID %>').value);
                startDate.setHours(document.getElementById('<%= ddlHoursStart.ClientID %>').value, document.getElementById('<%= ddlMinutesStart.ClientID %>').value);
                var endDate = new Date(document.getElementById('<%= txtEndDate.ClientID %>').value);
                endDate.setHours(document.getElementById('<%= ddlHoursEnd.ClientID %>').value, document.getElementById('<%= ddlMinutesEnd.ClientID %>').value);
                if (startDate > endDate) {
                    document.getElementById('lblError').style.display = "block";
                    check = false;
                }
            }
            catch (err) {
                alert(err);
                check = false;
            }
            return check;
        }
        </asp:PlaceHolder>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>
    <asp:HiddenField ID="hdnStartTime" runat="server" />
    <asp:HiddenField ID="hdnEndTime" runat="server" />
    <div>
        <table>
            <tr>
                <td>
                    <table border="0" cellpadding="5" cellspacing="0" style="width: 800px!important;">
                        <tr>
                            <td colspan="9">
                                <label style="color: Red; display: none; font-size: 11px" id="lblError">
                                    End date must be greater than start date.</label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="font-weight: bold; font-size: 16px" align="center" colspan="9">
                                Process Variation Chart
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Start Date:</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true" CssClass="textBoxClass" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" OnClientClick="return false;" runat="server" ImageUrl="~/Images/calendar.jpg"
                                    Height="20px" Width="30px" />
                            </td>
                            <td>
                                <ajax:CalendarExtender ID="CalendarExtender1" TargetControlID="txtStartDate" runat="server"
                                    PopupButtonID="ImageButton1" Format="dd-MMM-yy">
                                </ajax:CalendarExtender>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHoursStart" runat="server" CssClass="textBoxClass">
                                    <asp:ListItem Text="Select Hour" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label id="lblHoursStart" style="display: none" class="validators">
                                    *</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMinutesStart" runat="server" CssClass="textBoxClass">
                                    <asp:ListItem Text="Select Minutes" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="00" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMinutesStart" runat="server" Display="Dynamic"
                                    ControlToValidate="ddlMinutesStart" ErrorMessage="*" CssClass="validators" ValidationGroup="asfd"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <label id="lblMinutesStart" style="display: none" class="validators">
                                    *</label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>End Date</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true" CssClass="textBoxClass" />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgbtnCalendar" runat="server" ImageUrl="~/Images/calendar.jpg"
                                    Height="20px" Width="30px" />
                            </td>
                            <td>
                                <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" PopupButtonID="imgbtnCalendar"
                                    runat="server" Format="dd-MMM-yy"/>
                                <%--<ajax:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99/99/9999" MaskType="Date" TargetControlID="txtTranDateFrom" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True"></ajax:MaskedEditExtender>--%>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHoursEnd" runat="server" CssClass="textBoxClass">
                                    <asp:ListItem Text="Select Hour" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label id="lblHoursEnd" style="display: none" class="validators">
                                    *</label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlMinutesEnd" runat="server" CssClass="textBoxClass">
                                    <asp:ListItem Text="Select Minutes" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="00" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <label id="lblMinutesEnd" style="display: none" class="validators">
                                    *</label>
                            </td>
                            <td>
                                <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" OnClientClick="return validateDate();"
                                    Text="View Chart" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trInstrument" runat="server" visible="false">
            <td align="left">
                <label>Select Instrument : </label>
                <asp:DropDownList ID ="ddlInstrumnet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInstrument_SelectedIndexChanged"></asp:DropDownList>
                <asp:TextBox ID="txtInstType" Enabled="false" runat="server"></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Chart ID="chartFrequency" runat="server" BackColor="#efefef" Height="450px"
                                    Width="700px">
                                    <Series>
                                        <asp:Series BorderWidth="1" Name="Input" ChartType="Column" Color="Green" YAxisType="Primary">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX TitleFont="Callibri, 12px, style=UnderLine">
                                                <LabelStyle />
                                                <MajorGrid />
                                            </AxisX>
                                            <AxisY Title="Time(%)" TitleFont="Callibri, 12px, style=UnderLine">
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                            <td>
                               <asp:Chart ID="chartTrend" runat="server" BackColor="#efefef" Height="450px" Width="700px">
                                    <Series>
                                        <asp:Series BorderWidth="2" Name="Input" ChartType="Line" Color="Green" YAxisType="Primary">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX TitleFont="Callibri, 12px, style=UnderLine" Title="PI Trend">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid />
                                            </AxisX>
                                            <AxisY TitleFont="Callibri, 12px, style=UnderLine">
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Chart ID="chartReynoldNumber" runat="server" BackColor="#efefef" Height="450px" Width="700px">
                                    <Series>
                                        <asp:Series BorderWidth="2" Name="Input" ChartType="Line" Color="Green" YAxisType="Primary">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX TitleFont="Callibri, 12px, style=UnderLine" Title="Reynold Number">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid />
                                            </AxisX>
                                            <AxisY TitleFont="Callibri, 12px, style=UnderLine">
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </td>
                            <td>
                                <asp:Chart ID="chartVelocity" runat="server" BackColor="#efefef" Height="450px" Width="700px">
                                    <Series>
                                        <asp:Series BorderWidth="2" Name="Input" ChartType="Line" Color="Green" YAxisType="Primary">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="MainChartArea" BackColor="Black">
                                            <AxisX TitleFont="Callibri, 12px, style=UnderLine" Title="Velocity(in m/s)">
                                                <LabelStyle Format="dd/MM/yyyy\\nhh:mm" />
                                                <MajorGrid />
                                            </AxisX>
                                            <AxisY TitleFont="Callibri, 12px, style=UnderLine">
                                                <MajorGrid LineColor="LightPink" />
                                            </AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
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
