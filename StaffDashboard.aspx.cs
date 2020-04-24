using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffDashboard : System.Web.UI.Page
{
    DAO_Students daoStudents = new DAO_Students();
    DAO_Meetings daoMeeting = new DAO_Meetings();
    DAO_BlogPosts daoBlogPost = new DAO_BlogPosts();
    DAO_Documents daoDocument = new DAO_Documents();
    DAO_tblPersonalMessages daoMessage = new DAO_tblPersonalMessages();
    DAO_Allocations daoAllocation = new DAO_Allocations();
    public int TOTAL_STUDENTS, TOTAL_MEETINGS, TOTAL_POSTS, TOTAL_UPLOADS, TOTAL_SUPERVISES, TOTAL_SECOND, TOTAL_MESS;
    public DataTable tblStaffStudents;
    public String userID, USER_TYPE;
    public int userType;

    DAO daoObj = new DAO();
    protected void Page_Load(object sender, EventArgs e)
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

        TOTAL_STUDENTS = daoStudents.GetStuByStaffID(userID).Rows.Count;
        TOTAL_MEETINGS = daoMeeting.GetMeetingsByStaffID(userID).Rows.Count;
        TOTAL_POSTS = daoBlogPost.GetBlogPostByUserID(userID).Rows.Count;
        TOTAL_UPLOADS = daoDocument.GetUserUpload(userID,"").Rows.Count;

        TOTAL_SUPERVISES = daoStudents.GetStuSuperByStaffID(userID).Rows.Count;        
        TOTAL_SECOND = daoStudents.GetStuSecondByStaffID(userID).Rows.Count;
        TOTAL_MESS = daoMessage.getAllMessByStaffID(userID).Rows.Count;
        tblStaffStudents = daoStudents.GetStuByStaffID(userID);

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
}