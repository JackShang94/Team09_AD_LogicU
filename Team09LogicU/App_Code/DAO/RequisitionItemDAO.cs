using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code
{
    public class RequisitionItemDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public List<RequisitionItem> getRequisitionItem(int requisitionID)
        {
            return m.RequisitionItems.Where(x => x.requisitionID == requisitionID).ToList();
        }

     
        public void updateItemQty(RequisitionItem rI,int Qty)
        {
            if (rI.requisitionQty == 0)
            {
                removeItem(rI);
            }else if(rI.requisitionQty>0)
            {
                rI.requisitionQty = Qty;
            }
        }

        public void addItem(int requisitionID, string itemID, int requisitionQty)
        {
            RequisitionItem reqI = new RequisitionItem();
            reqI.requisitionID = requisitionID;
            reqI.itemID = itemID;
            reqI.requisitionQty = requisitionQty;

        }
        public void removeItem(RequisitionItem rI)//call through id or object???
        {
            m.RequisitionItems.Remove(rI);
            m.SaveChanges();
        }

    }

}