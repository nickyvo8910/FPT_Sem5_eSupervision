using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StaffCreateMeeting : System.Web.UI.Page
{
    public String userID, USER_TYPE;
    public int userType;
    private DAO_Meetings daoMeeting;
    private tblMeetings tblMeetings;
    private DAO_Students daoStudent;
    private tblStudents tbl_Student;
    private tblMeetingMembers tblMembers;
    private DAO_MeetingMembers daoMembers;
    public DataTable TblStudents;

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
        if (!Page.IsPostBack)
        {
            daoStudent = new DAO_Students();
            TblStudents = new DataTable();
            TblStudents = daoStudent.GetStuByStaffID(userID);
            fillStudentsList();
        }
        
    }
    public void fillStudentsList()
    {
        if (TblStudents != null)
        {
            foreach (DataRow dtRow in TblStudents.Rows)
            {
                my_multi_select3.Items.Add(new ListItem(dtRow[0].ToString() + ":" + dtRow[1].ToString(), dtRow[0].ToString()));
            }
        }
    }
    public void WriteEmptyLogChat(string filename)
    {
        string filepath = Server.MapPath("/Uploads/MeetingLogs/");
        TextWriter writer = new StreamWriter(@"" + filepath + filename, true);
        writer.WriteLine("--------------Chat Log--------------");
    }
    public void sendMeetingEmail(String Mail,string meetingID,string meetingHost, string meetingDate, string meetingPlace,string meetingTopic,string meetingType)
    {
        MailAddress to = new MailAddress(Mail);
        MailAddress from = new MailAddress("greenwichesupervisor94@gmail.com", "eSupervisor");
        MailMessage mail = new MailMessage(from, to);
        mail.Subject = "eSupervisor Meeting Notification";
        mail.Body = "Dear , " + Mail + ". \n" +
                    "This is the meeting info that you've recently involed: "
                    + "\nMeeting ID :" + meetingID
                    + "\nMeeting Type :" + meetingType
                    + "\nMeeting Date :" + meetingDate
                    + "\nMeeting Place :" + meetingPlace
                    + "\nMeeting Topic :" + meetingTopic
                    + "\nMeeting Host :" + meetingHost 
                    + "\n Your faithfully.";

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;

        smtp.Credentials = new System.Net.NetworkCredential("greenwichesupervisor94@gmail.com", "myproject");
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        string url = "";
        Boolean chkType = false;
        if (cbxOnline.Checked == true)
        {
            chkType = true;
        }
        string mTopic = txtTopic.Text.Trim();
        DateTime mDate = Convert.ToDateTime(txtDate.Text.Trim());
        string mPlace = "";
        if (placePnl.Visible == true)
        {
            mPlace = txtPlace.Text.Trim();
        }
        ArrayList arrSelectedStudent = new ArrayList();
        // GetSelectedIndices
        foreach (int i in my_multi_select3.GetSelectedIndices())
        {
            arrSelectedStudent.Add(my_multi_select3.Items[i].Text.Split(':')[0]);
        }
        //Insert tblMeetings
        daoMeeting = new DAO_Meetings();
        int crrID = Convert.ToInt32(daoMeeting.GetCrrMaxID().Rows[0][0].ToString())+1;
        tblMeetings = new tblMeetings();
        tblMeetings.MeetingTopic = mTopic;
        tblMeetings.MeetingDate = mDate;
        tblMeetings.MeetingPlace = mPlace;
        tblMeetings.MeetingType = chkType;
        if (chkType)
        {
            //Online meeting            
            //Create Logfile
            WriteEmptyLogChat(crrID+".txt");
            tblMeetings.MeetingLogFile = crrID + ".txt";
        }
        tblMeetings.MeetingHost = userID;
        tblMeetings.MeetingStatus = 1;
        if (daoMeeting.InsertMeeting(tblMeetings))
        {
            url = "StaffMeetings.aspx";
        }
        else
        {
            Response.Redirect("Error.aspx?error=Create New Meeting Failed");
        }
        //Insert tblMeetingMembers
        daoMembers = new DAO_MeetingMembers();
        for (int i = 0; i < arrSelectedStudent.Count; i++)
        {
            tblMembers = new tblMeetingMembers();
            tblMembers.MeetingID = crrID;
            tblMembers.MeetingMemberID = arrSelectedStudent[i].ToString();
            tblMembers.MemberStatus = 1;
            if (!daoMembers.InsertMeetingMember(tblMembers))
            {
                Response.Redirect("Error.aspx?error=Add New Meeting Member Failed");
            }
        }
        //Email Staff/Students
        DataTable tblStudentMail = new DataTable();
        tblStudentMail.Columns.Add("stuMail");
        daoStudent = new DAO_Students();
        string crrMail = "";
        for (int i = 0; i < arrSelectedStudent.Count; i++)
        {
            tbl_Student = new tblStudents();
            tbl_Student.StudentID = arrSelectedStudent[i].ToString();
            crrMail = daoStudent.GetStudentById(tbl_Student).Rows[0][4].ToString();
            
            tblStudentMail.Rows.Add(crrMail);
        }
        string mType ="";
        if(chkType){
            mType="Online";
        }else{
            mType="Offline";
        }
        foreach (DataRow dtRow in tblStudentMail.Rows)
        {
            sendMeetingEmail(dtRow[0].ToString(), "" + crrID, userID, mDate.ToShortDateString(), mPlace, mTopic, mType);
        }
        Response.Redirect(url);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}