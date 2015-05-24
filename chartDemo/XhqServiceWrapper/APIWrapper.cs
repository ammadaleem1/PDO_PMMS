using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using com.indx.xhq.solution.clientapi;
using java.lang;
using com.indx.xhq.solution;
using chartDemo.Entities;
using com.indx.xhq.util;

namespace chartDemo.XhqServiceWrapper
{
    public class APIWrapper
    {

        string ANS_HOST = ConfigurationSettings.AppSettings["AnsHost"] != null ? ConfigurationSettings.AppSettings["AnsHost"] : "148.151.135.7";

        public DataSheet GetDataSheet(string tagNumber)
        {
            Solution s = null;
            List<DataSheet> list = new List<DataSheet>();
            try
            {
                s = Solution.getConnection(ANS_HOST);
                SolRoot r = s.getRootObject();
                string collection = ConfigurationSettings.AppSettings["GlobalCollection"] != null ? ConfigurationSettings.AppSettings["GlobalCollection"] : "::colSchematics";
                ICollectionQuery icq = s.getGlobalCollection(collection);
                SolQueryCriterion[] criterions = new SolQueryCriterion[] {new SolQueryCriterion("sTagNo", SolQueryCriterion.EQ, new VariantValue(tagNumber))};
                SolQueryCriteria qc = new SolQueryCriteria(criterions);
                SolCollectionSet set = icq.query(new string[456] { "sAccess_HandheldTerm","sAmbientTemp_Max","sAmbientTemp_Min","sAmbientTemp_Units","sArea","sArea_Class","sAtmosphericPress_Max","sAtmosphericPress_Min",
                "sAtmosphericPress_Units","sCommunitaion_Type","sCommunitaion_With","sCoriolis_Acc_Inst_R_Max_Flow","sCoriolis_Acc_Inst_Range_Units","sCoriolis_Acc_Instr_R_Min_Flow","sCoriolis_Accuracy","sCoriolis_Accuracy_ref_to","sCoriolis_Body_Rating",
                "sCoriolis_Body_Rating_Units","sCoriolis_Cable_type","sCoriolis_Cal_Range_DCS_Max","sCoriolis_Cal_Range_Unit","sCoriolis_Cali_Range_DCS_Min","sCoriolis_Conn_Rating_Units","sCoriolis_End_Connction_Rating","sCoriolis_End_Connection_Size",
                "sCoriolis_End_Connection_Type","sCoriolis_End_Connection_Units","sCoriolis_Hydrostatic_Test","sCoriolis_Instr_R_MaxMeas_Flow","sCoriolis_Instr_R_MinCut_Flow","sCoriolis_InstRange_Flow_Units","sCoriolis_K_Factor","sCoriolis_K_Factor_Units",
                "sCoriolis_Materials_Body","sCoriolis_Materials_Housing","sCoriolis_Materials_Sensor","sCoriolis_Meter_Size_Units","sCoriolis_OP_Signal","sCoriolis_Power_Supply","sCoriolis_Pressure_Drop_Max","sCoriolis_Pressure_Drop_Min",
                "sCoriolis_Pressure_Drop_Normal","sCoriolis_Pressure_Drop_Units","sCoriolis_repeatablility","sCoriolis_reptablility_ref_to","sCoriolis_Sec_Conn_R_Units","sCoriolis_Sec_Conn_Rating","sCoriolis_Sec_Var_Description","sCoriolis_Temp_Compensator",
                "sCoriolis_Totalizer_type","sCoriolis_Tran_Tert_Descript","sCoriolis_Tran_Tert_Var_Tag_N","sCoriolis_Trans_Sec_Var_Tag_N","sCoriolis_Trans_Type","sDevice_SegAddress","sDP_Trans_Acc","sDP_Trans_Acc_Inst_R_Min_Flow","sDP_Trans_Acc_Inst_R_Units",
                "sDP_Trans_Acc_Instr_R_Max_Flow","sDP_Trans_Calib_R_DCS_Max","sDP_Trans_Calib_R_DCS_Min","sDP_Trans_Calibr_R_Unit","sDP_Trans_Dampening","sDP_Trans_Elect_Connection","sDP_Trans_Encl_Class","sDP_Trans_Failure_Mode","sDP_Trans_Fill_Fluid",
                "sDP_Trans_Function","sDP_Trans_Hydrostatic_Test","sDP_Trans_Inst_R_Flow_Units","sDP_Trans_Inst_R_Max_Meas_Flow","sDP_Trans_Inst_R_Min_Cut_Flow","sDP_Trans_Integ_Meter_Scale","sDP_Trans_Integ_Mount_Manifold","sDP_Trans_Lightnin_Protection",
                "sDP_Trans_Load_Resistance","sDP_Trans_Matrial_Element","sDP_Trans_Matrial_Housing","sDP_Trans_Matrial_Traceablty","sDP_Trans_Matrial_W_ORing","sDP_Trans_Max_R_Press","sDP_Trans_Max_R_Press_Unit","sDP_Trans_Max_R_Temp","sDP_Trans_Max_R_Temp_Units",
                "sDP_Trans_Min_R_Temp","sDP_Trans_Min_R_Temp_Units","sDP_Trans_Mount_Brackets","sDP_Trans_Mounting","sDP_Trans_Paint","sDP_Trans_Process_Connection","sDP_Trans_Repeatability","sDP_Trans_Resp_Time","sDP_Trans_Sec_Var_Description",
                "sDP_Trans_Sec_Var_Tag_Name","sDP_Trans_Supr_Elev_K","sDP_Trans_Tert_Description","sDP_Trans_Tert_Var_Tag_N","sDP_Trans_Wiring_Conn_Type","sDP_Transm_Matrial_Boltin","sDP_Transmitter_Power_Supply","sDP_Transmitter_Type","sDrawingNumber",
                "sFlow_Max","sFlow_Min","sFlow_Norm","sFlow_Units","sFluid","sFluid_State","sInstTypeDescription","sInsulation_Thick","sLine_Orientation","sLine_Size","sLine_Size_Units","sLineNo","sLocation","sMagnetic_Acc_Inst_R_Max_Flow","sMagnetic_Acc_Inst_R_Min_Flow",
                "sMagnetic_Acc_Inst_R_Units","sMagnetic_Accuracy","sMagnetic_Body_Rating","sMagnetic_Cable_Length","sMagnetic_Cable_Type","sMagnetic_Cable_Units","sMagnetic_Calib_R_DCS_Max","sMagnetic_Calib_R_DCS_Min","sMagnetic_Calib_R_Unit","sMagnetic_Coil_Drive",
                "sMagnetic_Elect_Conn","sMagnetic_Electrode_Type","sMagnetic_Grounding","sMagnetic_Hydrostatic_Test","sMagnetic_Hydrostatic_Test1","sMagnetic_Inst_R_Max_Meas_Flow","sMagnetic_Inst_R_Min_Cut_Flow","sMagnetic_Instr_R_Flow_Units","sMagnetic_Linearity",
                "sMagnetic_Local_Display","sMagnetic_Local_Display_Unit","sMagnetic_Material","sMagnetic_Materials_Conn_Seal","sMagnetic_Matrials_Body","sMagnetic_Matrials_Housing","sMagnetic_Matrials_Liner","sMagnetic_Meter_Bdy_conn_Size","sMagnetic_Meter_Bdy_Conn_Type",
                "sMagnetic_Meter_Bdy_Enclos","sMagnetic_Meter_Body_P_Supply","sMagnetic_Meter_Size","sMagnetic_Meter_Size_Units","sMagnetic_Press_Drop_Max","sMagnetic_Press_Drop_Min","sMagnetic_Press_Drop_Norm","sMagnetic_Press_Drop_Units","sMagnetic_Repeatability",
                "sMagnetic_Sec_Var_Description","sMagnetic_Str_Pip_Req_Dnstream","sMagnetic_Str_Pip_Req_Upstream","sMagnetic_Temp_Comp","sMagnetic_Totalizer_Type","sMagnetic_Totalizer_Type_Units","sMagnetic_Trans_Encl","sMagnetic_Trans_Mounting",
                "sMagnetic_Trans_P_Supply","sMagnetic_Trans_Sec_Var_Tag_N","sMagnetic_Trans_Tert_Descrptn","sMagnetic_Trans_Tert_Var_Tag_N","sMolecular_Weight","sOperating_Density","sOperatingDensity_Norm","sOrifice_Asso_Orific_Mtr_Run_T","sOrifice_Asso_Trans_T_H_Range",
                "sOrifice_Asso_Trans_T_L_Range","sOrifice_Asso_Trans_T_L_Range1","sOrifice_Beta_Ratio","sOrifice_Bore_Dia_deg_C_F","sOrifice_Bore_Diameter_Unit","sOrifice_Drain_Hole_Position","sOrifice_Drain_Venthol_sz_Unit","sOrifice_Drain_Venthole_size",
                "sOrifice_Facing","sOrifice_Flange_Material","sOrifice_Flange_Size","sOrifice_Flange_Size_Unit","sOrifice_Flanged_Rating","sOrifice_Gasket_Material","sOrifice_Material","sOrifice_Orifice_Plate_Type","sOrifice_OrifPlat_ref_Standard",
                "sOrifice_Pipe_Rey_Norm_Flow","sOrifice_Plate_Out_Dia_Unit","sOrifice_Plate_Outside_Dia","sOrifice_Plate_Tab","sOrifice_Plate_Thickness","sOrifice_Plate_Thickness_Unit","sOrifice_Press_Lss_Mtr_Mx_Flw","sOrifice_Prs_Ls_Mtr_Mx_Fl_Unit",
                "sOrifice_Seal_Material","sOrifice_Seal_Type","sOrifice_Standard","sOrifice_Taps_Orientation","sOrifice_Taps_Size","sOrifice_Taps_Size_Unit","sOrifice_Taps_Type","sOrifice_Upstr_Side_Tab_Stamp","sOutput_Signal","sPipe_ID","sPipe_ID_Units",
                "sPipe_Insulation","sPipe_Material","sPipe_Schedule","sPres_Diap_Sl_Pr_Con_R_Units","sPres_Diap_Sl_Pr_Con_Rating","sPres_Diap_Sl_Pr_Con_Size_Unit","sPress_Cali_R_DCS_Disp_R_Unit","sPress_Capillary_Length","sPress_Capillary_Length_Unit","sPress_Diap_Sl_Fill_Fl",
                "sPress_Diap_Sl_Pr_Con_Facing","sPress_Diap_Sl_Pr_Conn_Size","sPress_Flushing_Conn","sPress_Flushing_Conn_Units","sPress_Inst_R_MeasPres_Unit","sPress_Linearity_Ref_to","sPress_Sec_Var_description","sPress_Tert_Var_description","sPress_Trans_Sec_Var_T_N",
                "sPress_Trans_Tert_Var_T_N","sPressure_Acc_Ins_R_Prss_Unit","sPressure_Acc_Instr_R_Mn_Press","sPressure_Acc_Instr_R_Mx_Press","sPressure_Acc_Ref_to","sPressure_Accuracy","sPressure_Cali_R_DCS_Disp_R_Mn","sPressure_Cali_R_DCS_Disp_R_Mx",
                "sPressure_Capillary_Material","sPressure_Capillary_Type","sPressure_Dampening","sPressure_Diap_Material","sPressure_Diap_Sl_Pr_Con_T","sPressure_Elect_Conn","sPressure_Enclosure_type","sPressure_Failure_Mode","sPressure_Function",
                "sPressure_Housing_Material","sPressure_Inst_R_Max_Meas_Pres","sPressure_Inst_R_Min_Meas_Pres","sPressure_Linearity","sPressure_Load_Resistance","sPressure_Local_Display","sPressure_Local_Display_Unit",
                "sPressure_Manifold","sPressure_Manufacturer","sPressure_Material_Bolting","sPressure_Material_Element","sPressure_Material_Housing","sPressure_Matrial_W_ORing","sPressure_Max_Rated_Press","sPressure_Max_Rated_Press_Unit","sPressure_Max_Rated_Temp",
                "sPressure_Max_Rated_Temp1","sPressure_Min_Rated_Temp","sPressure_Min_Rated_Temp_Unit","sPressure_Mounting_Brackets","sPressure_Mterial_Traceability","sPressure_Namur_43","sPressure_Paint","sPressure_Power_Supply","sPressure_Repeatability","sPressure_Response_Time",
                "sPressure_Trans_Fill_Fluid","sPressure_Trans_Process_Conn","sPressure_Wiring_Conn_Type","sProcessPress_Max","sProcessPress_Min","sProcessPress_Norm","sProcessPress_Units","sProcessTemp_Max","sProcessTemp_Min","sProcessTemp_Norm",
                "sProcessTemp_Units","sStation","sTagNo","sUnitNo","sUS_Accuracy","sUS_Alarm_Contacts_No","sUS_Body_Material","sUS_Cable_length_to_Transducer","sUS_Cali_Range_Mn_for_DCS","sUS_Cali_Range_Mx_for_DCS","sUS_Calib_Range_DCS_Units",
                "sUS_Conduit_Cable_Connection","sUS_Conduit_Size","sUS_Conduit_Size_units","sUS_Connection_Materials","sUS_Connection_Rating_Units","sUS_Construction","sUS_Contact_Action","sUS_Contact_Form","sUS_Current_Rating","sUS_Current_Rating_Units",
                "sUS_Digital_Output","sUS_Electr_Encl_Classification","sUS_Element_Type","sUS_Housing_material","sUS_Hydrostatic_Test","sUS_Inst_Range_Max_Meas_Flow","sUS_Inst_Range_Min_Cutoff_Flow","sUS_Instr_Range_Flow_Units","sUS_Local_Display",
                "sUS_Meter_Bdy_Conn_Type","sUS_Meter_Bdy_Connection_Size","sUS_Meter_Bdy_Connection_Units","sUS_Mounting","sUS_Power_Supply","sUS_Pressure_Sensor_Tag_Name","sUS_Sec_Var_Description","sUS_Sensor_Material","sUS_Straight_Pipe_Req_Dnstream",
                "sUS_Straight_Pipe_Rq_Upstream","sUS_Temp_Sensor_Tag_Name","sUS_Trans_Tertiary_Description","sUS_Trans_Tertiary_Var_Tag_N","sUS_Transm_Sec_Var_Tag_Name","sUS_Trndcr_Conn_Size_Units","sUS_Trndcr_Connection_Rating","sUS_Trndcr_Connection_Size",
                "sUS_Validation_Test","sUS_Voltage_Rating","sUS_Voltage_Rating_Units","sVCone_Beta_Ratio","sVCone_Calibration","sVCone_Calibration1","sVCone_Cone_Config_Option","sVCone_Cone_Diameter","sVCone_Cone_Diameter_Units","sVCone_Cone_Temp_Units",
                "sVCone_Cone_Temperature","sVCone_Discharge_Coeff","sVCone_Distance_bt_Taps","sVCone_Distance_bt_Taps_Units","sVCone_DP_at_Sizing_Flow_Rate","sVCone_DP_Sizng_Fl_Rate_Units","sVCone_DP_Taps_Orientation","sVCone_DP_Taps_Size","sVCone_DP_Taps_Size_Units",
                "sVCone_DP_Taps_Type","sVCone_End_Conn_Facing","sVCone_End_Conn_Facing_Units","sVCone_End_Conn_Rating_Units","sVCone_End_Conn_Size_Units","sVCone_End_Connection_Rating","sVCone_End_Connection_Size","sVCone_End_Connection_Type","sVCone_Flow_Element_Cone_Matrl",
                "sVCone_Flow_Element_Pipe_Units","sVCone_Flow_Elment_Pipe_R","sVCone_Flow_Elment_Pipe_Sched","sVCone_Flow_Elmnt_Pipe_Matrl","sVCone_HydroStatic_Test","sVCone_Meter_Run_ref_Drwg","sVCone_Pipe_Internal_Dia_Sze","sVCone_Pipe_Internal_Diameter",
                "sVCone_Pressure_Drop_Max","sVCone_Pressure_Drop_Min",
                "sVCone_Pressure_Drop_Norm",
                "sVCone_Pressure_Drop_Units",
                "sVCone_Size_Flow_Rate",
                "sVCone_Size_Flow_Rate_Units",
                "sVCone_Strght_Pipe_Rq_Dnstream",
                "sVCone_Strght_Pipe_Rq_Upstream",
                "sVCone_XRay",
                "sVenturi_Beta_Ratio",
                "sVenturi_Coni_Conv_L_Units",
                "sVenturi_Coni_Conv_Length",
                "sVenturi_Coni_Div_Angle_Units",
                "sVenturi_Coni_Div_Length",
                "sVenturi_Coni_Div_Length_Units",
                "sVenturi_Conical_Diverge_Angle",
                "sVenturi_Convergence_Angle",
                "sVenturi_Cyl_Entr_Sec_L_Units",
                "sVenturi_Cyl_Entr_Sec_Length",
                "sVenturi_Discharge_coefficient",
                "sVenturi_Divergent_Angle",
                "sVenturi_End_Con_Typ_Sze_Units",
                "sVenturi_End_Connection_Size",
                "sVenturi_End_Connection_Type",
                "sVenturi_Facing",
                "sVenturi_Material",
                "sVenturi_Pressure_Drop_Max",
                "sVenturi_Pressure_Drop_Min",
                "sVenturi_Pressure_Drop_Normal",
                "sVenturi_Pressure_Drop_Unit",
                "sVenturi_Str_pipe_req_Dnstream",
                "sVenturi_Str_pipe_req_Upstream",
                "sVenturi_Taps_Orientation",
                "sVenturi_Taps_Size",
                "sVenturi_Taps_Size_Units",
                "sVenturi_Taps_Type",
                "sVenturi_Thickness",
                "sVenturi_Thickness_Units",
                "sVenturi_Throat_Diameter",
                "sVenturi_Throat_Diameter_Units",
                "sVenturi_Throat_Length",
                "sVenturi_Throat_Length_Units",
                "sVenturi_Type",
                "sVenturi_Venturi_Ref_Standard",
                "sViscosoty_Min",
                "sViscosoty_Units",
                "sVortex_Acc_Instr_R_Flow_Unit",
                "sVortex_Acc_Instr_R_Mn_Flow",
                "sVortex_Acc_Instr_R_Mx_Flow",
                "sVortex_Accuracy",
                "sVortex_Accuracy_ref_to",
                "sVortex_Body_Conn_R_Units",
                "sVortex_Body_Connection_Rating",
                "sVortex_Body_Size",
                "sVortex_Body_Size_Units",
                "sVortex_Cable_Type",
                "sVortex_Cali_R_DCS_Disp_R_Max",
                "sVortex_Cali_R_DCS_Disp_R_Min",
                "sVortex_Cali_R_DCS_Disp_R_Unit",
                "sVortex_End_Connection",
                "sVortex_End_Connection_Units",
                "sVortex_Hydrostatic_Test",
                "sVortex_Inst_R_Flow_Unit",
                "sVortex_Inst_R_Mn_Cuttoff_Flow",
                "sVortex_Inst_R_Mx_Meas_Flow",
                "sVortex_K_Fact_Stamped_mtr_bdy",
                "sVortex_K_Factor_Units",
                "sVortex_Linearity",
                "sVortex_Linearity_ref_to",
                "sVortex_Local_Display",
                "sVortex_Local_Display_Units",
                "sVortex_Local_Remt_Trans_T_No",
                "sVortex_Materials_Body",
                "sVortex_Materials_Housing",
                "sVortex_Materials_Sensor",
                "sVortex_Materials_Shedder",
                "sVortex_Meter_Size",
                "sVortex_Meter_Size_Units",
                "sVortex_Power_Supply",
                "sVortex_Pressure_Drop_Max",
                "sVortex_Pressure_Drop_Min",
                "sVortex_Pressure_Drop_Normal",
                "sVortex_Pressure_Drop_Unit",
                "sVortex_Reference_Drawing",
                "sVortex_repeatablility",
                "sVortex_reptablility_ref_to",
                "sVortex_Sec_Var_Description",
                "sVortex_Str_pipe_req_Dnstream",
                "sVortex_Str_pipe_req_Upstream",
                "sVortex_Tert_Var_",
                "sVortex_Tert_Var_Description",
                "sVortex_Trans_Sec_Var_Tag_N",
                "sVortex_Trans_Tert_Var_T_N",
                "Vortex_Type_of_Element",
                 },qc);
                StringBuffer buf = new StringBuffer();
                while (set.next())
                {
                    try
                    {
                        DataSheet sheet = DataSheetfromList(set);
                        list.Add(sheet);

                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }
            catch (SolException e)
            {
                throw e;
            }
            finally
            {
                if (s != null) s.disconnect();
            }
            return list.FirstOrDefault();
        }

        private static DataSheet DataSheetfromList(SolCollectionSet set)
        {
            DataSheet sheet = new DataSheet();
            sheet.sAccess_HandheldTerm = set.getStringValue(1);
            sheet.sAmbientTemp_Max = set.getStringValue(2);
            sheet.sAmbientTemp_Min = set.getStringValue(3);
            sheet.sAmbientTemp_Units = set.getStringValue(4);
            sheet.sArea = set.getStringValue(5);
            sheet.sArea_Class = set.getStringValue(6);
            sheet.sAtmosphericPress_Max = set.getStringValue(7);
            sheet.sAtmosphericPress_Min = set.getStringValue(8);
            sheet.sAtmosphericPress_Units = set.getStringValue(9);
            sheet.sCommunitaion_Type = set.getStringValue(10);
            sheet.sCommunitaion_With = set.getStringValue(11);
            sheet.sCoriolis_Acc_Inst_R_Max_Flow = set.getStringValue(12);
            sheet.sCoriolis_Acc_Inst_Range_Units = set.getStringValue(13);
            sheet.sCoriolis_Acc_Instr_R_Min_Flow = set.getStringValue(14);
            sheet.sCoriolis_Accuracy = set.getStringValue(15);
            sheet.sCoriolis_Accuracy_ref_to = set.getStringValue(16);
            sheet.sCoriolis_Body_Rating = set.getStringValue(17);
            sheet.sCoriolis_Body_Rating_Units = set.getStringValue(18);
            sheet.sCoriolis_Cable_type = set.getStringValue(19);
            sheet.sCoriolis_Cal_Range_DCS_Max = set.getStringValue(20);
            sheet.sCoriolis_Cal_Range_Unit = set.getStringValue(21);
            sheet.sCoriolis_Cali_Range_DCS_Min = set.getStringValue(22);
            sheet.sCoriolis_Conn_Rating_Units = set.getStringValue(23);
            sheet.sCoriolis_End_Connction_Rating = set.getStringValue(24);
            sheet.sCoriolis_End_Connection_Size = set.getStringValue(25);
            sheet.sCoriolis_End_Connection_Type = set.getStringValue(26);
            sheet.sCoriolis_End_Connection_Units = set.getStringValue(27);
            sheet.sCoriolis_Hydrostatic_Test = set.getStringValue(28);
            sheet.sCoriolis_Instr_R_MaxMeas_Flow = set.getStringValue(29);
            sheet.sCoriolis_Instr_R_MinCut_Flow = set.getStringValue(30);
            sheet.sCoriolis_InstRange_Flow_Units = set.getStringValue(31);
            sheet.sCoriolis_K_Factor = set.getStringValue(32);
            sheet.sCoriolis_K_Factor_Units = set.getStringValue(33);
            sheet.sCoriolis_Materials_Body = set.getStringValue(34);
            sheet.sCoriolis_Materials_Housing = set.getStringValue(35);
            sheet.sCoriolis_Materials_Sensor = set.getStringValue(36);
            sheet.sCoriolis_Meter_Size_Units = set.getStringValue(37);
            sheet.sCoriolis_OP_Signal = set.getStringValue(38);
            sheet.sCoriolis_Power_Supply = set.getStringValue(39);
            sheet.sCoriolis_Pressure_Drop_Max = set.getStringValue(40);
            sheet.sCoriolis_Pressure_Drop_Min = set.getStringValue(41);
            sheet.sCoriolis_Pressure_Drop_Normal = set.getStringValue(42);
            sheet.sCoriolis_Pressure_Drop_Units = set.getStringValue(43);
            sheet.sCoriolis_repeatablility = set.getStringValue(44);
            sheet.sCoriolis_reptablility_ref_to = set.getStringValue(45);
            sheet.sCoriolis_Sec_Conn_R_Units = set.getStringValue(46);
            sheet.sCoriolis_Sec_Conn_Rating = set.getStringValue(47);
            sheet.sCoriolis_Sec_Var_Description = set.getStringValue(48);
            sheet.sCoriolis_Temp_Compensator = set.getStringValue(49);
            sheet.sCoriolis_Totalizer_type = set.getStringValue(50);
            sheet.sCoriolis_Tran_Tert_Descript = set.getStringValue(51);
            sheet.sCoriolis_Tran_Tert_Var_Tag_N = set.getStringValue(52);
            sheet.sCoriolis_Trans_Sec_Var_Tag_N = set.getStringValue(53);
            sheet.sCoriolis_Trans_Type = set.getStringValue(54);
            sheet.sDevice_SegAddress = set.getStringValue(55);
            sheet.sDP_Trans_Acc = set.getStringValue(56);
            sheet.sDP_Trans_Acc_Inst_R_Min_Flow = set.getStringValue(57);
            sheet.sDP_Trans_Acc_Inst_R_Units = set.getStringValue(58);
            sheet.sDP_Trans_Acc_Instr_R_Max_Flow = set.getStringValue(59);
            sheet.sDP_Trans_Calib_R_DCS_Max = set.getStringValue(60);
            sheet.sDP_Trans_Calib_R_DCS_Min = set.getStringValue(61);
            sheet.sDP_Trans_Calibr_R_Unit = set.getStringValue(62);
            sheet.sDP_Trans_Dampening = set.getStringValue(63);
            sheet.sDP_Trans_Elect_Connection = set.getStringValue(64);
            sheet.sDP_Trans_Encl_Class = set.getStringValue(65);
            sheet.sDP_Trans_Failure_Mode = set.getStringValue(66);
            sheet.sDP_Trans_Fill_Fluid = set.getStringValue(67);
            sheet.sDP_Trans_Function = set.getStringValue(68);
            sheet.sDP_Trans_Hydrostatic_Test = set.getStringValue(69);
            sheet.sDP_Trans_Inst_R_Flow_Units = set.getStringValue(70);
            sheet.sDP_Trans_Inst_R_Max_Meas_Flow = set.getStringValue(71);
            sheet.sDP_Trans_Inst_R_Min_Cut_Flow = set.getStringValue(72);
            sheet.sDP_Trans_Integ_Meter_Scale = set.getStringValue(73);
            sheet.sDP_Trans_Integ_Mount_Manifold = set.getStringValue(74);
            sheet.sDP_Trans_Lightnin_Protection = set.getStringValue(75);
            sheet.sDP_Trans_Load_Resistance = set.getStringValue(76);
            sheet.sDP_Trans_Matrial_Element = set.getStringValue(77);
            sheet.sDP_Trans_Matrial_Housing = set.getStringValue(78);
            sheet.sDP_Trans_Matrial_Traceablty = set.getStringValue(79);
            sheet.sDP_Trans_Matrial_W_ORing = set.getStringValue(80);
            sheet.sDP_Trans_Max_R_Press = set.getStringValue(81);
            sheet.sDP_Trans_Max_R_Press_Unit = set.getStringValue(82);
            sheet.sDP_Trans_Max_R_Temp = set.getStringValue(83);
            sheet.sDP_Trans_Max_R_Temp_Units = set.getStringValue(84);
            sheet.sDP_Trans_Min_R_Temp = set.getStringValue(85);
            sheet.sDP_Trans_Min_R_Temp_Units = set.getStringValue(86);
            sheet.sDP_Trans_Mount_Brackets = set.getStringValue(87);
            sheet.sDP_Trans_Mounting = set.getStringValue(88);
            sheet.sDP_Trans_Paint = set.getStringValue(89);
            sheet.sDP_Trans_Process_Connection = set.getStringValue(90);
            sheet.sDP_Trans_Repeatability = set.getStringValue(91);
            sheet.sDP_Trans_Resp_Time = set.getStringValue(92);
            sheet.sDP_Trans_Sec_Var_Description = set.getStringValue(93);
            sheet.sDP_Trans_Sec_Var_Tag_Name = set.getStringValue(94);
            sheet.sDP_Trans_Supr_Elev_K = set.getStringValue(95);
            sheet.sDP_Trans_Tert_Description = set.getStringValue(96);
            sheet.sDP_Trans_Tert_Var_Tag_N = set.getStringValue(97);
            sheet.sDP_Trans_Wiring_Conn_Type = set.getStringValue(98);
            sheet.sDP_Transm_Matrial_Boltin = set.getStringValue(99);
            sheet.sDP_Transmitter_Power_Supply = set.getStringValue(100);
            sheet.sDP_Transmitter_Type = set.getStringValue(101);
            sheet.sDrawingNumber = set.getStringValue(102);
            sheet.sFlow_Max = set.getStringValue(103);
            sheet.sFlow_Min = set.getStringValue(104);
            sheet.sFlow_Norm = set.getStringValue(105);
            sheet.sFlow_Units = set.getStringValue(106);
            sheet.sFluid = set.getStringValue(107);
            sheet.sFluid_State = set.getStringValue(108);
            sheet.sInstTypeDescription = set.getStringValue(109);
            sheet.sInsulation_Thick = set.getStringValue(110);
            sheet.sLine_Orientation = set.getStringValue(111);
            sheet.sLine_Size = set.getStringValue(112);
            sheet.sLine_Size_Units = set.getStringValue(113);
            sheet.sLineNo = set.getStringValue(114);
            sheet.sLocation = set.getStringValue(115);
            sheet.sMagnetic_Acc_Inst_R_Max_Flow = set.getStringValue(116);
            sheet.sMagnetic_Acc_Inst_R_Min_Flow = set.getStringValue(117);
            sheet.sMagnetic_Acc_Inst_R_Units = set.getStringValue(118);
            sheet.sMagnetic_Accuracy = set.getStringValue(119);
            sheet.sMagnetic_Body_Rating = set.getStringValue(120);
            sheet.sMagnetic_Cable_Length = set.getStringValue(121);
            sheet.sMagnetic_Cable_Type = set.getStringValue(122);
            sheet.sMagnetic_Cable_Units = set.getStringValue(123);
            sheet.sMagnetic_Calib_R_DCS_Max = set.getStringValue(124);
            sheet.sMagnetic_Calib_R_DCS_Min = set.getStringValue(125);
            sheet.sMagnetic_Calib_R_Unit = set.getStringValue(126);
            sheet.sMagnetic_Coil_Drive = set.getStringValue(127);
            sheet.sMagnetic_Elect_Conn = set.getStringValue(128);
            sheet.sMagnetic_Electrode_Type = set.getStringValue(129);
            sheet.sMagnetic_Grounding = set.getStringValue(130);
            sheet.sMagnetic_Hydrostatic_Test = set.getStringValue(131);
            sheet.sMagnetic_Hydrostatic_Test1 = set.getStringValue(132);
            sheet.sMagnetic_Inst_R_Max_Meas_Flow = set.getStringValue(133);
            sheet.sMagnetic_Inst_R_Min_Cut_Flow = set.getStringValue(134);
            sheet.sMagnetic_Instr_R_Flow_Units = set.getStringValue(135);
            sheet.sMagnetic_Linearity = set.getStringValue(136);
            sheet.sMagnetic_Local_Display = set.getStringValue(137);
            sheet.sMagnetic_Local_Display_Unit = set.getStringValue(138);
            sheet.sMagnetic_Material = set.getStringValue(139);
            sheet.sMagnetic_Materials_Conn_Seal = set.getStringValue(140);
            sheet.sMagnetic_Matrials_Body = set.getStringValue(141);
            sheet.sMagnetic_Matrials_Housing = set.getStringValue(142);
            sheet.sMagnetic_Matrials_Liner = set.getStringValue(143);
            sheet.sMagnetic_Meter_Bdy_conn_Size = set.getStringValue(144);
            sheet.sMagnetic_Meter_Bdy_Conn_Type = set.getStringValue(145);
            sheet.sMagnetic_Meter_Bdy_Enclos = set.getStringValue(146);
            sheet.sMagnetic_Meter_Body_P_Supply = set.getStringValue(147);
            sheet.sMagnetic_Meter_Size = set.getStringValue(148);
            sheet.sMagnetic_Meter_Size_Units = set.getStringValue(149);
            sheet.sMagnetic_Press_Drop_Max = set.getStringValue(150);
            sheet.sMagnetic_Press_Drop_Min = set.getStringValue(151);
            sheet.sMagnetic_Press_Drop_Norm = set.getStringValue(152);
            sheet.sMagnetic_Press_Drop_Units = set.getStringValue(153);
            sheet.sMagnetic_Repeatability = set.getStringValue(154);
            sheet.sMagnetic_Sec_Var_Description = set.getStringValue(155);
            sheet.sMagnetic_Str_Pip_Req_Dnstream = set.getStringValue(156);
            sheet.sMagnetic_Str_Pip_Req_Upstream = set.getStringValue(157);
            sheet.sMagnetic_Temp_Comp = set.getStringValue(158);
            sheet.sMagnetic_Totalizer_Type = set.getStringValue(159);
            sheet.sMagnetic_Totalizer_Type_Units = set.getStringValue(160);
            sheet.sMagnetic_Trans_Encl = set.getStringValue(161);
            sheet.sMagnetic_Trans_Mounting = set.getStringValue(162);
            sheet.sMagnetic_Trans_P_Supply = set.getStringValue(163);
            sheet.sMagnetic_Trans_Sec_Var_Tag_N = set.getStringValue(164);
            sheet.sMagnetic_Trans_Tert_Descrptn = set.getStringValue(165);
            sheet.sMagnetic_Trans_Tert_Var_Tag_N = set.getStringValue(166);
            sheet.sMolecular_Weight = set.getStringValue(167);
            sheet.sOperating_Density = set.getStringValue(168);
            sheet.sOperatingDensity_Norm = set.getStringValue(169);
            sheet.sOrifice_Asso_Orific_Mtr_Run_T = set.getStringValue(170);
            sheet.sOrifice_Asso_Trans_T_H_Range = set.getStringValue(171);
            sheet.sOrifice_Asso_Trans_T_L_Range = set.getStringValue(172);
            sheet.sOrifice_Asso_Trans_T_L_Range1 = set.getStringValue(173);
            sheet.sOrifice_Beta_Ratio = set.getStringValue(174);
            sheet.sOrifice_Bore_Dia_deg_C_F = set.getStringValue(175);
            sheet.sOrifice_Bore_Diameter_Unit = set.getStringValue(176);
            sheet.sOrifice_Drain_Hole_Position = set.getStringValue(177);
            sheet.sOrifice_Drain_Venthol_sz_Unit = set.getStringValue(178);
            sheet.sOrifice_Drain_Venthole_size = set.getStringValue(179);
            sheet.sOrifice_Facing = set.getStringValue(180);
            sheet.sOrifice_Flange_Material = set.getStringValue(181);
            sheet.sOrifice_Flange_Size = set.getStringValue(182);
            sheet.sOrifice_Flange_Size_Unit = set.getStringValue(183);
            sheet.sOrifice_Flanged_Rating = set.getStringValue(184);
            sheet.sOrifice_Gasket_Material = set.getStringValue(185);
            sheet.sOrifice_Material = set.getStringValue(186);
            sheet.sOrifice_Orifice_Plate_Type = set.getStringValue(187);
            sheet.sOrifice_OrifPlat_ref_Standard = set.getStringValue(188);
            sheet.sOrifice_Pipe_Rey_Norm_Flow = set.getStringValue(189);
            sheet.sOrifice_Plate_Out_Dia_Unit = set.getStringValue(190);
            sheet.sOrifice_Plate_Outside_Dia = set.getStringValue(191);
            sheet.sOrifice_Plate_Tab = set.getStringValue(192);
            sheet.sOrifice_Plate_Thickness = set.getStringValue(193);
            sheet.sOrifice_Plate_Thickness_Unit = set.getStringValue(194);
            sheet.sOrifice_Press_Lss_Mtr_Mx_Flw = set.getStringValue(195);
            sheet.sOrifice_Prs_Ls_Mtr_Mx_Fl_Unit = set.getStringValue(196);
            sheet.sOrifice_Seal_Material = set.getStringValue(197);
            sheet.sOrifice_Seal_Type = set.getStringValue(198);
            sheet.sOrifice_Standard = set.getStringValue(199);
            sheet.sOrifice_Taps_Orientation = set.getStringValue(200);
            sheet.sOrifice_Taps_Size = set.getStringValue(201);
            sheet.sOrifice_Taps_Size_Unit = set.getStringValue(202);
            sheet.sOrifice_Taps_Type = set.getStringValue(203);
            sheet.sOrifice_Upstr_Side_Tab_Stamp = set.getStringValue(204);
            sheet.sOutput_Signal = set.getStringValue(205);
            sheet.sPipe_ID = set.getStringValue(206);
            sheet.sPipe_ID_Units = set.getStringValue(207);
            sheet.sPipe_Insulation = set.getStringValue(208);
            sheet.sPipe_Material = set.getStringValue(209);
            sheet.sPipe_Schedule = set.getStringValue(210);
            sheet.sPres_Diap_Sl_Pr_Con_R_Units = set.getStringValue(211);
            sheet.sPres_Diap_Sl_Pr_Con_Rating = set.getStringValue(212);
            sheet.sPres_Diap_Sl_Pr_Con_Size_Unit = set.getStringValue(213);
            sheet.sPress_Cali_R_DCS_Disp_R_Unit = set.getStringValue(214);
            sheet.sPress_Capillary_Length = set.getStringValue(215);
            sheet.sPress_Capillary_Length_Unit = set.getStringValue(216);
            sheet.sPress_Diap_Sl_Fill_Fl = set.getStringValue(217);
            sheet.sPress_Diap_Sl_Pr_Con_Facing = set.getStringValue(218);
            sheet.sPress_Diap_Sl_Pr_Conn_Size = set.getStringValue(219);
            sheet.sPress_Flushing_Conn = set.getStringValue(220);
            sheet.sPress_Flushing_Conn_Units = set.getStringValue(221);
            sheet.sPress_Inst_R_MeasPres_Unit = set.getStringValue(222);
            sheet.sPress_Linearity_Ref_to = set.getStringValue(223);
            sheet.sPress_Sec_Var_description = set.getStringValue(224);
            sheet.sPress_Tert_Var_description = set.getStringValue(225);
            sheet.sPress_Trans_Sec_Var_T_N = set.getStringValue(226);
            sheet.sPress_Trans_Tert_Var_T_N = set.getStringValue(227);
            sheet.sPressure_Acc_Ins_R_Prss_Unit = set.getStringValue(228);
            sheet.sPressure_Acc_Instr_R_Mn_Press = set.getStringValue(229);
            sheet.sPressure_Acc_Instr_R_Mx_Press = set.getStringValue(230);
            sheet.sPressure_Acc_Ref_to = set.getStringValue(231);
            sheet.sPressure_Accuracy = set.getStringValue(232);
            sheet.sPressure_Cali_R_DCS_Disp_R_Mn = set.getStringValue(233);
            sheet.sPressure_Cali_R_DCS_Disp_R_Mx = set.getStringValue(234);
            sheet.sPressure_Capillary_Material = set.getStringValue(235);
            sheet.sPressure_Capillary_Type = set.getStringValue(236);
            sheet.sPressure_Dampening = set.getStringValue(237);
            sheet.sPressure_Diap_Material = set.getStringValue(238);
            sheet.sPressure_Diap_Sl_Pr_Con_T = set.getStringValue(239);
            sheet.sPressure_Elect_Conn = set.getStringValue(240);
            sheet.sPressure_Enclosure_type = set.getStringValue(241);
            sheet.sPressure_Failure_Mode = set.getStringValue(242);
            sheet.sPressure_Function = set.getStringValue(243);
            sheet.sPressure_Housing_Material = set.getStringValue(244);
            sheet.sPressure_Inst_R_Max_Meas_Pres = set.getStringValue(245);
            sheet.sPressure_Inst_R_Min_Meas_Pres = set.getStringValue(246);
            sheet.sPressure_Linearity = set.getStringValue(247);
            sheet.sPressure_Load_Resistance = set.getStringValue(248);
            sheet.sPressure_Local_Display = set.getStringValue(249);
            sheet.sPressure_Local_Display_Unit = set.getStringValue(250);
            sheet.sPressure_Manifold = set.getStringValue(251);
            sheet.sPressure_Manufacturer = set.getStringValue(252);
            sheet.sPressure_Material_Bolting = set.getStringValue(253);
            sheet.sPressure_Material_Element = set.getStringValue(254);
            sheet.sPressure_Material_Housing = set.getStringValue(255);
            sheet.sPressure_Matrial_W_ORing = set.getStringValue(256);
            sheet.sPressure_Max_Rated_Press = set.getStringValue(257);
            sheet.sPressure_Max_Rated_Press_Unit = set.getStringValue(258);
            sheet.sPressure_Max_Rated_Temp = set.getStringValue(259);
            sheet.sPressure_Max_Rated_Temp1 = set.getStringValue(260);
            sheet.sPressure_Min_Rated_Temp = set.getStringValue(261);
            sheet.sPressure_Min_Rated_Temp_Unit = set.getStringValue(262);
            sheet.sPressure_Mounting_Brackets = set.getStringValue(263);
            sheet.sPressure_Mterial_Traceability = set.getStringValue(264);
            sheet.sPressure_Namur_43 = set.getStringValue(265);
            sheet.sPressure_Paint = set.getStringValue(266);
            sheet.sPressure_Power_Supply = set.getStringValue(267);
            sheet.sPressure_Repeatability = set.getStringValue(268);
            sheet.sPressure_Response_Time = set.getStringValue(269);
            sheet.sPressure_Trans_Fill_Fluid = set.getStringValue(270);
            sheet.sPressure_Trans_Process_Conn = set.getStringValue(271);
            sheet.sPressure_Wiring_Conn_Type = set.getStringValue(272);
            sheet.sProcessPress_Max = set.getStringValue(273);
            sheet.sProcessPress_Min = set.getStringValue(274);
            sheet.sProcessPress_Norm = set.getStringValue(275);
            sheet.sProcessPress_Units = set.getStringValue(276);
            sheet.sProcessTemp_Max = set.getStringValue(277);
            sheet.sProcessTemp_Min = set.getStringValue(278);
            sheet.sProcessTemp_Norm = set.getStringValue(279);
            sheet.sProcessTemp_Units = set.getStringValue(280);
            sheet.sStation = set.getStringValue(281);
            sheet.sTagNo = set.getStringValue(282);
            sheet.sUnitNo = set.getStringValue(283);
            sheet.sUS_Accuracy = set.getStringValue(284);
            sheet.sUS_Alarm_Contacts_No = set.getStringValue(285);
            sheet.sUS_Body_Material = set.getStringValue(286);
            sheet.sUS_Cable_length_to_Transducer = set.getStringValue(287);
            sheet.sUS_Cali_Range_Mn_for_DCS = set.getStringValue(288);
            sheet.sUS_Cali_Range_Mx_for_DCS = set.getStringValue(289);
            sheet.sUS_Calib_Range_DCS_Units = set.getStringValue(290);
            sheet.sUS_Conduit_Cable_Connection = set.getStringValue(291);
            sheet.sUS_Conduit_Size = set.getStringValue(292);
            sheet.sUS_Conduit_Size_units = set.getStringValue(293);
            sheet.sUS_Connection_Materials = set.getStringValue(294);
            sheet.sUS_Connection_Rating_Units = set.getStringValue(295);
            sheet.sUS_Construction = set.getStringValue(296);
            sheet.sUS_Contact_Action = set.getStringValue(297);
            sheet.sUS_Contact_Form = set.getStringValue(298);
            sheet.sUS_Current_Rating = set.getStringValue(299);
            sheet.sUS_Current_Rating_Units = set.getStringValue(300);
            sheet.sUS_Digital_Output = set.getStringValue(301);
            sheet.sUS_Electr_Encl_Classification = set.getStringValue(302);
            sheet.sUS_Element_Type = set.getStringValue(303);
            sheet.sUS_Housing_material = set.getStringValue(304);
            sheet.sUS_Hydrostatic_Test = set.getStringValue(305);
            sheet.sUS_Inst_Range_Max_Meas_Flow = set.getStringValue(306);
            sheet.sUS_Inst_Range_Min_Cutoff_Flow = set.getStringValue(307);
            sheet.sUS_Instr_Range_Flow_Units = set.getStringValue(308);
            sheet.sUS_Local_Display = set.getStringValue(309);
            sheet.sUS_Meter_Bdy_Conn_Type = set.getStringValue(310);
            sheet.sUS_Meter_Bdy_Connection_Size = set.getStringValue(311);
            sheet.sUS_Meter_Bdy_Connection_Units = set.getStringValue(312);
            sheet.sUS_Mounting = set.getStringValue(313);
            sheet.sUS_Power_Supply = set.getStringValue(314);
            sheet.sUS_Pressure_Sensor_Tag_Name = set.getStringValue(315);
            sheet.sUS_Sec_Var_Description = set.getStringValue(316);
            sheet.sUS_Sensor_Material = set.getStringValue(317);
            sheet.sUS_Straight_Pipe_Req_Dnstream = set.getStringValue(318);
            sheet.sUS_Straight_Pipe_Rq_Upstream = set.getStringValue(319);
            sheet.sUS_Temp_Sensor_Tag_Name = set.getStringValue(320);
            sheet.sUS_Trans_Tertiary_Description = set.getStringValue(321);
            sheet.sUS_Trans_Tertiary_Var_Tag_N = set.getStringValue(322);
            sheet.sUS_Transm_Sec_Var_Tag_Name = set.getStringValue(323);
            sheet.sUS_Trndcr_Conn_Size_Units = set.getStringValue(324);
            sheet.sUS_Trndcr_Connection_Rating = set.getStringValue(325);
            sheet.sUS_Trndcr_Connection_Size = set.getStringValue(326);
            sheet.sUS_Validation_Test = set.getStringValue(327);
            sheet.sUS_Voltage_Rating = set.getStringValue(328);
            sheet.sUS_Voltage_Rating_Units = set.getStringValue(329);
            sheet.sVCone_Beta_Ratio = set.getStringValue(330);
            sheet.sVCone_Calibration = set.getStringValue(331);
            sheet.sVCone_Calibration1 = set.getStringValue(332);
            sheet.sVCone_Cone_Config_Option = set.getStringValue(333);
            sheet.sVCone_Cone_Diameter = set.getStringValue(334);
            sheet.sVCone_Cone_Diameter_Units = set.getStringValue(335);
            sheet.sVCone_Cone_Temp_Units = set.getStringValue(336);
            sheet.sVCone_Cone_Temperature = set.getStringValue(337);
            sheet.sVCone_Discharge_Coeff = set.getStringValue(338);
            sheet.sVCone_Distance_bt_Taps = set.getStringValue(339);
            sheet.sVCone_Distance_bt_Taps_Units = set.getStringValue(340);
            sheet.sVCone_DP_at_Sizing_Flow_Rate = set.getStringValue(341);
            sheet.sVCone_DP_Sizng_Fl_Rate_Units = set.getStringValue(342);
            sheet.sVCone_DP_Taps_Orientation = set.getStringValue(343);
            sheet.sVCone_DP_Taps_Size = set.getStringValue(344);
            sheet.sVCone_DP_Taps_Size_Units = set.getStringValue(345);
            sheet.sVCone_DP_Taps_Type = set.getStringValue(346);
            sheet.sVCone_End_Conn_Facing = set.getStringValue(347);
            sheet.sVCone_End_Conn_Facing_Units = set.getStringValue(348);
            sheet.sVCone_End_Conn_Rating_Units = set.getStringValue(349);
            sheet.sVCone_End_Conn_Size_Units = set.getStringValue(350);
            sheet.sVCone_End_Connection_Rating = set.getStringValue(351);
            sheet.sVCone_End_Connection_Size = set.getStringValue(352);
            sheet.sVCone_End_Connection_Type = set.getStringValue(353);
            sheet.sVCone_Flow_Element_Cone_Matrl = set.getStringValue(354);
            sheet.sVCone_Flow_Element_Pipe_Units = set.getStringValue(355);
            sheet.sVCone_Flow_Elment_Pipe_R = set.getStringValue(356);
            sheet.sVCone_Flow_Elment_Pipe_Sched = set.getStringValue(357);
            sheet.sVCone_Flow_Elmnt_Pipe_Matrl = set.getStringValue(358);
            sheet.sVCone_HydroStatic_Test = set.getStringValue(359);
            sheet.sVCone_Meter_Run_ref_Drwg = set.getStringValue(360);
            sheet.sVCone_Pipe_Internal_Dia_Sze = set.getStringValue(361);
            sheet.sVCone_Pipe_Internal_Diameter = set.getStringValue(362);
            sheet.sVCone_Pressure_Drop_Max = set.getStringValue(363);
            sheet.sVCone_Pressure_Drop_Min = set.getStringValue(364);
            sheet.sVCone_Pressure_Drop_Norm = set.getStringValue(365);
            sheet.sVCone_Pressure_Drop_Units = set.getStringValue(366);
            sheet.sVCone_Size_Flow_Rate = set.getStringValue(367);
            sheet.sVCone_Size_Flow_Rate_Units = set.getStringValue(368);
            sheet.sVCone_Strght_Pipe_Rq_Dnstream = set.getStringValue(369);
            sheet.sVCone_Strght_Pipe_Rq_Upstream = set.getStringValue(370);
            sheet.sVCone_XRay = set.getStringValue(371);
            sheet.sVenturi_Beta_Ratio = set.getStringValue(372);
            sheet.sVenturi_Coni_Conv_L_Units = set.getStringValue(373);
            sheet.sVenturi_Coni_Conv_Length = set.getStringValue(374);
            sheet.sVenturi_Coni_Div_Angle_Units = set.getStringValue(375);
            sheet.sVenturi_Coni_Div_Length = set.getStringValue(376);
            sheet.sVenturi_Coni_Div_Length_Units = set.getStringValue(377);
            sheet.sVenturi_Conical_Diverge_Angle = set.getStringValue(378);
            sheet.sVenturi_Convergence_Angle = set.getStringValue(379);
            sheet.sVenturi_Cyl_Entr_Sec_L_Units = set.getStringValue(380);
            sheet.sVenturi_Cyl_Entr_Sec_Length = set.getStringValue(381);
            sheet.sVenturi_Discharge_coefficient = set.getStringValue(382);
            sheet.sVenturi_Divergent_Angle = set.getStringValue(383);
            sheet.sVenturi_End_Con_Typ_Sze_Units = set.getStringValue(384);
            sheet.sVenturi_End_Connection_Size = set.getStringValue(385);
            sheet.sVenturi_End_Connection_Type = set.getStringValue(386);
            sheet.sVenturi_Facing = set.getStringValue(387);
            sheet.sVenturi_Material = set.getStringValue(388);
            sheet.sVenturi_Pressure_Drop_Max = set.getStringValue(389);
            sheet.sVenturi_Pressure_Drop_Min = set.getStringValue(390);
            sheet.sVenturi_Pressure_Drop_Normal = set.getStringValue(391);
            sheet.sVenturi_Pressure_Drop_Unit = set.getStringValue(392);
            sheet.sVenturi_Str_pipe_req_Dnstream = set.getStringValue(393);
            sheet.sVenturi_Str_pipe_req_Upstream = set.getStringValue(394);
            sheet.sVenturi_Taps_Orientation = set.getStringValue(395);
            sheet.sVenturi_Taps_Size = set.getStringValue(396);
            sheet.sVenturi_Taps_Size_Units = set.getStringValue(397);
            sheet.sVenturi_Taps_Type = set.getStringValue(398);
            sheet.sVenturi_Thickness = set.getStringValue(399);
            sheet.sVenturi_Thickness_Units = set.getStringValue(400);
            sheet.sVenturi_Throat_Diameter = set.getStringValue(401);
            sheet.sVenturi_Throat_Diameter_Units = set.getStringValue(402);
            sheet.sVenturi_Throat_Length = set.getStringValue(403);
            sheet.sVenturi_Throat_Length_Units = set.getStringValue(404);
            sheet.sVenturi_Type = set.getStringValue(405);
            sheet.sVenturi_Venturi_Ref_Standard = set.getStringValue(406);
            sheet.sViscosoty_Min = set.getStringValue(407);
            sheet.sViscosoty_Units = set.getStringValue(408);
            sheet.sVortex_Acc_Instr_R_Flow_Unit = set.getStringValue(409);
            sheet.sVortex_Acc_Instr_R_Mn_Flow = set.getStringValue(410);
            sheet.sVortex_Acc_Instr_R_Mx_Flow = set.getStringValue(411);
            sheet.sVortex_Accuracy = set.getStringValue(412);
            sheet.sVortex_Accuracy_ref_to = set.getStringValue(413);
            sheet.sVortex_Body_Conn_R_Units = set.getStringValue(414);
            sheet.sVortex_Body_Connection_Rating = set.getStringValue(415);
            sheet.sVortex_Body_Size = set.getStringValue(416);
            sheet.sVortex_Body_Size_Units = set.getStringValue(417);
            sheet.sVortex_Cable_Type = set.getStringValue(418);
            sheet.sVortex_Cali_R_DCS_Disp_R_Max = set.getStringValue(419);
            sheet.sVortex_Cali_R_DCS_Disp_R_Min = set.getStringValue(420);
            sheet.sVortex_Cali_R_DCS_Disp_R_Unit = set.getStringValue(421);
            sheet.sVortex_End_Connection = set.getStringValue(422);
            sheet.sVortex_End_Connection_Units = set.getStringValue(423);
            sheet.sVortex_Hydrostatic_Test = set.getStringValue(424);
            sheet.sVortex_Inst_R_Flow_Unit = set.getStringValue(425);
            sheet.sVortex_Inst_R_Mn_Cuttoff_Flow = set.getStringValue(426);
            sheet.sVortex_Inst_R_Mx_Meas_Flow = set.getStringValue(427);
            sheet.sVortex_K_Fact_Stamped_mtr_bdy = set.getStringValue(428);
            sheet.sVortex_K_Factor_Units = set.getStringValue(429);
            sheet.sVortex_Linearity = set.getStringValue(430);
            sheet.sVortex_Linearity_ref_to = set.getStringValue(431);
            sheet.sVortex_Local_Display = set.getStringValue(432);
            sheet.sVortex_Local_Display_Units = set.getStringValue(433);
            sheet.sVortex_Local_Remt_Trans_T_No = set.getStringValue(434);
            sheet.sVortex_Materials_Body = set.getStringValue(435);
            sheet.sVortex_Materials_Housing = set.getStringValue(436);
            sheet.sVortex_Materials_Sensor = set.getStringValue(437);
            sheet.sVortex_Materials_Shedder = set.getStringValue(438);
            sheet.sVortex_Meter_Size = set.getStringValue(439);
            sheet.sVortex_Meter_Size_Units = set.getStringValue(440);
            sheet.sVortex_Power_Supply = set.getStringValue(441);
            sheet.sVortex_Pressure_Drop_Max = set.getStringValue(442);
            sheet.sVortex_Pressure_Drop_Min = set.getStringValue(443);
            sheet.sVortex_Pressure_Drop_Normal = set.getStringValue(444);
            sheet.sVortex_Pressure_Drop_Unit = set.getStringValue(445);
            sheet.sVortex_Reference_Drawing = set.getStringValue(446);
            sheet.sVortex_repeatablility = set.getStringValue(447);
            sheet.sVortex_reptablility_ref_to = set.getStringValue(448);
            sheet.sVortex_Sec_Var_Description = set.getStringValue(449);
            sheet.sVortex_Str_pipe_req_Dnstream = set.getStringValue(450);
            sheet.sVortex_Str_pipe_req_Upstream = set.getStringValue(451);
            sheet.sVortex_Tert_Var_ = set.getStringValue(452);
            sheet.sVortex_Tert_Var_Description = set.getStringValue(453);
            sheet.sVortex_Trans_Sec_Var_Tag_N = set.getStringValue(454);
            sheet.sVortex_Trans_Tert_Var_T_N = set.getStringValue(455);
            sheet.Vortex_Type_of_Element = set.getStringValue(456);
            return sheet;
        }
    }
}