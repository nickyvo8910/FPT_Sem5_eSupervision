using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Meetings
/// </summary>
public class DAO_Meetings
{
    private DataAccess dataAccess;
	public DAO_Meetings()
	{
        dataAccess = new DataAccess();
	}

    public DataTable GetMeetingsByStaffID(string staffID)
    {
        string query = string.Format(@"SELECT  *
        FROM           tblMeetings
        WHERE            (meetingHost = '{0}') AND (meetingStatus = '{1}') OR
                         (meetingStatus = '{2}') order by meetingDate desc",staffID,1,2);
         return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetMeetingByID(int meetingID)
    {
        string query = string.Format(@"SELECT  *
        FROM           tblMeetings
        WHERE            (meetingID = '{0}')", meetingID);
        return dataAccess.ExecuteQuery(query);
    }
    public bool InsertMeeting(tblMeetings meetings)
    {
        
            String query = string.Format(@"INSERT INTO tblMeetings
                  ( meetingType, meetingDate, meetingPlace, meetingTopic, meetingHost, meetingLogFile,meetingStatus)
                   VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                      meetings.MeetingType, meetings.MeetingDate, meetings.MeetingPlace,
                      meetings.MeetingTopic, meetings.MeetingHost, meetings.MeetingLogFile,
                      meetings.MeetingStatus);
            if (dataAccess.ExecuteNonQuery(query))
            return true;
        
         return false;
    }
    public DataTable GetCrrMaxID()
    {
        string query = string.Format(@"SELECT  Max(meetingID)
        FROM           tblMeetings");        
        return dataAccess.ExecuteQuery(query);
    }  
    public DataTable GetMeetingLog(string ID)
    {
        String query = String.Format(@"SELECT meetingLogFile FROM tblMeetings WHERE meetingID='{0}'", ID);
        return dataAccess.ExecuteQuery(query);
    }
}