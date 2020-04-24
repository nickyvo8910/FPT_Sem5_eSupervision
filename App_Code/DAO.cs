using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DAO
{
    public static SqlConnection sqlCon;
    public static SqlCommand sqlCom;
    public static SqlDataAdapter sqlAdap;
    public static DataSet dtSet = new DataSet();

	public DAO()
	{
        sqlCon = new SqlConnection("Data Source=.; Initial Catalog =eSupervisor;User Id = sa;Password =12345678");
        sqlCom = new SqlCommand();
        sqlAdap = new SqlDataAdapter();

	}   
}