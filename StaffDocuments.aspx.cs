using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffDocuments : System.Web.UI.Page
{
    public String userID;
    int userType;
    DataClassesDataContext db = new DataClassesDataContext();

    DAO daoObject = new DAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userID"] == null || Session["userType"] == null){           
            Response.Redirect("Login.aspx");
        }else{
            userID = Session["userID"].ToString();
            userType = Convert.ToInt32(Session["userType"].ToString());

            if (!IsPostBack)
            {
                fillData();
            }
        }
    }
    public string getFileNameByID(int ID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getDocLinkByID";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", ID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        string sql = (string)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        return sql;
    }
   /* public DataTable getMyUploads(String myID, String topic)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getUserUploads";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@uploader", myID);
        DAO.sqlCom.Parameters.AddWithValue("@topic", topic);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "uploadsTab" + myID;
        return dtTab;
    }

    public DataTable getMyStudentUploads(String myID, String stuName)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getStudentsUploads";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@staffID", myID);
        DAO.sqlCom.Parameters.AddWithValue("@studentName", stuName);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "studentUploadsTab" + myID;
        return dtTab;
    }
    */
    public void fillData()
    {
        if (Request.QueryString["myUpload"] == null)
        {
            GridView1.DataSource = db.getUserUploads(userID, "");
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = db.getUserUploads(userID,Request.QueryString["myUpload"].ToString().Trim());
            GridView1.DataBind();
        }
        
        if (Request.QueryString["studentUpload"] == null)
        {
            GridView2.DataSource = db.getStudentsUploads(userID, "");
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = db.getStudentsUploads(userID,Request.QueryString["studentUpload"].ToString().Trim());
            GridView2.DataBind();
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                string filename="";
                if (FileUploadControl.PostedFile.ContentType == "text/plain" || FileUploadControl.PostedFile.ContentType == "application/pdf" || FileUploadControl.PostedFile.ContentType == "application/msword" || FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || FileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel" || FileUploadControl.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    if (FileUploadControl.PostedFile.ContentLength < 5242880)//in Bytes
                    {
                        filename = Path.GetFileName(FileUploadControl.FileName);
                        if (filename.Length > 125)
                        {
                            String[] fileName = filename.Split(new Char[] { '.' });
                            string ext = fileName[fileName.Length - 1];
                            filename = filename.Substring(0, 120) + "." + ext;

                        }
                        //If file with the same name exist, it will be combine with Time value
                        if (!System.IO.File.Exists(Server.MapPath("~/Uploads/Documents/") + filename))
                        {

                            FileUploadControl.SaveAs(Server.MapPath("~/Uploads/Documents/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        else
                        {
                            filename = DateTime.Now.ToString("hh-mm-ss_dd-MM-yyyy") + "_" + filename;
                            FileUploadControl.SaveAs(Server.MapPath("~/Uploads/Documents/") + filename);
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
                    StatusLabel.Text = "Upload status: Only PDF, EXCEL, WORD or TEXT files are accepted!";
                    return;
                }

                //Record data to DB
                String title = txtTitle.Text.Trim();
                db.uploadNewDocument(userID, title, filename);
                Response.Redirect("StaffDocuments.aspx");
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                return;
            }
        }
    }
    protected void btnCancelUpload_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffDocuments.aspx");
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdDownload")
            {
                string fileNameStr = e.CommandArgument.ToString();
                string filePath = "~/Uploads/Documents/";
                String[] fileNames = fileNameStr.Split('.');
                string ext = fileNames[fileNames.Length - 1];
                if (ext.Equals("docx") || ext.Equals("doc"))
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                }
                else if (ext.Equals("xls") || ext.Equals("xlsx"))
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else if (ext.Equals("pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else if (ext.Equals("txt"))
                {
                    Response.ContentType = "text/plain";
                }
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileNameStr);
                Response.WriteFile(filePath + fileNameStr);
                Response.End();
            }
            else if (e.CommandName == "cmdUpdate")
            {

            }
            else if (e.CommandName == "cmdDelete")
            {
                int fileID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                string filename = getFileNameByID(fileID);
                string filepath = Server.MapPath("/Uploads/Documents/");
                File.Delete(filepath + filename);

                db.removeUserUpload(fileID);
                Response.Redirect(Request.Url.AbsoluteUri);

            }
        }
        catch (FileNotFoundException fileEx)
        {
            string message = "<script language=javascript>alert('Current File is Not Available.\\n Please contact the file's owner for a new version.');</script>";
            Page.RegisterStartupScript("script", message);
        }
        catch (DirectoryNotFoundException dirEx)
        {
            string message = "<script language=javascript>alert('Current Directory is Not Available.\\n Please contact the file's owner for a new version.');</script>";
            Page.RegisterStartupScript("script", message);
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "cmdDownload")
            {
                string fileNameStr = e.CommandArgument.ToString();
                string filePath = "~/Uploads/Documents/";
                String[] fileNames = fileNameStr.Split('.');
                string ext = fileNames[fileNames.Length - 1];
                if (ext.Equals("docx") || ext.Equals("doc"))
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                }
                else if (ext.Equals("xls") || ext.Equals("xlsx"))
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                else if (ext.Equals("pdf"))
                {
                    Response.ContentType = "application/pdf";
                }
                else if (ext.Equals("txt"))
                {
                    Response.ContentType = "text/plain";
                }
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileNameStr);
                Response.WriteFile(filePath + fileNameStr);
                Response.End();
            }
            else if (e.CommandName == "cmdComment")
            {

            }
        }
        catch (FileNotFoundException fileEx)
        {
            string message = "<script language=javascript>alert('Current File is Not Available.\\n Please contact the file's owner for a new version.');</script>";
            Page.RegisterStartupScript("script", message);
        }
        catch (DirectoryNotFoundException dirEx)
        {
            string message = "<script language=javascript>alert('Current Directory is Not Available.\\n Please contact the file's owner for a new version.');</script>";
            Page.RegisterStartupScript("script", message);
        }
    }
}