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
            bool isSelected = CheckBox1.Checked;
            if (isSelected)
            {
                //this.DisplayLowStockItem();
            }
            this.BindGrid();
        }

        private void BindGrid()
        {
            List<ReorderItem> reorderList = new List<ReorderItem>();

            reorderList = itemDAO.findItemList();
            GridView_reorderList.DataSource = reorderList;
            GridView_reorderList.DataBind();

        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView_reorderList.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {

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
                    ddlSupplier.DataSource = supItemDAO.findSupplierListByItemID(itemID);
                    ddlSupplier.AppendDataBoundItems = true;
                    ddlSupplier.DataTextField = "supplierID";
                    ddlSupplier.DataValueField = "supplierID";
                    ddlSupplier.DataBind();
                   
                }

            }
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}