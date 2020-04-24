using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    DAO data = new DAO();
    public int login(String ID, String Pass)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblStaffs where staffID=@ID and staffPass=@Pass and staffStatus != @Status";
        DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
        DAO.sqlCom.Parameters.AddWithValue("@Status", 2);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblStudents where studentID=@ID and studentPass=@Pass and studentStatus != @Status";
        DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
        DAO.sqlCom.Parameters.AddWithValue("@Status", 2);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql1 = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (sql == 1)
        {
            return getStaffType(ID);
        }
        else if (sql1 == 1)
        {
            return 1;
        }
        else return 0;
    }
    public int getStaffType(String ID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select staffType from tblStaffs where staffID=@ID and staffStatus !=@Status";
        DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Status", 2);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }

    public int getAccByMail(String Mail)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblStaffs where staffMailAddr=@Mail and staffStatus != @Status";
        DAO.sqlCom.Parameters.AddWithValue("@Mail", Mail);
        DAO.sqlCom.Parameters.AddWithValue("@Status", 2);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblStudents where studentMailAddr=@Mail and studentStatus != @Status";
        DAO.sqlCom.Parameters.AddWithValue("@Mail", Mail);
        DAO.sqlCom.Parameters.AddWithValue("@Status", 2);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql1 = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (sql == 1)
        {
            return 2; //Staff Account
        }
        else if (sql1 == 1)
        {
            return 1;//Student Account
        }
        else return 0;
    }
    public String getRandomCode()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var result = new string(
            Enumerable.Repeat(chars, 8)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
        return result;
    }

    public void mailCode(String Mail, String Code)
    {
        MailAddress to = new MailAddress(Mail);
        MailAddress from = new MailAddress("greenwichesupervisor94@gmail.com", "eSupervisor");
        MailMessage mail = new MailMessage(from, to);
        mail.Subject = "eSupervisor Password Recovery";
        mail.Body = "Dear , " + Mail + ". \n" +
                    "This is the securitycode that can be used as your new password : " + Code+
                    "\n For your own security concern we recommend you to chang this to your own password."
                    + "\n Thank you for your patience";

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;

        smtp.Credentials = new System.Net.NetworkCredential("greenwichesupervisor94@gmail.com", "myproject");
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }
    public int resetPasswordAndUpdateStatus(String Mail, String Pass)
    {
        int sql=0;
        int accType = getAccByMail(Mail);
        //Set User's Password to new random code + Update User's Status
        if (accType == 1)//Student Account
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "update tblStudents set [studentPass] =@Pass,studentStatus=@Status"
                                   + " where tblStudents.studentMailAddr =@Mail ";
            DAO.sqlCom.CommandType = CommandType.Text;
            DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
            DAO.sqlCom.Parameters.AddWithValue("@Status", 0);
            DAO.sqlCom.Parameters.AddWithValue("@Mail", Mail);
            DAO.sqlCom.Connection = DAO.sqlCon;
            sql = DAO.sqlCom.ExecuteNonQuery();
            DAO.sqlCon.Close();
            if (sql == 1)

                return 1;
            else
                return 0;
        }
        else if (accType == 2)//Staff Account
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "update tblStaffs set [staffPass] =@Pass,staffStatus=@Status"
                                   + " where tblStaffs.staffMailAddr =@Mail";
            DAO.sqlCom.CommandType = CommandType.Text;
            DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
            DAO.sqlCom.Parameters.AddWithValue("@Status", 0);
            DAO.sqlCom.Parameters.AddWithValue("@Mail", Mail);
            DAO.sqlCom.Connection = DAO.sqlCon;
            sql = DAO.sqlCom.ExecuteNonQuery();
            DAO.sqlCon.Close();
            if (sql == 1)

                return 1;
            else
                return 0;
        }
        return sql;
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtID.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
        if (Request.QueryString["action"] != null)
        {
            string action = Request.QueryString["action"].ToString();
            if (action.Equals("logout"))
            {
                Session.Abandon();
                Request.Cookies.Clear();
            }
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        try
        {
            int logged = login(txtID.Text.Trim(), txtPassword.Text.Trim());
            if (logged == 1)//Student
            {
                Session["userID"] = txtID.Text.Trim();
                Session["userType"] = logged;
                //lblLogin.Text = "Hi, " + Session["userID"].ToString() + ",";
                // lnkbtnLogOut.Visible = true;
                // lblError.Visible = false;
                // panelLogin.Visible = false;

                //Remember Me Function implementation
                if (chkRemember.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtID.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                //End Rememberme function implementation

                Response.Redirect("studentDashboard.aspx");

            }
            else if (logged == 2)//Supervisor or Secondmarker (Staffs)
            {
                Session["userID"] = txtID.Text.Trim();
                Session["userType"] = logged;
                //Remember Me Function implementation
                if (chkRemember.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtID.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                //End Rememberme function implementation
                Response.Redirect("StaffDashboard.aspx");
            }
            else if (logged == 3)//Manager
            {
                Session["userID"] = txtID.Text.Trim();
                Session["userType"] = logged;
                //Remember Me Function implementation
                if (chkRemember.Checked)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

                }
                Response.Cookies["UserName"].Value = txtID.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                //End Rememberme function implementation
                Response.Redirect("managerDashboard.aspx");
            }
            else
            {
                txtID.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
                lblError.Text = "Log In Failed !!! Try Again ?";

                lblError.Visible = true;
                return;
            }
        }
        catch (Exception ex )
        {
            txtID.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            lblError.Text = "Log In Failed!!! The following error occured: "+ex.Message;

            lblError.Visible = true;
            return;
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string mail = txtEmail.Text.Trim();
            int checkMail = getAccByMail(mail);
            //Check whether this email address is existed in the system.
            if (checkMail != 0)//Existed
            {
                String code = getRandomCode();//Get a random code for new password
                //Change user's password into new code and update user's status to "Not Yet Activated"
                int sqlStt = resetPasswordAndUpdateStatus(mail, code);
                if (sqlStt == 1)//SQL excecution completed
                {
                    mailCode(mail, code);
                    txtID.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                }
                else//SQL excecution failed
                {
                    txtID.Text = "";
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                    lblError.Text = "System cannot reset your password. \n Contact adninistrator for for information.";
                    lblError.Visible = true;
                    return;
                }
            }
            else//Not Existed
            {
                txtID.Text = "";
                txtPassword.Text = "";
                txtEmail.Text = "";
                lblError.Text = "This email doesn't belong to any account in the system !!! Try Again ?";
                lblError.Visible = true;
                return;
            }
        }
        catch (Exception ex)
        {
            txtID.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            lblError.Text = "Recovery Failed!!! The following error occured: " + ex.Message;

            lblError.Visible = true;
            return;
        }
    }
}
