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

    public partial class SC_ViewReorderList : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();
        StockCardDAO sDAO = new StockCardDAO();
        List<PurchaseOrder> poCart = new List<PurchaseOrder>();
        List<ReorderCart> reorderCart = new List<ReorderCart>();
        List<ReorderItem> list = new List<ReorderItem>();
        protected void Page_Load(object sender, EventArgs e)
        {

            list = (List<ReorderItem>)Session["finalReorderList"];
            string staffID = (string)Session["loginID"];

            if (Session["finalReorderList"] != null)
            {
                var groupedSupplierList = list.Select(x => x.SupplierID).Distinct().ToList();

                

                for (int i = 0; i < groupedSupplierList.Count; i++)
                {
                    reorderCart.Add(new ReorderCart());
                    reorderCart[i].SupplierID = groupedSupplierList[i].ToString();
                    reorderCart[i].StaffName = storeStaffDAO.getStoreStaffInfoById(staffID).storeStaffName;
                    reorderCart[i].OrderDate = DateTime.Now.ToShortDateString();

                    poCart.Add(new PurchaseOrder());
                    poCart[i].supplierID = reorderCart[i].SupplierID;
                    poCart[i].orderBy = reorderCart[i].StaffName;
                    poCart[i].orderDate = DateTime.Now;
                }

                GridView_reorderListBySup.DataSource = reorderCart;
                GridView_reorderListBySup.DataBind();
            }
        }

        protected void LinkButton_ViewPO_Click(object sender, EventArgs e)
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string supplierID = "";
            if (row != null)
            {
                supplierID = (row.FindControl("lblSupID") as Label).Text;
                Response.Redirect("SC_ShowPurchaseOrder.aspx?supplierID=" + supplierID);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (reorderCart.Count!=0)
            {
                for (int i = 0; i < poCart.Count; i++)
                {
                    PoDAO.CreateNewPO(poCart[i]);//update PO table

                    string supplierID = poCart[i].supplierID;
                    List<ReorderItem> list1 = new List<ReorderItem>();
                    List<PurchaseOrderItem> poItemCart = new List<PurchaseOrderItem>();
                    List<StockCard> sList = new List<StockCard>();

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].SupplierID == supplierID)
                        {
                            list1.Add(list[j]);
                        }
                    }

                    for (int k = 0; k < list1.Count; k++)
                    {
                        poItemCart.Add(new PurchaseOrderItem());
                        poItemCart[k].itemID = list1[k].ItemID;
                        poItemCart[k].quantity = list1[k].OrderQty;
                        poItemCart[k].poID = poCart[i].poID;
                        POItemDAO.CreateNewPOItem(poItemCart[k]);//Update Purchase Order Item table

                        itemDAO.UpdateItemQtyOnHand(poItemCart[k].itemID, poItemCart[k].quantity);//Update Item Table

                        sList.Add(new StockCard());
                        sList[k].itemID = list1[k].ItemID;
                        sList[k].date = poCart[i].orderDate;
                        sList[k].quantity = list1[k].OrderQty;
                        sList[k].balance = itemDAO.GetItemQtyByItemID(list1[k].ItemID);
                        sList[k].record = poCart[i].supplierID;
                        sDAO.CreateNewRecord(sList[k]);

                    }
                }


                Session["finalReorderList"] = null;
                Session["reorderList"] = null;
                GridView_reorderListBySup.DataSource = null;
                GridView_reorderListBySup.DataBind();

                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Success！');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Empty list, please check！');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["finalReorderList"] = null;
            Session["reorderList"] = null;
            Response.Redirect("SC_Inv_ManageReorder.aspx?");
        }
    }
}