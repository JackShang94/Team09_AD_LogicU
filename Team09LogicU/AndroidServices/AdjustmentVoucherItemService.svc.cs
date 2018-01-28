using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.AndroidServices;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdjustmentVoucherItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdjustmentVoucherItemService.svc or AdjustmentVoucherItemService.svc.cs at the Solution Explorer and start debugging.
    public class AdjustmentVoucherItemService : IAdjustmentVoucherItemService
    {
        AdjustmentVoucherItemDAO adjItemDAO = new AdjustmentVoucherItemDAO();

        public List<WCFAdjustmentVoucherItem> findAdjItemListByAdjID(string adjID)
        {
            List<WCFAdjustmentVoucherItem> targetAdjList = new List<WCFAdjustmentVoucherItem>();
            List<AdjustmentVoucherItem> adjList = adjItemDAO.getAdjustmentVoucherItemListByADJVID(Convert.ToInt32(adjID));
            foreach (AdjustmentVoucherItem ai in adjList)
            {
                WCFAdjustmentVoucherItem wcfAi = WCFAdjustmentVoucherItem.Make(ai.adjVItemID, ai.adjVID, ai.quantity, ai.itemID, ai.record);
                targetAdjList.Add(wcfAi);
            }
            return targetAdjList;
        }

        public void addAdjVoucherItem(WCFAdjustmentVoucherItem wcfAdjItem)
        {
            adjItemDAO.addAdjustmentVoucherItem(wcfAdjItem.AdjItemVID, wcfAdjItem.ItemID, wcfAdjItem.Qty, wcfAdjItem.Record);
        }
    }
}
