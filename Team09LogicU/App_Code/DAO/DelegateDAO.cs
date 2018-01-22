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

        //add new delegate
        public void delegateToStaff(string newHeadId, DateTime startDate, DateTime endDate)
        {
            Models.Delegate d = new Models.Delegate();
            DeptStaff staff = context.DeptStaffs.Where(x => x.staffID == newHeadId).First();

            d.staffID = newHeadId;
            d.startDate = startDate;
            d.endDate = endDate;
            d.status = "active";
            context.Delegates.Add(d);
            context.SaveChanges();

        }
        //search for all delegates for this department(for viewing delegate history)
        public List<Models.Delegate> findDelegatesByDepartment(string departmentID)
        {
            List<Models.Delegate> delegateList = context.Delegates.Where(x => x.DeptStaff.deptID == departmentID).ToList();
            return delegateList;
        }

        //find delegate by ID
        public Models.Delegate findDelegationById(int id)
        {
            Models.Delegate d = new Models.Delegate();
            List<Models.Delegate> dlist = context.Delegates.Where(x => x.delegateID == id).ToList();
            if (dlist.Count() > 0)
            {
                d = dlist.First();
            }
            return d;
        }

        //update delegation status according to time
        public void updateStatusAndStaffRoleByDate(DateTime today)
        {
            List<Models.Delegate> dList = context.Delegates.ToList();
            foreach (Models.Delegate d in dList)
            {
                //when the delegation starts
                if (d.status == "active" && today >= d.startDate)
                {
                    d.status = "On delegation";
                    d.DeptStaff.role = "delegateHead";
                    string currentHeadID = d.DeptStaff.Department.headStaffID;
                    DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                    currendHead.role = "outOfOfficeHead";
                }
                //when the delegation comes to end
                else if (d.status == "On delegation" && today > d.endDate)
                {
                    d.status = "expired";
                    d.DeptStaff.role = "emp";

                    string currentHeadID = d.DeptStaff.Department.headStaffID;
                    DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                    currendHead.role = "head";
                }
            }
            context.SaveChanges();
        }

        //change delegation status when the head manipulates
        public void cancelDelegation(int delegateID)
        {
            String LoginID = (string)HttpContext.Current.Session["loginID"];
            Models.Delegate d = context.Delegates.Where(x => x.delegateID == delegateID).First();
            //terminate the delegation that has started
            if (d.status == "On delegation")
            {
                d.status = "terminated";
                d.DeptStaff.role = "emp";
                //string currentHeadID = d.DeptStaff.Department.headStaffID;
                //DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                //currendHead.role = "head";

                DeptStaff sdsd = context.DeptStaffs.Where(x => x.staffID == LoginID).First();
                sdsd.role = "head";
            }
            //cancel the delegation that has not started
            if (d.status == "active")
            {
                d.status = "cancelled";
            }
            context.SaveChanges();
        }
    }
}