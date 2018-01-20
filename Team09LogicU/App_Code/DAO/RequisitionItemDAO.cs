using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class RequisitionItemDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public List<RequisitionItem> getRequisitionItem(int requisitionID)
        {
            return m.RequisitionItems.Where(x => x.requisitionID == requisitionID).ToList();
        }

        public List<ItemCart> findRequisitionItemByID(int requisitionID)
        {
            List<ItemCart> list = m.RequisitionItems.
                Where(x => x.requisitionID == requisitionID).Select(x => new ItemCart { Description = x.Item.description, Quantity = x.requisitionQty, UnitOfMeasure = x.Item.unitOfMeasure }).ToList<ItemCart>();
            return list;
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

        /***********add one Item to Requisition***********/
        public RequisitionItem addItem(int requisitionID, string itemID, int requisitionQty)
        {
            RequisitionItem reqI = new RequisitionItem();
            reqI.requisitionID = requisitionID;
            reqI.itemID = itemID;
            reqI.requisitionQty = requisitionQty;
            return reqI;

        }
        public void removeItem(RequisitionItem rI)//call through id or object???
        {
            m.RequisitionItems.Remove(rI);
            m.SaveChanges();
        }

    }

}