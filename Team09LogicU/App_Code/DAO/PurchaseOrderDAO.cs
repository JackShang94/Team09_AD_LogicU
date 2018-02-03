using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{

    public class PurchaseOrderDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public void CreateNewPO(PurchaseOrder po)
        {
            m.PurchaseOrders.Add(po);
            m.SaveChanges();
        }

        public List<PurchaseOrder> findPOList()
        {
            List<PurchaseOrder> listPO = m.PurchaseOrders.ToList();
            return listPO;
        }

        public PurchaseOrder findPObypoID(int poID)
        {
            List<PurchaseOrder> listPO = m.PurchaseOrders.Where(x => x.poID == poID).ToList();
            PurchaseOrder po = new PurchaseOrder();
            if (listPO.Count() > 0)
            {
                po = listPO.First();
            }
            return po;
        }

        public List<PurchaseOrder> findPOByDate(DateTime from, DateTime to)
        {
            List<PurchaseOrder> list = m.PurchaseOrders.ToList<PurchaseOrder>();

            List<PurchaseOrder> finalList = new List<PurchaseOrder>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].orderDate.Year > from.Year && list[i].orderDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].orderDate.Year == from.Year || list[i].orderDate.Year == to.Year)
                {
                    if (
                        (list[i].orderDate.Year == from.Year && list[i].orderDate.Year != to.Year && list[i].orderDate.Month > from.Month) ||
                        (list[i].orderDate.Year == to.Year && list[i].orderDate.Year != from.Year && list[i].orderDate.Month < to.Month) ||

                        (list[i].orderDate.Year == to.Year && list[i].orderDate.Year == from.Year
                        && list[i].orderDate.Month < to.Month && list[i].orderDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].orderDate.Month == from.Month && list[i].orderDate.Month != to.Month && list[i].orderDate.Day > from.Day) ||
                            (list[i].orderDate.Month == to.Month && list[i].orderDate.Month != from.Month && list[i].orderDate.Day < to.Day) ||

                            (list[i].orderDate.Month == to.Month && list[i].orderDate.Month == from.Month
                            && list[i].orderDate.Day < to.Day && list[i].orderDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;

        }

        public List<PurchaseOrder> findPOBySupplierID(string supID)
        {
            List<PurchaseOrder> list = m.PurchaseOrders.
                Where(x => x.supplierID == supID).ToList<PurchaseOrder>();
            return list;
        }

        public List<PurchaseOrder> findPOByDateAndSupID(DateTime from, DateTime to, string supID)
        {
            List<PurchaseOrder> list = m.PurchaseOrders.
                Where(x =>x.supplierID == supID)
                .ToList<PurchaseOrder>();
            List<PurchaseOrder> finalList = new List<PurchaseOrder>();
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].orderDate.Year > from.Year && list[i].orderDate.Year < to.Year)
                {
                    finalList.Add(list[i]);
                }
                else if (list[i].orderDate.Year == from.Year || list[i].orderDate.Year == to.Year)
                {
                    if (
                        (list[i].orderDate.Year == from.Year && list[i].orderDate.Year != to.Year && list[i].orderDate.Month > from.Month) ||
                        (list[i].orderDate.Year == to.Year && list[i].orderDate.Year != from.Year && list[i].orderDate.Month < to.Month) ||

                        (list[i].orderDate.Year == to.Year && list[i].orderDate.Year == from.Year
                        && list[i].orderDate.Month < to.Month && list[i].orderDate.Month > from.Month)
                        )
                    {
                        finalList.Add(list[i]);
                    }
                    else
                    {
                        if (
                            (list[i].orderDate.Month == from.Month && list[i].orderDate.Month != to.Month && list[i].orderDate.Day > from.Day) ||
                            (list[i].orderDate.Month == to.Month && list[i].orderDate.Month != from.Month && list[i].orderDate.Day < to.Day) ||

                            (list[i].orderDate.Month == to.Month && list[i].orderDate.Month == from.Month
                            && list[i].orderDate.Day < to.Day && list[i].orderDate.Day > from.Day)
                            )
                        {
                            finalList.Add(list[i]);
                        }
                    }
                }
            }
            return finalList;
        }

        public List<int> findPOIDbyMonth(DateTime time)
        {
            List<int> poIDlist = new List<int>();

            List<PurchaseOrder> list = m.PurchaseOrders.
                Where(x => (x.orderDate.Year == time.Year) && (x.orderDate.Month == time.Month))
                .ToList<PurchaseOrder>();
            for (int i = 0; i < list.Count(); i++)
            {
                poIDlist.Add(list[i].poID);
            }
            return poIDlist;
        }

        public string findSupplierIDbyPOid(int poID)
        {
            string supplierID;
            PurchaseOrder po = m.PurchaseOrders.Where(x => (x.poID == poID)).First();
            supplierID = po.supplierID;
            return supplierID;
        }

        public DateTime findOrderDatebyPOid(int poID)
        {
            DateTime orderDate;
            PurchaseOrder po = m.PurchaseOrders.Where(x => (x.poID == poID)).First();
            orderDate = po.orderDate;
            return orderDate;
        }

    }
}