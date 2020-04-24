using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerUpdateStaff : System.Web.UI.Page
{
    public String userID, USER_TYPE, staffID;
    public int userType;
    private DAO_Staffs daoStaff;
    private tblStaffs crrStaff;
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
        if (Request.QueryString["staffID"] != null)
        {
            staffID = Request.QueryString["staffID"].ToString();
        }
        crrStaff = new tblStaffs();
        daoStaff = new DAO_Staffs();
        if (!Page.IsPostBack)
        {        
        crrStaff.StaffID = staffID;
        DataRow dtRow = (DataRow)daoStaff.GetStaffById(crrStaff).Rows[0];
        crrStaff.StaffName = dtRow[1].ToString();
        crrStaff.StaffBirth = Convert.ToDateTime(dtRow[3].ToString());
        crrStaff.StaffMailAddr = dtRow[4].ToString();
        crrStaff.StaffPhone = dtRow[5].ToString();
        crrStaff.StaffAddr = dtRow[6].ToString();

        // fill Data
        
            txtID.Text = crrStaff.StaffID;
            hidID.Value = crrStaff.StaffID;
            txtName.Text = crrStaff.StaffName;
            txtBirthday.Text = crrStaff.StaffBirth.ToShortDateString();
            txtEmail.Text = crrStaff.StaffMailAddr;
            txtMobile.Text = crrStaff.StaffPhone;
            txtAddress.Text = crrStaff.StaffAddr;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string crrID = hidID.Value;
            string crrName = txtName.Text.Trim();
            DateTime crrBirth = Convert.ToDateTime(txtBirthday.Text.Trim());
            string crrMail = txtEmail.Text.Trim();
            string crrPhone = txtMobile.Text.Trim();
            string crrAddr = txtAddress.Text.Trim();

            crrStaff = new tblStaffs();
            crrStaff.StaffID = crrID;
            crrStaff.StaffName = crrName;

            crrStaff.StaffBirth = crrBirth;
            crrStaff.StaffMailAddr = crrMail;
            crrStaff.StaffPhone = crrPhone;
            crrStaff.StaffAddr = crrAddr;

            if (!daoStaff.UpdateStaff(crrStaff))
            {
                Response.Redirect("Error.aspx?error=Update Staff Info Failed");
            }
            else
            {
                Response.Redirect("ManagingStaff.aspx", false);
            }
        }
        catch (Exception ex)
        {

            Response.Redirect("Error.aspx?error=" + ex.Message + ex.StackTrace.Replace("\n", ""));
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManagingStaff.aspx");
    }
}