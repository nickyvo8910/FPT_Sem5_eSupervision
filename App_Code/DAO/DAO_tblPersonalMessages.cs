using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_tblPersonalMessages
/// </summary>
public class DAO_tblPersonalMessages
{
    private DataAccess dataAccess;

	public DAO_tblPersonalMessages()
	{
		dataAccess = new DataAccess();
	}

    public DataTable getStaffConversations(string staffID)
    {
        String query =
            String.Format(
                @"select stuID,studentName,count(*) as 'Total Mess' from tblPersonalMessages inner join tblStudents on tblPersonalMessages.stuID = tblStudents.studentID where staffID = '{0}' 
                group by stuID,studentName",
                staffID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable getAllMessByStaffID(string staffID)
    {
        String query =
           String.Format(
               @"select stuID,studentName from tblPersonalMessages inner join tblStudents on tblPersonalMessages.stuID = tblStudents.studentID where staffID = '{0}'",
               staffID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable getAllMessConversationsByStuID(string stuId)
    {
        String query =
           String.Format(
               @"select tblPersonalMessages.staffID,staffName,count(*) as 'Total Mess' from tblPersonalMessages inner join tblStaffs on tblPersonalMessages.staffID = tblStaffs.staffID 
                where stuID = '{0}'
                GROUP BY tblPersonalMessages.staffID,staffName",
               stuId);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable getAllMessByStuID(string stuId)
    {
        String query =
           String.Format(
               @"select tblPersonalMessages.staffID,staffName from tblPersonalMessages inner join tblStaffs on tblPersonalMessages.staffID = tblStaffs.staffID 
                where stuID = '{0}'",
               stuId);
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable getStaffConversationDetails(string staffID, string stuID)
    {
        String query =
           String.Format(
               @"select messSentTime,messInfo from tblPersonalMessages where staffID ='{0}' and stuID ='{1}'
                order by messSentTime ",
               staffID,stuID);
        return dataAccess.ExecuteQuery(query);
    }

    public bool InsertMessage(tblPersonalMessages mess)
    {

        String query = string.Format(@"INSERT INTO tblPersonalMessages
                  ( staffID, stuID, messSentTime, messInfo, messStatus)
                   VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                  mess.StaffID, mess.StuID, mess.MessSentTime,
                  mess.MessInfo,
                  mess.MessStatus);
        if (dataAccess.ExecuteNonQuery(query))
            return true;

        return false;
    }

}