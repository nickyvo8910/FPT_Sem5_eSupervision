using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentProfileEdit : System.Web.UI.Page
{
    public String userID, USER_TYPE;
    public int userType;
    public tblStudents Tbl_Student;
    DAO_Students daoStudent;
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
        Tbl_Student = new tblStudents();
        Tbl_Student.StudentID = userID;
        DataRow dtRow = (DataRow)daoStudent.GetStudentById(Tbl_Student).Rows[0];
        Tbl_Student.StudentName = dtRow[1].ToString();
        Tbl_Student.StudentAcademicYear = dtRow[2].ToString();
        Tbl_Student.StudentBirth = Convert.ToDateTime(dtRow[3].ToString());
        Tbl_Student.StudentMailAddr = dtRow[4].ToString();
        Tbl_Student.StudentPhone = dtRow[5].ToString();
        Tbl_Student.StudentAddr = dtRow[6].ToString();
        Tbl_Student.StudentAvatar = dtRow[9].ToString();

        if (!Page.IsPostBack)
        {
            txtName.Text = Tbl_Student.StudentName;
            txtBirthday.Text = Tbl_Student.StudentBirth.ToShortDateString();
            txtEmail.Text = Tbl_Student.StudentMailAddr;
            txtMobile.Text = Tbl_Student.StudentPhone;
            txtAddress.Text = Tbl_Student.StudentAddr;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string url = "";
        try
        {
            Tbl_Student = new tblStudents();
            Tbl_Student.StudentID = userID;
            Tbl_Student.StudentName = txtName.Text.Trim();
            Tbl_Student.StudentBirth = Convert.ToDateTime(txtBirthday.Text.Replace("-", "/").Trim());
            Tbl_Student.StudentMailAddr = txtEmail.Text.Trim();
            Tbl_Student.StudentPhone = txtMobile.Text.Trim();
            Tbl_Student.StudentAddr = txtAddress.Text.Trim();
            bool sql = daoStudent.UpdateProfile(Tbl_Student);
            if (sql)
            {
                url = "StudentProfile.aspx";
            }
            else
            {
                url = "Error.aspx?error=Error";
            }
        }

        catch (Exception ex)
        {
            url = "Error.aspx?error=" + ex.Message + ex.StackTrace.Replace("\n", "");
        }
        Response.Redirect(url);
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        if (!txtCurPass.Text.Equals("") && !txtNewPass.Text.Equals("") && !txtRePass.Text.Equals(""))
        {
            string crrPass = txtCurPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string rePass = txtRePass.Text.Trim();
            if (newPass.Length >= 50)
            {
                PassLabel.Text = "Password Length Should Not Exceed 50 Chars";
                return;
            }
            if (!rePass.Equals(newPass))
            {
                PassLabel.Text = "Retype Password Do Not Match";
                return;
            }
            Tbl_Student = new tblStudents();
            Tbl_Student.StudentID = userID;
            Tbl_Student.StudentPass = crrPass;
            if (daoStudent.validateUserNamePassworld(Tbl_Student))
            {
                Tbl_Student.StudentPass = newPass;
                if (daoStudent.Update_Password(Tbl_Student))
                {
                    PassLabel.Text = "Password Update Successed";
                }
                else
                {
                    PassLabel.Text = "Password Update Failed";
                }
            }
            else
            {
                PassLabel.Text = "Old Password Did Not Match Our Record";
                return;
            }
        }
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename = "";
                //if (FileUploadControl.PostedFile.ContentType == "text/plain" || FileUploadControl.PostedFile.ContentType == "application/pdf" || FileUploadControl.PostedFile.ContentType == "application/msword" || FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || FileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel" || FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                if (FileUploadControl.PostedFile.ContentType == "image/jpeg" || FileUploadControl.PostedFile.ContentType == "image/png")
                {
                    if (FileUploadControl.PostedFile.ContentLength < 5242880)//in Bytes
                    {
                        filename = Path.GetFileName(FileUploadControl.FileName);
                        if (filename.Length > 200)
                        {
                            String[] fileName = filename.Split(new Char[] { '.' });
                            string ext = fileName[fileName.Length - 1];
                            filename = filename.Substring(0, 200) + "." + ext;

                        }
                        //If file with the same name exist, it will be combine with Time value
                        if (!System.IO.File.Exists(Server.MapPath("~/Uploads/Avatars/") + filename))
                        {

                            FileUploadControl.SaveAs(Server.MapPath("~/Uploads/Avatars/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        else
                        {
                            filename = DateTime.Now.ToString("hh-mm-ss_dd-MM-yyyy") + "_" + filename;
                            FileUploadControl.SaveAs(Server.MapPath("~/Uploads/Avatars/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";

                        }

                    }
                    else
                    {
                        StatusLabel.Text = "Upload status: The file has to be less than 5 MB !";
                        return;
                    }
                }
                else
                {
                    StatusLabel.Text = "Upload status: Only Image/JPEG/PNG files are accepted!";
                    return;
                }

                //Record data to DB
                Tbl_Student = new tblStudents();
                Tbl_Student.StudentID = userID;
                Tbl_Student.StudentAvatar = filename;
                if (daoStudent.Update_Avatar(Tbl_Student))
                {
                    StatusLabel.Text = "Upload status: Update Avatar Successed";
                }
                else
                {
                    string filepath = Server.MapPath("/Uploads/Avatars/");
                    File.Delete(filepath + filename);
                    StatusLabel.Text = "Upload status: Update Avatar Failed";
                    return;
                }

            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                return;
            }
        }
    }
}