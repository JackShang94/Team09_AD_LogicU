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
    public partial class SC_Inv_AdjustmentVoucher : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
         
        public string staffID;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {
                this.BindGrid();


                string name = Session["loginID"].ToString();
                this.staffID = name;

                List<cart> lc = new List<cart>();

                foreach (var i in (List<cart>)Session["cart"])
                {
                    if (i.Name == name)
                    {
                        lc.Add(i);
                    }
                }
            }
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
            List<Item> list = new List<Item>();

            string itemID = textbox_Search.Text;

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
        protected void GridView_CatalogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Add")
            {
                string itemid  = e.CommandArgument.ToString();
                label.Text = itemid;
            }
        }
        protected void Btn_Adjvlist_Click(object sender, EventArgs e)
        {

            int i = 1;//test
            string name = this.staffID;
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];
            if (lc.Count > 0)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();

                adjvdao.addAdjustmentVoucher(i,name,DateTime.Now);

                lc = new List<cart>();//clear the cart session
                Session["cart"] = lc;
                HttpContext.Current.Response.Redirect("SC_Inv_AdjVoucherDetail.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('Nothing in cart')", true);
                return;
            }
        }
    }
}