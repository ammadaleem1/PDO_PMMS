<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WGMeterDataSheet.aspx.cs" Inherits="chartDemo.GeneralPages.WGMeterDataSheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Data Sheet</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

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

</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            WG Meter Tube
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                          
                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  General
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <table class="table datasheettable no-border"><tr>
                                    <td class="no-border">
                                    <table class="table table-condensed table-bordered">
                                    <tr><td colspan="2"><h4>Project Name</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblProjectName" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>P&ID No</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblProjectID" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Service</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblService" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Location</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblLocation" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Line No</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblLineNo" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Equipment No</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblEquipNo" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Area Classfication</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblAreaClass" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr>
                                    <td><h4>Design Press (Min/Max)</h4></td><td><h4><small>Units</small></h4></td>
                                    <td><h4><small> to </small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblDesignPress" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Design Temp (Min/Max)</h4></td><td><h4><small>Units</small></h4></td>
                                    <td><h4><small> to </small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblDesignTemp" runat="server" Text="" /></small></h4></td>
                                    </tr>
                                    </table>
                                    </td>
                                    <td  class="no-border">
                                    <table class="table table-condensed table-bordered">
                                    <tr><td colspan="2"><h4>Tag Number</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblTagNo" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Plant Name</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblPlantName" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Area Name</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblAreaName" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Unit Name</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblUnitName" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="2"><h4>Work Breakdown Structure</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblWorkBreak" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr>
                                    <td><h4>Ambient Temp (Min/Max)</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblAmbientTempUnit" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblAmbientTempMin" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblAmbientTempMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Atmospheric Pressure</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblAtomUnit" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblAtomMin" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblAtomMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Max Allowable Press Drop</h4></td><td><h4><small><asp:Label ID="Label16" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label ID="Label8" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label ID="Label21" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>MWP @ Design Temp</h4></td><td><h4><small><asp:Label ID="Label17" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label ID="Label20" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label ID="Label19" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    </table>
                                    </td>
                                    </tr></table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Process
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <table class="table table-condensed table-bordered">
                                    <tr>
                                    <td><h4>Fluid</h4></td><td colspan="4"><h4>Fluid State</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblFluid" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lbllblFluidState" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Flow Rate</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFlowUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFlowMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFlowNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFlowMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Process Pressure</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblProcPressUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblProcPressMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblProcPressNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblProcPressMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Process Temperature</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblProcTempUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblProcTempMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblProcTempNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblProcTempMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Operating SG / Density</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblOpDensityUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblOpDensityMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblOpDensityNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblOpDensityMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Base SG / Density</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblBaseDensityUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblBaseDensityMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblBaseDensityNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblBaseDensityMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Molecular Weight</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMoleWeightUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMoleWeightMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMoleWeightNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMoleWeightMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Condensate Molecular Weight</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblConMoleWeightUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblConMoleWeightMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblConMoleWeightNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblConMoleWeightMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Hydrocarbon Molar Weight</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblHydMolWgUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblHydMolWgMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblHydMolWgNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblHydMolWgMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Fluid Viscosity</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Compressibility @ Operating</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressOpUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressOpMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressOpNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressOpMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Compressibility @ Base</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressBsUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressBsMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressBsNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblCompressBsMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Reynolds No</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Measured dP</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMeasureddPUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMeasureddPMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMeasureddPNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMeasureddPMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Steam Quality</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblSteamQltyUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblSteamQltyMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblSteamQltyNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblSteamQltyMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Vapour Pressure</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblVapPressUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblVapPressMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblVapPressNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblVapPressMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Percent Solids</h4></td><td colspan="4"><h4>Solids Type</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblPercentSolids" runat="server" Text="-" />%</small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblSolidsType" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Ratio of Specific Heat Cp/Cv</h4></td><td colspan="4"><h4></h4></td>
                                    <td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblRatioofHeat" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Pipe
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                      <table class="table table-condensed table-bordered">
                                        <tr>
                                        <td><h4>Line Size</h4></td><td><h4><small>Units</small></h4></td><td><h4><small>Pipe Schedule</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblLineSize" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblLineSizeUnit" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPipeSchedule" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Pipe Material</h4></td>
                                        <td colspan="3"><h4><small><asp:Label CssClass="dslabel" ID="lblPipeMaterial" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Pipe Insulation</h4></td><td><h4><small>Insulation Thickness</small></h4></td><td><h4><small>Units</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPipeInsulation" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblInsulationThick" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblInsulationUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Pipe ID</h4></td><td><h4><small>Units</small></h4></td><td><h4><small>Line Orientation</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPipeID" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblPipeIDUnit" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblLineOrient" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                      </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Venturi Tube
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered">
                                        <tr><td colspan="5"><h4>Type</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblVenturiType" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr><td colspan="5"><h4>Material</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblVenturiMaterial" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td colspan="3"><h4>Thickness</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblVenturiThick" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblVenturiThickUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="5"><h4>Beta Ratio</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblBetaRatio" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr><td colspan="5"><h4>Discharge Coefficient</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblDisCoefficient" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td colspan="3"><h4>Cylinder Entrance Section Length</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblCylSecLength" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblCylSecLengthUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Conical Convert Length</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConConvertLength" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConConvertLengthUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Throat Length</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblThroatLength" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblThroatLengthUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Throat Diameter</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblThroatDiameter" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblThroatDiameterUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Cornical Diverge Length</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConDivergeLength" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConDivergeLengthUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Cornical Diverge Angle</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConDivergeAngle" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConDivergeAngleUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="5"><h4>Tape Type</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblTapeType" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td colspan="3"><h4>Tape Size</h4></td><td colspan="2"><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblTapeSize" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblTapeTypeUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="5"><h4>Tape Orientaion</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblTapeOrientation" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr><td colspan="5"><h4>Overreading Exponent</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblOverExponent" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr><td colspan="5"><h4>Overreading Parameter</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblOverParameter" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td colspan="2"><h4>End Connection Type</h4></td><td><h4><small>Facing</small></h4></td><td><h4><small>Size</small></h4></td><td><h4><small>Units</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblEndConnType" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblEndConnFacing" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblEndConnSize" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblEndConnUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="3"><h4>Convergence Angle</h4></td><td colspan="2"><h4><small>Divergent Angle</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblConAngle" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblDivAngle" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Pressure Drop</h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td><td><h4><small>Units</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPressDropMin" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblPressDropNorm" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPressDropMax" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblPressDropUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="5"><h4>Brill & Beggs Variable</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblBrnBgVar" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td colspan="3"><h4>Straight Pipe Requirements - Upstream</h4></td><td colspan="2"><h4><small>Downstream</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblStrPipeup" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblStrPipedown" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="5"><h4>Venturi Reference Standard</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblVenturiRefStandard" runat="server" Text="-" /></small></h4></td></tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Test
                                </div>
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered">
                                        <tr><td><h4>Hydrostatic Test</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblHydroTest" runat="server" Text="-" /></small></h4></td></tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Purchase
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered">
                                        <tr><td colspan="2"><h4>Manufacturer</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblPurManufacturer" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr><td colspan="2"><h4>Model No</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblPurModelNo" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td><h4>PO No</h4></td><td><h4>Item No</h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblPurPONo" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblPurItemNo" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="2"><h4>Serial No</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblPurSerialNo" runat="server" Text="-" /></small></h4></td></tr>
                                        <tr>
                                        <td><h4>Device Pressure Registration</h4></td><td><h4>ECCN</h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblDvPressRegistration" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblPurDvECCN" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Electrical Approval</h4></td><td><h4>ECCN</h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblElecApproval" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblElecECCN" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                     </table>
                                </div>
                               </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
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
</body>
</html>
