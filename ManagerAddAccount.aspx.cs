using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerAddAccount : System.Web.UI.Page
{
    private DAO_Staffs daoStaff;
    private DAO_Students daoStudent;
    private tblStudents DTOStudent;
    private tblStaffs DTOStaff;
    public String userID ,USER_TYPE;
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
            int choice = Convert.ToInt32(dropType.SelectedValue);
            if (!Page.IsPostBack)
            {
                for (int i = 2000; i <= 2015; i++)
                {
                    dropAca.Items.Add(i.ToString());
                }
            }
            switch (choice)
            {
                case 1:
                    {
                        daoStudent = new DAO_Students();
                        DTOStudent = new tblStudents();
                        string crrID = daoStudent.GetCrrMaxID();
                        string newID = crrID.Substring(0, crrID.Length - 1) + (Convert.ToInt32(crrID.Substring(crrID.Length - 1, 1)) + 1).ToString();
                        txtID.Text = newID;
                        hidID.Value = newID;
                    }
                    break;
                case 2:
                    {
                        daoStaff = new DAO_Staffs();
                        DTOStaff = new tblStaffs();
                        string crrID = daoStaff.GetCrrMaxID();
                        string newID = crrID.Substring(0, crrID.Length - 1) + (Convert.ToInt32(crrID.Substring(crrID.Length - 1, 1)) + 1).ToString();
                        txtID.Text = newID;
                        hidID.Value = newID;
                    }
                    break;
                case 3:
                    {
                        daoStaff = new DAO_Staffs();
                        DTOStaff = new tblStaffs();
                        string crrID = daoStaff.GetCrrMaxID();
                        string newID = crrID.Substring(0, crrID.Length - 1) + (Convert.ToInt32(crrID.Substring(crrID.Length - 1, 1)) + 1).ToString();
                        txtID.Text = newID;
                        hidID.Value = newID;
                    }
                    break;
            }
        }
    }
    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int choice = Convert.ToInt32(dropType.SelectedValue);
        switch (choice)
        {
            case 1:
                {
                    dropAca.Visible = true;
                }
                break;
            case 2:
                {
                    dropAca.Visible = false;
                }
                break;
            case 3:
                {
                    dropAca.Visible = false;
                }
                break;
        }
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
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        String UserID = hidID.Value.ToString();
        String Name = txtName.Text.Trim();
        String Year = dropAca.SelectedItem.Text.Trim();
        DateTime Birth = Convert.ToDateTime(txtBirthday.Text.Trim());
        String Mail = txtEmail.Text.Trim();
        String Phone = txtMobile.Text.Trim();
        String Addr = txtAddress.Text.Trim();
        int accType = Convert.ToInt32(dropType.SelectedValue);
        String Pass = getRandomCode();
        string url = "Error.aspx?error=";
        try
        {
            int sql = 0;
            switch (accType)
            {
                case 1:
                    {
                        /*if (DAO.sqlCon.State == ConnectionState.Open)
                            DAO.sqlCon.Close();
                        DAO.sqlCon.Open();
                        DAO.sqlCom = new SqlCommand();
                        DAO.sqlCom.CommandText = "InserttblStudents";
                        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
                        DAO.sqlCom.Parameters.AddWithValue("@studentID", UserID);
                        DAO.sqlCom.Parameters.AddWithValue("@studentName", Name);
                        DAO.sqlCom.Parameters.AddWithValue("@studentPass", Pass);
                        DAO.sqlCom.Parameters.AddWithValue("@studentMailAddr", Mail);
                        DAO.sqlCom.Parameters.AddWithValue("@studentAcademicYear", Year);
                        DAO.sqlCom.Parameters.AddWithValue("@studentAvatar", "");
                        DAO.sqlCom.Parameters.AddWithValue("@studentBirth", Birth);
                        DAO.sqlCom.Parameters.AddWithValue("@studentAddr", Addr);
                        DAO.sqlCom.Parameters.AddWithValue("@studentPhone", Phone);
                        DAO.sqlCom.Connection = DAO.sqlCon;
                        sql = DAO.sqlCom.ExecuteNonQuery();*/
                        DTOStudent.StudentAcademicYear = Year;
                        DTOStudent.StudentAddr = Addr;
                        DTOStudent.StudentAvatar = "";
                        DTOStudent.StudentBirth = Birth;
                        DTOStudent.StudentID = UserID;
                        DTOStudent.StudentMailAddr = Mail;
                        DTOStudent.StudentPass = Pass;
                        DTOStudent.StudentPhone = Phone;
                        DTOStudent.StudentName = Name;
                        DTOStudent.StudentStatus = 1;

                        if (daoStudent.InsertStudent(DTOStudent))
                        {
                            url = "ManagingStaff.aspx";
                        }
                        else
                        {

                        }
                    }
                    break;
                case 2:
                    {
                        if (DAO.sqlCon.State == ConnectionState.Open)
                            DAO.sqlCon.Close();
                        DAO.sqlCon.Open();
                        DAO.sqlCom = new SqlCommand();
                        DAO.sqlCom.CommandText = "InsertStaff";
                        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
                        DAO.sqlCom.Parameters.AddWithValue("@staffID", UserID);
                        DAO.sqlCom.Parameters.AddWithValue("@staffName", Name);
                        DAO.sqlCom.Parameters.AddWithValue("@staffPass", Pass);
                        DAO.sqlCom.Parameters.AddWithValue("@staffMailAddr", Mail);
                        DAO.sqlCom.Parameters.AddWithValue("@staffAvatar", "");
                        DAO.sqlCom.Parameters.AddWithValue("@staffBirth", Birth);
                        DAO.sqlCom.Parameters.AddWithValue("@staffAddr", Addr);
                        DAO.sqlCom.Parameters.AddWithValue("@staffPhone", Phone);
                        DAO.sqlCom.Parameters.AddWithValue("@staffType", 2);
                        DAO.sqlCom.Connection = DAO.sqlCon;
                        sql = DAO.sqlCom.ExecuteNonQuery();
                        DAO.sqlCon.Close();
                    }
                    break;
                case 3:
                    {
                        if (DAO.sqlCon.State == ConnectionState.Open)
                            DAO.sqlCon.Close();
                        DAO.sqlCon.Open();
                        DAO.sqlCom = new SqlCommand();
                        DAO.sqlCom.CommandText = "InsertStaff";
                        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
                        DAO.sqlCom.Parameters.AddWithValue("@staffID", UserID);
                        DAO.sqlCom.Parameters.AddWithValue("@staffName", Name);
                        DAO.sqlCom.Parameters.AddWithValue("@staffPass", Pass);
                        DAO.sqlCom.Parameters.AddWithValue("@staffMailAddr", Mail);
                        DAO.sqlCom.Parameters.AddWithValue("@staffAvatar", "");
                        DAO.sqlCom.Parameters.AddWithValue("@staffBirth", Birth);
                        DAO.sqlCom.Parameters.AddWithValue("@staffAddr", Addr);
                        DAO.sqlCom.Parameters.AddWithValue("@staffPhone", Phone);
                        DAO.sqlCom.Parameters.AddWithValue("@staffType", 3);
                        DAO.sqlCom.Connection = DAO.sqlCon;
                        sql = DAO.sqlCom.ExecuteNonQuery();
                        DAO.sqlCon.Close();
                    }
                    break;
            }
        }
        catch (SqlException ex)
        {
            Response.Redirect(String.Format("Error.aspx?error={0}", ex.Message.Replace("\n", "")));
        }
        Response.Redirect("ManagerDashboard.aspx");
    }
}