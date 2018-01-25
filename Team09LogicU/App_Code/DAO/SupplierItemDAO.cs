using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class SupplierItemDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public List<SupplierItem> findSupplierListByItemID(string itemID)
        {
            var qry = m.SupplierItems.Where(x => x.itemID == itemID).OrderBy(x => x.preferenceRank);
            return qry.ToList<SupplierItem>();
        }

        public void updateSupplierItem(string itemID, List<string> supList, List<decimal> priceList)
        {
            List<SupplierItem> supItemList = m.SupplierItems.Where(x => x.itemID == itemID).ToList();
            SupplierItem i_1 = supItemList.Where(x => x.preferenceRank == "1").First();
            SupplierItem i_2 = supItemList.Where(x => x.preferenceRank == "2").First();
            SupplierItem i_3 = supItemList.Where(x => x.preferenceRank == "3").First();
            i_1.supplierID = supList[0];
            i_1.price = priceList[0];

            i_2.supplierID = supList[1];
            i_2.price = priceList[1];

            i_3.supplierID = supList[2];
            i_3.price = priceList[2];

            m.SaveChanges();

        }

        public List<string> getSupplierByItem(string itemID)
        {
            List<SupplierItem> supItemList = m.SupplierItems.Where(x => x.itemID == itemID).ToList();
            List<string> supList = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (supItemList.Count() > 0)
                {
                    string s = supItemList.Where(x => x.preferenceRank == (i + 1).ToString()).First().supplierID;
                    supList.Add(s);
                }
            }
            return supList;
        }

        public List<decimal> getPriceByItem(string itemID)
        {
            List<SupplierItem> supItemList = m.SupplierItems.Where(x => x.itemID == itemID).ToList();
            List<decimal> pricelist = new List<decimal>();
            for (int i = 0; i < 3; i++)
            {
                if (supItemList.Count() > 0)
                {
                    decimal p = supItemList.Where(x => x.preferenceRank == (i + 1).ToString()).First().price;
                    pricelist.Add(p);
                }
            }
            return pricelist;
        }

        public decimal getPriceByItemIDAndSupplierID(string itemID, string supplierID)
        {
            List<SupplierItem> supItemList = m.SupplierItems.Where(x => x.itemID == itemID && x.supplierID==supplierID).ToList();
            SupplierItem supItem = new SupplierItem();
            if (supItemList.Count != 0)
            {
                supItem = supItemList.First();
            }
            decimal price = supItem.price;
            return price;
        }
        public SupplierItem findSupplierItemByItemIDAndSupplier(string itemID, string supplierID)
        {
            SupplierItem item = new SupplierItem();
            List<SupplierItem> list = m.SupplierItems.
                Where(x => x.itemID == itemID && x.supplierID == supplierID).ToList<SupplierItem>();
            if (list.Count() > 0)
            {
                item = list.First();
            }
            return item;
        }
    }
}