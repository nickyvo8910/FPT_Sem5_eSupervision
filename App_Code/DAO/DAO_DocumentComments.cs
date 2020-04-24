using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_DocumentComments
/// </summary>
public class DAO_DocumentComments
{
    private DataAccess dataAccess;

	public DAO_DocumentComments()
	{
        dataAccess = new DataAccess();
	}

    public DataTable GetAllDocumentComments()
    {
        string query =
            @"SELECT tblDocumentComments.commentID, tblStaffs.staffName, tblDocuments.documentTitle, tblDocumentComments.commentInfo, tblDocumentComments.commentStatus
                    FROM     tblDocumentComments INNER JOIN
                  tblStaffs ON tblDocumentComments.commentStaffID = tblStaffs.staffID INNER JOIN
                  tblDocuments ON tblDocumentComments.commentDocID = tblDocuments.documentID";
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable GetDocumentCommentsByStaffId(tblStaffs staffs)
    {
        String query =
            String.Format(@"SELECT tblDocumentComments.commentID, tblStaffs.staffName, tblDocuments.documentTitle, tblDocumentComments.commentInfo, tblDocumentComments.commentStatus
                        FROM     tblDocumentComments INNER JOIN
                  tblStaffs ON tblDocumentComments.commentStaffID = tblStaffs.staffID INNER JOIN
                  tblDocuments ON tblDocumentComments.commentDocID = tblDocuments.documentID
                        WHERE  (tblStaffs.staffID = '{0}')", staffs.StaffID);
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable GetDocumentCommentsByComment(tblStaffs staffs, tblDocumentComment documentComment)
    {
        String query =
            String.Format(
                @"SELECT tblDocumentComments.commentID, tblStaffs.staffName, tblDocuments.documentTitle, tblDocumentComments.commentInfo, tblDocumentComments.commentStatus
                        FROM     tblDocumentComments INNER JOIN
                  tblStaffs ON tblDocumentComments.commentStaffID = tblStaffs.staffID INNER JOIN
                  tblDocuments ON tblDocumentComments.commentDocID = tblDocuments.documentID
                    WHERE  (tblDocumentComments.commentInfo LIKE '{0}') AND (tblStaffs.staffID = '{1}')",
                documentComment.commentInfo, staffs.StaffID);
        return dataAccess.ExecuteQuery(query);
    }

    public bool InsertDocumentComments(tblDocumentComments documentComments)
    {
        String query = String.Format(@"INSERT INTO tblDocumentComments
                  (commentDate, commentDocID, commentStaffID, commentInfo, commentStatus)
                    VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                                     documentComments.CommentDate, documentComments.CommentDocID,
                                     documentComments.CommentStaffID, documentComments.CommentInfo,
                                     documentComments.CommentStatus);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
}