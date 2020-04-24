using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblBlogPosts
/// </summary>
public class tblBlogPosts
{
    private int postID;

    public int PostID
    {
        get { return postID; }
        set { postID = value; }
    }
    private string postOwnerID;

    public string PostOwnerID
    {
        get { return postOwnerID; }
        set { postOwnerID = value; }
    }
    private DateTime postDate;

    public DateTime PostDate
    {
        get { return postDate; }
        set { postDate = value; }
    }
    private string postInfo;

    public string PostInfo
    {
        get { return postInfo; }
        set { postInfo = value; }
    }
    private int postStatus;

    public int PostStatus
    {
        get { return postStatus; }
        set { postStatus = value; }
    }
}