<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MechanicalDetails.ascx.cs" Inherits="chartDemo.Controls.MechanicalDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    .Red
    {
         background-color: Red;    width: 20px;    height: 20px;    border-radius: 50%;
    }
    .Green
    {
         background-color:Green;    width: 20px;    height: 20px;    border-radius: 50%;
    }
    .Blue
    {
         background-color:Blue;    width: 20px;    height: 20px;    border-radius: 50%;
    }
    .Yellow
    {
         background-color:Yellow;    width: 20px;    height: 20px;    border-radius: 50%;
    }
</style>
<table>
<tr>
<td valign="top">
<telerik:RadGrid runat="server" ID="gvSAPData" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        AutoGenerateColumns="false" >
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="[Functional Location]" HeaderText="Func. Loc." HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[Tag_Number]" HeaderText="Inst. Tag" HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[PI_Tag No]" HeaderText="PI Tag" HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[Manufacturer of asset]" HeaderText="Manufacturer" HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[ManufactSerialNumber]" HeaderText="Manuf. SNo." HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[Mnwkctr]" HeaderText="Mnwkctr" HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="[MCPData]" HeaderText="MCP" HeaderStyle-Width="145px" AllowFiltering="true"></telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</td>
<td valign="top">
<telerik:RadGrid runat="server" ID="gvVerification" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="false"
        AutoGenerateColumns="false" >
        <MasterTableView>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="Calibration" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("CalibrationIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Maintenance" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("MaintIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Inst.Type" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("InstTypeIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="PEFS" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("PEFSIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="PI Tag" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("PITagIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Tag No." HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("TagNumberIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="SAP" HeaderStyle-Width="80px">
                    <ItemTemplate><p class='<%#Eval("SAPIntegrity") %>'></p></ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</td>
</tr>
</table>