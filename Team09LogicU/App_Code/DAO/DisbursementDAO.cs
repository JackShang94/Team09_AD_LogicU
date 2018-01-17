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

        //To clear the cart without deleting them.
        //public static void CleanDispursementCart()
        //{
        //    disbCart = new List<DisbursementCart>();
        //    disbCartList = new List<DisbursementCart>();
        //}
        //Create disbursement by 
        public void createDisbursement(string reqID,string departmentID, string storeStaffID)
        {
            DateTime today = DateTime.Today;
            Disbursement dl = new Disbursement();
            dl.deptID = departmentID;
            dl.storeStaffID = storeStaffID;
            dl.disburseDate = (today.DayOfWeek == DayOfWeek.Sunday ? today.AddDays(1) : today.AddDays(7 - (int)today.DayOfWeek + 1));
            dl.status = "Pending";
            model.Disbursements.Add(dl);
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
        //Not sure whether thistwo methods are functional or not
        /*public List<DateTime> getDistinctDeliveryDates()
        {
            List<DateTime> hm = (from x in context.Disbursements select x.disburseDate).Distinct().ToList();
            return hm;
        }
        public DateTime DateTimeNext()
        {
            DayOfWeek day = DayOfWeek.Monday;
            //DateTime result = new DateTime(2017, 07, 12);
            //Please uncomment the below line when doing the live test.
            DateTime result = DateTime.Now.Date;
            while (result.DayOfWeek != day)
            {
                result = result.AddDays(1);
            }
            return result;
        }*/

        //public void CreateDisbursement(string itemID, int qn, int ac)
        //{
        //    int QoH = new Model1().Items.Where(x => x.itemId == itemID).Select(x => x.quantityOnHand).First();
        //    if (Math.Abs(ac) <= QoH)
        //    {
        //        //List<DisbursementListCart> disbCartList = new List<DisbursementListCart>();
        //        RequisitionDAO req = new RequisitionDAO();
        //        List<string> reqIds = req.GetRequisitionsIDs();
        //        List<string> deptIds = context.RequisitionItems.Where(x => reqIds.Contains(x.Requisition.requisitionId) && x.itemId == itemID).Select(x => x.Requisition.departmentId).ToList();
        //        foreach (string dep in deptIds)
        //        {
        //            DisbursementListCart disb = new DisbursementListCart();
        //            disb.ItemID = itemID;
        //            disb.DeptId = dep;
        //            List<int> SumQN = context.RequisitionItems.Where(x => reqIds.Contains(x.Requisition.requisitionId) && x.Requisition.departmentId == dep && x.itemId == itemID).Select(x => (x.quantity)).ToList();
        //            disb.QuantityNeeded = 0;
        //            foreach (int i in SumQN)
        //            {
        //                disb.QuantityNeeded = disb.QuantityNeeded + i;
        //            }
        //            if (qn == ac)
        //            {
        //                disb.QuantityRetrieved = disb.QuantityNeeded;
        //            }
        //            else if (disb.QuantityNeeded <= ac)
        //            {
        //                disb.QuantityRetrieved = disb.QuantityNeeded;
        //                ac = ac - disb.QuantityNeeded;
        //            }
        //            else if (disb.QuantityNeeded > ac)
        //            {
        //                disb.QuantityRetrieved = ac;
        //                ac = 0;
        //            }
        //            else
        //            {
        //                disb.QuantityRetrieved = 0;
        //            }
        //            disbCartList.Add(disb);
        //        }
        //        UpdateDisbursementCart(disbCartList);
        //    }
        //    else
        //    {
        //        throw new QuantityExceeded_thanOnHandException("Retrieved quantity is greater then on hand quantity (" + QoH + ") for the Item " + itemID);
        //    }

        //}

        //public void UpdateDisbursementCart(List<DisbursementListCart> disbCartList)
        //{
        //    foreach (DisbursementListCart d in disbCart)
        //    {
        //        foreach (DisbursementListCart disb in disbCartList)
        //        {
        //            if ((d.DeptId == disb.DeptId) && (d.ItemID == disb.ItemID))
        //            {
        //                disb.QuantityRetrieved = d.QuantityRetrieved;
        //            }
        //        }
        //    }
        //}

        //public void GenerateDisbursement()
        //{
        //    HashSet<string> depID = new HashSet<string>();
        //    foreach (DisbursementListCart d in disbCartList)
        //    {
        //        if (!depID.Contains(d.DeptId))
        //        {
        //            depID.Add(d.DeptId);
        //        }
        //    }
        //    foreach (string dep in depID)
        //    {
        //        DateTime today = DateTime.Today;
        //        DateTime disburseDt = today.DayOfWeek == DayOfWeek.Sunday ? today.AddDays(1) : today.AddDays(7 - (int)today.DayOfWeek + 1);
        //        try
        //        {
        //            DisbursementList oldDisb = context.DisbursementLists.Where(x => x.departmentId == dep && (x.disburseDate.Year) == disburseDt.Year && (x.disburseDate.Month) == disburseDt.Month && (x.disburseDate.Day) == disburseDt.Day && x.status == "Ready for Delivery").First();
        //            List<DisbursementItem> oldDisbItems = oldDisb.DisbursementItems.ToList();
        //            foreach (DisbursementListCart d in disbCartList)
        //            {
        //                int flagCount = 0;
        //                foreach (DisbursementItem dItem in oldDisbItems)
        //                {
        //                    if (d.ItemID == dItem.itemId && d.DeptId == dItem.DisbursementList.departmentId)
        //                    {
        //                        dItem.requestQuantity = dItem.actualQuantity + d.QuantityNeeded;
        //                        dItem.actualQuantity = dItem.actualQuantity + d.QuantityRetrieved;
        //                        flagCount = 1;
        //                    }
        //                }
        //                if (flagCount == 0)
        //                {
        //                    DisbursementItem dItem = new DisbursementItem();
        //                    dItem.itemId = d.ItemID;
        //                    dItem.requestQuantity = d.QuantityNeeded;
        //                    dItem.actualQuantity = d.QuantityRetrieved;
        //                    oldDisbItems.Add(dItem);
        //                }
        //            }
        //            oldDisb.DisbursementItems = oldDisbItems;
        //            context.SaveChanges();
        //        }
        //        catch (Exception exep)
        //        {
        //            DisbursementList disb = new DisbursementList();

        //            disb.departmentId = dep;
        //            disb.disburseDate = disburseDt;
        //            disb.status = "Ready for Delivery";
        //            foreach (DisbursementListCart d in disbCartList)
        //            {
        //                if (d.DeptId == dep)
        //                {
        //                    DisbursementItem dItem = new DisbursementItem();
        //                    dItem.itemId = d.ItemID;
        //                    dItem.requestQuantity = d.QuantityNeeded;
        //                    dItem.actualQuantity = d.QuantityRetrieved;
        //                    disb.DisbursementItems.Add(dItem);
        //                }
        //            }
        //            context.DisbursementLists.Add(disb);
        //            context.SaveChanges();
        //        }
        //    }
        //}

    }
}