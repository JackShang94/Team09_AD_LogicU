using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DisbursementDAO
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
           
        }
       
        public Disbursement findHistoryDisbursementByDeptId(string deptId, DateTime historyDate)
        {
            DateTime historyMonday = historyDate.Date.DayOfWeek == DayOfWeek.Sunday ? historyDate.Date.AddDays(-7 + 1) : historyDate.Date.AddDays(-(int)historyDate.Date.DayOfWeek + 1);
            Disbursement disbl = model.Disbursements.Where(x => x.deptID == deptId && x.disburseDate == historyMonday).First();
            return disbl;
        }
        public void updateDisbursementStatus(int disID, string status)
        {
            var a = model.Disbursements.Where(x => x.disbursementID == disID).ToList();
            if (a == null)
            {
                return;
            }

            a.First().status = status;
            model.SaveChanges();
        }
        public List<Disbursement> getDisbursementListByDeptID(String deptid)
        {
            return model.Disbursements.Where(x => x.deptID == deptid).ToList();
        }
        public List<Disbursement> getAwaitingDisbursementListByDeptID(String deptid)
        {
            return model.Disbursements.Where(x => x.deptID == deptid && x.status== "Awaiting Delivery").ToList();
        }
        public List<int> getCurrentDisbursementsId(string status,string deptid)
        {
            return model.Disbursements.Where(x => x.status == status&&x.deptID==deptid).Select(x => x.disbursementID).ToList();
        }
        public Disbursement getDisbursmentbyId(int disbursmentid)
        {
            Disbursement dismbt = model.Disbursements.FirstOrDefault(a => a.disbursementID == disbursmentid);
            if (dismbt != null)
                return dismbt;
            else
                return null;
        }
        public Disbursement getDisbursementByDept(string deptid)
        {
            Disbursement dismbt = model.Disbursements.FirstOrDefault(x => x.deptID == deptid);
            if (dismbt != null)
                return dismbt;
            else
                return null;
        }

        public List<DisbursementCart> getDisbursementItemByDisID(int disburseID )
        {

            var a = from i in model.Items
                    join di in model.DisbursementItems on i.itemID equals di.itemID
                    join d in model.Disbursements on di.disbursementID equals d.disbursementID
                    where d.disbursementID == disburseID
                    select new DisbursementCart
                    {
                        ItemID = i.itemID,
                        ItemDescription = i.description,
                        Expectedc = di.expectedQty,
                        Actual = di.actualQty
                    };

            List < DisbursementCart > ldc = new List<DisbursementCart>();
            if (a==null)
            {
                return ldc;
            }
            ldc = (List<DisbursementCart>)a.ToList();
            return ldc;
        }
        
        public List<Disbursement> getAllAwaitingDisbursement()
        {
            return model.Disbursements.Where(x => x.status == "Awaiting Delivery").ToList();
        }
        public List<Disbursement> getAllCompletedDisbursement()
        {
            
            return model.Disbursements.Where(x => x.status == "Completed").ToList();
        }
        public List<Disbursement> getAllCompletedDisbursementBydeptID(string deptID)
        {

            return model.Disbursements.Where(x => x.status == "Completed"&&x.deptID==deptID).ToList();
        }
        public List<Disbursement> getAllCompletedDisbursementBydeptIDandDate(DateTime from, DateTime to, string deptID)
        {
            List<Disbursement> list = model.Disbursements.Where(x => (x.status == "Completed") && (x.deptID == deptID)).ToList();
            List<Disbursement> finalList = new List<Disbursement>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].disburseDate.Year > from.Year && list[i].disburseDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if(list[i].disburseDate.Year == from.Year || list[i].disburseDate.Year == to.Year)
                {
                    if (
                        (list[i].disburseDate.Year == from.Year && list[i].disburseDate.Year!=to.Year && list[i].disburseDate.Month > from.Month ) ||
                        (list[i].disburseDate.Year == to.Year && list[i].disburseDate.Year != from.Year && list[i].disburseDate.Month < to.Month )||
                        
                        (list[i].disburseDate.Year == to.Year && list[i].disburseDate.Year == from.Year
                        && list[i].disburseDate.Month < to.Month && list[i].disburseDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].disburseDate.Month == from.Month && list[i].disburseDate.Month != to.Month && list[i].disburseDate.Day > from.Day) ||
                            (list[i].disburseDate.Month == to.Month && list[i].disburseDate.Month != from.Month && list[i].disburseDate.Day < to.Day)||

                            (list[i].disburseDate.Month == to.Month && list[i].disburseDate.Month == from.Month 
                            && list[i].disburseDate.Day < to.Day && list[i].disburseDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }
        public void savingActualQty(int disID,string itemID, int actualqty)
        {
            var k = model.DisbursementItems.Where(x => x.itemID == itemID&&x.disbursementID==disID).ToList();
            if (k.Count == 0)
            {
                return;
            }
            DisbursementItem i = k.First();
            i.actualQty = actualqty;
            model.SaveChanges();
        }

        
       
        public List<Disbursement> deptDisbursementHistory(string deptId)
        {
            return model.Disbursements.Where(x => x.deptID == deptId).ToList();
        }

    }
}