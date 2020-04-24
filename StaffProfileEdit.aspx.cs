using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffProfileEdit : System.Web.UI.Page
{
    DAO_Staffs daoStaff;
    public tblStaffs crrStaff;
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
        crrStaff = new tblStaffs();
        daoStaff = new DAO_Staffs();
        crrStaff.StaffID = userID;
        if (!Page.IsPostBack)
        {
            DataRow dtRow = (DataRow)daoStaff.GetStaffById(crrStaff).Rows[0];
            crrStaff.StaffName = txtName.Text = dtRow[1].ToString();
            crrStaff.StaffBirth = Convert.ToDateTime(dtRow[3].ToString());
            txtBirthday.Text = crrStaff.StaffBirth.ToShortDateString();
            crrStaff.StaffMailAddr = txtEmail.Text = dtRow[4].ToString();
            crrStaff.StaffPhone = txtMobile.Text = dtRow[5].ToString();
            crrStaff.StaffAddr = txtAddress.Text = dtRow[6].ToString();
        }
    }
    public string getAvatarByID(String ID)
    {
        string prefix = ID.Substring(0, 3);
        if (prefix.Equals("STA"))
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStaffAvaByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
        else
        {
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "getStudentAvaByID";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            string sql = (string)DAO.sqlCom.ExecuteScalar();
            DAO.sqlCon.Close();
            return sql;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string url = "";
        try
        {
            crrStaff = new tblStaffs();
            crrStaff.StaffID = userID;
            crrStaff.StaffName = txtName.Text.Trim();
            crrStaff.StaffBirth = Convert.ToDateTime(txtBirthday.Text.Replace("-","/").Trim());
            crrStaff.StaffMailAddr = txtEmail.Text.Trim();
            crrStaff.StaffPhone = txtMobile.Text.Trim();
            crrStaff.StaffAddr = txtAddress.Text.Trim();
            bool sql = daoStaff.UpdateStaff(crrStaff);
            if (sql)
            {
                url = "StaffProfile.aspx";
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
            crrStaff = new tblStaffs();
            crrStaff.StaffID = userID;
            crrStaff.StaffPass = crrPass;
            if (daoStaff.validateUserNamePassworld(crrStaff))
            {
                crrStaff.StaffPass = newPass;
                if (daoStaff.UpdatePassword(crrStaff))
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
                crrStaff = new tblStaffs();
                crrStaff.StaffID=userID;
                crrStaff.StaffAvatar=filename;
                if (daoStaff.UpdateAvatar(crrStaff))
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