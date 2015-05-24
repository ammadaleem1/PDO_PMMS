<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoriolisDataSheet.aspx.cs" Inherits="chartDemo.GeneralPages.CoriolisDataSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h3 class="page-header"><asp:Label ID="lblTagNumber" runat="server" ></asp:Label> - Magnetic</h3>
        </div>
        <!-- /.col-lg-12 -->
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
                                    <td  class="no-border">
                                    <table class="table table-condensed table-bordered datasheettable">
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
                                    <table class="table table-condensed table-bordered datasheettable">
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
                                </div></div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Process
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <table class="table table-condensed table-bordered datasheettable">
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
                                    <td><h4>Fluid Conductivity</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidConUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidConMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidConNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidConMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                     <tr>
                                    <td><h4>Fluid Viscosity</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblFluidVisMax" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Reynolds No</h4></td><td><h4><small>Unit</small></h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Normal</small></h4></td><td><h4><small>Max</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldUnit" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldMin" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldNorm" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblReynoldMax" runat="server" Text="-" /></small></h4></td>
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
                                    <td><h4>Foaming</h4></td><td colspan="4"><h4>Corrosive/Abrasive Property</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblFoaming" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblCorAbProperty" runat="server" Text="-" /></small></h4></td>
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
                                      <table class="table table-condensed table-bordered datasheettable">
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
                                </div></div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Meter
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <table class="table table-condensed table-bordered datasheettable">
                                    <tr>
                                    <td><h4>Electrode Type</h4></td><td colspan="4"><h4>Material</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagElectrodeType" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMaterial" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Coil Drive</h4></td><td colspan="4"><h4>Power Supply</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagCoilDrive" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMeterBodyPSupply" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4"><h4>Meter Size</h4></td><td><h4><small>Units</small></h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMeterSize" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMeterSizeUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Connection Type</h4></td><td colspan="3"><h4>Size</h4></td><td><h4><small>Units</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMeterBdyConnType" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMeterBdyConnSize" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMeterBdyConnTypeUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4"><h4>Body Rating</h4></td><td><h4><small>Units</small></h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagBodyRating" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagBodyRatingUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4"><h4>Instr Range (Min Cutoff Flow to Max Measurable Flow)</h4></td><td><h4><small>Units</small></h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblInsMinFlow" runat="server" Text="-" /> to <asp:Label CssClass="dslabel" ID="lblInsMaxFlow" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblInsFlowUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4"><h4>Accurate Instr Range (Min to Max Accurate Flow)</h4></td><td><h4><small>Units</small></h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblAccInsMinFlow" runat="server" Text="" /> to <asp:Label CssClass="dslabel" ID="lblAccInsMaxFlow" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblAccInsFlowUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td colspan="4"><h4>Calibrated Range (DCS Display Range)</h4></td><td><h4><small>Units</small></h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagCaliMinRange" runat="server" Text="" /> to <asp:Label CssClass="dslabel" ID="lblMagCaliMaxRange" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagCaliRangeUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Materials - Housing</h4></td><td colspan="4"><h4>Materials - Body</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMaterialHousing" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMaterialBody" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Materials - Linear</h4></td><td colspan="4"><h4>Materials - Connection Seal</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMaterialLinear" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagMaterialConnSeal" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Straight Pipe Requirements - Upstream</h4></td><td colspan="4"><h4>Downstream</h4></td>
                                    <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblStrPipUpstream" runat="server" Text="-" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblStrPipDownstream" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr>
                                    <td><h4>Pressure Drop</h4></td><td><h4><small>Min</small></h4></td><td><h4><small>Norm</small></h4></td><td><h4><small>Max</small></h4></td><td><h4><small>Units</small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagPressDropMin" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMagPressDropNorm" runat="server" Text="-" /></small></h4></td>
                                    <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagPressDropMax" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMagPressDropUnit" runat="server" Text="-" /></small></h4></td>
                                    </tr>
                                    <tr><td colspan="5"><h4>Enclosure</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblMeterBdyEnclosure" runat="server" Text="-" /></small></h4></td></tr>
                                    <tr><td colspan="5"><h4>Grounding</h4></td><td colspan="4"><h4><small><asp:Label CssClass="dslabel" ID="lblMagGrounding" runat="server" Text="" /></small></h4></td></tr>
                                    </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Comm&Soft
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered datasheettable">
                                        <tr>
                                        <td><h4>Communication Type</h4></td><td><h4>Communication With</h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblCommType" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblCommWith" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Output Signal</h4></td><td><h4>Device Segment Address</h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblOutputSignal" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblDeviceSegAddress" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr><td colspan="2"><h4>Accessible from Hand Held Terminal</h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblAccessHHT" runat="server" Text="-" /></small></h4></td></tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Transmitter
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered datasheettable">
                                        <tr>
                                        <td><h4>Transmitter Mounting</h4></td><td colspan="2"><h4><small>Temperature Compensator</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblTransMounting" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagTempComp" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                         <tr>
                                        <td><h4>Accuracy</h4></td><td colspan="2"><h4><small>Linearity</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagAccuracy" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagLinearity" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Repeatibility</h4></td><td colspan="2"><h4><small>Power Supply</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagRepeatability" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagPowerSupp" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td colspan="2"><h4>Totalizer Type</h4></td><td><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagTotalizerType" runat="server" Text="" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMagTotalizerTypeUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Cable Type</h4></td><td><h4><small>Length</small></h4></td><td><h4><small>Units</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagCableType" runat="server" Text="-" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMagCableTypeLength" runat="server" Text="-" /></small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagCableTypeUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                        <tr>
                                        <td><h4>Electical Connection</h4></td><td colspan="2"><h4><small>Enclosure</small></h4></td>
                                        <td><h4><small><asp:Label CssClass="dslabel" ID="lblMagElectricalConn" runat="server" Text="" /></small></h4></td><td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagTransEnclosure" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                         <tr>
                                        <td colspan="2"><h4>Local Display</h4></td><td><h4><small>Units</small></h4></td>
                                        <td colspan="2"><h4><small><asp:Label CssClass="dslabel" ID="lblMagLocalDisp" runat="server" Text="" /></small></h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblMagLocalDispUnit" runat="server" Text="-" /></small></h4></td>
                                        </tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Test
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered datasheettable">
                                        <tr><td><h4>Hydrostatic Test</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblHydroTest" runat="server" Text="-" /></small></h4></td></tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Reference
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered datasheettable">
                                        <tr><td><h4>Transmitter Secondary Variable Tag Name</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblTransSecVarTagName" runat="server" Text="" /></small></h4></td></tr>
                                        <tr><td><h4>Secondary Variable Description</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblSecVarDesc" runat="server" Text="" /></small></h4></td></tr>
                                        <tr><td><h4>Transmitter Tertiary Variable Tag Name</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblTransTerVarTagName" runat="server" Text="" /></small></h4></td></tr>
                                        <tr><td><h4>Tertiary Variable Description</h4></td><td><h4><small><asp:Label CssClass="dslabel" ID="lblTerVarDesc" runat="server" Text="" /></small></h4></td></tr>
                                     </table>
                                </div>
                                </div>

                                <div class="panel panel-default">
                                <div class="panel-heading">
                                  Purchase
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                     <table class="table table-condensed table-bordered datasheettable">
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
                 
 
 </asp:Content>