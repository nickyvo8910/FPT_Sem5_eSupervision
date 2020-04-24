using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblMeetingMembers
/// </summary>
public class tblMeetingMembers
{
    private int meetingID;

    public int MeetingID
    {
        get { return meetingID; }
        set { meetingID = value; }
    }
    private string meetingMemberID;

    public string MeetingMemberID
    {
        get { return meetingMemberID; }
        set { meetingMemberID = value; }
    }
    private int memberStatus;

    public int MemberStatus
    {
        get { return memberStatus; }
        set { memberStatus = value; }
    }
}