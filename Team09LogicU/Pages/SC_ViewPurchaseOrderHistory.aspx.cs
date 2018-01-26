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

            List<string> supNameList = new List<string>();
            foreach (Supplier s in supplierList)
            {
                supNameList.Add(s.supplierName);
            }

            ddlSupplier.Items.Clear();
            ddlSupplier.DataSource = supNameList;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridBasedOnSearch();
        }

        protected void BindGridBasedOnSearch()
        {
            List<PurchaseOrder> POList = new List<PurchaseOrder>();
            string supplierName = ddlSupplier.Text;
            string from = txtFrom.Text;
            string to = txtTo.Text;

            if ((from == "" || to == "") && supplierName == "---Select Supplier---")
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please input search condition！');</script>");
                POList = PoDAO.findPOList();
            }

            if (supplierName == "---Select Supplier---" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                POList = PoDAO.findPOByDate(dateFrom, dateTo);
            }
            if ((from == "" || to == "") && supplierName != "---Select Supplier---")
            {
                string supID = supDAO.findSupplierByName(supplierName).supplierID;
                POList = PoDAO.findPOBySupplierID(supID);
            }
            if (from != "" && to != "" && supplierName != "---Select Supplier---")
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                string supID = supDAO.findSupplierByName(supplierName).supplierID;
                POList = PoDAO.findPOByDateAndSupID(dateFrom, dateTo, supID);
            }

            GridView_PurchaseOrder.DataSource = POList;
            GridView_PurchaseOrder.DataBind();
        }

        protected void LinkButton_View_Click(object sender, EventArgs e) 
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string poID = "";
            if (row != null)
            {
                poID = (row.FindControl("lblpoID") as Label).Text;
                Response.Redirect("SC_PurchaseOrderHistoryDetail.aspx?poID=" + poID);
            }
        }


    }
}