using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class StockCardDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        //find all stock record
        public List<StockCard> getAllStockCard()
        {
            List<StockCard> sList = context.StockCards.ToList<StockCard>();
            return sList;
        }

        //search stock card by item category
        public List<StockCard> getStockCardByCat(string cat)
        {
            List<StockCard> sList = context.StockCards.Where(x => x.Item.Category.description == cat).ToList<StockCard>();
            return sList;
        }

        //search stock card by items
        public List<StockCard> getStockCardByItem(string itemID)
        {
            List<StockCard> sList = context.StockCards.Where(x => x.itemID==itemID).ToList<StockCard>();
            return sList;
        }
    }
}