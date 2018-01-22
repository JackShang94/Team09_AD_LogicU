using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DeptStaffDAO
    {
        //SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        //find a staff by ID
        public DeptStaff findStaffByID(string staffId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.staffID == staffId).ToList();
            DeptStaff staff = new DeptStaff();
            if(staffList.Count()>0)
            {
                staff = staffList.First();
            }
            return staff;
        }


        //find staff by name
        public DeptStaff findStaffByName(string staffName)
        {
            return context.DeptStaffs.Where(x => x.staffName == staffName).First();
        }

        //find staff by role
        public DeptStaff findStaffByRole(string role)
        {
            return context.DeptStaffs.Where(x => x.role == role).First();
        }

        //find all staff of specific department
        public List<DeptStaff> findStaffByDept(string deptId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.deptID == deptId).ToList();
            return staffList;

        }

        //find all staff whose roles are employee (not head && not rep)
        public List<DeptStaff> findOnlyEmployee(string deptId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.deptID == deptId
                                                                &&x.role=="emp").ToList();
            return staffList;
        }

        public List<DeptStaff> findEmployeeAndRep(string deptId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.deptID == deptId
                                                                && (x.role == "emp" || x.role == "rep")).ToList();
            return staffList;
        }

        //find the current rep of certain department
        public DeptStaff findDeptRep(string deptId)
        {
            DeptStaff staff = new DeptStaff();
            var s = context.DeptStaffs.Where(x => x.deptID == deptId && x.role == "rep").ToList();
            if (s.Count > 0)
            {
                staff = s.First();
            }
            return staff;
        }

        //update the rep of certain department
        public void updateRepName(DeptStaff newRep, DeptStaff oldRep )
        {
            newRep.role = "rep";
            oldRep.role = "emp";
            context.SaveChanges();
        }

        public string getRoleByStaffID(string staffID)
        {
            return context.DeptStaffs.Where(x => x.staffID == staffID).Select(y => y.role).ToList().First().ToString();
        }
    }
}