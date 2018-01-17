using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.DAO
{
    public class ItemDAO
    {

        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public  List<object> getItemList()
        {

            return m.Items.Select(x => new { x.itemID, x.categoryID, x.location, x.description, x.reorderLevel, x.reorderQty, x.unitOfMeasure, x.qtyOnHand }).ToList<object>();
        }
        

        

    }
}