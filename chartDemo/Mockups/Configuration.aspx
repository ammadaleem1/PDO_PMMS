<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="chartDemo.Mockups.Configuration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Configuration</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />

   <link href="../Assets/css/bootstrap.min.css" rel="stylesheet" />
   <link href="../Assets/css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
   <link href="../Assets/css/plugins/timeline.css" rel="stylesheet" />
   <link href="../Assets/css/sb-admin-2.css" rel="stylesheet" />
   <!--<link href="../Assets/css/plugins/morris.css" rel="stylesheet" />-->
   <link href="../Assets/font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" />
   <link href="../Assets/css/plugins/dataTables.bootstrap.css" rel="stylesheet" />
   <script src="../Assets/js/jquery-1.11.0.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .riTextBox {
            border:none!important;
        }
        @media(min-width:738px) {
        #page-wrapper {
        position: inherit;
        margin: 0 0 0 0px;
        padding: 0 0px;
        border-left: 1px solid #000;
    }
}
    </style>
</head>
<body>
   <div id="page-wrapper">
   
    <form id="form1" runat="server">
         <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    
   
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Configuration</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
        
    <div class="row">
        <div class="col-lg-4">
            <div class="form-group">
                    <label>Field 1:</label>
                    <asp:TextBox ID="txtField1" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                   
            </div>
            <div class="form-group">
                    <label>Field 2:</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text=""></asp:TextBox>
            </div>
            <div class="form-group">
                    <label>Field 3:</label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text=""></asp:TextBox>
            </div>
            <div class="form-group">
             <label>File upload:</label>
             <asp:FileUpload ID="txtFilePath" runat="server" CssClass="form-control"></asp:FileUpload>
            </div>
            <div class="form-group">
             <asp:Button ID="btnSubmit" runat="server" CssClass="buttongradient" Text="Submit"></asp:Button>
            </div>
        </div>
    <div class="col-lg-12">
<hr />
<telerik:RadGrid ID="gvRelData" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" Skin="WebBlue" AllowFilteringByColumn="true" AutoGenerateColumns="false">
<MasterTableView DataKeyNames="ID" HeaderStyle-Font-Names="helvetica" Font-Names="helvetica"  HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Bold="true">
    <Columns>
    <telerik:GridBoundColumn DataField="FileName" HeaderText="Meter Name"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="UploadedDate" HeaderText="Uploaded Date"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="UploadedBy" HeaderText="Uploaded By"></telerik:GridBoundColumn>
    </Columns>
    <NoRecordsTemplate>
           <div style="text-align:center;">No records found.</div>
    </NoRecordsTemplate>
</MasterTableView>
</telerik:RadGrid>
</div>
    
   </div>
        <!-- Bootstrap Core JavaScript -->
       
<script src="../Assets/js/bootstrap.min.js"></script>
<script src="../Assets/js/plugins/metisMenu/metisMenu.min.js"></script>
        
<!-- Morris Charts JavaScript -->
<script src="../Assets/js/plugins/morris/raphael.min.js"></script>
<!--<script src="../Assets/js/plugins/morris/morris.min.js"></script>
<script src="../Assets/js/plugins/morris/morris-data.js"></script>-->
        
<script src="../Assets/js/plugins/dataTables/jquery.dataTables.js"></script>
<script src="../Assets/js/plugins/dataTables/dataTables.bootstrap.js"></script>
<script src="../Assets/js/sb-admin-2.js"></script>
    </form>

    </div>
</body>
</html>