using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerDashboard : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    public int TOTAL_USER, TOTAL_INACTIVE, TOTAL_ALLOCATION, TOTAL_NOTALLOCATED, TOTAL_BLOG, TOTAL_ALLOCATIONMADE;
    public String userID ,USER_TYPE;
    public int userType;
    public DataTable activaStaffsTab;
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
            }
            TOTAL_USER = getTotalUser();
            TOTAL_INACTIVE = getInactiveStudents();
            TOTAL_ALLOCATION = getTotalAllocation();
            TOTAL_NOTALLOCATED = getTotaNotAllocated();
            TOTAL_BLOG = getTotalPost(userID);
            TOTAL_ALLOCATIONMADE = getTotalMadeAllocations(userID);
            activaStaffsTab = getTop5ActiveStaff();
        }
    }
    public int getTotalUser()
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "reportTotalUser";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
    public int getInactiveStudents()
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "reportTotalInactiveStudents";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
    public int getTotalAllocation()
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "reportTotalAllocations";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
    public int getTotaNotAllocated()
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "reportTotalNotAllocated";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
    public int getTotalPost(string myID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getTotalBlogPost";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@ID", myID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
    public int getTotalMadeAllocations(string myID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getTotalMadeAllocations";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@ID", myID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }


    public string getUserNameByID(String ID)
    {
        string prefix = ID.Substring(0, 3);
        if (prefix.Equals("STA"))
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStaffNameByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
        else 
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStudentNameByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
    }
    public string getAvatarByID(String ID)
    {
        string prefix = ID.Substring(0, 3);
        if (prefix.Equals("STA"))
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStaffAvaByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
        else
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStudentAvaByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
    }
    public DataTable getTop5ActiveStaff()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getTop5ActiveStaffs";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "TOPactiveStaffs";
        return dtTab;
    }
}