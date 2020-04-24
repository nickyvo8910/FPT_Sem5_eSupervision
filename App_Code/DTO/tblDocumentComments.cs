using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblDocumentComments
/// </summary>
public class tblDocumentComments
{
    private int commentID;

    public int CommentID
    {
        get { return commentID; }
        set { commentID = value; }
    }
    private DateTime commentDate;

    public DateTime CommentDate
    {
        get { return commentDate; }
        set { commentDate = value; }
    }
    private int commentDocID;

    public int CommentDocID
    {
        get { return commentDocID; }
        set { commentDocID = value; }
    }
    private string commentStaffID;

    public string CommentStaffID
    {
        get { return commentStaffID; }
        set { commentStaffID = value; }
    }
    private string commentInfo;

    public string CommentInfo
    {
        get { return commentInfo; }
        set { commentInfo = value; }
    }
    private int commentStatus;

    public int CommentStatus
    {
        get { return commentStatus; }
        set { commentStatus = value; }
    }
}