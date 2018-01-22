using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DisbursementListDAO
    {
        SA45_Team09_LogicUEntities model = new DBEntities().getDBInstance();
        public void createDisbursement(string departmentID, string storeStaffID)
        {
            Disbursement dl = new Disbursement();
            dl.deptID = departmentID;
            dl.storeStaffID = storeStaffID;
            dl.disburseDate = DateTime.Now;
            dl.status = "Pending";
            model.Disbursements.Add(dl);          
            //1.Firstly need to get the current requisitionID, then update status to "Process"
            //.
            //.
            //.
            //2.Get Item information from retrieveal form, a list containing itemID DepartmentID, then recorded in the disbursementItem Database.
            //.
            //.
            //.
        }
        public Disbursement findHistoryDisbursementByDeptId(string deptId, DateTime historyDate)
        {
            DateTime historyMonday = historyDate.Date.DayOfWeek == DayOfWeek.Sunday ? historyDate.Date.AddDays(-7 + 1) : historyDate.Date.AddDays(-(int)historyDate.Date.DayOfWeek + 1);
            Disbursement disbl = model.Disbursements.Where(x => x.deptID == deptId && x.disburseDate == historyMonday).First();
            return disbl;
        }
        public void updateDisbursementStatus(Disbursement disbl, string status)
        {
            disbl.status = status;
            model.SaveChanges();
        }
        public Disbursement getCurrentDisbursementsByDepartment(String deptid, DateTime naw)
        {
            Disbursement selectedDisbursement = model.Disbursements.FirstOrDefault(a => a.deptID == deptid && a.disburseDate.Year == naw.Year && a.disburseDate.Month == naw.Month && a.disburseDate.Day == naw.Day);
            if (selectedDisbursement != null)
            {
                return selectedDisbursement;
            }
            return null;
        }
        public Disbursement getDisbursmentbyId(int disbursmentid)
        {
            Disbursement dismbt = model.Disbursements.FirstOrDefault(a => a.disbursementID == disbursmentid);
            if (dismbt != null)
                return dismbt;
            else
                return null;
        }
     

        

    }
}