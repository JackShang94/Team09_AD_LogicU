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

        public void terminateDelegate(Models.Delegate delegateItem)
        {
            if (delegateItem.status == "active")
            {
                delegateItem.status = "cancelled";
            }
            else
            {
                delegateItem.status = "terminated";

                string currentHeadID = delegateItem.DeptStaff.Department.headStaffID;
                DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                currendHead.role = "outOfOfficeHead";

                DeptStaff employee = context.DeptStaffs.Where(x => x.staffID == delegateItem.staffID).ToList().First();
                employee.role = "emp";
            }
            context.SaveChanges();
        }
        public void addDelegate(string selectedStaff, DateTime startDate,DateTime endDate)
        {
            Models.Delegate delegateItem = new Models.Delegate();
            delegateItem.staffID = selectedStaff;
            delegateItem.startDate = startDate;
            delegateItem.endDate = endDate;
            delegateItem.status = "active";

            context.Delegates.Add(delegateItem);
            context.SaveChanges();
        }

        public void updateDelegateStatus(List<Models.Delegate> delegateList, DateTime operationDate)
        {
            foreach (Models.Delegate item in delegateList)
            {
                if (item.endDate < operationDate && item.status != "cancelled"&&item.status != "terminated" && item.status != "expired")//expired
                {
                    item.status = "expired";

                    string currentHeadID = item.DeptStaff.Department.headStaffID;
                    DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                    currendHead.role = "head";

                    DeptStaff employee = context.DeptStaffs.Where(x => x.staffID == item.staffID).ToList().First();
                    employee.role = "emp";
                }
                else
                {
                    if (item.startDate<= operationDate && item.endDate >= operationDate && item.status != "cancelled" && item.status != "terminated" && item.status != "expired")//between delegate days
                    {
                        item.status = "On delegation";

                        string currentHeadID = item.DeptStaff.Department.headStaffID;
                        DeptStaff currendHead = context.DeptStaffs.Where(x => x.staffID == currentHeadID).First();
                        currendHead.role = "outOfOfficeHead";

                        DeptStaff employee = context.DeptStaffs.Where(x => x.staffID == item.staffID).ToList().First();
                        employee.role = "delegateHead";
                    }
                }
            }
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

    }
}