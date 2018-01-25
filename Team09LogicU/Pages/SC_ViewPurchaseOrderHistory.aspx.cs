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
    public partial class SC_ViewPurchaseOrderHistory : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();
        StockCardDAO sDAO = new StockCardDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDDL();
                this.BindGrid();
            }
        }

        protected void BindDDL()
        {
            List<Supplier> supplierList = new List<Supplier>();
            supplierList = supDAO.getSupplierList();

            ddlSupplier.Items.Clear();
            ddlSupplier.DataSource = supplierList;
            ddlSupplier.AppendDataBoundItems = true;
            ddlSupplier.Items.Insert(0, new ListItem("---Select Supplier---"));
            ddlSupplier.DataBind();
        }

        protected void BindGrid()
        {
            List<PurchaseOrder> POList = new List<PurchaseOrder>();
            POList = PoDAO.findPOList();
            GridView_PurchaseOrder.DataSource = POList;
            GridView_PurchaseOrder.DataBind();
        }

    }
}