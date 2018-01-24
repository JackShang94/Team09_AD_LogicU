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

        public SupplierItem findSupplierItemByItemIDAndSupplier(string itemID, string supplierID)
        {
            SupplierItem item = new SupplierItem();
            List<SupplierItem> list = m.SupplierItems.
                Where(x => x.itemID == itemID && x.supplierID==supplierID).ToList<SupplierItem>();
            if (list.Count() > 0)
            {
                item = list.First();
            }
            return item;
        }

    }
}