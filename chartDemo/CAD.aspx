<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAD.aspx.cs" Inherits="chartDemo.CAD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        function me() {
            alert("called");
            var winCtrl = document.getElementById("MyWinControl");
            winCtrl.Model1("E:\\HMW0902-1-003_O P&ID Drawing.dwg");
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <image id = "PictureBox1" runat="server" style="display:none"></image>
         <object id="MyWinControl" classid="ClassLibrary1.dll#ClassLibrary1.ViewControl"            
          height="100" width="300" VIEWASTEXT/>
          <input type="button" onclick="me()" value="Send Message" /> 
    </div>

    </form>
</body>
</html>
