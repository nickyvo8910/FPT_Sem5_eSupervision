using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagingStudents : System.Web.UI.Page
{
    private DAO_Students daoStudent;
    private tblStudents DTOStudent;
    public DataTable tblAllStudents;
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
        daoStudent = new DAO_Students();
        try
        {
            tblAllStudents = daoStudent.GetAllStudent();
        }
        catch (Exception ex)
        {
            Response.Redirect("Error.aspx?error=" + ex.Message.Replace("\n", "") + ex.StackTrace.Replace("\n", ""));
        }
        if (Request.QueryString["action"] != null && Request.QueryString["stuID"] != null)
        {
            string action = Request.QueryString["action"].ToString();
            if (action.Equals("Delete"))
            {
                string studentID = Request.QueryString["stuID"].ToString();
                //Delete
            }
        }
    }
}