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
        public List<DisbursementCart>getDisbursementCartItem(int disId)
        {
            List<DisbursementItem> disbursementItems;
            List<DisbursementCart> disbursementCarts=new List<DisbursementCart>();
            disbursementItems = context.DisbursementItems.Where(x => x.disbursementID == disId).ToList();
            foreach (DisbursementItem items in disbursementItems)
            {
                DisbursementCart carts = new DisbursementCart();
                    carts.ItemDescription = context.Items.Where(x => x.itemID == items.itemID).Select(x => x.description).First().ToString();
                    carts.Expectedc = items.expectedQty;
                    carts.Actual = items.actualQty;
                    carts.Disburstime = context.Disbursements.Where(x => x.disbursementID == disId).Select(x => x.disburseDate).First();
                    carts.Status = context.Disbursements.Where(x => x.disbursementID == disId).Select(x => x.status).First().ToString();
                disbursementCarts.Add(carts);
            }
            return disbursementCarts;
        }


        //Save the input actual qty
        public void savingActualQty(int disbursementItemID, int actualqty)
        {
            DisbursementItem i = context.DisbursementItems.Where(x => x.disbursementItemID == disbursementItemID).First();
            i.actualQty = actualqty;
            context.SaveChanges();
        }
    }
}