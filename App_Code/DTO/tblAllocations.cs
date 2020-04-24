using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblAllocations
/// </summary>
public class tblAllocations
{
    private int eventID;

    public int EventID
    {
        get { return eventID; }
        set { eventID = value; }
    }
    private string eventCreatorID;

    public string EventCreatorID
    {
        get { return eventCreatorID; }
        set { eventCreatorID = value; }
    }
    private string eventAffectedStaffID;

    public string EventAffectedStaffID
    {
        get { return eventAffectedStaffID; }
        set { eventAffectedStaffID = value; }
    }
    private string eventAffectedStudentID;

    public string EventAffectedStudentID
    {
        get { return eventAffectedStudentID; }
        set { eventAffectedStudentID = value; }
    }
    private string eventType;

    public string EventType
    {
        get { return eventType; }
        set { eventType = value; }
    }
    private DateTime eventDate;

    public DateTime EventDate
    {
        get { return eventDate; }
        set { eventDate = value; }
    }
    private string eventInfo;

    public string EventInfo
    {
        get { return eventInfo; }
        set { eventInfo = value; }
    }
    private int eventStatus;

    public int EventStatus
    {
        get { return eventStatus; }
        set { eventStatus = value; }
    }
}