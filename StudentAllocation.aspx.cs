using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentAllocation : System.Web.UI.Page
{
    private DAO_Students daoStudent;
    private tblStudents DTOStudent;
    public DataTable tblAllStudents, tblAcaYears;
    private string staffID;
    private string action;
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
        daoStudent = new DAO_Students();
        try
        {
            if (!Page.IsPostBack)
            {
                tblAcaYears = daoStudent.GetAllAcademicYear();
                dropYear.DataValueField = "studentAcademicYear";
                dropYear.DataTextField = "studentAcademicYear";
                dropYear.DataSource = tblAcaYears;
                DataBind();
            }
            string acaYear = dropYear.SelectedValue.ToString();
            tblAllStudents = daoStudent.GetAllStudentByAcademicYear(acaYear);
            GetData();
        }
        catch (Exception ex)
        {
            Response.Redirect("Error.aspx?error=" + ex.Message.Replace("\n", "") + ex.StackTrace.Replace("\n", ""));
        }
        if (Request.QueryString["action"] != null && Request.QueryString["staffID"] != null)
        {
            action = Request.QueryString["action"].ToString();
            staffID = Request.QueryString["staffID"].ToString();
        }
        
    }

    protected void updateCheckedItems()
    {
        //new list
        List<string> list = new List<string>();
        if (ViewState["SelectedRecords"] != null)
        {
            //get pre selected items
            list = (List<string>)ViewState["SelectedRecords"];
        }
        foreach (GridViewRow row in GridView1.Rows)
        {
            //locate chkbox
            CheckBox chk = (CheckBox)row.FindControl("chkSelect");
            //get datakey of the row
            var selectedKey = GridView1.DataKeys[row.RowIndex].Value.ToString();
            if (chk.Checked)
            {
                if (!list.Contains(selectedKey))
                {
                    list.Add(selectedKey);
                }
            }
            else
            {
                if (list.Contains(selectedKey))
                {
                    list.Remove(selectedKey);
                }
            }
        }
        ViewState["SelectedRecords"] = list;
    }
    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        updateCheckedItems();
        GridView1.PageIndex = e.NewPageIndex;
        this.GetData();
    }

    /// <summary> 
    /// Gets the data. 
    /// </summary> 
    private void GetData()
    {
        GridView1.DataSource = tblAllStudents;
        GridView1.DataBind();
    }

    /// <summary> 
    /// Gets the selected records. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <see cref="System.EventArgs"/>
    ///    instance containing the event data.</param> 
    protected void GetSelectedRecords(object sender, EventArgs e)
    {
        //Response.Write("<h3>Selected records</h3>");
        List<string> list = ViewState["SelectedRecords"] as List<string>;
        
        if (list != null)
        {
            DTOStudent = new tblStudents();
            int count = 0;
            foreach (string id in list)
            {
                //Response.Write(id + "<br />");
                DTOStudent.StudentID = id;
                DataTable crrStu = new DataTable();
                crrStu = daoStudent.GetStudentById(DTOStudent); try
                {
                    if (action.Equals("setSuper"))
                    {
                        DTOStudent.StudentSupervisorID = staffID;
                        if (daoStudent.Update_Super(DTOStudent))
                            count++;
                    }
                    else if (action.Equals("setSecond"))
                    {
                        DTOStudent.StudentSecondMarkerID = staffID;
                        if (daoStudent.Update_Second(DTOStudent))
                            count++;
                    }


                }
                catch (Exception ex)
                {

                    Response.Redirect("Error.aspx?error=" + ex.Message.Replace("\n", "") + ex.StackTrace.Replace("\n", ""));
                }
            }            
                string message = "<script language=javascript>alert('"+(count)+" Row(s) has been successfully updated.\\n Please refresh this page to see the changes.');</script>";
                Page.RegisterStartupScript("script", message);
                
        }
    }

    /// <summary> 
    /// Looks for selection. 
    /// </summary> 
    /// <param name="sender">The sender.</param> 
    /// <param name="e">The <seecref="System.Web.UI.WebControls.GridViewRowEventArgs"/>
    ///     instance containing the event data.</param> 
    protected void ReSelectSelectedRecords(object sender, GridViewRowEventArgs e)
    {
        List<string> list = ViewState["SelectedRecords"] as List<string>;
        if (e.Row.RowType == DataControlRowType.DataRow && list != null)
        {
            var stuID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            if (list.Contains(stuID))
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkSelect");
                chk.Checked = true;
            }
        }
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        updateCheckedItems();
    }
    protected void dropYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}