using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DAO_Students
/// </summary>
public class DAO_Students
{
	
    private DataAccess dataAccess;
    //private tblStudents student;
    public DAO_Students()
    {
        dataAccess = new DataAccess();
    }
    public bool UpdateProfile(tblStudents student)
    {
        String query = String.Format(@"UPDATE tblStudents
                                        SET          studentName ='{0}', studentBirth = '{1}', studentMailAddr = '{2}', 
                                                    studentPhone = '{3}', studentAddr = '{4}'
                                        WHERE  studentID = '{5}'",student.StudentName, student.StudentBirth, student.StudentMailAddr, student.StudentPhone,student.StudentAddr, student.StudentID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool CheckAccountExist(tblStudents student)
    {
        String query = String.Format(@"SELECT studentID, studentPass
                                        FROM     tblStudents
                                        WHERE  (studentID = '{0}') AND (studentPass = '{1}')", student.StudentID, student.StudentPass);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return true;
        return false;
    }

    public bool Update_Password(tblStudents student)
    {
        
            String query = String.Format(@"UPDATE tblStudents
                                            SET          studentPass = '{0}'
                                            WHERE  (studentID = '{1}')", student.StudentPass, student.StudentID);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        return false;
    }
    public bool Update_Avatar(tblStudents student)
    {
            String query = String.Format(@"UPDATE tblStudents
                                            SET          studentAvatar = '{0}'
                                            WHERE  (studentID = '{1}')", student.StudentAvatar, student.StudentID);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        return false;
    }
    public bool Update_Super(tblStudents student)
    {

        String query = String.Format(@"UPDATE tblStudents
                                            SET          studentSupervisorID = '{0}'
                                            WHERE  (studentID = '{1}')", student.StudentSupervisorID, student.StudentID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;

        return false;
    }
    public bool Update_Second(tblStudents student)
    {

        String query = String.Format(@"UPDATE tblStudents
                                            SET         studentSecondMarkerID = '{0}'
                                            WHERE  (studentID = '{1}')", student.StudentSecondMarkerID, student.StudentID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;

        return false;
    }

    private bool validateUserName(tblStudents students)
    {
        String query = String.Format("select * from tblStudents where studentID = '{0}'", students.StudentID);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return false;
        return true;
    }

    private bool validateUserMail(tblStudents students)
    {
        String query = String.Format("select * from tblStudents where studentMailAddr = '{0}'", students.StudentMailAddr);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return false;
        return true;
    }
    public bool validateUserNamePassworld(tblStudents stu)
    {
        String query = String.Format("Select * from tblStudents where studentID = '{0}' and studentPass = '{1}'",
                                     stu.StudentID, stu.StudentPass);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return true;
        return false;
    }

    public bool InsertStudent(tblStudents students)
    {
        if(validateUserMail(students) && validateUserName(students))
        {
            String query = String.Format(@"INSERT INTO tblStudents
                  (studentID, studentName, studentAcademicYear, studentBirth, studentMailAddr, studentPhone, studentAddr,studentStatus,studentPass,studentAvatar)
                   VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}')",
                                         students.StudentID, students.StudentName, students.StudentAcademicYear,
                                         students.StudentBirth, students.StudentMailAddr, students.StudentPhone,
                                         students.StudentAddr,students.StudentStatus,students.StudentPass,students.StudentAvatar);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        }
        return false;
    }

    public DataTable GetAllStudent()
    {
        string query =
            @"SELECT studentID, studentName, studentMailAddr,studentAcademicYear, studentBirth, studentAddr,studentPhone,studentSupervisorID,studentSecondMarkerID,studentLastLogin,  studentStatus
        FROM tblStudents";
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetAllStudentByAcademicYear(string acaYear)
    {
        string query =
           String.Format(@"SELECT studentID, studentName, studentMailAddr,studentAcademicYear, studentBirth, studentAddr,studentPhone,studentSupervisorID,studentSecondMarkerID,studentLastLogin,  studentStatus
        FROM tblStudents 
        WHERE (studentAcademicYear ='{0}')",acaYear);
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable GetStudentById(tblStudents students)
    {
        String query =
            String.Format(@"SELECT studentID, studentName, studentAcademicYear, studentBirth, studentMailAddr, studentPhone, studentAddr,studentSupervisorID,studentSecondMarkerID,studentAvatar
                            FROM     tblStudents
                            WHERE  (studentID = '{0}')", students.StudentID);
        return dataAccess.ExecuteQuery(query);
    }
    public String GetStudentNameById(string studentID)
    {
        String query =
            String.Format(@"SELECT  studentName
                            FROM     tblStudents
                            WHERE  (studentID = '{0}')", studentID);
        return dataAccess.ExecuteQuery(query).Rows[0][0].ToString();
    }

    public bool UpdateInfoStudent(tblStudents students)
    {
        String query = String.Format(@"UPDATE tblStudents
                                    SET studentName ='{0}', studentAcademicYear ='{1}', studentBirth ='{2}', 
                                        studentMailAddr ='{3}', studentPhone ='{4}', studentAddr ='{5}'
                                    WHERE  (studentID = '{6}')",
                                     students.StudentName, students.StudentAcademicYear, students.StudentBirth,
                                     students.StudentMailAddr, students.StudentPhone, students.StudentAddr,
                                     students.StudentID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool UpdateStudentStatus(tblStudents students)
    {
        String query = String.Format(@"UPDATE tblStudents
                                        SET          studentStatus = {0}
                                        WHERE  (studentID = '{1}')",students.StudentStatus, students.StudentID);
        if(dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
    public DataTable GetStuByStaffID(string ID)
    {
        String query =
            String.Format(@"SELECT studentID, studentName, studentAcademicYear, studentBirth, studentMailAddr, studentPhone, studentAddr,studentSupervisorID,studentSecondMarkerID
            FROM         tblStudents
            WHERE        (studentSupervisorID = '{0}') OR (studentSecondMarkerID = '{1}')", ID,ID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetStuSuperByStaffID(string ID)
    {
        String query =
            String.Format(@"SELECT studentID, studentName, studentAcademicYear, studentBirth, studentMailAddr, studentPhone, studentAddr,studentSupervisorID,studentSecondMarkerID
            FROM         tblStudents
            WHERE        (studentSupervisorID = '{0}')", ID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetStuSecondByStaffID(string ID)
    {
        String query =
            String.Format(@"SELECT studentID, studentName, studentAcademicYear, studentBirth, studentMailAddr, studentPhone, studentAddr,studentSupervisorID,studentSecondMarkerID
            FROM         tblStudents
            WHERE         (studentSecondMarkerID = '{0}')", ID);
        return dataAccess.ExecuteQuery(query);
    }
    public DataTable GetAllAcademicYear()
    {
        String query =
            String.Format(@"SELECT studentAcademicYear
            FROM         tblStudents
            GROUP BY      studentAcademicYear
            ORDER BY        studentAcademicYear DESC                             ");
        return dataAccess.ExecuteQuery(query);
    }
    public String GetCrrMaxID()
    {
        string query = string.Format(@"SELECT  Max(studentID)
        FROM           tblStudents");
        return dataAccess.ExecuteQuery(query).Rows[0][0].ToString();
    }
    public DateTime GetStuLastLogin(string stuID)
    {
        String query =
            String.Format(@"SELECT studentLastLogin
            FROM         tblStudents
            WHERE         (studentID = '{0}')", stuID);
        return Convert.ToDateTime(dataAccess.ExecuteQuery(query).Rows[0][0].ToString());
    }
}