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
    }
}