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
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
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
        //find all staff of specific department
        public List<DeptStaff> findStaffByDept(string deptId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.deptID == deptId).ToList();
            return staffList;

        }

        //find all staff whose roles are employee
        public List<DeptStaff> findOnlyEmployee(string deptId)
        {
            List<DeptStaff> staffList = context.DeptStaffs.Where(x => x.deptID == deptId
                                                                &&x.role!="head"&&x.role!="rep").ToList();
            return staffList;
        }
    }
}