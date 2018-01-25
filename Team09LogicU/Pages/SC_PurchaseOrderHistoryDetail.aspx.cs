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
    public partial class SC_PurchaseOrderHistoryDetail : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();
        StockCardDAO sDAO = new StockCardDAO();
        PurchaseOrder po = new PurchaseOrder();
        static int poID;
        protected void Page_Load(object sender, EventArgs e)
        {
            poID = Int32.Parse(Request.QueryString["poID"]);
            if (!IsPostBack)
            {
                po = PoDAO.findPObypoID(poID);
                string orderStaff = po.orderBy;
                string supName = po.Supplier.supplierName;
                DateTime orderDate = po.orderDate;

                lblpoID.Text = Convert.ToString(poID);
                lblSupplierName.Text = supName;
                lblOrderDate.Text = orderDate.ToString("dd/MM/yyyy");
                lblName.Text = orderStaff;                

                BindData();
            }

        }
        public void BindData()
        {
            List<PurchaseOrderItem> PurchaseOrderItemList = POItemDAO.findPOItembypoID(poID);
            List<POItem> poItemList = new List<POItem>();
            decimal total = 0;

            string supID = po.Supplier.supplierID;
            for (int i = 0; i < PurchaseOrderItemList.Count(); i++)
            {
                poItemList.Add(new POItem());
                poItemList[i].ItemID = PurchaseOrderItemList[i].itemID;
                poItemList[i].OrderQty = PurchaseOrderItemList[i].quantity;
                poItemList[i].Description = PurchaseOrderItemList[i].Item.description;
                poItemList[i].Price = supItemDAO.getPriceByItemIDAndSupplierID(PurchaseOrderItemList[i].itemID,supID);
                poItemList[i].TotalAmount = poItemList[i].Price * poItemList[i].OrderQty;
            }
            for (int i = 0; i < poItemList.Count(); i++)
            {
                total = poItemList[i].TotalAmount + total;
            }

            lblTotal.Text = Convert.ToString(total);
            
            GridView_PODetail.DataSource = poItemList;
            GridView_PODetail.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SC_ViewPurchaseOrderHistory.aspx");
        }
    }
}