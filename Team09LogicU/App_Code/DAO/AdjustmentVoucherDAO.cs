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
        public List<AdjustmentVoucher> getAdjustmentVoucherListByStaffID(string staffID)
        {
            return context.AdjustmentVouchers.Where(x => x.storeStaffID == staffID).ToList<AdjustmentVoucher>(); ;
        }
        public List<AdjustmentVoucher> getAdjustmentVoucherListByID(int adjvID)
        {
            return context.AdjustmentVouchers.Where(x => x.adjVID == adjvID).ToList<AdjustmentVoucher>();
        }

        public List<AdjustmentVoucher> getadjvByStaffIDandStatus(string staffID, string status)
        {
            return context.AdjustmentVouchers.Where(x => x.storeStaffID == staffID && x.status == status).ToList<AdjustmentVoucher>();
        }
        public List<AdjustmentVoucher> findadjvbyStatus(string status)
        {
            return context.AdjustmentVouchers.Where(x => x.status == status).ToList<AdjustmentVoucher>();
        } 


        public List<AdjustmentVoucher> findadjvbyStatusandDate(DateTime from, DateTime to, string status)
        {
            List<AdjustmentVoucher> list = context.AdjustmentVouchers.
                Where(x => (x.adjDate.Year >= from.Year && x.adjDate.Month >= from.Month && x.adjDate.Day >= from.Day)
                && (x.adjDate.Year <= to.Year && x.adjDate.Month <= to.Month && x.adjDate.Day <= to.Day)
                &&(x.status == status)).ToList<AdjustmentVoucher>();
            return list;
        }
        public List<AdjustmentVoucher> findadjvbyStatusandDateStaffID(DateTime from, DateTime to, string status,string staffID)
        {
            List<AdjustmentVoucher> list = context.AdjustmentVouchers.
                Where(x => (x.adjDate.Year >= from.Year && x.adjDate.Month >= from.Month && x.adjDate.Day >= from.Day)
                && (x.adjDate.Year <= to.Year && x.adjDate.Month <= to.Month && x.adjDate.Day <= to.Day)
                && (x.status == status) && x.storeStaffID == staffID).ToList<AdjustmentVoucher>();
            return list;
        }

        public List<AdjustmentVoucher> findadjvbyDate(DateTime from, DateTime to)
        {
            return context.AdjustmentVouchers.Where(x => x.adjDate >= from && x.adjDate <= to).ToList<AdjustmentVoucher>();
        }

        public List<AdjustmentVoucher> findadjvbyDateandStaffID(DateTime from, DateTime to,string staffID)
        {
            return context.AdjustmentVouchers.Where(x => (x.adjDate >= from && x.adjDate <= to)&&(x.storeStaffID == staffID)).ToList<AdjustmentVoucher>();
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
        public void ApproveAdjustmentVoucherStatus(AdjustmentVoucher adjv, string managerID)
        {

            adjv.status = "Approved";
            adjv.authorisedBy = managerID;
  
            // context.SaveChanges();
           
            context.SaveChanges();

        }
        public void RejectAdjustmentVoucherStatus(AdjustmentVoucher adjv, string managerID)
        {

            adjv.status = "Rejected";
            adjv.authorisedBy = managerID;



            context.SaveChanges();

        }

        //Method1
        public void SendtoManager(AdjustmentVoucher adjv, string managerID)
        {
            StoreStaffDAO stsdao = new StoreStaffDAO();
            StoreStaff sts=     stsdao.getstorestaffbyrole("manager");
            adjv.authorisedBy = sts.role;//manager only one person???
            context.SaveChanges();

        }
        //Method2

        public void SendtoManageranother(AdjustmentVoucher adjv)
        {
            adjv.authorisedBy = "";
            adjv.status = "PendingForManager";
            context.SaveChanges();

        }

        //public int judgeprice(int adjVID)
        //{
        //    AdjustmentVoucherItem adjvoucheritem = new AdjustmentVoucherItem();
        
        //    AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();

        //    List<AdjustmentVoucherItem> adjvitemlist= adjvidao.getAdjustmentVoucherItemListByADJVID(adjVID);
        //    int num; string ITEMID;
        //    int stop = 0;
        //    SupplierItemDAO suppitemdao = new SupplierItemDAO();      
        //    for (num = 0; num < adjvitemlist.Count - 1; num++)
        //    {
        //         ITEMID = adjvitemlist[num].itemID;     
        //        List<SupplierItem> supilist = suppitemdao.findSupplierListByItemID(ITEMID);
        //        for (int j = 0; j < 3; j++)
        //        {if (supilist[j].price>=2)
        //            {
        //                stop = 1;
        //                break;     
        //            }
        //        }
        //        if (stop == 1)
        //        {            
        //            break;
        //        }
        //    }
        //    return stop;
        //}
        public int price(int adjVID)
        {
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
            List<AdjustmentVoucherItem> adjvitemlist = adjvidao.getAdjustmentVoucherItemListByADJVID(adjVID);
            int stop = 0;
            foreach (AdjustmentVoucherItem breakitem in adjvitemlist)
            {
                //update item quantity
                SupplierItem supplieritem;
                List<SupplierItem> itemlist = context.SupplierItems.Where(x => x.itemID == breakitem.itemID).ToList();
                if (itemlist.Count > 0)// not null
                {
                    supplieritem = itemlist.First();
                    if (supplieritem.price >= 2)
                    {
                        stop = 1;
                        break;
                    }
                }

            }
            context.SaveChanges();
            return stop;        
        }
        

    }
}