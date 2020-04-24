using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffMeetings : System.Web.UI.Page
{
    public tblStaffs crrStaff;
    public String userID, USER_TYPE;
    public int userType;
    private DAO_Meetings daoMeeting;
    public DataTable tblStaffMeetings;

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
        daoMeeting = new DAO_Meetings();
        tblStaffMeetings = new DataTable();
        tblStaffMeetings = daoMeeting.GetMeetingsByStaffID(userID);

    }
}