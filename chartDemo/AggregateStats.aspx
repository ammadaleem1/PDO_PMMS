<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AggregateStats.aspx.cs" MasterPageFile="~/MasterPages/Site.Master" Inherits="chartDemo.AggregateStats" Title="Aggregate Stats" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
  <%--<link href="/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <title>Chart Demo</title>
    <script type="text/javascript" language="javascript">
    <asp:PlaceHolder runat="server">
    function ClientNodeClicked(sender, eventArgs) {
        var node = eventArgs.get_node();
        //alert("You clicked " + node.get_level());
        document.getElementById('<%= hdnNode.ClientID %>').value = node.get_level();
        document.getElementById('<%= hdnValue.ClientID %>').value = node.get_text();
    }</asp:PlaceHolder>
</script>
</asp:Content>
  
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <asp:HiddenField ID="hdnValue" Value="" runat="server" />
    <asp:HiddenField ID="hdnNode" Value="" runat="server" />
    
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
          <AjaxSettings>
               <telerik:AjaxSetting AjaxControlID="ddlMainClass">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
               <telerik:AjaxSetting AjaxControlID="ddlSubClass1">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart2"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
               <telerik:AjaxSetting AjaxControlID="ddlSubClass2">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart3"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlInstrumentType">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart4"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlProcessFunction">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart5"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ddlService">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart6"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
               <telerik:AjaxSetting AjaxControlID="ddlTimeRange">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart1"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart2"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart3"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart4"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart5"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart6"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
               <telerik:AjaxSetting AjaxControlID="RadTreeView1">
                    <UpdatedControls>
                         <telerik:AjaxUpdatedControl ControlID="RadChart1"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart2"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart3"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart4"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart5"></telerik:AjaxUpdatedControl>
                         <telerik:AjaxUpdatedControl ControlID="RadChart6"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
               </telerik:AjaxSetting>
          </AjaxSettings>
     </telerik:RadAjaxManager>
    <div class="row">
        <div class="col-lg-12">

             <table width="100%"><tr>
     <td valign="top" style="border-right: 1px solid black;">
     <table cellpadding="0" cellspacing="0" border="0">
     <!---- time range area ------->
      <tr><td>&nbsp;</td></tr>
        <tr>
            <td></td><td></td>
            <td>
            <label style="font-size: 13px;">Select Time Range:&nbsp;</label>  
        <asp:DropDownList CssClass="textBoxClass" ID="ddlTimeRange" runat="server" AutoPostBack="True" 
          Width="225px" >
                <%--<asp:ListItem Text="8 Hours" Value="8" Selected="True"></asp:ListItem>--%>
                <asp:ListItem Text="24 Hours" Value="24"></asp:ListItem>
                <asp:ListItem Text="1 week" Value="168"></asp:ListItem>
                <asp:ListItem Text="1 month" Value="720"></asp:ListItem>
                <asp:ListItem Text="1 year" Value="8640"></asp:ListItem>
        </asp:DropDownList>
            </td>
            <td></td><td></td>
        </tr>
        <tr height="10px"></tr>
        <!---- first 3 charts area ------->
        <tr>
            <td>
            <div style="display: block;float:left;margin-right:30px;width:500px;margin-left:10px;border:1px solid #000000;">
        Select Primary Function : <asp:DropDownList CssClass="textBoxClass" ID="ddlMainClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMainClass_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource1" DataTextField="sMainClass" DataValueField="sMainClass">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart1" runat="server" Width="500px" Height="270px" OnDataBound="RadChart1_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource2" Skin="LightBlue" ChartTitle-TextBlock-Text="Primary Function Distribution"  AutoLayout="true" >
           <Legend  >
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="smainlcass">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
            <td>
            </td>
            <td>
            <div style="display: block;float:left;border:1px solid #000000;margin-right:30px;">
        Select Secondary Function : <asp:DropDownList CssClass="textBoxClass" ID="ddlSubClass1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubClass1_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource3" DataTextField="sSubClass1" DataValueField="sSubClass1">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart2" runat="server" Width="500px" Height="270px" OnDataBound="RadChart2_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource4" Skin="LightBlue" ChartTitle-TextBlock-Text="Secondary Function Distribution" AutoLayout="true" >
          <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sSubClass1" >
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
            <td>
            </td>
            <td>
            <div style="display: block;float:left;border:1px solid #000000">
        Select Tertiary Function : <asp:DropDownList CssClass="textBoxClass" ID="ddlSubClass2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubClass2_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource5" DataTextField="sSubClass2" DataValueField="sSubClass2">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart3" runat="server" Width="500px" Height="270px" OnDataBound="RadChart3_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource6" Skin="LightBlue" ChartTitle-TextBlock-Text="Tertiary Function Distribution"  AutoLayout="true" >
           <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sSubClass2">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
        </tr>
        <tr height="10px"></tr>
        <!---- next 3 charts area ------->
        <tr>
            <td>
            <div style="display: block;float:left;margin-right:30px;width:500px;margin-left:10px;border:1px solid #000000;">
        Select Instrument Type : <asp:DropDownList CssClass="textBoxClass" ID="ddlInstrumentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstrumentType_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource7" DataTextField="sinstrumenttype" DataValueField="sinstrumenttype">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart4" runat="server" Width="500px" Height="270px" OnDataBound="RadChart4_DataBound"  SeriesOrientation="Vertical" PlotArea-XAxis-AutoShrink="true" 
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource8" Skin="LightBlue" ChartTitle-TextBlock-Text=" Instrument Type Distribution"  AutoLayout="true" >
          <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sinstrumenttype">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
            <td>
            </td>
            <td>
            <div style="display: block;float:left;border:1px solid #000000;margin-right:30px;">
        Select Process Type : <asp:DropDownList CssClass="textBoxClass" ID="ddlProcessFunction" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProcessFunction_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource9" DataTextField="sprocessfunctiontype" DataValueField="sprocessfunctiontype">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart5" runat="server" Width="500px" Height="270px" OnDataBound="RadChart5_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource10" Skin="LightBlue" ChartTitle-TextBlock-Text="Process Type Distribution"  AutoLayout="true" >
           <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sprocessfunctiontype">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
            <td>
            </td>
            <td>
            <div style="display: block;float:left;border:1px solid #000000">
        Select Service : <asp:DropDownList CssClass="textBoxClass" ID="ddlService" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlService_SelectedIndexChanged"
          Width="225px" DataSourceID="SqlDataSource11" DataTextField="sservice" DataValueField="sservice">
     </asp:DropDownList>
     <br />
     <telerik:RadChart ID="RadChart6" runat="server" Width="500px" Height="270px" OnDataBound="RadChart6_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource12" Skin="LightBlue" ChartTitle-TextBlock-Text=" Service Distribution"  AutoLayout="true" >
          <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sservice">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
        </tr>
        <!---- next 3 charts area ------->
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr height="10px"></tr>
        <!---- MFM Chart ------>
        <tr>
            <td align="left" style="padding-left:10px;">
                <div style="display: block;float:left;border:1px solid #000000">
     <telerik:RadChart ID="RadChart7" runat="server" Width="500px" Height="270px" OnDataBound="RadChart7_DataBound"
          DataGroupColumn="sStatus" AutoTextWrap="true" DataSourceID="SqlDataSource14" Skin="LightBlue" ChartTitle-TextBlock-Text=" MPFM Distribution"  AutoLayout="true" >
           <Legend>
                <%--<TextBlock><Appearance Position-AlignedPosition="TopLeft" Location="InsidePlotArea"></Appearance></TextBlock>--%>
               <Appearance Overflow="Row" GroupNameFormat="#VALUE" Position-AlignedPosition="TopLeft" Location="InsidePlotArea">
               </Appearance>
          </Legend>
          <ChartTitle> 
               <TextBlock> 
                        <Appearance TextProperties-Font="Calibiri, 10px"> 
                        </Appearance> 
               </TextBlock> 
        </ChartTitle> 
          <PlotArea XAxis-Appearance-TextAppearance-TextProperties-Font="Calibiri,9px">
               <XAxis DataLabelsColumn="sSubClass2">
               </XAxis>
          </PlotArea>
     </telerik:RadChart>
    </div>
            </td>
        </tr>

     </table>
     </td></tr></table>
     </div></div>
    <!-------- data sources ----------------->
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct mainclass as smainclass from InstFuncHierarchy"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(smainclass varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(smainclass,sStatus)  select  smainclass,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(smainclass,'') <> ''     and smainclass like @sMainClass and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by smainclass,stagnumber insert into #LocalTempTable(smainclass,sStatus)   select  dev.MainClass,case   when (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%' when  (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'  else '>30%' end     from Excursion exc inner join InstFuncHierarchy dev on exc.DeviceName=dev.Mech_Eqpt_no where   exc.StartTime >  dateadd(hour,-convert(int,@timerange),getdate()) and exc.DeviceName is not null and dev.MainClass is not null and dev.MainClass like @sMainClass     and @Station = Case  @Node when '1' then dev.Cluster when '2' then dev.Area  when '3' then dev.Station else @Station end group by dev.MainClass,exc.DeviceName   select #LocalTempTable.smainclass,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by smainclass,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlMainClass" DefaultValue="%" Name="sMainClass" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>
     
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct SubClass1 as sSubClass1 from InstFuncHierarchy  order  by SubClass1"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(ssubclass1 varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(ssubclass1,sStatus)  select  sSubClass1,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(sSubClass1,'') <> ''     and sSubClass1 like @sSubClass1 and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by sSubClass1,stagnumber insert into #LocalTempTable(ssubclass1,sStatus) select  dev.SubClass1,case   when (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%' when  (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'  else '>30%' end     from Excursion exc inner join InstFuncHierarchy dev on exc.DeviceName=dev.Mech_Eqpt_no where   exc.StartTime >  dateadd(hour,-convert(int,@timerange),getdate()) and exc.DeviceName is not null and dev.SubClass1 is not null and dev.SubClass1 like @sSubClass1     and @Station = Case  @Node when '1' then dev.Cluster when '2' then dev.Area  when '3' then dev.Station else @Station end group by dev.SubClass1,exc.DeviceName   select #LocalTempTable.ssubclass1,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by ssubclass1,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlSubClass1" DefaultValue="%" Name="sSubClass1" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>

     <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct SubClass2 as sSubClass2 from InstFuncHierarchy order  by SubClass2"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(ssubclass2 varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(ssubclass2,sStatus)  select  sSubClass2,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(sSubClass2,'') <> ''     and sSubClass2 like @sSubClass2 and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by sSubClass2,stagnumber insert into #LocalTempTable(ssubclass2,sStatus) select  dev.SubClass2,case   when (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%' when  (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'  else '>30%' end     from Excursion exc inner join InstFuncHierarchy dev on exc.DeviceName=dev.Mech_Eqpt_no where   exc.StartTime >  dateadd(hour,-convert(int,@timerange),getdate()) and exc.DeviceName is not null and dev.SubClass2 is not null and dev.SubClass2 like @sSubClass2     and @Station = Case  @Node when '1' then dev.Cluster when '2' then dev.Area  when '3' then dev.Station else @Station end group by dev.SubClass2,exc.DeviceName   select #LocalTempTable.ssubclass2,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by ssubclass2,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlSubClass2" DefaultValue="%" Name="sSubClass2" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>

      <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct Instrument_Type_Description as sinstrumenttype from InstFuncHierarchy where Instrument_Type_Description is not null and Instrument_Type_Description <> 'null' union select ''"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(sinstrumenttype varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(sinstrumenttype,sStatus)  select  sinstrumenttype,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(sInstrumentType,'') <> ''     and sInstrumentType like @sinstrumenttype and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by sInstrumentType,stagnumber   select #LocalTempTable.sinstrumenttype,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by sinstrumenttype,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlInstrumentType" DefaultValue="%" Name="sinstrumenttype" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>

     <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct Process_Function_Type as sprocessfunctiontype from InstFuncHierarchy order by Process_Function_Type"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(sprocessfunctiontype varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(sprocessfunctiontype,sStatus)  select  sprocessfunctiontype,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(sprocessfunctiontype,'') <> ''     and sprocessfunctiontype like @sprocessfunctiontype and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by sprocessfunctiontype,stagnumber   select #LocalTempTable.sprocessfunctiontype,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by sprocessfunctiontype,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlProcessFunction" DefaultValue="%" Name="sprocessfunctiontype" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>

      <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT distinct Service as sService from InstFuncHierarchy where Service is not null and Service <> 'null' union select ''"></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(sservice varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(sservice,sStatus)  select  sservice,case   when ((Case @timerange when 24 then sum(i24Hr10Per) when 168 then sum(i1Wk10Per) when 720 then sum(i1Mn10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%'   when  ((Case @timerange when 24 then sum(i24Hr10Per) else sum(i1Yr10Per) end)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'    else '>30%' end      from InstrumentAggregateExcursionLog where        spitag is not null and isnull(sservice,'') <> ''     and sservice like @sservice and @Station = Case  @Node when '1' then sDirectorate when '2' then sCluster when '3' then sStation else @Station end      group by sservice,stagnumber   select #LocalTempTable.sservice,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by sservice,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <asp:ControlParameter ControlID="ddlService" DefaultValue="%" Name="sservice" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
          </SelectParameters>
     </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource13" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="SELECT * from PlantHierarchy "></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource14" runat="server" ConnectionString="Initial Catalog=PMMS;Data Source=mus-vsqc-002\sqlinst2;User Id=pmms;Password=pdo2013;"
          SelectCommand="CREATE TABLE #LocalTempTable(ssubclass2 varchar(255),asd int, asdf int,sStatus varchar(50)) insert into #LocalTempTable(ssubclass2,sStatus) select  dev.SubClass2,case   when (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60)) *100 < 10 then '<10%' when  (SUM(datediff(minute,exc.starttime,exc.endtime)/60)/(datediff(minute,dateadd(hour,-convert(int,@timerange),getdate()),GETDATE())/60))*100 between 10 and 30 then 'Between10&30%'  else '>30%' end     from Excursion exc inner join InstFuncHierarchy dev on exc.DeviceName=dev.Mech_Eqpt_no where   exc.StartTime >  dateadd(hour,-convert(int,@timerange),getdate()) and exc.DeviceName is not null and dev.SubClass2 is not null and dev.SubClass2 like 'MPFM'     and @Station = Case  @Node when '1' then dev.Cluster when '2' then dev.Area  when '3' then dev.Station else @Station end group by dev.SubClass2,exc.DeviceName   select #LocalTempTable.ssubclass2,#LocalTempTable.sStatus, COUNT(#LocalTempTable.sStatus) from #LocalTempTable group by ssubclass2,sStatus        drop table #LocalTempTable">
          <SelectParameters>
               <%--<asp:ControlParameter ControlID="ddlMainClass" DefaultValue="%" Name="sMainClass" PropertyName="SelectedValue" />--%>
               <asp:ControlParameter ControlID="ddlTimeRange" DefaultValue="%" Name="timerange" PropertyName="SelectedValue" />
               <asp:ControlParameter ControlID="hdnValue" DefaultValue="%" Name="Station" PropertyName="Value" />
               <asp:ControlParameter ControlID="hdnNode" DefaultValue="%" Name="Node" PropertyName="Value" />
               <%--<asp:ControlParameter DefaultValue="MPFM" Name="sSubClass2" />--%>
          </SelectParameters>
     </asp:SqlDataSource>
     <!-------- end data sources ------------->
   </asp:Content>