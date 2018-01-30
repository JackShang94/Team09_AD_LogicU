using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ItemService.svc or ItemService.svc.cs at the Solution Explorer and start debugging.
    public class ItemService : IItemService
    {
        ItemDAO itemDAO = new ItemDAO();

        public List<WCFItem> findAll()
        {
            List<WCFItem> targetItemList = new List<WCFItem>();
            List<Item> ilist = itemDAO.getItemList();
            foreach (Item i in ilist)
            {
                WCFItem wcfItem = WCFItem.Make(i.itemID, i.categoryID, i.description,i.location,i.unitOfMeasure,i.reorderLevel,i.reorderQty,i.qtyOnHand);
                targetItemList.Add(wcfItem);
            }
            return targetItemList;
        }

        public List<WCFItem> findItemBySearch(string keyword)
        {
            List<WCFItem> targetItemList = new List<WCFItem>();
            List<Item> ilist = itemDAO.getItemBySearch(keyword);
            foreach(Item i in ilist)
            {
                WCFItem wcfItem = WCFItem.Make(i.itemID, i.categoryID, i.description, i.location, i.unitOfMeasure, i.reorderLevel, i.reorderQty, i.qtyOnHand);
                targetItemList.Add(wcfItem);
            }
            return targetItemList;
        }
    }
}
