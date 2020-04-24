using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_MeetingMembers
/// </summary>
public class DAO_MeetingMembers
{
    private DataAccess dataAccess;
	public DAO_MeetingMembers()
	{
	    dataAccess = new DataAccess();
	}
    public bool InsertMeetingMember(tblMeetingMembers meetingMembers)
    {

        String query = string.Format(@"INSERT INTO tblMeetingMembers
                  ( meetingID,meetingMemberID, memberStatus)
                   VALUES ('{0}', '{1}', '{2}')",
                  meetingMembers.MeetingID,meetingMembers.MeetingMemberID, meetingMembers.MemberStatus);
        if (dataAccess.ExecuteNonQuery(query))
            return true;

        return false;
    }

    public DataTable GetMembersByMeetingId(int meetingID)
    {
        String query = string.Format(@"SELECT * FROM tblMeetingMembers WHERE meetingID={0}", meetingID);
       return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetMeeetingsByMemberId(string memberID)
    {
        String query = string.Format(@"SELECT * FROM tblMeetingMembers WHERE meetingMemberID='{0}'", memberID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetMeeetingsByMemberIdForStu(string memberID)
    {
        String query = string.Format(@"SELECT tblMeetingMembers.meetingID,tblMeetings.meetingTopic,tblMeetings.meetingType,tblMeetings.meetingDate,tblMeetings.meetingPlace,tblMeetings.meetingStatus,tblMeetings.meetingHost FROM tblMeetingMembers join tblMeetings on tblMeetingMembers.meetingID = tblMeetings.meetingID WHERE meetingMemberID='{0}' and (tblMeetings.meetingStatus =1 or tblMeetings.meetingStatus=2)
order by meetingDate desc", memberID);
        return dataAccess.ExecuteQuery(query);
    }

}