using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.indx.xhq.solution.clientapi;
using java.lang;
using System.Configuration;
using chartDemo.XhqServiceWrapper;

namespace chartDemo.GeneralPages
{
    public partial class UltraSonicDataSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            APIWrapper apiWrapper = new APIWrapper();
            Entities.DataSheet sheet = apiWrapper.GetDataSheet(Request.QueryString["TagNumber"]);
            BindData(sheet);
        }

        void BindData(Entities.DataSheet sheet)
        {
            if (sheet != null)
            {
                #region General
                lblLocation.Text = sheet.sStation;
                lblTagNo.Text = sheet.sTagNo;
                lblAreaName.Text = sheet.sArea;
                lblUnitName.Text = sheet.sUnitNo;
                lblAmbientTempUnit.Text = sheet.sAmbientTemp_Units;
                lblAmbientTempMin.Text = sheet.sAmbientTemp_Min;
                lblAmbientTempMax.Text = sheet.sAmbientTemp_Max;
                lblAtomUnit.Text = sheet.sAtmosphericPress_Units;
                lblAtomMin.Text = sheet.sAtmosphericPress_Min;
                lblAtomMax.Text = sheet.sAtmosphericPress_Max;
                #endregion

                #region Process
                lblFluid.Text = sheet.sFluid;
                lblFlowUnit.Text = sheet.sFlow_Units;
                lblFlowMin.Text = sheet.sFlow_Min;
                lblFlowNorm.Text = sheet.sFlow_Norm;
                lblFlowMax.Text = sheet.sFlow_Max;
                lblProcPressUnit.Text = sheet.sProcessPress_Units;
                lblProcPressMin.Text = sheet.sProcessPress_Min;
                lblProcPressNorm.Text = sheet.sProcessPress_Norm;
                lblProcPressMax.Text = sheet.sProcessPress_Max;
                lblProcTempUnit.Text = sheet.sProcessTemp_Units;
                lblProcTempMin.Text = sheet.sProcessTemp_Min;
                lblProcTempNorm.Text = sheet.sProcessTemp_Norm;
                lblProcTempMax.Text = sheet.sProcessTemp_Max;
                lblOpDensityUnit.Text = sheet.sOperating_Density;
                lblOpDensityNorm.Text = sheet.sOperatingDensity_Norm;
                lblFluidConNorm.Text = sheet.sMolecular_Weight;
                lblFluidVisUnit.Text = sheet.sViscosoty_Units;
                lblFluidVisMin.Text = sheet.sViscosoty_Min;
                #endregion

                #region Comm
                lblCommWith.Text = sheet.sCommunitaion_With;
                lblCommType.Text = sheet.sCommunitaion_Type;
                lblOutputSignal.Text = sheet.sOutput_Signal;
                lblDeviceSegAddress.Text = sheet.sDevice_SegAddress;
                lblAccessHHT.Text = sheet.sAccess_HandheldTerm;
                #endregion

                #region Transmitter
                lblTransMounting.Text = sheet.sDP_Trans_Mounting;
                lblMagTempComp.Text = sheet.sMagnetic_Temp_Comp;
                lblMagAccuracy.Text = sheet.sMagnetic_Accuracy;
                lblMagLinearity.Text = sheet.sMagnetic_Linearity;
                lblMagRepeatability.Text = sheet.sMagnetic_Repeatability;
                lblMagPowerSupp.Text = sheet.sMagnetic_Trans_P_Supply;
                lblMagTotalizerType.Text = sheet.sMagnetic_Totalizer_Type;
                lblMagTotalizerTypeUnit.Text = sheet.sMagnetic_Totalizer_Type_Units;
                lblMagCableType.Text = sheet.sMagnetic_Cable_Type;
                lblMagCableTypeLength.Text = sheet.sMagnetic_Cable_Length;
                lblMagCableTypeUnit.Text = sheet.sMagnetic_Cable_Units;
                lblMagElectricalConn.Text = sheet.sMagnetic_Elect_Conn;
                lblMagTransEnclosure.Text = sheet.sMagnetic_Trans_Encl;
                lblMagLocalDisp.Text = sheet.sMagnetic_Local_Display;
                lblMagLocalDispUnit.Text = sheet.sMagnetic_Local_Display_Unit;
                #endregion

                #region Pipe
                lblLineSize.Text = sheet.sLine_Size;
                lblLineSizeUnit.Text = sheet.sLine_Size_Units;
                lblPipeSchedule.Text = sheet.sPipe_Schedule;
                lblPipeMaterial.Text = sheet.sPipe_Material;
                lblPipeInsulation.Text = sheet.sPipe_Insulation;
                lblInsulationThick.Text = sheet.sInsulation_Thick;
                lblPipeID.Text = sheet.sPipe_ID;
                lblPipeIDUnit.Text = sheet.sPipe_ID_Units;
                #endregion

                #region Reference
                lblTransSecVarTagName.Text = sheet.sMagnetic_Trans_Sec_Var_Tag_N;
                lblSecVarDesc.Text = sheet.sMagnetic_Sec_Var_Description;
                lblTransTerVarTagName.Text = sheet.sMagnetic_Trans_Tert_Var_Tag_N;
                lblTerVarDesc.Text = sheet.sMagnetic_Trans_Tert_Descrptn;
                #endregion

                #region Test
                lblHydroTest.Text = sheet.sMagnetic_Hydrostatic_Test;
                #endregion

                #region Meter Body
                lblMagElectrodeType.Text = sheet.sMagnetic_Electrode_Type;
                lblMagMaterial.Text = sheet.sMagnetic_Material;
                lblMagCoilDrive.Text = sheet.sMagnetic_Coil_Drive;
                lblMeterBodyPSupply.Text = sheet.sMagnetic_Meter_Body_P_Supply;
                lblMagMeterSize.Text = sheet.sMagnetic_Meter_Size;
                lblMagMeterSizeUnit.Text = sheet.sMagnetic_Meter_Size_Units;
                lblMeterBdyConnType.Text = sheet.sMagnetic_Meter_Bdy_Conn_Type;
                lblMeterBdyConnTypeUnit.Text = "";
                lblMeterBdyConnSize.Text = sheet.sMagnetic_Meter_Bdy_conn_Size;
                lblMagBodyRating.Text = sheet.sMagnetic_Body_Rating;
                lblMagBodyRatingUnit.Text = "";
                lblInsMinFlow.Text = sheet.sMagnetic_Inst_R_Min_Cut_Flow;
                lblInsMaxFlow.Text = sheet.sMagnetic_Inst_R_Max_Meas_Flow;
                lblAccInsMinFlow.Text = sheet.sMagnetic_Acc_Inst_R_Min_Flow;
                lblAccInsMaxFlow.Text = sheet.sMagnetic_Acc_Inst_R_Max_Flow;
                lblAccInsFlowUnit.Text = sheet.sMagnetic_Acc_Inst_R_Units;
                lblMagCaliMinRange.Text = sheet.sMagnetic_Calib_R_DCS_Min;
                lblMagCaliMaxRange.Text = sheet.sMagnetic_Calib_R_DCS_Max;
                lblMagCaliRangeUnit.Text = sheet.sMagnetic_Calib_R_Unit;
                lblMagMaterialHousing.Text = sheet.sMagnetic_Matrials_Housing;
                lblMagMaterialLinear.Text = sheet.sMagnetic_Matrials_Liner;
                lblMagMaterialBody.Text = sheet.sMagnetic_Matrials_Body;
                lblMagMaterialConnSeal.Text = sheet.sMagnetic_Materials_Conn_Seal;
                lblStrPipDownstream.Text = sheet.sMagnetic_Str_Pip_Req_Dnstream;
                lblStrPipUpstream.Text = sheet.sMagnetic_Str_Pip_Req_Upstream;
                lblMagPressDropMin.Text = sheet.sMagnetic_Press_Drop_Min;
                lblMagPressDropMax.Text = sheet.sMagnetic_Press_Drop_Max;
                lblMagPressDropNorm.Text = sheet.sMagnetic_Press_Drop_Norm;
                lblMagPressDropUnit.Text = sheet.sMagnetic_Press_Drop_Units;
                lblMeterBdyEnclosure.Text = sheet.sMagnetic_Meter_Bdy_Enclos;
                lblMagGrounding.Text = sheet.sMagnetic_Grounding;
                #endregion
            }
        }


    }
}