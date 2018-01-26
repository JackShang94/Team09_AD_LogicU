using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class AdjustmentVoucherDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        public List<AdjustmentVoucher> getAdjustmentVoucherList()
        {
            return context.AdjustmentVouchers.ToList();
        }
        public List<AdjustmentVoucher> getAdjustmentVoucherListByID(int adjvID)
        {
            return context.AdjustmentVouchers.Where(x => x.adjVID == adjvID).ToList<AdjustmentVoucher>();
        }

        public List<AdjustmentVoucher> getadjvByStaffIDandStatus(string staffID, string status)
        {
            return context.AdjustmentVouchers.Where(x => x.storeStaffID == staffID && x.status == status).ToList<AdjustmentVoucher>();
        }
        public AdjustmentVoucher findAdjustmentVoucherByadjvId(int adjvID)
        {
            return context.AdjustmentVouchers.Find(adjvID);
        }

        public void addAdjustmentVoucher(string storestaffID, List<AdjustmentVouchercart> list)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();    
            adjvoucher.storeStaffID = storestaffID;
            adjvoucher.adjDate = DateTime.Now;
            adjvoucher.status = "pending";
            adjvoucher.authorisedBy = "";
            context.AdjustmentVouchers.Add(adjvoucher);
           // context.SaveChanges();
            int adjvID = adjvoucher.adjVID;
            /*************Then Add ADJVItems******************/
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
            
            foreach ( AdjustmentVouchercart cartitem in list)
            {
                AdjustmentVoucherItem adjvi = new AdjustmentVoucherItem();
                adjvi.adjVID = adjvoucher.adjVID;
                adjvi.itemID = cartitem.ItemID;
                adjvi.quantity = cartitem.Qty;
                adjvi.record = cartitem.Record;
                context.AdjustmentVoucherItems.Add(adjvi);
            }
            context.SaveChanges();

        }
    }
}