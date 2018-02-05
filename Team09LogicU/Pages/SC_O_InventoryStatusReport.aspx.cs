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
    public partial class SC_O_InventoryStatusReport : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
        StockCardDAO stockCardDAO = new StockCardDAO();
        string TableData;
        TextBox tb = new TextBox();
        string strPageNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        protected void inventoryStatusGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label s = InventoryStatusGridView.SelectedRow.FindControl("ItemID") as Label;
            string itemID = s.Text;
            TableData = getStockCardData(itemID);
            chartData.InnerHtml = "<script>var chart1Data =" + TableData + ";</script>";
        }
        protected void BindGridView()
        {
           List<Item> itemList =  itemDAO.getItemList();
            InventoryStatusGridView.DataSource = itemList;
            InventoryStatusGridView.DataBind();
        }

        protected string getStockCardData(string itemID)
        {
           List<StockCard> cardList =   stockCardDAO.getStockCardByItem(itemID);

            string data = "[" +
            "['Date', 'Balance'],";
            foreach (StockCard item in cardList)
            {
                data = data + "['" + item.date + "'," + item.balance + "],";
            }
            return data = data + "]";
        }

        protected void InventoryStatusGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {               
                tb = (TextBox)InventoryStatusGridView.BottomPagerRow.FindControl("inPageNum");
                InventoryStatusGridView.PageIndex = e.NewPageIndex;
                tb.Text = (InventoryStatusGridView.PageIndex + 1).ToString();
                strPageNum = tb.Text;
               BindGridView();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }

        protected void InventoryStatusGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                tb = (TextBox)InventoryStatusGridView.BottomPagerRow.FindControl("inPageNum");

            }
            try
            {

                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                InventoryStatusGridView_PageIndexChanging(null, ea);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }
    }
}