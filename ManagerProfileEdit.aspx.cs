using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerProfileEdit : System.Web.UI.Page
{
    public DataRow staffInfo;
    public String userID, USER_TYPE;
    public int userType;
    private tblStaffs crrStaff;
    private DAO_Staffs daoStaff;
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

            staffInfo = getStaffsByPK(userID);
        }
        if (!Page.IsPostBack)
        {

            txtName.Text = staffInfo[1].ToString();
            txtBirthday.Text = staffInfo[4].ToString().Substring(0, 10);
            txtEmail.Text = staffInfo[2].ToString();
            txtMobile.Text = staffInfo[6].ToString();
            txtAddress.Text = staffInfo[5].ToString();
        }
    }
    public DataRow getStaffsByPK(String myID)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getStaffsByPK";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@ID", myID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        return (DataRow)dtTab.Rows[0];
    }
    public int updateStaffInfo(string staffID, string staffName, string staffMailAddr, string staffAvatar, DateTime staffBirth, string staffAddr, string staffPhone) 
    {      
            if (DAO.sqlCon.State == ConnectionState.Open)
                DAO.sqlCon.Close();
            DAO.sqlCon.Open();
            DAO.sqlCom = new SqlCommand();
            DAO.sqlCom.CommandText = "update tblStaffs set staffName=@Name,staffMailAddr=@Mail,staffAvatar=@Avatar,staffBirth=@Birth,staffAddr=@Addr,staffPhone=@Phone where staffID=@ID";
            DAO.sqlCom.CommandType = CommandType.Text;
            DAO.sqlCom.Parameters.AddWithValue("@Name", staffName);
            DAO.sqlCom.Parameters.AddWithValue("@Mail", staffMailAddr);
            DAO.sqlCom.Parameters.AddWithValue("@Avatar", staffAvatar);
            DAO.sqlCom.Parameters.AddWithValue("@Birth", staffBirth);
            DAO.sqlCom.Parameters.AddWithValue("@Addr", staffAddr);
            DAO.sqlCom.Parameters.AddWithValue("@Phone", staffPhone);
            DAO.sqlCom.Parameters.AddWithValue("@ID", staffID);
            DAO.sqlCom.Connection = DAO.sqlCon;
            int sql =DAO.sqlCom.ExecuteNonQuery();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string staffID = staffInfo[0].ToString();
            string staffName = txtName.Text.Trim();
            string staffMailAddr = txtEmail.Text.Trim();
            string staffAvatar = staffInfo[3].ToString().Trim();
            DateTime staffBirth = Convert.ToDateTime(txtBirthday.Text.Trim()).Date;
            string staffAddr = txtAddress.Text.Trim();
            string staffPhone = txtMobile.Text.Trim();

            int checkMail = getAccByMail(staffMailAddr);
            if (checkMail == 0 || staffMailAddr.Equals(staffInfo[2].ToString().Trim()))
            {
                updateStaffInfo(staffID, staffName, staffMailAddr, staffAvatar, staffBirth, staffAddr, staffPhone);        
            }
            else
            {
                //lblEmail.Text = "*";
                //lblEmail.Visible = true;
            }
        }        
        catch (Exception ex)
        {
            Response.Redirect("Error.aspx?error="+ex.Message+ex.StackTrace.Replace("\n",""));
        }
        
        Response.Redirect("ManagerProfile.aspx");
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        daoStaff = new DAO_Staffs();
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
                crrStaff.StaffID = userID;
                crrStaff.StaffAvatar = filename;
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