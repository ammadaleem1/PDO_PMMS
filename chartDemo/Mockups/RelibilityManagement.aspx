<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelibilityManagement.aspx.cs" Inherits="chartDemo.Mockups.RelibilityManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Relibility Management</title>
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
            <h1 class="page-header">Relibility Management</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
        
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                  <h3>
                    <asp:Label ID="lbl" runat="server" Text="Instrument Name"></asp:Label>
                   </h3> 
            </div>
            <div class="form-group">
                    <label>Current Status:</label>
                    <asp:Label ID="lblCurrentAlert" runat="server" CssClass="btn btn-xs btn-warning" Text="Kindly enter the Activation Date for current status"></asp:Label>
                    <%-- Active
                     <button type="button" class="btn btn-success">
                                    <i class="fa fa-check"></i>
                                </button>
                  --%>
            </div>
            <div class="form-group">
                    <label>Device Activation Date:</label>
                    <telerik:raddatepicker id="rdDate" width="31%" runat="server" cssclass="form-control">
                    </telerik:raddatepicker>
            </div>
           
            <div class="col-lg-6" style="padding-left:0px;">
            <div class="form-group">
                    <label>Total Failure Hours:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </label>
                    <asp:Label ID="lblTotalFailHour" runat="server" Text="20" CssClass="form-control" style="display:inline; width:14%;" />
            </div>
            <br />
            <div class="form-group">
                    <label>Total Working Hours:&nbsp;&nbsp; &nbsp;&nbsp; </label>
                    <asp:Label ID="lblTotalWorkHour" runat="server" Text="20" CssClass="form-control" style="display:inline; width:14%;"  />
            </div>
            <br />
            <div class="form-group">
                    <label>Total No. of Failures:&nbsp;&nbsp;&nbsp;&nbsp;  </label>
                    <asp:Label ID="lblNoFailures" runat="server" Text="20" CssClass="form-control" style="display:inline; width:14%;"/>
            </div>
            </div>
                       
        </div>
        <div class="col-lg-6">
            <div class="form-group">
                    <asp:RadioButton ID="RadioButton1" runat="server" /><label>MTBF:</label>
                    <asp:Label ID="lblMTBF" runat="server" Text="20" CssClass="form-control" style="display:inline; width:20%; padding: 8px 16px; font-size:18px; font-weight:bold;" />
           &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="RadioButton2" runat="server" /><label>MTTR:</label>
                    <asp:Label ID="lblMTTR" runat="server" Text="20" CssClass="form-control form-control" style="display:inline; width:20%; padding: 8px 16px; font-size:18px; font-weight:bold;"  />
                     <br />
                     <br />
                     <br /> 
            <asp:Label ID="Label1" runat="server" CssClass="btn btn-xs btn-info" style="margin-left:140px;" Text="Select MTTR/MTBF for chart rendering"></asp:Label>

            </div>
                     
            <asp:Image ID="imgChart" runat="server" ImageUrl="~/Assets/images/mschart25.png" />
        </div>
        
        </div>
    <div class="col-lg-12">
<hr />
<telerik:RadGrid ID="gvRelData" runat="server" PageSize="25" Width="100%" AllowPaging="True" AllowSorting="true" Skin="WebBlue" AllowFilteringByColumn="true" AutoGenerateColumns="false">
<MasterTableView DataKeyNames="ID" HeaderStyle-Font-Names="helvetica" Font-Names="helvetica"  HeaderStyle-Font-Size="Medium" HeaderStyle-Font-Bold="true">
    <Columns>
    <telerik:GridBoundColumn DataField="MeterName" HeaderText="Meter Name"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="Date" HeaderText="Date"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="Status" HeaderText="Status"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MTBF" HeaderText="MTBF"></telerik:GridBoundColumn>
    <telerik:GridBoundColumn DataField="MTTR" HeaderText="MTTR"></telerik:GridBoundColumn>
    </Columns>
    <NoRecordsTemplate>
           <div style="text-align:center;">No records found.</div>
    </NoRecordsTemplate>
</MasterTableView>
</telerik:RadGrid>
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