using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentMyMessaging : System.Web.UI.Page
{
    public String UserId;
    public String USER_TYPE;
    public int UserType;
    public string StaffID, StaffName;
    private DAO_tblPersonalMessages daoMess;

    private DAO_Staffs daoStaffs;
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
        if (Request.QueryString["staffID"] != null)
        {
            StaffID = Request.QueryString["staffID"].ToString().Trim();

        }
        else
        {
            Response.Redirect("StudentMessagings.aspx");
        }
        //get all Mess between Staff/Student
        daoMess = new DAO_tblPersonalMessages();
        daoStaffs = new DAO_Staffs();
        StaffName = daoStaffs.GetStaffNameByID(StaffID);
        tblConversation = daoMess.getStaffConversationDetails(StaffID, UserId);

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
        tblMess.StuID = UserId;
        tblMess.StaffID = StaffID;
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