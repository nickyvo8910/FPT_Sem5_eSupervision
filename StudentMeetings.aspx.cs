using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentMeetings : System.Web.UI.Page
{

    public tblStaffs crrStaff;
    public String userID, USER_TYPE;
    public int userType;
    private DAO_MeetingMembers daoMember;
    public DAO_Staffs DaoStaff;
    public DataTable tblStuMeetings;
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
        daoMember = new DAO_MeetingMembers();
        DaoStaff = new DAO_Staffs();
        tblStuMeetings = new DataTable();
        tblStuMeetings = daoMember.GetMeeetingsByMemberIdForStu(userID);
    }
}