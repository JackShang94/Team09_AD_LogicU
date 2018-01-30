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
    public partial class SC_Inv_StockCardDetail : System.Web.UI.Page
    {
        StockCardDAO scDAO = new StockCardDAO();
        ItemDAO iDAO = new ItemDAO();
        string itemID;
        Item i;
        List<StockCard> sList;
        protected void Page_Load(object sender, EventArgs e)
        {
            itemID = Request.QueryString["itemID"];
            showStockInfo(itemID);
        }

        public void showStockInfo(string itemID)
        {
            i = iDAO.getItemByID(itemID);
            label_itemcode.Text = i.itemID;
            label_description.Text = i.description;
            label_measure.Text= i.unitOfMeasure;
            sList = scDAO.getStockCardByItem(itemID);
            GridView_ItemStock.DataSource = sList;
            GridView_ItemStock.DataBind();

        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SC_Inv_ViewInventoryList.aspx");
        }
    }
}