using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DAO_Documents
/// </summary>
public class DAO_Documents
{
    private DataAccess dataAccess;

	public DAO_Documents()
	{
        dataAccess = new DataAccess();
	}

    public DataTable GetUserUpload(string uploader, string topic)
    {
        String query =
            String.Format(
                @"select tblDocuments.documentID,tblDocuments.documentTitle,tblDocuments.documentDate,tblDocuments.documentLink,tblStudents.studentName,tblStaffs.staffName from tblStaffs right join tblDocuments on tblStaffs.staffID = tblDocuments.documentUploader left join tblStudents on tblDocuments.documentUploader = tblStudents.studentID
                                    where tblDocuments.documentUploader='{0}' and tblDocuments.documentTitle like '%'+'{1}'+'%' and documentStatus = 1
                                    order by tblDocuments.documentDate desc",uploader,topic);
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable GetAllDocumentOfStaffByStudent(tblStaffs staffs, tblStudents students)
    {
        String query =
            String.Format(@"select tblStudents.studentID,tblStudents.studentName,tblDocuments.documentID,tblDocuments.documentTitle,tblDocuments.documentDate,tblDocuments.documentLink from tblDocuments left join tblStudents on tblDocuments.documentUploader = tblStudents.studentID
                                        where (tblStudents.studentSupervisorID = '{0}' or tblStudents.studentSecondMarkerID ='{1}') and tblStudents.studentName like '%'+'{2}'+'%' and documentStatus = 1
                                        order by tblDocuments.documentDate desc",
                          staffs.StaffID, staffs.StaffID, students.StudentID);
        return dataAccess.ExecuteQuery(query);
    }

    public bool InsertDocument(tblDocuments documents)
    {
        String query = String.Format(@"INSERT INTO tblDocuments
                  (documentTitle, documentDate, documentLink, documentDes, documentUploader, documentStatus)
                VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5})",
                                     documents.DocumentTitle, documents.DocumentDate, documents.DocumentLink,
                                     documents.DocumentDes, documents.DocumentUploader, documents.DocumentStatus);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool UpdateStatusDocument(tblDocuments documents)
    {
        String query = String.Format(@"UPDATE tblDocuments
                        SET          documentStatus ='{0}'
                                    WHERE  (documentID = {1})",
                                     documents.DocumentStatus, documents.DocumentID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
}