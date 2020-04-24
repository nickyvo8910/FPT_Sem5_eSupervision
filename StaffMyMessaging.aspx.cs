using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffMyMessaging : System.Web.UI.Page
{

    private ChatRecord chatRec;
    public String UserId;
    public String USER_TYPE;
    public int UserType;
    public string StudentID, StudentName;
    private DAO_tblPersonalMessages daoMess;
    private DAO_Students daoStudents;
    public DataTable tblConversation;
    private tblPersonalMessages tblMess;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null || Session["userType"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            UserId = Session["userID"].ToString();
            UserType = Convert.ToInt32(Session["userType"].ToString());
            switch (UserType)
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
        if (Request.QueryString["studentID"] != null)
        {
            StudentID = Request.QueryString["studentID"].ToString().Trim();

        }
        else
        {
            Response.Redirect("StaffMessagings.aspx");
        }
        //get all Mess between Staff/Student
        daoMess = new DAO_tblPersonalMessages();
        daoStudents = new DAO_Students();
        StudentName = daoStudents.GetStudentNameById(StudentID);
        tblConversation = daoMess.getStaffConversationDetails(UserId, StudentID);
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string messStr = txtMessInfo.Text.Trim();
        if (messStr.Length > 250)
        {
            messStr = messStr.Substring(0, 250);
        }
        messStr = UserId + " : " + messStr;
        tblMess = new tblPersonalMessages();
        tblMess.MessSentTime = DateTime.Now;
        tblMess.StaffID = UserId;
        tblMess.StuID = StudentID;
        tblMess.MessInfo = messStr;
        tblMess.MessStatus = 1;
        if (daoMess.InsertMessage(tblMess))
        {
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Response.Redirect("Error.asxp?error=Insert New Message Failed.");
        }

    }
}