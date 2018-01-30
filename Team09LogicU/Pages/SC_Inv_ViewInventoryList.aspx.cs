using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using System.Data;

namespace Team09LogicU.Pages
{
    public partial class SC_Inv_StockManagement : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
        CategoryDAO catDAO = new CategoryDAO();
        List<Item> itemList;
        DataTable iTable;
        TextBox tb = new TextBox();
        string strPageNum = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownList_bindCatInfo();

                itemList = itemDAO.getItemList();
                showItemInfo(itemList);
            }
            tb.Text = strPageNum;
            UpdateGridviewByDropdownList();
        }

        public void showItemInfo(List<Item> iList)
        {
            iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("Item Code", typeof(string)));
            iTable.Columns.Add(new DataColumn("Description", typeof(string)));
            iTable.Columns.Add(new DataColumn("Unit of Measure", typeof(string)));
            iTable.Columns.Add(new DataColumn("Current Qty", typeof(int)));
            iTable.Columns.Add(new DataColumn("Reorder Level", typeof(int)));
            iTable.Columns.Add(new DataColumn("Reorder Qty", typeof(int)));
            foreach (Item i in iList)
            {
                DataRow dr = iTable.NewRow();
                dr["Item Code"] = i.itemID;
                dr["Description"] = i.description;
                dr["Unit of Measure"] = i.unitOfMeasure;
                dr["Current Qty"] = i.qtyOnHand;
                dr["Reorder Level"] = i.reorderLevel;
                dr["Reorder Qty"] = i.reorderQty;
                iTable.Rows.Add(dr);
            }
            GridView_stock.DataSource = iTable;
            GridView_stock.DataBind();
        }

        public void dropDownList_bindCatInfo()
        {
            List<Category> catList = catDAO.getCategoryList();
            DropDownList_cat.DataSource = catList;
            DropDownList_cat.DataTextField = "description";
            DropDownList_cat.DataValueField = "categoryID";
            DropDownList_cat.AppendDataBoundItems = true;
            DropDownList_cat.Items.Insert(0, new ListItem("--All--"));
            DropDownList_cat.DataBind();
        }

        protected void GridView_stock_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;
            string itemID = GridView_stock.Rows[i].Cells[1].Text.ToString();
            Response.Redirect("SC_Inv_StockCardDetail.aspx?itemID=" + itemID);
        }

        protected void DropDownList_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGridviewByDropdownList();
        }
        protected void UpdateGridviewByDropdownList()
        {
            if (DropDownList_cat.Text == "--All--")
            {
                itemList = itemDAO.getItemList();//all items
            }
            else
            {
                string cat = DropDownList_cat.Text;
                itemList = itemDAO.getItemByCat(cat);//items with specific CAT
            }
            showItemInfo(itemList);
        }
        protected void GridView_stock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_stock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_stock.PageIndex = e.NewPageIndex;
                tb = (TextBox)GridView_stock.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_stock.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                UpdateGridviewByDropdownList();
            }
            catch
            {
            }
        }

        protected void GridView_stock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                tb = (TextBox)GridView_stock.BottomPagerRow.FindControl("inPageNum");
            }
            try
            {              
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView_stock_PageIndexChanging(null, ea);
            }
            catch
            {
            }
        }      
    }
}