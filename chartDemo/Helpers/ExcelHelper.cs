using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace chartDemo.Helpers
{
    public static class ExcelHelper
    {
        public static DataSet ReadData(string fileCompletePath)
        {
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string query = null;
            string connString = "";
            string strFileType = System.IO.Path.GetExtension(fileCompletePath).ToString().ToLower();
            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileCompletePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileCompletePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }

            //Create the connection object
            conn = new OleDbConnection(connString);
            //Open connection
            if (conn.State == ConnectionState.Closed) conn.Open();

            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
                return null;

            String[] excelSheets = new String[dt.Rows.Count];
            int i = 0;

            // Add the sheet name to the string array.

            foreach (DataRow row in dt.Rows)
            {
                excelSheets[i] = row["TABLE_NAME"].ToString();
                i++;
            }

            ds = new DataSet();
            for (int j = 0; j < excelSheets.Length; j++)
            {
                query = "SELECT * FROM ["+excelSheets[j]+"]";
                               
                //Create the command object
                cmd = new OleDbCommand(query, conn);
                da = new OleDbDataAdapter(cmd);
                ds.Tables.Add(new DataTable());
                da.Fill(ds.Tables[j]);
            }
            da.Dispose();
            conn.Close();
            conn.Dispose();
            return ds;
        }
    }
}
