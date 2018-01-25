using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.Pages
{
    public partial class SM_SearchItem : System.Web.UI.Page
    {
        ItemDAO iDAO = new ItemDAO();
        List<Item> iList = new List<Item>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iList = iDAO.getItemList();
                showItemListInfo();
            }
        }
        public void showItemListInfo()
        {
            GridView_itemList.DataSource = iList;
            GridView_itemList.DataBind();
        }
        protected void Button_search_Click(object sender, EventArgs e)
        {
            string keyword = textbox_Search.Text;
            iList = iDAO.getItemBySearch(keyword);
            showItemListInfo();
        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_AddItem.aspx");
        }


        protected void GridView_itemList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;
            string itemID = GridView_itemList.Rows[i].Cells[1].Text.ToString();
            Response.Redirect("SM_EditItem.aspx?itemID=" + itemID);
        }
    }
}