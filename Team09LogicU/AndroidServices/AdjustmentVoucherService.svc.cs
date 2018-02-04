using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdjustmentVoucherService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdjustmentVoucherService.svc or AdjustmentVoucherService.svc.cs at the Solution Explorer and start debugging.
    public class AdjustmentVoucherService : IAdjustmentVoucherService
    {
        AdjustmentVoucherDAO adjDAO = new AdjustmentVoucherDAO();
        public void addAdjVoucher(List<WCFAdjustmentVoucherItem> adjItemList)
        {
            List<AdjustmentVoucherItemcart> adjItemCart = new List<AdjustmentVoucherItemcart>();
            foreach(WCFAdjustmentVoucherItem  wcfAI in adjItemList)
            {
                AdjustmentVoucherItemcart cartItem = new AdjustmentVoucherItemcart();
                cartItem.ItemID = wcfAI.ItemID;
                cartItem.Qty = wcfAI.Qty;
                cartItem.Record = wcfAI.Record;

                adjItemCart.Add(cartItem);
            }
            adjDAO.addAdjV(adjItemCart);
        }

        public List<WCFAdjustmentVoucher> findAllAdjVoucher()
        {
            List<WCFAdjustmentVoucher> targetAdjList = new List<WCFAdjustmentVoucher>();
            List<AdjustmentVoucher> adjList = adjDAO.getAdjustmentVoucherList();
            foreach (AdjustmentVoucher adj in adjList )
            {
                WCFAdjustmentVoucher wcfAdj = WCFAdjustmentVoucher.Make(adj.adjVID, adj.storeStaffID, adj.authorisedBy, adj.adjDate, adj.status);
                targetAdjList.Add(wcfAdj);
            }
            return targetAdjList;
        }

        public List<WCFAdjustmentVoucher> findAdjByDate(DateTime from,DateTime to)
        {
            List<WCFAdjustmentVoucher> targetAdjList = new List<WCFAdjustmentVoucher>();
            List<AdjustmentVoucher> adjList = adjDAO.findadjvbyDate(from, to);
            foreach (AdjustmentVoucher adj in adjList)
            {
                WCFAdjustmentVoucher wcfAdj = WCFAdjustmentVoucher.Make(adj.adjVID, adj.storeStaffID, adj.authorisedBy, adj.adjDate, adj.status);
                targetAdjList.Add(wcfAdj);
            }
            return targetAdjList;
        }
    }
}
