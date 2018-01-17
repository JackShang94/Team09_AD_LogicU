using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class OutstandingDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        //create new outstanding for one department
        public void createOutstandingList(string deptID, string storeStaffID)
        {
            Outstanding outstanding = new Outstanding();
            outstanding.deptID = deptID;
            outstanding.disburseDate = DateTime.Today.AddDays(7);//add to the next-week disbursementList
            outstanding.storeStaffID = storeStaffID;
            outstanding.status = "waiting for replenishment";
            context.SaveChanges();
        }
        //find outstanding list by department 
        public List<Outstanding> findOutstanding_ByDepartment(string deptID)
        {
            List<Outstanding> osList = context.Outstandings.Where(x => x.deptID == deptID).ToList();
            return osList;
        }

        //change the status of outstanding if finished disbursement
        public void clearOutstanding_ByDepartment(string deptID)
        {
            List<Outstanding> oslist = findOutstanding_ByDepartment(deptID);
            foreach (Outstanding os in oslist)
            {
                os.status = "Already replenished";
            }
            context.SaveChanges();
        }
    }
}