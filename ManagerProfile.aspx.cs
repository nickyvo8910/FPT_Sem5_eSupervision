using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerProfile : System.Web.UI.Page
{
    public DataRow staffInfo;
    public String userID ,USER_TYPE;
    public int userType;

    DAO daoObject = new DAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null || Session["userType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                userID = Session["userID"].ToString();
                userType = Convert.ToInt32(Session["userType"].ToString());
                switch (userType)
                {
                    case 1:
                        {
                            USER_TYPE = "Student";
                        }
                        break;
                    case 2:
                        {
                            USER_TYPE = "Staff/Falcuty";
                        }
                        break;
                    case 3:
                        {
                            USER_TYPE = "Manager";
                        }
                        break;
                }
                staffInfo = getStaffsByPK(userID);
            }
        }

    }

    public DataRow getStaffsByPK(String myID)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getStaffsByPK";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@ID", myID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        return (DataRow)dtTab.Rows[0];
    }
    
}