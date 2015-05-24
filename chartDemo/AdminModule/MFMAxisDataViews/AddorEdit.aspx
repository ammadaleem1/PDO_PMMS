<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddorEdit.aspx.cs" MasterPageFile="~/MasterPages/AdminSite.Master" Inherits="chartDemo.AdminModule.MFMAxisDataViews.AddorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
<title>Functional Hierarcy</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">MFM Axis Data</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-6">
    <div class="form-group">
            <label>Meter Name</label>
            <asp:TextBox ID="txtMeterName" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtMeterName" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Min Value</label>
            <asp:TextBox ID="txtMinValue" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMinValue" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Max Value</label>
            <asp:TextBox ID="txtMaxValue" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxValue" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Log Base</label>
            <asp:TextBox ID="txtLogBase" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLogBase" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Axis</label>
            <asp:DropDownList ID="ddlAxis" runat="server" CssClass="form-control">
                <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
                <asp:ListItem Text="X-Axis" Value="x"></asp:ListItem>
                <asp:ListItem Text="Y-Axis" Value="y"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvAxis" runat="server" InitialValue="0" ControlToValidate="ddlAxis" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
          <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="buttongradient" />&nbsp;
          <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" CssClass="buttongradient" CausesValidation="false" />
    </div>
</div>  
</div>

</asp:Content>