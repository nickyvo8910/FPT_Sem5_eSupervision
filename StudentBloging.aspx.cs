using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentBloging : System.Web.UI.Page
{
    public String UserId;
    public String USER_TYPE;
    public int UserType;

    private DAO_BlogPosts daoBlog;
    private DAO_Students daoStudent;
    public DataTable TblAllPost;
    private tblBlogPosts tblPost;
    public tblStudents TblCrrStudent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null || Session["userType"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            UserId = Session["userID"].ToString();
            UserType = Convert.ToInt32(Session["userType"].ToString());
            switch (UserType)
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
        TblCrrStudent = new tblStudents();
        TblCrrStudent.StudentID = UserId;
        DataRow crrStaff = (DataRow)daoStudent.GetStudentById(TblCrrStudent).Rows[0];
        TblCrrStudent.StudentAvatar = crrStaff[9].ToString();
        TblCrrStudent.StudentName = crrStaff[1].ToString();
        TblCrrStudent.StudentMailAddr = crrStaff[4].ToString();

        daoBlog = new DAO_BlogPosts();
        TblAllPost = daoBlog.GetBlogPostByUserID(UserId);
        if (Request.QueryString["action"] != null && Request.QueryString["postID"] != null)
        {
            string action = Request.QueryString["action"].ToString();
            int postID = Convert.ToInt32(Request.QueryString["postID"].ToString());
            if (action.Equals("Delete"))
            {
                tblPost = new tblBlogPosts();
                tblPost.PostID = postID;
                if (!daoBlog.UpdateBlogPostStatus(tblPost))
                {
                    Response.Redirect("Error.aspx?error=Delete Blog Post Failed.");
                }
                else
                {
                    Response.Redirect("StudentBloging.aspx");
                }
            }
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        tblPost = new tblBlogPosts();
        string postInfo = txtPostInfo.Text.Trim();
        tblPost.PostInfo = postInfo;
        tblPost.PostDate = DateTime.Now;
        tblPost.PostStatus = 1;
        tblPost.PostOwnerID = UserId;

        if (daoBlog == null)
        {
            daoBlog = new DAO_BlogPosts();
        }
        if (!daoBlog.InsertBlogPost(tblPost))
        {
            Response.Redirect("Error.aspx?error=Insert Blog Post Failed.");
        }
        else
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}