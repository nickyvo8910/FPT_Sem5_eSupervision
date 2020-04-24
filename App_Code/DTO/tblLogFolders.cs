using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblLogFolders
/// </summary>
public class tblLogFolders
{
    private string meetingLogFolder;

    public string MeetingLogFolder
    {
        get { return meetingLogFolder; }
        set { meetingLogFolder = value; }
    }
    private string avatarFolder;

    public string AvatarFolder
    {
        get { return avatarFolder; }
        set { avatarFolder = value; }
    }
    private string documentFolder;

    public string DocumentFolder
    {
        get { return documentFolder; }
        set { documentFolder = value; }
    }
}