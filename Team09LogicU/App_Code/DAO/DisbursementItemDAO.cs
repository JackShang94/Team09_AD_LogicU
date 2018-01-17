using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DisbursementItemDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        //1.add retrieved-items to disbursement list
        public void createNewDisburesementItem(int disbId, string itemId, int expectedQty, int actualQty)
        {
            DisbursementItem disbItem = new DisbursementItem();
            disbItem.disbursementID = disbId;
            disbItem.itemID = itemId;
            disbItem.expectedQty = expectedQty;
            disbItem.actualQty = actualQty;
            context.DisbursementItems.Add(disbItem);
            context.SaveChanges();
            //After finished requisition, use foreach to add items.
            //.
            //.
            //.
        }

        //2.Retrieving a list of items from the selectedDisbursment by ID
        public List<DisbursementItem> getDisbursementItemsByDisbursementId(int disId)
        {
            List<DisbursementItem> disbursementItems;
            disbursementItems = context.DisbursementItems.Where(x => x.disbursementID == disId).ToList();
            return disbursementItems;
        }

        //public dynamic getDisbursementItemsbyDisbursment(int disbursmentid)
        //    {
        //        var hm = from disbst in context.DisbursementItems
        //                 where disbst.disbursementId == disbursmentid
        //                 join item in context.Items
        //                 on disbst.itemId equals item.itemId
        //                 join DisbursementList in context.DisbursementLists
        //                 on disbst.disbursementId equals DisbursementList.disbursementId
        //                 select new { disbst.disbItemSK, disbst.requestQuantity, disbst.actualQuantity, item.description, item.unitOfMeasure, DisbursementList.status };
        //        return hm.ToList();
        //    }
        //what is happening here, I NEED the above ^ method to work. 


        //Save the input actual qty
        public void savingActualQty(int disbursementItemID, int actualqty)
        {
            DisbursementItem i = context.DisbursementItems.Where(x => x.disbursementItemID == disbursementItemID).First();
            i.actualQty = actualqty;
            context.SaveChanges();
        }
    }
}