using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffMessagings : System.Web.UI.Page
{
    public String userID, USER_TYPE;
    public int userType;
    public tblStaffs crrStaff;
    private DAO_tblPersonalMessages daoMessages;
    private DAO_Students daoStudents;
    public DataTable tblStaffStudents;
    public DataTable tblStaffMessages;
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
        tblStaffMessages = new DataTable();
        tblStaffStudents = new DataTable();
        tblStaffMessages = daoMessages.getStaffConversations(userID);
        tblStaffStudents = daoStudents.GetStuByStaffID(userID);
        fillData();
    }
    private void fillData()
    {
        GridView1.DataSource = tblStaffMessages;
        GridView1.DataBind();
    }
}