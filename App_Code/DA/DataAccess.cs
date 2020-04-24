using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for DataAccess
/// </summary>
public class DataAccess
{
    private String ConnectionString = "Data Source=.;Initial Catalog=eSupervisor;User ID=sa;Password=12345678";
    public SqlConnection Conn;
    private SqlDataAdapter aDapter;
    private DataTable dataTable;

	public DataAccess()
	{
        Connect();
	}

    public void Connect() 
    {
        try
        {
            Conn = new SqlConnection(ConnectionString);
            Conn.Open();
            Conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ExecuteQuery(string query)
    {
        aDapter = new SqlDataAdapter(query, Conn);
        dataTable = new DataTable();
        aDapter.Fill(dataTable);
        return dataTable;
    }

    public bool ExecuteNonQuery(string query)
    {
        int RowEffect = 0;
        try
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            SqlCommand cmd = new SqlCommand(query, Conn);
            RowEffect = (int)cmd.ExecuteNonQuery();
            Conn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        if (RowEffect > 0)
            return true;
        return false;
    }
}