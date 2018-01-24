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




        public void addAdjustmentVoucher(int i,string storestaffID, DateTime adjdate)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();

            adjvoucher.storeStaffID = storestaffID;
            adjvoucher.adjDate = adjdate;

            context.AdjustmentVouchers.Add(adjvoucher);
            context.SaveChanges();
        }
    }
}