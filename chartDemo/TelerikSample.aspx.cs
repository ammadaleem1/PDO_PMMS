using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.OracleClient;
using com.indx.xhq.solution;
using com.indx.xhq.util;
using com.indx.xhq.solution.clientapi;
using java.lang;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ApplicationBlocks.Data;
namespace chartDemo
{
    public partial class TelerikSample : System.Web.UI.Page
    {
        //"dEndDate", "dStartDate", "sInstrumentType", "sMainClass", "sSubClass1", "sSubClass2", "sProcessFunctionType", "sService", "sDirectorate", "sCluster", "sArea", "sStation" , "sTagNumber", "sPiTag"
        public class XHQMembersForANS
        {
            public DateTime dStartDate { get; set; }
            public DateTime dEndDate { get; set; }
            public string sInstrumentType { get; set; }
            public string sMainClass { get; set; }
            public string sSubClass1 { get; set; }
            public string sSubClass2 { get; set; }
            public string sProcessFunctionType { get; set; }
            public string sService { get; set; }
            public string sDirectorate { get; set; }
            public string sCluster { get; set; }
            public string sArea { get; set; }
            public string sStation { get; set; }
            public string sTagNumber { get; set; }
            public string sPiTag { get; set; }
        }
        private string GetOracleConnectionString()
        {
            return "Data Source=ARDHDV.world;Persist Security Info=True;User ID=wh_pmms;Password=PMMS;Unicode=True";
        }
        public DataTable GetDataTable()
        {
            /*string sql = "select vct.Validity_Status,vct.start_date,vct.end_date,vct.formation_gas,vct.gross,vct.oil,vct.water from v_conduit_test vct inner join v_conduit vc on VCT.CONDUIT_NAME=VC.CONDUIT_NAME where VCT.SEPARATOR_ID IS NOT NULL and vct.separator_id like '%' and vct.conduit_name = 'F018' and vct.validity_status='valid test' ";
            //if (!includeAbondoned)
            //{
            //    sql += "and vc.actual_status not like '%ABAN_%' ";
            //}
            //if (!string.IsNullOrEmpty(Request.Form["txtStartDate"]) && !string.IsNullOrEmpty(Request.Form["txtEndDate"]))
            //{
            //  sql += "and vct.start_date >= '" + startDate + "' and vct.end_date <= '" + endDate + "' ";
            //}
            sql += "order by 2";
            string connectionString = GetOracleConnectionString();
            using (System.Data.OracleClient.OracleConnection connection = new System.Data.OracleClient.OracleConnection())
            {
                connection.Close();
                connection.ConnectionString = connectionString;
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                DataSet ds = new DataSet();
                OracleDataAdapter adapter = new OracleDataAdapter(command);
                adapter.Fill(ds);
                connection.Close();
                return ds.Tables[0];
            }*/
            return null;
        }
        public void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
               // LoadDataForRadGrid1();
            } XHQCall();
        }
        void XHQCall()
        {
            Solution s = null;
            List<XHQMembersForANS> list = new List<XHQMembersForANS>();
            DataTable dt = new DataTable();

            dt.Columns.Add("dEndDate", typeof(DateTime));
            dt.Columns.Add("dStartDate", typeof(DateTime));
            dt.Columns.Add("sArea", typeof(string));
            dt.Columns.Add("sCluster", typeof(string));
            dt.Columns.Add("sDirectorate", typeof(string));
            dt.Columns.Add("sInstrumentType", typeof(string));
            dt.Columns.Add("sMainClass", typeof(string));
            dt.Columns.Add("sPiTag", typeof(string));
            dt.Columns.Add("sProcessFunctionType", typeof(string));
            dt.Columns.Add("sService", typeof(string));
            dt.Columns.Add("sStation", typeof(string));
            dt.Columns.Add("sSubClass1", typeof(string));
            dt.Columns.Add("sSubClass2", typeof(string));
            dt.Columns.Add("sTagNumber", typeof(string));
            try
            {
                ConnectionString conn = new ConnectionString();
                string connectionSql = conn.GetConnectionString().ToString();
                DateTime dtMaxEndDate = new DateTime();
                dtMaxEndDate = Convert.ToDateTime(SqlHelper.ExecuteScalar(connectionSql, "GetLastExcursionDate").ToString());
                //SolQueryCriteria sqc = new SolQueryCriteria(
                s = Solution.getConnection("148.151.135.7");
                SolRoot r = s.getRootObject();
                ICollectionQuery icq = s.getGlobalCollection("::colAggregateExcursion2");
                SolQueryCriterion[] criterions = new SolQueryCriterion[] {
new SolQueryCriterion("dEndDate", SolQueryCriterion.GT, new
VariantValue(dtMaxEndDate.ToString()))
};
                SolQueryCriteria qc = new SolQueryCriteria(criterions);
                SolCollectionSet set = icq.query(new string[14] {"dEndDate", "dStartDate", "sInstrumentType", "sMainClass", "sSubClass1", "sSubClass2", "sProcessFunctionType", "sService", "sDirectorate", "sCluster", "sArea", "sStation" , "sTagNumber", "sPiTag"}, null);
                set.setMaxFetchRows(20000);
                //StringBuffer buf = new StringBuffer();
                while (set.next())
                {
                    DataRow dr = dt.NewRow();
                    //XHQMembersForANS xhqmembersForANS = new XHQMembersForANS();
                    try
                    {
                        DateTime dtStart = Convert.ToDateTime(set.getTimestampValue(2).toString());
                        DateTime dtEnd = Convert.ToDateTime(set.getTimestampValue(1).toString());
                        //string startDate = set.getStringValue(2);
                        //dr["dStartDate"] = Convert.ToDateTime(startDate);
                        //string endDate = set.getStringValue(1);
                        //dr["dEndDate"] = Convert.ToDateTime(endDate);
                        dr["dStartDate"] = dtStart;
                        dr["dEndDate"] = dtEnd;
                    }
                    catch (System.Exception ex)
                    { }
                    dr["sInstrumentType"] = set.getStringValue(3);
                    dr["sMainClass"] = set.getStringValue(4);
                    dr["sSubClass1"] = set.getStringValue(5);
                    dr["sSubClass2"] = set.getStringValue(6);
                    dr["sProcessFunctionType"] = set.getStringValue(7);
                    dr["sService"] = set.getStringValue(8);
                    dr["sDirectorate"] = set.getStringValue(9);
                    dr["sCluster"] = set.getStringValue(10);
                    dr["sArea"] = set.getStringValue(11);
                    dr["sStation"] = set.getStringValue(12);
                    dr["sTagNumber"] = set.getStringValue(13);
                    dr["sPiTag"] = set.getStringValue(14);
                    dt.Rows.Add(dr);
                    /*dr["sInstrumentTag = set.getStringValue(3);
                    float outParameter = 0;
                    if (float.TryParse(set.getStringValue(4), out outParameter))
                        dr["rMeasMaxFR = set.getFloatValue(4);
                    if (float.TryParse(set.getStringValue(5), out outParameter))
                        dr["rMeasMinFR = set.getFloatValue(5);
                    */
                    //dr["dStartDate = DateTime.Parse(set.getStringValue(3));
                    //dr["dEndDate = DateTime.Parse(set.getStringValue(4));
                    //list.Add(xhqmembersForANS);
                }
                string connectionString = ConfigurationSettings.AppSettings["PDOConnection"];
                using (SqlConnection destinationConnection = new SqlConnection(connectionString))
                {
                    destinationConnection.Open();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
                    {
                        bulkCopy.DestinationTableName = "InstrumentExcursionLog1";
                        bulkCopy.BatchSize = 1000;
                        bulkCopy.WriteToServer(dt);
                    }
                }
     //           var queryLastNames =
     //from student in list
     //group student by student.sPiTag into newGroup
     //orderby newGroup.Key
     //select newGroup;
            }
            catch (SolException e)
            {
            }
            finally
            {
                if (s != null) s.disconnect();
            }
            //return list.GroupBy(x => x.sPiTag).Select(y => y.First()).ToList();
        }
        protected void RadGrid1_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            LoadDataForRadGrid1();
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            LoadDataForRadGrid1();
        }

        protected void RadGrid1_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            LoadDataForRadGrid1();
        }

        private void LoadDataForRadGrid1()
        {
           // RadGrid1.DataSource = GetDataTable();
        }

        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as RadGrid).DataSource = GetDataTable();
        }
 

    }
}
