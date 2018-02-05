using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class SOAItems
    {
        public string itemID;
        public string itemName;
        public int soldQuantity;
        public decimal unitPrice;
        public decimal totalPrice;
    }

    public class SOADAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
        public List<SOAItems> getSOAItems(string deptID, DateTime startDate, DateTime endDate)
        {
            bool IsNewItem = true;
            List<SOAItems> soaItemList = new List<SOAItems>();
            ///add this month disbursement items
            List<Disbursement> dList = getDisbursementListByDeptAndDate(deptID, startDate, endDate);
            foreach (Disbursement disBursement in dList)
            {
                foreach (DisbursementItem disitem in disBursement.DisbursementItems)
                {
                    IsNewItem = true;
                    foreach (SOAItems item in soaItemList)
                    {
                        if (disitem.itemID == item.itemID)//not new item
                        {
                            IsNewItem = false;
                            item.soldQuantity = item.soldQuantity + disitem.actualQty;
                            item.totalPrice = item.totalPrice + item.unitPrice * item.soldQuantity;
                        }
                    }
                    if (IsNewItem)
                    {
                        SOAItems newItem = new SOAItems();
                        newItem.itemID = disitem.itemID;
                        newItem.itemName = disitem.Item.description;
                        newItem.soldQuantity = disitem.actualQty;
                        newItem.unitPrice = context.SupplierItems.Where(x => x.itemID == disitem.itemID && x.preferenceRank=="1").Select(x => x.price).ToList().First();
                        newItem.totalPrice = disitem.actualQty * newItem.unitPrice;

                        soaItemList.Add(newItem);
                    }
                }
            }
            return soaItemList;
        }

        public List<Disbursement> getDisbursementListByDeptAndDate(string deptID, DateTime startDate, DateTime endDate)
        {
            List<Disbursement> dList = new List<Disbursement>();
            dList = context.Disbursements.Where(x => x.disburseDate >= startDate && x.disburseDate <= endDate && x.status == "Completed" && x.deptID == deptID).ToList();
            return dList;
        }
    }
}