using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentDashboard : System.Web.UI.Page
{
    DAO_Students daoStudents = new DAO_Students();
    DAO_Meetings daoMeeting = new DAO_Meetings();
    DAO_Staffs daoStaff = new DAO_Staffs();
    DAO_BlogPosts daoBlogPost = new DAO_BlogPosts();
    DAO_MeetingMembers daoMember = new DAO_MeetingMembers();
    DAO_Documents daoDocument = new DAO_Documents();
    DAO_tblPersonalMessages daoMessage = new DAO_tblPersonalMessages();
    DAO_Allocations daoAllocation = new DAO_Allocations();
    public int  TOTAL_MEETINGS, TOTAL_POSTS, TOTAL_UPLOADS,TOTAL_MESS;
    public DataTable tblCommunication;
    public String userID, USER_TYPE, SuperName, SecondName, LastLogin;
    public int userType;
    tblStudents tbl_Student;
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

        TOTAL_MEETINGS = daoMember.GetMeeetingsByMemberId(userID).Rows.Count;
        TOTAL_POSTS = daoBlogPost.GetBlogPostByUserID(userID).Rows.Count;
        TOTAL_UPLOADS = daoDocument.GetUserUpload(userID, "").Rows.Count;
        TOTAL_MESS = daoMessage.getAllMessByStuID(userID).Rows.Count;
        SuperName = SecondName = "Not Set";
        tbl_Student = new tblStudents();
        tbl_Student.StudentID=userID;
        SuperName = daoStudents.GetStudentById(tbl_Student).Rows[0][7].ToString();
        if (!SuperName.Equals("Null") && (!SuperName.Equals("NULL")))
        {
            SuperName = daoStaff.GetStaffNameByID(SuperName);
        }
        SecondName = daoStudents.GetStudentById(tbl_Student).Rows[0][8].ToString();
        if (!SecondName.Equals("Null") && (!SecondName.Equals("NULL")))
        {
            SecondName = daoStaff.GetStaffNameByID(SecondName);
        }
        DateTime lastLoginDate = daoStudents.GetStuLastLogin(userID);
        LastLogin = lastLoginDate.ToShortDateString() + " " + lastLoginDate.ToShortTimeString();

        tblCommunication = daoMessage.getAllMessConversationsByStuID(userID);

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