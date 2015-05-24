<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminSite.Master" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="chartDemo.AdminModule.MFMPointsViews.ImportData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
<div class="row">
    <div class="col-lg-12">
        <asp:Label ID="lblMessage" runat="server" ></asp:Label>
       <div class="form-group">
          <asp:FileUpload ID="txtFilePath" runat="server"></asp:FileUpload>&nbsp;&nbsp;
          <asp:Button ID="btnUpload" runat="server" Text="Start Importing Data" CssClass="btn btn-primary" onclick="btnUpload_Click" />&nbsp;&nbsp;
          <a href="../../Assets/ExcelTemplates/MFMPoints_Sample.xlsx" class="btn btn-primary">Download Template</a>
        </div>
    </div>
        <!-- /.col-lg-12 -->
</div>
</asp:Content>
