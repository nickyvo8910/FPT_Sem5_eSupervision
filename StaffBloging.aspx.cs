using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffBloging : System.Web.UI.Page
{
    public String UserId;
    public String USER_TYPE;
    public int UserType;

    private DAO_BlogPosts daoBlog;
    private DAO_Staffs daoStaff;
    public DataTable TblAllPost;
    private tblBlogPosts tblPost;
    public tblStaffs TblCrrStaff;


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

        daoStaff = new DAO_Staffs();
        TblCrrStaff = new tblStaffs();
        TblCrrStaff.StaffID = UserId;
        DataRow crrStaff = (DataRow)daoStaff.GetStaffById(TblCrrStaff).Rows[0];
        TblCrrStaff.StaffAvatar = crrStaff[7].ToString();
        TblCrrStaff.StaffName = crrStaff[1].ToString();
        TblCrrStaff.StaffMailAddr = crrStaff[4].ToString();

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
                    Response.Redirect("StaffBloging.aspx");
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
    }
}