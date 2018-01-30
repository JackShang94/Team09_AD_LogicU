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
        public  List<Item> getItemList()
        {
            return m.Items.ToList<Item>();
           // return m.Items.Select(x => new { x.itemID, x.categoryID, x.location, x.description, x.reorderLevel, x.reorderQty, x.unitOfMeasure, x.qtyOnHand }).ToList<object>();
        }

        public List<ReorderItem> findItemList()
        {
            List<ReorderItem> list = m.Items.OrderBy(x => x.itemID).
                Select(x => new ReorderItem { ItemID = x.itemID, Description = x.description, UnitOfMeasure = x.unitOfMeasure,
                    QtyOnHand = x.qtyOnHand, ReorderLevel = x.reorderLevel, ReorderQty = x.reorderQty
                }).ToList<ReorderItem>();
            return list;

        }
       
        public void addItem(string itemID,string desc,string location,string category,List<decimal> pList,int reorderLevel,int reorderQty,string uom,List<string> sup,int qty)
        {
            Item i = new Item();
          
            i.itemID = itemID;
            i.description = desc;
            i.location = location;
            i.categoryID = category;
            i.reorderLevel = reorderLevel;
            i.reorderQty = reorderQty;
            i.unitOfMeasure = uom;
            i.qtyOnHand = qty;
            m.Items.Add(i);
            
            
            for(var j=0;j<sup.Count; j++)
            {
                SupplierItem si = new SupplierItem();
                si.supplierID = sup[j];
                si.itemID = itemID;
                si.price = pList[j];
                si.preferenceRank =( j + 1).ToString();
                m.SupplierItems.Add(si);
            }
            m.SaveChanges();

       
        }

        public List<Item> getItemByitemID(string itemID)
        {
            return m.Items.Where(x=>x.itemID==itemID).ToList<Item>();
        }
        
        public List<Item> getItemByDesc(string desc)
        {
            if (!String.IsNullOrWhiteSpace(desc))
            {
                return m.Items.Where(x => x.description.ToLower().Contains(desc.ToLower())).ToList<Item>();
            }
            return new List<Item>();
           
        }
        public string getDescByItemID(string itemID)
        {
            var a= m.Items.Where(x => x.itemID == itemID);
            if (a!=null)
            {
                return a.Select(x => x.description).First().ToString();
            }
            return "";
        }
        public List<Item> getItemByCat(string category)
        {
            return m.Items.Where(x => x.Category.description == category).ToList<Item>();
        }
        public List<Item> getItemByCategory(string category)
        {
            return m.Items.Where(x => x.Category.categoryID == category).ToList<Item>();
        }
        public Item getItemByID(string itemID)
        {
            Item i = new Item();
            List<Item> iList = m.Items.Where(x => x.itemID == itemID).ToList<Item>();
            if (iList.Count() > 0)
            {
                i = iList.First();
            }
            return i;
        }


        public void UpdateItemQtyOnHand(string itemID, int qty)
        {
            List<Item> list = m.Items.Where(x => x.itemID == itemID).ToList<Item>();
            Item i = new Item();
            if (list.Count() > 0)
            {
                i = list.First();
            }
            i.qtyOnHand = i.qtyOnHand + qty;
            m.SaveChanges();
        }

        public void updateStockCardAndItemQuantity(List<AdjustmentVoucherItem> adjlist)
        {
            foreach (AdjustmentVoucherItem breakitem in adjlist)
            {
               
                    //update item quantity
                    Item item;
                    List<Item> itemlist = m.Items.Where(x => x.itemID == breakitem.itemID).ToList();
                    if (itemlist.Count > 0)// not null
                    {
                        item = itemlist.First();
                        item.qtyOnHand = item.qtyOnHand + breakitem.quantity;
                        //update stock card
                        StockCard st = new StockCard();
                        st.itemID = breakitem.itemID;
                        st.date = DateTime.Now;
                        st.quantity = breakitem.quantity;
                        st.balance = item.qtyOnHand;
                        st.record = breakitem.record;

                        m.StockCards.Add(st);
                    }
                
            }
            m.SaveChanges();
        }


        public int GetItemQtyByItemID(string itemID)
        {
            Item i = new Item();
            List<Item> iList = m.Items.Where(x => x.itemID == itemID).ToList<Item>();
            if (iList.Count() > 0)
            {
                i = iList.First();
            }
            int qty = i.qtyOnHand;
            return qty;
        }
         public List<Item> getItemBySearch(string keyword)
        {
            return m.Items.Where(x => x.itemID.Contains(keyword) || x.categoryID.Contains(keyword)
                                                                 || x.description.Contains(keyword)).ToList();
        }

        public void updateItem(string itemID, string desc, string location, int reorderLevel, int reorderQty, string uom)
        {
            Item i = new Item();
            List<Item> ilist = m.Items.Where(x => x.itemID == itemID).ToList();
            if(ilist.Count()>0)
            {
                i = ilist.First();
                i.description = desc;
                i.location = location;
                i.reorderLevel = reorderLevel;
                i.reorderQty = reorderQty;
                i.unitOfMeasure = uom;
            }
            m.SaveChanges();
        }
        //public List<string> getDescListByItemIDList(List<string> itemID)
        //{
        //    List<string> ldesc = new List<string>();
        //    //m.Items.Where(x=>x.itemID == itemID)
        //    //from d in m.RequisitionItems
        //    //join e in m.Items
        //    //m.RequisitionItems.GroupJoin(
        //    //    m.Items,
        //    //    item => item.item_ID,
        //    //    ritem => ritem.item_ID,
        //    //    (x, y) => new { ritem = x, item = y })
        //    //    .SelectMany(
        //    //      x => x.item
        //    //    )
        //}
        //public List<Item> getRecentItemList(string staffID) //used by requisition think u may need
        //{
        //    //Requisition r = new Requisition();
        //    //RequisitionDAO rdao = new RequisitionDAO();
        //    //List<Requisition> lr = new List<Requisition>();
        //    //lr =rdao.getRequisitionByStaffID(staffID);
        //    //m.RequisitionItems
        //    //string itemID = m.RequisitionItems.Where(y=>y.).Select(x => new { x.itemID }).Take(5);

        //    //return m.Items.OrderBy(x=>x.).Select(x=>x.).ToList<Item>();
        //}

    }
}