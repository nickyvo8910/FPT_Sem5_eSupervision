using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblStudents
/// </summary>
public class tblStudents
{
    private string studentID;

    public string StudentID
    {
        get { return studentID; }
        set { studentID = value; }
    }
    private string studentName;

    public string StudentName
    {
        get { return studentName; }
        set { studentName = value; }
    }
    private string studentPass;

    public string StudentPass
    {
        get { return studentPass; }
        set { studentPass = value; }
    }

    private string studentPassNew;

    public string StudentPassNew
    {
        get { return studentPassNew; }
        set { studentPassNew = value; }
    }
    private string studentMailAddr;

    public string StudentMailAddr
    {
        get { return studentMailAddr; }
        set { studentMailAddr = value; }
    }
    private string studentAcademicYear;

    public string StudentAcademicYear
    {
        get { return studentAcademicYear; }
        set { studentAcademicYear = value; }
    }
    private string studentAvatar;

    public string StudentAvatar
    {
        get { return studentAvatar; }
        set { studentAvatar = value; }
    }
    private DateTime studentBirth;

    public DateTime StudentBirth
    {
        get { return studentBirth; }
        set { studentBirth = value; }
    }
    private string studentAddr;

    public string StudentAddr
    {
        get { return studentAddr; }
        set { studentAddr = value; }
    }
    private string studentPhone;

    public string StudentPhone
    {
        get { return studentPhone; }
        set { studentPhone = value; }
    }
    private string studentSupervisorID;

    public string StudentSupervisorID
    {
        get { return studentSupervisorID; }
        set { studentSupervisorID = value; }
    }
    private string studentSecondMarkerID;

    public string StudentSecondMarkerID
    {
        get { return studentSecondMarkerID; }
        set { studentSecondMarkerID = value; }
    }
    private DateTime studentLastLogin;

    public DateTime StudentLastLogin
    {
        get { return studentLastLogin; }
        set { studentLastLogin = value; }
    }
    private int studentStatus;

    public int StudentStatus
    {
        get { return studentStatus; }
        set { studentStatus = value; }
    }
}