using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonConnection
/// </summary>
public class CommonConnection
{
    public static SqlConnection sqlCon;
    public static String stringCNN;
    public static DataSet dtSet = new DataSet();
	public CommonConnection()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public CommonConnection(String dbName, String id, String pass)
        {
            stringCNN = "Data Source = .; Initial Catalog =" + dbName + "; User Id = " + id + "; Password =" + pass;
            sqlCon = new SqlConnection(stringCNN);
            sqlCon.Open();
        }
}