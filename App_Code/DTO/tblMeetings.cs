using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblMeetings
/// </summary>
public class tblMeetings
{
    private int meetingID;

    public int MeetingID
    {
        get { return meetingID; }
        set { meetingID = value; }
    }
    private Boolean meetingType;

    public Boolean MeetingType
    {
        get { return meetingType; }
        set { meetingType = value; }
    }
    private DateTime meetingDate;

    public DateTime MeetingDate
    {
        get { return meetingDate; }
        set { meetingDate = value; }
    }
    private string meetingPlace;

    public string MeetingPlace
    {
        get { return meetingPlace; }
        set { meetingPlace = value; }
    }
    private string meetingTopic;

    public string MeetingTopic
    {
        get { return meetingTopic; }
        set { meetingTopic = value; }
    }
    private string meetingHost;

    public string MeetingHost
    {
        get { return meetingHost; }
        set { meetingHost = value; }
    }
    private string meetingLogFile;

    public string MeetingLogFile
    {
        get { return meetingLogFile; }
        set { meetingLogFile = value; }
    }
    private int meetingStatus;

    public int MeetingStatus
    {
        get { return meetingStatus; }
        set { meetingStatus = value; }
    }
}