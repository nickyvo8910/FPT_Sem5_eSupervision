using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for tblDocuments
/// </summary>
public class tblDocuments
{
    private int documentID;

    public int DocumentID
    {
        get { return documentID; }
        set { documentID = value; }
    }
    private string documentTitle;

    public string DocumentTitle
    {
        get { return documentTitle; }
        set { documentTitle = value; }
    }
    private DateTime documentDate;

    public DateTime DocumentDate
    {
        get { return documentDate; }
        set { documentDate = value; }
    }
    private string documentLink;

    public string DocumentLink
    {
        get { return documentLink; }
        set { documentLink = value; }
    }
    private string documentDes;

    public string DocumentDes
    {
        get { return documentDes; }
        set { documentDes = value; }
    }
    private string documentUploader;

    public string DocumentUploader
    {
        get { return documentUploader; }
        set { documentUploader = value; }
    }
    private int documentStatus;

    public int DocumentStatus
    {
        get { return documentStatus; }
        set { documentStatus = value; }
    }
}