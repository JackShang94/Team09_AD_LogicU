using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class PurchaseOrderItemDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public void CreateNewPOItem(PurchaseOrderItem poItem)
        {
            m.PurchaseOrderItems.Add(poItem);
            m.SaveChanges();
        }
    }
}