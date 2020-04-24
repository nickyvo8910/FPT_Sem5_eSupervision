using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentMyMeeting : System.Web.UI.Page
{

    public DAO_Meetings DaoMeetings;
    public DAO_MeetingMembers DaoMembers;
    public tblMeetings TblMeetings;
    public DAO_Staffs DaoStaff;
    public tblMeetingMembers TblMembers;
    public DAO_Students DaoStudents;
    public String UserId;
    public String USER_TYPE;
    public int UserType;
    public int MeetingId;
    public DataTable TblMeetingInfo;
    public DataTable TblMeetingMembers;
    private ChatRecord chatRec;

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
        if (Request.QueryString["meetingID"] != null)
        {
            MeetingId = Convert.ToInt32(Request.QueryString["meetingID"].ToString().Trim());

        }
        else
        {
            Response.Redirect("StudentMeetings.aspx");
        }
        DaoMeetings = new DAO_Meetings();
        DaoMembers = new DAO_MeetingMembers();
        TblMeetingInfo = new DataTable();
        TblMeetingMembers = new DataTable();
        //get that Meeting
        TblMeetings = new tblMeetings();
        DataRow dtRow = (DataRow)DaoMeetings.GetMeetingByID(MeetingId).Rows[0];
        TblMeetings.MeetingID = Convert.ToInt32(dtRow[0].ToString());
        TblMeetings.MeetingType = Convert.ToBoolean(dtRow[1].ToString());
        TblMeetings.MeetingDate = Convert.ToDateTime(dtRow[2].ToString().Trim());
        TblMeetings.MeetingPlace = dtRow[3].ToString();
        TblMeetings.MeetingTopic = dtRow[4].ToString();
        TblMeetings.MeetingHost = dtRow[5].ToString();
        TblMeetings.MeetingLogFile = dtRow[6].ToString();
        TblMeetings.MeetingStatus = Convert.ToInt32(dtRow[7].ToString());
        //get members list
        TblMeetingMembers = DaoMembers.GetMembersByMeetingId(MeetingId);
        DaoStudents = new DAO_Students();
        DaoStaff = new DAO_Staffs();
        //getMeetingLog
        GetMeetingMessages(MeetingId);
    }


    //get meeting log
    public DataTable GetMeetingMessages(int meetingID)
    {
        try
        {
            string filepath = Server.MapPath("/Uploads/MeetingLogs/");
            string filename = meetingID + ".txt";
            string[] lines = System.IO.File.ReadAllLines(@"" + filepath + filename);
            int count = lines.Length;
            TblMeetingInfo.Columns.Add("ChatDate");
            TblMeetingInfo.Columns.Add("ChatTime");
            TblMeetingInfo.Columns.Add("ChatInfo");
            foreach (string messStr in lines)
            {
                string[] chatParts = messStr.Split('|');
                chatRec = new ChatRecord();
                chatRec.Date = chatParts[0];
                chatRec.Time = chatParts[1];
                chatRec.Data = chatParts[2];
                TblMeetingInfo.Rows.Add(chatRec.Date, chatRec.Time, chatRec.Data);
            }

        }
        catch (Exception ex)
        {
            Response.Redirect(("Error.aspx?error=" + ex.Message + ex.StackTrace).Replace("\n", ""));
        }
        return TblMeetingInfo;
    }

    public void WriteLogChat(ChatRecord cRecord, int meetingID)
    {
        string filepath = Server.MapPath("/Uploads/MeetingLogs/");
        string filename = meetingID + ".txt";
        TextWriter writer = new StreamWriter(@"" + filepath + filename, true);
        writer.WriteLine(cRecord.Date + "|" + cRecord.Time + "|" + cRecord.Data);
        writer.Close();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string messInfo = txtMessInfo.Text.Trim();
        messInfo = UserId + " : " + messInfo;
        DateTime datetimeInfo = DateTime.Now;
        ChatRecord chatRec = new ChatRecord();
        chatRec.Date = datetimeInfo.ToShortDateString();
        chatRec.Time = datetimeInfo.ToShortTimeString();
        chatRec.Data = messInfo;
        WriteLogChat(chatRec, MeetingId);
        Response.Redirect(Request.RawUrl);
    }
}