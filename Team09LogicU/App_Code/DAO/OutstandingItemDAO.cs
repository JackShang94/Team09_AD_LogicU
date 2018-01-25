using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class OutstandingItemDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        // add new outstanding item 
        public void createNewOutstandingItem(string itemID, int osID, int needed, int actual)
        {
            OutstandingItem outstandingItem = new OutstandingItem();
            outstandingItem.outstandingID = osID;
            outstandingItem.itemID = itemID;
            outstandingItem.expectedQty = needed - actual;
            outstandingItem.actualQty = outstandingItem.expectedQty;

            context.OutstandingItems.Add(outstandingItem);
            context.SaveChanges();
        }

        // find all outstanding items by outstandingID
        public List<OutstandingItem> getOutstandingItemsByOutstandingId(int outstandingId)
        {
            List<OutstandingItem> outstandingItems;
            outstandingItems = context.OutstandingItems.Where(x => x.outstandingID == outstandingId).ToList();
            return outstandingItems;
        }

        //save the actual quantity for osItems
        public void saveOutstandingItems(int index, int actual)
        {
            OutstandingItem osItem = context.OutstandingItems.Where(x => x.outstandingItemID == index).First();
            osItem.actualQty = actual;
            context.SaveChanges();
        }

        //update the qty of osItems when replenished
        public void updateOsItem_ByItem_and_ByDept(string itemId, string deptId)
        {
            List<OutstandingItem> osItemList = context.OutstandingItems.Where(x => x.itemID == itemId
                                                                      && x.Outstanding.deptID == deptId)
                                                                      .ToList();
            foreach (OutstandingItem osItem in osItemList)
            {
                osItem.actualQty = osItem.expectedQty;
            }
            context.SaveChanges();
        }

        public List<OutstandingCart> getPendingOutstandingCartByDeptID(string deptID,string status)
        {
            //int fromYear = from.Year;
            //int toYear = to.Year;
            //int fromMonth = from.Month;
            //int toMonth = to.Month;
            //int fromDay = from.Day;
            //int toDay = to.Day;

            var a = (from o in context.Outstandings
                     where o.status == status && o.deptID == deptID
                     join oi in context.OutstandingItems on o.outstandingID equals oi.outstandingID
                     join i in context.Items on oi.itemID equals i.itemID
                     select new OutstandingCart
                     {
                         ItemID = i.itemID,
                         ItemDesc = i.description,
                         Unit = i.unitOfMeasure,
                         Needed = oi.expectedQty,
                         DisburseDate = o.disburseDate
                     });
            List<OutstandingCart> loc = new List<OutstandingCart>();
            if (a == null)
            {
                return loc;
            }
            loc = (List<OutstandingCart>)a.ToList();

            return loc;
             
                      
                        

        }
    }
}