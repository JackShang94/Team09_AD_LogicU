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
    public partial class SC_Inv_ManageReorder : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitBindGrid();
            }
            else
            {
                BindGrid();
            }
        }

        private void InitBindGrid()
        {
            List<ReorderItem> list = new List<ReorderItem>();
            list = itemDAO.findItemList();

            ReorderItem item = new ReorderItem();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                item = list[i];
                if (item.ReorderLevel <= item.QtyOnHand)
                {
                    list.RemoveAt(i);
                }
            }

            System.Web.HttpContext.Current.Session["reorderList"] = list;

            GridView_reorderList.DataSource = list;
            GridView_reorderList.DataBind();
        }

        private void BindGrid()
        {
            List<ReorderItem> list = new List<ReorderItem>();
            list = (List<ReorderItem>)System.Web.HttpContext.Current.Session["reorderList"];
            GridView_reorderList.DataSource = list;
            GridView_reorderList.DataBind();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_reorderList.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView_reorderList.Rows[e.RowIndex];
            string itemID = (GridView_reorderList.DataKeys[e.RowIndex].Values[0]).ToString();
            string supplierID = (row.FindControl("ddlSuppliers") as DropDownList).SelectedItem.Value;
            int orderQty = Int32.Parse((row.FindControl("txtOrderQty") as TextBox).Text);

            List<ReorderItem> reorderList = new List<ReorderItem>();
            reorderList = (List<ReorderItem>)System.Web.HttpContext.Current.Session["reorderList"];

            foreach (ReorderItem rItem in reorderList)
            {
                if (rItem.ItemID == itemID)
                {
                    rItem.OrderQty = orderQty;
                    rItem.SupplierID = supplierID;
                }
            }

            System.Web.HttpContext.Current.Session["reorderList"] = reorderList;

            GridView_reorderList.EditIndex = -1;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_reorderList.EditIndex = -1;
            BindGrid();
        }
       
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    string itemID = (e.Row.FindControl("lblItemID") as Label).Text;
                    DropDownList ddlSupplier = e.Row.FindControl("ddlSuppliers") as DropDownList;
                    List<SupplierItem> list = new List<SupplierItem>();
                    list = supItemDAO.findSupplierListByItemID(itemID);

                    var q = list.Select(p =>
                    new { supplierID = p.supplierID, DisplayText = p.supplierID.ToString() + "---$" + p.price });

                    ddlSupplier.AppendDataBoundItems = true;
                    ddlSupplier.DataSource = q;
                    ddlSupplier.DataValueField = "supplierID";
                    ddlSupplier.DataTextField = "DisplayText";
                    ddlSupplier.DataBind();
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("SC_ViewReorderReport.aspx");
        }
    }

}