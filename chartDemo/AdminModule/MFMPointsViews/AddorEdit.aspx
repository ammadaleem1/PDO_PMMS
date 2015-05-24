<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddorEdit.aspx.cs" MasterPageFile="~/MasterPages/AdminSite.Master" Inherits="chartDemo.AdminModule.MFMPointsViews.AddorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
<title>Functional Hierarcy</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div class="row">
<div class="col-lg-6">
    <div class="form-group">
            <label>Meter Name</label>
            <asp:TextBox ID="txtMeterName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtMeterName" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Measurement Section</label>
            <asp:TextBox ID="txtMeasurementSection" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMeasurementSection" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Point Gas</label>
            <asp:TextBox ID="txtPointGas" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPointGas" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Point Oil</label>
            <asp:TextBox ID="txtPointOil" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPointOil" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
          <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />&nbsp;
          <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary" CausesValidation="false" />
    </div>
</div>  
</div>

</asp:Content>