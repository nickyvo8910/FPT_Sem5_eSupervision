using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffAllocation : System.Web.UI.Page
{
    private DAO_Staffs daoStaff;
    private tblStaffs DTOStaff;
    public DataTable tblAllStaffs;
    public string actionPasser;
    public String userID, USER_TYPE;
    public int userType;
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
        daoStaff = new DAO_Staffs();
        try
        {
            tblAllStaffs = daoStaff.GetAllStaff();
        }
        catch (Exception ex)
        {
            Response.Redirect("Error.aspx?error=" + ex.Message.Replace("\n", "") + ex.StackTrace.Replace("\n", ""));
        }
        if (Request.QueryString["action"] != null)
        {
            actionPasser = Request.QueryString["action"].ToString();
           
        }
    }
}