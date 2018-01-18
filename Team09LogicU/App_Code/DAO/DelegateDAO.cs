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
            //create delegate first
            d.staffID = newHeadId;
            d.startDate = startDate;
            d.endDate = endDate;
            context.Delegates.Add(d);
            //change the role of the employee to head
            staff.role = "delegateHead";
            context.SaveChanges();

        }
        //search for all delegates for this department(for viewing delegate history)
        public List<Models.Delegate> findDelegatesByDepartment(string departmentID)
        {
            string staffID = context.DeptStaffs.Where(x => x.deptID == departmentID).First().staffID;
            List<Models.Delegate> delegateList = context.Delegates.ToList<Models.Delegate>();
            return delegateList;
        }

        public bool isActiveDelegate(int delegateID)
        {
            Models.Delegate d = context.Delegates.Where(x => x.delegateID == delegateID).First();
            DateTime now = DateTime.Today;
            if (d.endDate >= now)
            { return true; }
            else
                return false;
        }

        //terminate delegate
        public void terminateDelegate(int delegateID)
        {
            Models.Delegate d = context.Delegates.Where(x => x.delegateID == delegateID).First();
            try
            {
                d.endDate = DateTime.Today;
                context.SaveChanges();
            }
            catch (InvalidOperationException)
            {

            }

        }
        
    }
}