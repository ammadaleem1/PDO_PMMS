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
    public partial class VenturiDataSheet : System.Web.UI.Page
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
                lblMoleWeightNorm.Text = sheet.sMolecular_Weight;
                lblFluidVisUnit.Text = sheet.sViscosoty_Units;
                lblFluidVisMin.Text = sheet.sViscosoty_Min;
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

                #region Venturi Tube
                lblVenturiType.Text = sheet.sVenturi_Type;
                lblVenturiMaterial.Text = sheet.sVenturi_Material;
                lblVenturiThick.Text = sheet.sVenturi_Thickness;
                lblVenturiThickUnit.Text = sheet.sVenturi_Thickness_Units;
                lblBetaRatio.Text = sheet.sVenturi_Beta_Ratio;
                lblCylSecLength.Text = sheet.sVenturi_Cyl_Entr_Sec_Length;
                lblCylSecLengthUnit.Text = sheet.sVenturi_Cyl_Entr_Sec_L_Units;
                lblConConvertLength.Text = sheet.sVenturi_Coni_Conv_Length;
                lblConConvertLengthUnit.Text = sheet.sVenturi_Coni_Conv_L_Units;
                lblThroatLength.Text = sheet.sVenturi_Throat_Length;
                lblThroatLengthUnit.Text = sheet.sVenturi_Throat_Length_Units;
                lblThroatDiameter.Text = sheet.sVenturi_Throat_Diameter;
                lblThroatDiameterUnit.Text = sheet.sVenturi_Throat_Diameter_Units;
                lblConDivergeLength.Text = sheet.sVenturi_Coni_Div_Length;
                lblConDivergeLengthUnit.Text = sheet.sVenturi_Coni_Div_Length_Units;
                lblConDivergeAngle.Text = sheet.sVenturi_Conical_Diverge_Angle;
                lblConDivergeAngle.Text = sheet.sVenturi_Coni_Div_Angle_Units;
                lblTapeType.Text = sheet.sVenturi_Taps_Type;
                lblTapeSize.Text = sheet.sVenturi_Taps_Size;
                lblTapeSize.Text = sheet.sVenturi_Taps_Size_Units;
                lblTapeOrientation.Text = sheet.sVenturi_Taps_Orientation;
                lblEndConnType.Text = sheet.sVenturi_End_Connection_Type;
                lblEndConnFacing.Text = sheet.sVenturi_Facing;
                lblEndConnSize.Text = sheet.sVenturi_End_Connection_Size;
                lblEndConnUnit.Text = sheet.sVenturi_End_Con_Typ_Sze_Units;
                lblConAngle.Text = sheet.sVenturi_Convergence_Angle;
                lblDivAngle.Text = sheet.sVenturi_Divergent_Angle;
                lblPressDropMax.Text = sheet.sVenturi_Pressure_Drop_Max;
                lblPressDropMin.Text = sheet.sVenturi_Pressure_Drop_Min;
                lblPressDropUnit.Text = sheet.sVenturi_Pressure_Drop_Unit;
                lblPressDropNorm.Text = sheet.sVenturi_Pressure_Drop_Normal;
                lblStrPipeup.Text = sheet.sVenturi_Str_pipe_req_Upstream;
                lblStrPipedown.Text = sheet.sVenturi_Str_pipe_req_Dnstream;
                lblStrPipedown.Text = sheet.sVenturi_Str_pipe_req_Dnstream;
                lblDisCoefficient.Text = sheet.sVenturi_Discharge_coefficient;
                lblVenturiRefStandard.Text = sheet.sVenturi_Venturi_Ref_Standard;

                #endregion

            }
        }


    }
}