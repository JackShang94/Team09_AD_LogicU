using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.Pages
{
    public partial class SC_PrintPurchaseOrder : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ReorderItem> list = new List<ReorderItem>();
            list = (List<ReorderItem>)System.Web.HttpContext.Current.Session["finalReorderList"];
            string supplierID = Request.QueryString["supplierID"];

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].SupplierID != supplierID)
                {
                    list.RemoveAt(i);
                }
            }

            List<POItem> POList = new List<POItem>();
            SupplierItem SupItem = new SupplierItem();
            Item item = new Item();
            for (int i = 0; i < list.Count; i++)
            {
                string itemID = list[i].ItemID;
                SupItem = supItemDAO.findSupplierItemByItemIDAndSupplier(itemID,supplierID);
                item = itemDAO.getItemByID(itemID);
                POList.Add(new POItem());
                POList[i].ItemID = itemID;
                POList[i].Description = item.description;
                POList[i].OrderQty = list[i].OrderQty;
                POList[i].Price = SupItem.price;
                POList[i].TotalAmount = (POList[i].Price) * (POList[i].OrderQty);
            }
           
            GridView_PurchaseOrder.DataSource = POList;
            GridView_PurchaseOrder.DataBind();

        }
    }
}