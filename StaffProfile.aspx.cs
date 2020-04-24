using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffProfile : System.Web.UI.Page
{
    DAO_Staffs daoStaff = new DAO_Staffs();
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
        crrStaff.StaffID =userID;
        DataRow dtRow =(DataRow) daoStaff.GetStaffById(crrStaff).Rows[0];
        crrStaff.StaffName = dtRow[1].ToString();
        //crrStaff.StaffType = dtRow[2].ToString();
        crrStaff.StaffBirth = Convert.ToDateTime(dtRow[3].ToString());
        crrStaff.StaffMailAddr = dtRow[4].ToString();
        crrStaff.StaffPhone = dtRow[5].ToString();
        crrStaff.StaffAddr = dtRow[6].ToString();
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
}