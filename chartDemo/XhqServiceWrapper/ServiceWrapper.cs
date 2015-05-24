using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using chartDemo.XHQService;
using System.Data;

namespace chartDemo.XhqServiceWrapper
{
    public class ServiceWrapper
    {
        string serverName = "mus-ws-204.corp.pdo.om";
        XhqServiceClient client;
        public ServiceWrapper()
        {
            client = new XhqServiceClient();
        }

        public DataTable GetInstrumentsList(int level, string filterText)
        {
            string whereClause = string.Empty;
            switch (level)
            {
                case 2:
                    whereClause = "sMainClass = '" + filterText + "'";
                    break;
                case 3:
                    whereClause = "sMeasurementClass1 = '" + filterText + "'";
                    break;
                case 4:
                    whereClause = "sMeasurementClass2 = '" + filterText + "'";
                    break;
                default:
                    whereClause = "";
                    break;
            }
            try
            {
                string columns = "sAreaName,sInstrumentType,sCluster,sDirectorate,sMainClass,sMeasurementClass1,sMeasurementClass2,sMechanicalEquipment,sPITag,sProcessFunctionType,sService,sStation,sTagNumber,sDrawingNumber,sWellName";
                //string[][] col1 = client.GetCollectionDataFilter(serverName, "::PDO_InstrumentsMain", columns, whereClause, "", (!string.IsNullOrEmpty(whereClause))?client.GetCollectionCount(serverName, "::PDO_InstrumentsMain", whereClause) : 100);
                string[][] col1 = client.GetCollectionDataFilter(serverName, "::PDO_InstrumentsMain", columns, whereClause, "", client.GetCollectionCount(serverName, "::PDO_InstrumentsMain", whereClause) );
                if (col1 != null)
                    return GetDataTableFromArray(col1, columns.Split(','));
                else
                    return null;

            }
            catch (Exception e)
            {
                client.Close();
            }
            return null;
        }

        DataTable GetDataTableFromArray(string[][] array,string[] headers)
        {
            DataTable _dataTable = new DataTable();

            for (int i = 0; i < headers.Length; i++)
            {
                _dataTable.Columns.Add(headers[i]);
            }

            for (int i = 0; i < array[0].Length; i++)
            {

                DataRow dr = _dataTable.NewRow();

                for (int j = 0; j < array.Length; j++)
                {

                    dr[j] = array[j][i];

                }

                _dataTable.Rows.Add(dr);

            }

            return _dataTable;
        }
    }
}



