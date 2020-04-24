using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblStaffs
/// </summary>
public class tblStaffs
{
    private string staffID;

    public string StaffID
    {
        get { return staffID; }
        set { staffID = value; }
    }
    private string staffName;

    public string StaffName
    {
        get { return staffName; }
        set { staffName = value; }
    }
    private string staffPassNew;

    private string staffPass;

    public string StaffPass
    {
        get { return staffPass; }
        set { staffPass = value; }
    }
    private string staffMailAddr;

    public string StaffMailAddr
    {
        get { return staffMailAddr; }
        set { staffMailAddr = value; }
    }
    private string staffAvatar;

    public string StaffAvatar
    {
        get { return staffAvatar; }
        set { staffAvatar = value; }
    }
    private DateTime staffBirth;

    public DateTime StaffBirth
    {
        get { return staffBirth; }
        set { staffBirth = value; }
    }
    private string staffAddr;

    public string StaffAddr
    {
        get { return staffAddr; }
        set { staffAddr = value; }
    }
    private string staffPhone;

    public string StaffPhone
    {
        get { return staffPhone; }
        set { staffPhone = value; }
    }
    private int staffType;

    public int StaffType
    {
        get { return staffType; }
        set { staffType = value; }
    }
    private int staffStatus;

    public int StaffStatus
    {
        get { return staffStatus; }
        set { staffStatus = value; }
    }

    public string StaffPassNew
    {
        get { return staffPassNew; }
        set { staffPassNew = value; }
    }
}