using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class DisbursementItemDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

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
        }

        //2.Retrieving a list of items from the selectedDisbursment by ID
        public List<DisbursementItem> getDisbursementItemsByDisbursementId(int disId)
        {
            List<DisbursementItem> disbursementItems;
            disbursementItems = context.DisbursementItems.Where(x => x.disbursementID == disId).ToList();
            return disbursementItems;
           
        }

        //Save the input actual qty
        public void savingActualQty(int disbursementItemID, int actualqty)
        {
            var k = context.DisbursementItems.Where(x => x.disbursementItemID == disbursementItemID).ToList();
            if (k.Count == 0)
            {
                return;
            }
            DisbursementItem i = k.First();
            i.actualQty = actualqty;
            context.SaveChanges();
        }
    }
}