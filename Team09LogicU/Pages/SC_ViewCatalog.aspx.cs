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
    public partial class SC_ViewCatalog : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        TextBox tb = new TextBox();
        string strPageNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
            tb.Text = strPageNum;
        }

        protected void GridView_CatalogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                tb = (TextBox)GridView_CatalogList.BottomPagerRow.FindControl("inPageNum");
                GridView_CatalogList.PageIndex = e.NewPageIndex;
                tb.Text = (GridView_CatalogList.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                updateGV();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }

        }
        protected void updateGV()
        {
            List<Item> list = new List<Item>();
            string keyword = TextBox_Search.Text;

            if (keyword == "")
            {

                list = itemDAO.getItemList();
            }
            else
            {
                list = itemDAO.getItemBySearch(keyword);
            }
            GridView_CatalogList.DataSource = list;
            GridView_CatalogList.DataBind();
        }

        protected void BindGrid()
        {
            List<Item> itemlist = new List<Item>();
            itemlist = itemDAO.getItemList();
            GridView_CatalogList.DataSource = itemlist;
            GridView_CatalogList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            updateGV();
        }

        protected void GridView_CatalogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "go")
            {
                tb = (TextBox)GridView_CatalogList.BottomPagerRow.FindControl("inPageNum");
            }

            try
            {
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView_CatalogList_PageIndexChanging(null, ea);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }
    }
}