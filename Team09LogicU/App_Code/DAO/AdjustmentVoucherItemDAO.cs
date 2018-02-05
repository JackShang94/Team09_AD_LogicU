using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class AdjustmentVoucherItemDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        public List<AdjustmentVoucherItem> getAdjustmentVoucherItemList()
        {
            return context.AdjustmentVoucherItems.ToList();
        }

        public List<AdjustmentVoucherItem> getAdjustmentVoucherItemListByID(int adjvitemID)
        {
            return context.AdjustmentVoucherItems.Where(x => x.adjVItemID == adjvitemID).ToList<AdjustmentVoucherItem>();
        }

        public List<AdjustmentVoucherItem> getAdjustmentVoucherItemListByADJVID(int adjvID)
        {
            return context.AdjustmentVoucherItems.Where(x => x.adjVID == adjvID).ToList<AdjustmentVoucherItem>();
        }

        public AdjustmentVoucherItem addAdjustmentVoucherItem(int adjVID, string itemID, int qty, string record)
        {
            AdjustmentVoucherItem adjvoucheritem = new AdjustmentVoucherItem();
            adjvoucheritem.quantity = qty;
            adjvoucheritem.itemID = itemID;
            adjvoucheritem.adjVID = adjVID;
            adjvoucheritem.record = record;
            return adjvoucheritem;
        }

    }
}