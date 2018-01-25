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


        public void addAdjustmentVoucher(string storestaffID, Dictionary<string, int> dict)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();

            adjvoucher.storeStaffID = storestaffID;
            adjvoucher.adjDate = DateTime.Now;
            adjvoucher.status = "pending";
            adjvoucher.authorisedBy = "";
            context.AdjustmentVouchers.Add(adjvoucher);
            context.SaveChanges();
            int adjvID = adjvoucher.adjVID;
            /*************Then Add ADJVItems******************/
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
            foreach (var d in dict)
            {
             AdjustmentVoucherItem adjvi = adjvidao.addAdjustmentVoucherItem(adjvID, d.Key, d.Value);
                context.AdjustmentVoucherItems.Add(adjvi);
            }
            context.SaveChanges();

        }
    }
}