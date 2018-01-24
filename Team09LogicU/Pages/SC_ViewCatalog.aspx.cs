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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //this.BindDDL();
                this.BindGrid();
            }
        }

        //protected void BindDDL()
        //{

        //    //List<Category> categorylist = categoryDAO.getCategoryList();
        //    //List<string> catalog = new List<string>();
        //    //foreach (Category c in categorylist)
        //    //{
        //    //    catalog.Add(c.categoryID);
        //    //}
        //    //ddlCategory.Items.Clear();
        //    //ddlCategory.DataSource = catalog;
        //    //ddlCategory.AppendDataBoundItems = true;
        //    ddlCategory.Items.Insert(0, new ListItem("---Select Catagory---"));
        //    ddlCategory.DataBind();
        //}
        protected void GridView_CatalogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_CatalogList.PageIndex = e.NewPageIndex;
            this.BindGrid();
           
        }

        protected void BindGrid()
        {
           // string itemID = itemDAO.getItemByitemID(ddlCategory.ToString()).ToString();
            List<Item> itemlist = new List<Item>();
            //itemlist = itemDAO.getItemByitemID(itemID);
            //itemlist = itemDAO.getItemByitemID(TextBox_SearchByID.ToString());
            itemlist = itemDAO.getItemList();
            GridView_CatalogList.DataSource = itemlist;
            GridView_CatalogList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            List<Item> list = new List<Item>();

            string itemID = TextBox_SearchByID.Text;

            if (itemID == "")
            {

                list = itemDAO.getItemList();
            }
            else
            {
                list = itemDAO.getItemByitemID(itemID);
            }
            GridView_CatalogList.DataSource = list;
            GridView_CatalogList.DataBind();
        }
    }
}