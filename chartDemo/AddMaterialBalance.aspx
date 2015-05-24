<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMaterialBalance.aspx.cs"
    Inherits="chartDemo.AddMaterialBalance" Title="Add Material Balance" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<link rel="stylesheet" href="jQuery/jquery-ui.css" />
<script src="jQuery/jquery-1.9.1.js" type="text/javascript"></script>
<script src="jQuery/jquery-ui.js" type="text/javascript"></script>
<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <title>Add Material Balance</title>
    <style type="text/css">
        body
        {
            font-family: Calibri;
           /* background-color: Gray;*/
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
        .rgRow {font-size:10px;font-family:Arial}
        .rgAltRow {font-size:10px;font-family:Arial}
    </style>
  
    <script type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">
    <asp:PlaceHolder runat="server">
    Array.prototype.clean = function(deleteValue) {
  for (var i = 0; i < this.length; i++) {
    if (this[i] == deleteValue) {         
      this.splice(i, 1);
      i--;
    }
  }
  return this;
};
    function fillTable()
    {
        var a = "asdf.pv,qw.pv,,zxc.az,";
        var arr = a.split(',').clean("");
        for(var i =1; i <= arr.length; i++)
        {
            var table = document.getElementById('tblInputTags');
            var row = table.insertRow(i);
            var cell0 = row.insertCell(0);
            var cell1 = row.insertCell(1);
            var cell2 = row.insertCell(2);
            var cell3 = row.insertCell(3);

            var newSelect0 = document.createElement('select');
            newSelect0.id="ddlOperator"+i.toString()+"a";
            for(var j =0 ; j<7; j++)
                newSelect0.appendChild(createOption(j));
            cell0.appendChild(newSelect0);

            var newTxtBx = document.createElement('input');
            newTxtBx.type = 'text';
            newTxtBx.id = 'txtTag'+i.toString();
            newTxtBx.value = arr[i-1];
            cell1.appendChild(newTxtBx);

            var newSelect2 = document.createElement('select');
            newSelect2.id="ddlOperator"+i.toString()+"b";
            for(var j =0 ; j<7; j++)
                newSelect2.appendChild(createOption(j));
            cell2.appendChild(newSelect2);

            var button = document.createElement('input');
            button.type='button';
            button.id= + i.toString();
            button.value="Remove";
            button.onclick=function(){document.getElementById("tblInputTags").deleteRow(this.id);};
            cell3.appendChild(button);
        }
    }
    function createOption(i)
    {
    var option = document.createElement('option');
    if(i==0)
    {
        option.value = "0";
        option.innerHTML="Select Operator";
    }
    if(i==1)
    {
        option.value = "1";
        option.innerHTML="(";
    }
    if(i==2)
    {
        option.value = "2";
        option.innerHTML=")";
    }
    if(i==3)
    {
        option.value = "3";
        option.innerHTML="+";
    }
    if(i==4)
    {
        option.value = "4";
        option.innerHTML="-";
    }
    if(i==5)
    {
        option.value = "5";
        option.innerHTML="*";
    }
    if(i==6)
    {
        option.value = "6";
        option.innerHTML="/";
    }
     return option;   
    }
    function Select(sender, eventArgs) {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
    var MasterTable = grid.get_masterTableView(); var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
    var cell = MasterTable.getCellByColumnUniqueName(row, "pitag");
    var pitag=document.getElementById('<%=hdnPiTags.ClientID%>');
        pitag.value = pitag.value + ',' + cell.innerHTML;
        } 

         function DeSelect(sender, eventArgs) 
         {
           var grid = sender;
           var gridSelectedItems = grid.get_selectedItems();
           var MasterTable = grid.get_masterTableView();
           var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
           var cell = MasterTable.getCellByColumnUniqueName(row, "pitag");
           var pitag=document.getElementById('<%= hdnPiTags.ClientID  %>');
           pitag.value = pitag.value.replace(","+cell.innerHTML,'');
        } 
        function done(InputOrOutput)
        {
            fillTable();
        }
        function isValid()
        {
        if(document.getElementById('<%= txtInput.ClientID %>').value == '' && document.getElementById('<%= txtOuput.ClientID %>').value== '')
            {
                alert("Please provide input or output tags.");
                return false;
            }
            if(document.getElementById('<%= txtMaterialBalanceName.ClientID %>').value=='')
            {
            alert("Please provide Material Balance name.");
                return false;
            }
            return true;
        }
        function GetInputValue()
        {
            return document.getElementById('<%= txtInput.ClientID %>').value;
        }
        function GetOutputValue()
        {
            return document.getElementById('<%= txtOuput.ClientID %>').value;
        }
       function ViewChart()
       {
        if(document.getElementById('<%= txtInput.ClientID %>').value == '' && document.getElementById('<%= txtOuput.ClientID %>').value== '')
            {
                alert("Please provide input or output tags.");
                return false;
            }
            var input = document.getElementById('<%= txtInput.ClientID %>').value;
        var output = document.getElementById('<%= txtOuput.ClientID %>').value;
            window.open("MaterialBalanceChart.aspx?txtInput="+input+"&txtOuput="+output,"_blank","toolbar=no, scrollbars=yes, resizable=yes, top=100, left=300, width=1000, height=900");
       }
    </asp:PlaceHolder>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
   <%-- <ajax:ToolkitScriptManager ID="toolkit1" runat="server">
    </ajax:ToolkitScriptManager>--%>
   <telerik:RadSkinManager ID="QsfSkinManager" runat="server" ShowChooser="false" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnablePageHeadUpdate="false">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridInst">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridInst"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="txtInput"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="txtOuput"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="lblStatus"></telerik:AjaxUpdatedControl >
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridPI">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridPI"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="txtInput"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="txtOuput"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="btnInsertTags"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="lblStatus"></telerik:AjaxUpdatedControl >
                </UpdatedControls>
            </telerik:AjaxSetting>
           <%--  <telerik:AjaxSetting AjaxControlID="lblStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnInsertTags"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="btnAddViewChart" ></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
           <telerik:AjaxSetting AjaxControlID="btnInsertTags">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblStatus"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddViewChart">
                <UpdatedControls>
                   <telerik:AjaxUpdatedControl ControlID="lblStatus"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:HiddenField ID="hdnPiTags" runat="server" />
    <asp:HiddenField ID="hdnInput" Value="" runat="server" />
    <asp:HiddenField ID="hdnOutput" Value="" runat="server"/>
    <div id="container" style="width:1500px;margin:0 auto;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td><label>Material Balance Name : </label></td>
                            <td><asp:TextBox ID="txtMaterialBalanceName" runat="server" CssClass="textBoxClass"></asp:TextBox></td>
                            <td><asp:RequiredFieldValidator ID="rfv" ControlToValidate="txtMaterialBalanceName" runat="server" Display="Dynamic" ErrorMessage="*" CssClass="validators" ValidationGroup="Add"></asp:RequiredFieldValidator> </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width:1600px">
                    <telerik:RadGrid runat="server" ID="RadGridInst" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGridInst_NeedDataSource" AutoGenerateColumns="false" AllowMultiRowSelection="true">
                        <MasterTableView>
                            <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Input" UniqueName="rbtn"> 
                                        <ItemTemplate> 
                                            <asp:RadioButtonList ID="rbtnInputOutput" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="SomethingChanged">
                                                <asp:ListItem Text="Input" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Output" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<asp:CheckBox ID="chkInput" runat="server" AutoPostBack="false" /> --%>
                                        </ItemTemplate> 
                                </telerik:GridTemplateColumn> 
                               <%-- <telerik:GridTemplateColumn HeaderText="Output"> 
                                        <ItemTemplate> 
                                            <asp:CheckBox ID="chkOutput" runat="server" AutoPostBack="false"/> 
                                        </ItemTemplate> 
                                </telerik:GridTemplateColumn> 
                                <telerik:GridClientSelectColumn UniqueName="ChkSelectInput" HeaderText="Input" ButtonType="LinkButton" Text="Select"></telerik:GridClientSelectColumn>
                                <telerik:GridClientSelectColumn UniqueName="ChkSelectOutput" HeaderText="Output" ButtonType="LinkButton" Text="Select"></telerik:GridClientSelectColumn>--%>
                                <telerik:GridBoundColumn DataField="pitag" HeaderText="Pi Tag" HeaderStyle-Width="300px" AllowFiltering="true" UniqueName="PiTag"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="mainClass" HeaderText="Main Class" HeaderStyle-Width="200px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SubClass1" HeaderText="Sub Class1" HeaderStyle-Width="200px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SubClass2" HeaderText="Sub Class2" HeaderStyle-Width="200px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="cluster" HeaderText="Cluster" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="area" HeaderText="Area" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="station" HeaderText="Station" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Mech_Eqpt_no" HeaderText="Mech Equip" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="tag_no" HeaderText="Tag Number" HeaderStyle-Width="100px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Instrument_Type_Description" HeaderText="Instrument Type" HeaderStyle-Width="200px" AllowFiltering="true"></telerik:GridBoundColumn>
                
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                            <%--<Selecting AllowRowSelect="true"  />
                            <ClientEvents OnRowSelecting="Select" OnRowDeselecting="DeSelect"></ClientEvents>--%>
                        </ClientSettings>
                    </telerik:RadGrid>
                </td>
                <%--<td>
                </td>--%>
            </tr>
            <tr height="15px"></tr>
            <tr>
                <td  align="left">
                    <%--<table><tr>
                    <td><asp:Label ID="lblTitle" Text="Tag Name:" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtTagName" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnGetTags" Text="Search" runat="server" OnClick="btnGetTags_Click" /></td></tr></table>--%>
                </td><%--<td></td>--%>
            </tr>
            <tr height="15px"></tr>
            <tr>
                <td align="left">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top" width="800px"><table><tr>
                    <td><asp:Label ID="lblTitle" Text="Tag Name:" runat="server"></asp:Label></td>
                    <td><asp:TextBox ID="txtTagName" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnGetTags" Text="Search" runat="server" OnClick="btnGetTags_Click" /></td></tr></table></td>
                        <td valign="top" style="text-align:center;"><asp:Label ID="lblInputHeading" runat="server" Text="Input Equation"></asp:Label></td>
                        <td valign="top" style="text-align:center;"><asp:Label ID="lblOutputHeading" runat="server" Text="Output Equation"></asp:Label></td>
                    </tr>
                    <tr>
                    <td valign="top" width="800px">
                    <telerik:RadGrid runat="server" ID="RadGridPI" AllowPaging="True" AllowSorting="true" AllowFilteringByColumn="true"
        OnNeedDataSource="RadGridPI_NeedDataSource" AutoGenerateColumns="false" AllowMultiRowSelection="true">
                        <MasterTableView>
                            <Columns>
                                <%--<telerik:GridClientSelectColumn UniqueName="ChkSelect" HeaderText="Select" ButtonType="LinkButton" Text="Select"></telerik:GridClientSelectColumn>--%>
                                 <telerik:GridTemplateColumn HeaderText="Input" UniqueName="rbtn"> 
                                        <ItemTemplate> 
                                            <asp:RadioButtonList ID="rbtnInputOutputPI" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="SomethingChanged">
                                                <asp:ListItem Text="Input" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Output" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate> 
                                </telerik:GridTemplateColumn> 
                                <telerik:GridBoundColumn DataField="Descriptor" HeaderText="Descriptor" HeaderStyle-Width="150px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EngUnits" HeaderText="EngUnits" HeaderStyle-Width="130px" AllowFiltering="true"></telerik:GridBoundColumn>
                                <%--<telerik:GridBoundColumn DataField="PointType" HeaderText="Point Type" HeaderStyle-Width="150px" AllowFiltering="true"></telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn DataField="Instrumenttag" HeaderText="Instrument Tag" HeaderStyle-Width="150px" AllowFiltering="true" ItemStyle-CssClass="sdf"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PITag" HeaderText="PI Tag" HeaderStyle-Width="150px" AllowFiltering="true" ItemStyle-CssClass="sdf"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings>
                           <%-- <Selecting AllowRowSelect="true"  />
                            <ClientEvents OnRowSelecting="Select" OnRowDeselecting="DeSelect"></ClientEvents>--%>
                        </ClientSettings>
                    </telerik:RadGrid></td>
                    <td valign="top" style="text-align:center;padding-left: 5px;"><textarea id="txtInput" runat="server" rows="10" cols="1" style="width:350px"  ></textarea><%--<table><tr><td><asp:Label ID="lblInputHeading" runat="server" Text="Input Equation"></asp:Label></td></tr><tr><td valign="top"><textarea id="txtInput" runat="server" rows="10" cols="1" style="width:350px"  ></textarea></td></tr></table>--%></td>
                    <td valign="top" style="text-align:center;padding-left: 5px;"><textarea id="txtOuput" runat="server" rows="10" cols="1" style="width:350px" ></textarea><%--<table><tr><td><asp:Label ID="lblOutputHeading" runat="server" Text="Output Equation"></asp:Label></td></tr><tr><td valign="top"><textarea id="txtOuput" runat="server" rows="10" cols="1" style="width:350px" ></textarea></td></tr></table>--%></td>
                    </tr>
                    <%--<tr><td></td></tr>--%>
                    </table>
                </td><%--<td></td>--%>
            </tr>
            <tr height="15px"></tr>
            <tr>
                <td  align="right">
                    <table><tr><td><asp:Button ID="btnAddViewChart" Text="Save and View Chart" runat="server" OnClick="btnAddViewChart_Click" OnClientClick="return isValid()" ValidationGroup="Add" /></td><td><asp:Button ID="btnInsertTags" Text="Save Material Balance" runat="server" OnClick="btnInsertTags_Click" OnClientClick="return isValid()" ValidationGroup="Add" /></td></tr></table>
                    
                    
                </td><%--<td></td>--%>
            </tr>
            <tr height="15px"></tr>
            </table>
    </div>
   
    </form>
</body>
</html>
