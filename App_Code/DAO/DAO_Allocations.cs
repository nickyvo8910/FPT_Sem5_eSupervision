using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Allocations
/// </summary>
public class DAO_Allocations
{
    private DataAccess dataAccess;

    public DAO_Allocations()
    {
        dataAccess = new DataAccess();
    }

    public DataTable GetAllAllocations()
    {
        string query =
            @"SELECT tblAllocations.eventID, tblStaffs.staffID, tblStaffs.staffName, tblStudents.studentID, tblStudents.studentName, tblAllocations.eventType, tblAllocations.eventDate, 
                  tblAllocations.eventInfo, tblAllocations.eventStatus
                    FROM     tblAllocations INNER JOIN
                  tblStaffs ON tblAllocations.eventAffectedStaffID = tblStaffs.staffID AND tblAllocations.eventCreatorID = tblStaffs.staffID INNER JOIN
                  tblStudents ON tblAllocations.eventAffectedStudentID = tblStudents.studentID AND tblStaffs.staffID = tblStudents.studentSupervisorID AND 
                  tblStaffs.staffID = tblStudents.studentSecondMarkerID";
        return dataAccess.ExecuteQuery(query);
    }

    private bool validateEventId(tblAllocations allocations)
    {
        String query = String.Format(@"SELECT *
                                        FROM     tblAllocations
                                        WHERE eventID = '{0}'",
                                     allocations.EventID);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return false;
        return true;
    }


    public bool InsertAllocations(tblAllocations allocations)
    {
        if(validateEventId(allocations))
        {
            String query = String.Format(@"INSERT INTO tblAllocations
                  (eventID, eventCreatorID, eventAffectedStaffID, eventAffectedStudentID, eventType, eventDate, eventInfo, eventStatus)
                  VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                                     allocations.EventID, allocations.EventCreatorID, allocations.EventAffectedStaffID,
                                     allocations.EventAffectedStudentID,
                                     allocations.EventType, allocations.EventDate, allocations.EventInfo,
                                     allocations.EventStatus);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        }
        return false;
    }

    public bool UpdateAllocations(tblAllocations allocations)
    {
        String query = String.Format(@"UPDATE tblAllocations
                                    SET          eventAffectedStudentID ='{0}', eventType ='{1}', eventDate ='{2}', eventInfo ='{3}', eventStatus = {4},eventAffectedStaffID ='{5}'
                                    WHERE  (WHERE  (eventCreatorID = '{6}'))",
                                     allocations.EventAffectedStudentID, allocations.EventType, allocations.EventDate,
                                     allocations.EventInfo, allocations.EventStatus, allocations.EventAffectedStaffID,
                                     allocations.EventCreatorID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
}