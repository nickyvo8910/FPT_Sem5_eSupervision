using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblPersonalMessages
/// </summary>
public class tblPersonalMessages
{
    private string staffID;

    public string StaffID
    {
        get { return staffID; }
        set { staffID = value; }
    }
    private string stuID;

    public string StuID
    {
        get { return stuID; }
        set { stuID = value; }
    }
    private DateTime messSentTime;

    public DateTime MessSentTime
    {
        get { return messSentTime; }
        set { messSentTime = value; }
    }
    private string messInfo;

    public string MessInfo
    {
        get { return messInfo; }
        set { messInfo = value; }
    }
    private int messStatus;

    public int MessStatus
    {
        get { return messStatus; }
        set { messStatus = value; }
    }
}