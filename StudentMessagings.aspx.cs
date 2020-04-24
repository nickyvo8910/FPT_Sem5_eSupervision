using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentMessagings : System.Web.UI.Page
{
    public String userID, USER_TYPE;
    public int userType;
    private DAO_tblPersonalMessages daoMessages;
    private DAO_Students daoStudents;
    public tblStudents crrStudent;
    public DataTable tblStuMessages;
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
        daoMessages = new DAO_tblPersonalMessages();
        daoStudents = new DAO_Students();
        tblStuMessages = new DataTable();

        tblStuMessages = daoMessages.getAllMessConversationsByStuID(userID);
        crrStudent = new tblStudents();
        crrStudent.StudentID = userID;
        DataRow dtRow = (DataRow)daoStudents.GetStudentById(crrStudent).Rows[0];
        crrStudent.StudentSupervisorID = dtRow[7].ToString();
        crrStudent.StudentSecondMarkerID = dtRow[8].ToString();

        fillData();
    }
    private void fillData()
    {
        GridView1.DataSource = tblStuMessages;
        GridView1.DataBind();
    }
}