using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;
using System.Web.SessionState;

namespace Team09LogicU.App_Code.DAO
{
    public class AdjustmentVoucherDAO : System.Web.SessionState.IRequiresSessionState
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        public List<AdjustmentVoucher> getAdjustmentVoucherList()
        {
            return context.AdjustmentVouchers.OrderByDescending(x => x.adjVID).ToList();
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
                Where(x => (x.status == status)).ToList<AdjustmentVoucher>();
            List<AdjustmentVoucher> finalList = new List<AdjustmentVoucher>();
            for (int i = 0; i < list.Count(); i++)// compare adjustment  datetime
            {
                if (list[i].adjDate.Year > from.Year && list[i].adjDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].adjDate.Year == from.Year || list[i].adjDate.Year == to.Year)
                {
                    if (
                        (list[i].adjDate.Year == from.Year && list[i].adjDate.Year != to.Year && list[i].adjDate.Month > from.Month) ||
                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year != from.Year && list[i].adjDate.Month < to.Month) ||

                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year == from.Year
                        && list[i].adjDate.Month < to.Month && list[i].adjDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].adjDate.Month == from.Month && list[i].adjDate.Month != to.Month && list[i].adjDate.Day > from.Day) ||
                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month != from.Month && list[i].adjDate.Day < to.Day) ||

                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month == from.Month
                            && list[i].adjDate.Day < to.Day && list[i].adjDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }

        public List<AdjustmentVoucher> findadjvbyStatusandDateStaffID(DateTime from, DateTime to, string status, string staffID)
        {
            List<AdjustmentVoucher> list = context.AdjustmentVouchers.
                Where(x => (x.status == status) && x.storeStaffID == staffID).ToList<AdjustmentVoucher>();
            List<AdjustmentVoucher> finalList = new List<AdjustmentVoucher>();
            for (int i = 0; i < list.Count(); i++)// compare adjustment  datetime
            {
                if (list[i].adjDate.Year > from.Year && list[i].adjDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].adjDate.Year == from.Year || list[i].adjDate.Year == to.Year)
                {
                    if (
                        (list[i].adjDate.Year == from.Year && list[i].adjDate.Year != to.Year && list[i].adjDate.Month > from.Month) ||
                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year != from.Year && list[i].adjDate.Month < to.Month) ||

                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year == from.Year
                        && list[i].adjDate.Month < to.Month && list[i].adjDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].adjDate.Month == from.Month && list[i].adjDate.Month != to.Month && list[i].adjDate.Day > from.Day) ||
                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month != from.Month && list[i].adjDate.Day < to.Day) ||

                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month == from.Month
                            && list[i].adjDate.Day < to.Day && list[i].adjDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;

        }

        public List<AdjustmentVoucher> findadjvbyDate(DateTime from, DateTime to)
        {
            List<AdjustmentVoucher> list = context.AdjustmentVouchers.ToList<AdjustmentVoucher>();
            List<AdjustmentVoucher> finalList = new List<AdjustmentVoucher>();
            for (int i = 0; i < list.Count(); i++)// compare adjustment  datetime
            {
                if (list[i].adjDate.Year > from.Year && list[i].adjDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].adjDate.Year == from.Year || list[i].adjDate.Year == to.Year)
                {
                    if (
                        (list[i].adjDate.Year == from.Year && list[i].adjDate.Year != to.Year && list[i].adjDate.Month > from.Month) ||
                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year != from.Year && list[i].adjDate.Month < to.Month) ||

                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year == from.Year
                        && list[i].adjDate.Month < to.Month && list[i].adjDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].adjDate.Month == from.Month && list[i].adjDate.Month != to.Month && list[i].adjDate.Day > from.Day) ||
                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month != from.Month && list[i].adjDate.Day < to.Day) ||

                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month == from.Month
                            && list[i].adjDate.Day < to.Day && list[i].adjDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }

        public List<AdjustmentVoucher> findadjvbyDateandStaffID(DateTime from, DateTime to, string staffID)
        {
            List<AdjustmentVoucher> list = context.AdjustmentVouchers.Where(x => (x.adjDate >= from && x.adjDate <= to) && (x.storeStaffID == staffID)).ToList<AdjustmentVoucher>();
            List<AdjustmentVoucher> finalList = new List<AdjustmentVoucher>();
            for (int i = 0; i < list.Count(); i++)// compare adjustment  datetime
            {
                if (list[i].adjDate.Year > from.Year && list[i].adjDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].adjDate.Year == from.Year || list[i].adjDate.Year == to.Year)
                {
                    if (
                        (list[i].adjDate.Year == from.Year && list[i].adjDate.Year != to.Year && list[i].adjDate.Month > from.Month) ||
                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year != from.Year && list[i].adjDate.Month < to.Month) ||

                        (list[i].adjDate.Year == to.Year && list[i].adjDate.Year == from.Year
                        && list[i].adjDate.Month < to.Month && list[i].adjDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].adjDate.Month == from.Month && list[i].adjDate.Month != to.Month && list[i].adjDate.Day > from.Day) ||
                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month != from.Month && list[i].adjDate.Day < to.Day) ||

                            (list[i].adjDate.Month == to.Month && list[i].adjDate.Month == from.Month
                            && list[i].adjDate.Day < to.Day && list[i].adjDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }


        public AdjustmentVoucher findAdjustmentVoucherByadjvId(int adjvID)
        {
            return context.AdjustmentVouchers.Find(adjvID);
        }

        public void addAdjustmentVoucher(string storestaffID, List<AdjustmentVoucherItemcart> list)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();
            adjvoucher.storeStaffID = (string)System.Web.HttpContext.Current.Session["loginID"];
            adjvoucher.storeStaffID = storestaffID;
            adjvoucher.adjDate = DateTime.Now;
            adjvoucher.status = "pending";
            adjvoucher.authorisedBy = "";
            context.AdjustmentVouchers.Add(adjvoucher);
            int adjvID = adjvoucher.adjVID;
            /*************Then Add ADJVItems******************/
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();

            foreach (AdjustmentVoucherItemcart cartitem in list)
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

        public void addAdjV(List<AdjustmentVoucherItemcart> list)
        {
            AdjustmentVoucher adjvoucher = new AdjustmentVoucher();
            adjvoucher.storeStaffID = (string)System.Web.HttpContext.Current.Session["loginID"];
            adjvoucher.adjDate = DateTime.Now;
            adjvoucher.status = "pending";
            adjvoucher.authorisedBy = "";
            context.AdjustmentVouchers.Add(adjvoucher);

            int adjvID = adjvoucher.adjVID;
            /*************Then Add ADJVItems******************/
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();

            foreach (AdjustmentVoucherItemcart cartitem in list)
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
            StoreStaff sts = stsdao.getstorestaffbyrole("manager");
            adjv.authorisedBy = sts.role;//manager only one person
            context.SaveChanges();
        }

        //Method2
        public void SendtoManageranother(AdjustmentVoucher adjv)
        {
            adjv.authorisedBy = "";
            adjv.status = "PendingForManager";
            context.SaveChanges();

        }
        public int price(int adjVID)
        {
            AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
            List<AdjustmentVoucherItem> adjvitemlist = adjvidao.getAdjustmentVoucherItemListByADJVID(adjVID);
            int stop = 0;
            decimal unittotal = 0;
            int qty = 0;
            foreach (AdjustmentVoucherItem breakitem in adjvitemlist)
            {
                //update item quantity
                SupplierItem supplieritem;
                List<SupplierItem> itemlist = context.SupplierItems.Where(x => x.itemID == breakitem.itemID).ToList();
                if (itemlist.Count > 0)// not null
                {
                    supplieritem = itemlist.First();
                    qty = Math.Abs(breakitem.quantity);
                    unittotal = ((supplieritem.price) * qty);
                    if (unittotal >= 250)
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