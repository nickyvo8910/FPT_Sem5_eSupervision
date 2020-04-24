using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerUpdateStudent : System.Web.UI.Page
{
    public String userID, USER_TYPE, studentID;
    public int userType;
    private DAO_Students daoStudent;
    private tblStudents crrStudent; 
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
        if (Request.QueryString["stuID"] != null)
        {
            studentID = Request.QueryString["stuID"].ToString();
        }
        for (int i = 2000; i <= 2015; i++)
        {
            dropAca.Items.Add(i.ToString());
        }
        crrStudent = new tblStudents();
        daoStudent = new DAO_Students();
        crrStudent.StudentID = studentID;
        DataRow dtRow = (DataRow)daoStudent.GetStudentById(crrStudent).Rows[0];
        crrStudent.StudentName = dtRow[1].ToString();
        crrStudent.StudentAcademicYear = dtRow[2].ToString();
        crrStudent.StudentBirth=Convert.ToDateTime(dtRow[3].ToString());
        crrStudent.StudentMailAddr=dtRow[4].ToString();
        crrStudent.StudentPhone=dtRow[5].ToString();
        crrStudent.StudentAddr = dtRow[6].ToString();

        // fill Data
        if (!Page.IsPostBack)
        {
            txtID.Text = crrStudent.StudentID;
            hidID.Value = crrStudent.StudentID;
            txtName.Text = crrStudent.StudentName;
            string aca = crrStudent.StudentAcademicYear;
            int listIndex = 0;
            foreach (ListItem lItem in dropAca.Items)
            {
                if (lItem.Text.Equals(aca))
                {
                    dropAca.SelectedIndex = listIndex;
                }
                listIndex++;
            }
            txtBirthday.Text = crrStudent.StudentBirth.ToShortDateString();
            txtEmail.Text = crrStudent.StudentMailAddr;
            txtMobile.Text = crrStudent.StudentPhone;
            txtAddress.Text = crrStudent.StudentAddr;
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string crrID = hidID.Value;
            string crrName = txtName.Text.Trim();
            string crrAca = dropAca.SelectedItem.Text.Trim();
            DateTime crrBirth = Convert.ToDateTime(txtBirthday.Text.Trim());
            string crrMail = txtEmail.Text.Trim();
            string crrPhone = txtMobile.Text.Trim();
            string crrAddr = txtAddress.Text.Trim();

            crrStudent = new tblStudents();
            crrStudent.StudentID = crrID;
            crrStudent.StudentName = crrName;
            crrStudent.StudentAcademicYear = crrAca;
            crrStudent.StudentBirth = crrBirth;
            crrStudent.StudentMailAddr = crrMail;
            crrStudent.StudentPhone = crrPhone;
            crrStudent.StudentAddr = crrAddr;

            if (!daoStudent.UpdateInfoStudent(crrStudent))
            {
                Response.Redirect("Error.aspx?error=Update Student Info Failed");
            }
            else
            {
                Response.Redirect("ManagingStudents.aspx", false);
            }
        }
        catch (Exception ex)
        {

            Response.Redirect("Error.aspx?error="+ex.Message+ex.StackTrace.Replace("\n",""));
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagingStudents.aspx");
    }
}