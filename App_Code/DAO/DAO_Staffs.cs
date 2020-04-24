using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DAO_Staffs
/// </summary>
public class DAO_Staffs
{
    private DataAccess dataAccess;

    public DAO_Staffs()
    {
        dataAccess = new DataAccess();
    }

    public DataTable GetAllStaff()
    {
        string query = @"SELECT staffID, staffName, staffMailAddr, staffBirth, staffType, staffPhone, staffStatus,staffAvatar
                        FROM     tblStaffs";
        return dataAccess.ExecuteQuery(query);
    }

    public DataTable GetStaffById(tblStaffs staff)
    {
        String query = String.Format(@"SELECT staffID, staffName, staffType, staffBirth, staffMailAddr, staffPhone, staffAddr,staffAvatar
                                        FROM     tblStaffs
                                        WHERE  (staffID = '{0}')", staff.StaffID);
        return dataAccess.ExecuteQuery(query);
    }

    public bool UpdateStaff(tblStaffs staff)
    {
        String query = String.Format(@"UPDATE tblStaffs
                                        SET          staffName = '{0}', staffBirth = '{1}',
                                                     staffMailAddr = '{2}', staffPhone = '{3}', staffAddr = '{4}'
                                        WHERE  (staffID = '{5}')", staff.StaffName, staff.StaffBirth, staff.StaffMailAddr, staff.StaffPhone, staff.StaffAddr, staff.StaffID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool InsertStaff(tblStaffs staffs)
    {
        if (validateMail(staffs) && validateUserName(staffs))
        {
            String query = String.Format(@"INSERT INTO tblStaffs
                  (staffID, staffName, staffPass, staffMailAddr, staffAvatar, staffBirth, staffAddr, staffPhone, staffType, staffStatus)
                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                                         staffs.StaffID, staffs.StaffName, staffs.StaffPass, staffs.StaffMailAddr,
                                         staffs.StaffAvatar, staffs.StaffBirth,
                                         staffs.StaffAddr, staffs.StaffPhone, staffs.StaffType, staffs.StaffStatus);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        }
        return false;
    }

    private bool validateUserName(tblStaffs staffs)
    {
        String query = String.Format("select * from tblStaffs where staffID = '{0}'", staffs.StaffID);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
        {
            return false;
        }
        return true;
    }

    private bool validateMail(tblStaffs staffs)
    {
        String query = String.Format("select * from tblStaffs where staffMailAddr = '{0}'", staffs.StaffMailAddr);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
        {
            return false;
        }
        return true;
    }

    public bool UpdateStaffProfile(tblStaffs staffs)
    {
        String query = String.Format(@"UPDATE tblStaffs
                                        SET   staffName ='{0}', staffBirth ='{1}', staffMailAddr ='{2}', staffPhone ='{3}', staffAddr ='{4}'
                                        WHERE  (staffID = '{5}')",
                                     staffs.StaffName, staffs.StaffBirth, staffs.StaffMailAddr, staffs.StaffPhone,
                                     staffs.StaffAddr, staffs.StaffID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }

    public bool validateUserNamePassworld(tblStaffs staffs)
    {
        String query = String.Format("Select * from tblStaffs where staffID = '{0}' and staffPass = '{1}'",
                                     staffs.StaffID, staffs.StaffPass);
        if (dataAccess.ExecuteQuery(query).Rows.Count > 0)
            return true;
        return false;
    }

    public bool UpdatePassword(tblStaffs staffs)
    {
        String query = String.Format(@"UPDATE tblStaffs
                            SET          staffPass ='{0}'
                            WHERE  (staffID = '{1}')", staffs.StaffPass, staffs.StaffID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
    public bool UpdateAvatar(tblStaffs staffs)
    {
            String query = String.Format(@"UPDATE tblStaffs
                            SET          staffAvatar ='{0}'
                            WHERE  (staffID = '{1}')", staffs.StaffAvatar, staffs.StaffID);
            if (dataAccess.ExecuteNonQuery(query))
                return true;
        return false;
    }

    public bool UpdateStaffStatus(tblStaffs staffs)
    {
        String query = String.Format(@"UPDATE tblStaffs
                                        SET          staffStatus = '{0}'
                                        WHERE  (staffID = '{1}')",
                                     staffs.StaffStatus, staffs.StaffID);
        if (dataAccess.ExecuteNonQuery(query))
            return true;
        return false;
    }
    public String GetCrrMaxID()
    {
        string query = string.Format(@"SELECT  Max(staffID)
        FROM           tblStaffs");
        return dataAccess.ExecuteQuery(query).Rows[0][0].ToString();
    }
    public String GetStaffNameByID(string staffID)
    {
        string query = string.Format(@"SELECT  staffName
        FROM           tblStaffs
        WHERE   (staffID='{0}')",staffID);
        return dataAccess.ExecuteQuery(query).Rows[0][0].ToString();
    }
}