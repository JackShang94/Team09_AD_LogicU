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

    public partial class SC_ViewReorderReport : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<ReorderItem> list = new List<ReorderItem>();
            list = (List<ReorderItem>)System.Web.HttpContext.Current.Session["reorderList"];

            string staffID = (string)Session["loginID"];

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].OrderQty == 0)
                {
                    list.RemoveAt(i);
                }
            }

            System.Web.HttpContext.Current.Session["finalReorderList"] = list;

            var groupedSupplierList = list.Select(x => x.SupplierID).Distinct().ToList();
            
            List<ReorderCart> reorderCart = new List<ReorderCart>();
            for (int i = 0; i < groupedSupplierList.Count; i++)
            {
                reorderCart.Add(new ReorderCart());
                reorderCart[i].SupplierID = groupedSupplierList[i].ToString();
                reorderCart[i].StaffName = storeStaffDAO.getStoreStaffInfoById(staffID).storeStaffName;              
                reorderCart[i].OrderDate =DateTime.Now.ToShortDateString();
            }


            GridView_reorderListBySup.DataSource = reorderCart;
            GridView_reorderListBySup.DataBind();
        }

        protected void LinkButton_ViewPO_Click(object sender, EventArgs e)  
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string supplierID = "";
            if (row != null)
            {
                supplierID = (row.FindControl("lblSupID") as Label).Text;
                Response.Redirect("SC_PrintPurchaseOrder.aspx?supplierID=" + supplierID);
            }
        }

        protected void btnReorderReport_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}