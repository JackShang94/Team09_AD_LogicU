using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DelegateDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        //disable the authority of the absent head 
        public void disableHead(string headId)
        {
            DeptStaff head = context.DeptStaffs.Where(x => x.staffID == headId).First();
            head.role = "outOfOfficeHead";
            context.SaveChanges();
        }

        //new delegate
        public void delegateToStaff(string newHeadId, DateTime startDate, DateTime endDate)
        {
            Models.Delegate d = new Models.Delegate();
            DeptStaff staff = context.DeptStaffs.Where(x => x.staffID == newHeadId).First();
            //1.create delegate 
            d.staffID = newHeadId;
            d.startDate = startDate;
            d.endDate = endDate;
            context.Delegates.Add(d);

            //2.change the role of the employee to head
            staff.role = "delegateHead";
            context.SaveChanges();


        }
        //search for all delegates for this department(for viewing delegate history)
        public List<Models.Delegate> findDelegatesByDepartment(string departmentID)
        {
            List<Models.Delegate> delegateList = context.Delegates.Where(x => x.DeptStaff.deptID == departmentID).ToList();
            return delegateList;
        }

        public bool isActiveDelegate(int delegateID)
        {
            Models.Delegate d = context.Delegates.Where(x => x.delegateID == delegateID).First();
            DateTime now = DateTime.Today;
            if (d.endDate >now)
            { return true; }
            else
                return false;
        }

        //terminate delegate
        public void terminateDelegate(int delegateID)
        {
            //1.change the endDate
            Models.Delegate d = context.Delegates.Where(x => x.delegateID == delegateID).First();
            d.endDate = DateTime.Today;

            //2.change the role back("delegateHead" back to"emp","outOfOfficeHead" back to "head")
            d.DeptStaff.role = "emp";
            string hId = d.DeptStaff.Department.headStaffID;
            DeptStaff head = context.DeptStaffs.Where(x => x.staffID == hId).First();
            head.role = "head";
            context.SaveChanges();
        }

    }
}