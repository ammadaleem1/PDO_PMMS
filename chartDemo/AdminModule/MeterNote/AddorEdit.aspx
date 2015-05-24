<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddorEdit.aspx.cs" MasterPageFile="~/MasterPages/PopUp.Master" Inherits="chartDemo.AdminModule.MeterNote.AddorEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
<title>Meter Notes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Meter Notes</h1>
        </div>
        <!-- /.col-lg-12 -->
</div>
<div class="row">
<div class="col-lg-6">
    <div class="form-group">
            <label>Category</label>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="-1" runat="server" ControlToValidate="ddlCategory" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
            <label>Comments</label>
            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtComment" Display="Dynamic">Required</asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
          <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />&nbsp;
          <asp:Button runat="server" ID="btnBack" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary" CausesValidation="false" />
    </div>
</div>  
</div>

</asp:Content>