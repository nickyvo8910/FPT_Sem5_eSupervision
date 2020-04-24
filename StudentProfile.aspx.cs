using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentProfile : System.Web.UI.Page
{
    public String userID, USER_TYPE;
    public int userType;
    public tblStudents Tbl_Student;
    DAO_Students daoStudent;
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
        daoStudent = new DAO_Students();
        Tbl_Student = new tblStudents();
        Tbl_Student.StudentID = userID;
        DataRow dtRow = (DataRow)daoStudent.GetStudentById(Tbl_Student).Rows[0];
        Tbl_Student.StudentName = dtRow[1].ToString();
        Tbl_Student.StudentAcademicYear = dtRow[2].ToString();
        Tbl_Student.StudentBirth = Convert.ToDateTime(dtRow[3].ToString());
        Tbl_Student.StudentMailAddr = dtRow[4].ToString();
        Tbl_Student.StudentPhone = dtRow[5].ToString();
        Tbl_Student.StudentAddr = dtRow[6].ToString();
        Tbl_Student.StudentAvatar = dtRow[9].ToString();

    }
}