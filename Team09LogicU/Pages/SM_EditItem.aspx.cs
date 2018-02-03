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
    public partial class SM_EditItem : System.Web.UI.Page
    {
        ItemDAO iDAO = new ItemDAO();
        CategoryDAO catDAO = new CategoryDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        Item i;
        string itemID;
        string desc;
        string location;
        int reorderLevel;
        int reorderQty;
        string uom;
        List<string> supplierList = new List<string>();
        List<decimal> priceList = new List<decimal>();

        string logInRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            itemID = Request.QueryString["itemID"];
            logInRole = (string)Session["loginRole"];
            if (logInRole == "manager")
            {
                if (!IsPostBack)
                {
                    dropDownList_bindInfo();
                    displayItemInfo(itemID);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void dropDownList_bindInfo()
        {
            List<Supplier> slist1 = supDAO.getSupplierList();
            dropdownlist_Supplier1.DataSource = slist1;
            dropdownlist_Supplier1.DataTextField = "supplierID";
            dropdownlist_Supplier1.DataValueField = "supplierID";
            dropdownlist_Supplier1.DataBind();

            List<Supplier> slist2 = supDAO.getSupplierList();
            dropdownlist_Supplier2.DataSource = slist2;
            dropdownlist_Supplier2.DataTextField = "supplierID";
            dropdownlist_Supplier2.DataValueField = "supplierID";
            dropdownlist_Supplier2.DataBind();

            List<Supplier> slist3 = supDAO.getSupplierList();
            dropdownlist_Supplier3.DataSource = slist3;
            dropdownlist_Supplier3.DataTextField = "supplierID";
            dropdownlist_Supplier3.DataValueField = "supplierID";
            dropdownlist_Supplier3.DataBind();
        } 
        public void displayItemInfo(string itemID)
        {
            i = iDAO.getItemByID(itemID);
            TextBox_itemcode.Text = i.itemID;
            TextBox_category.Text = i.categoryID;
            TextBox_qty.Text = i.qtyOnHand.ToString();

            TextBox_Description.Text = i.description;
            TextBox_location.Text = i.location;
            TextBox_ReorderLevel.Text = i.reorderLevel.ToString();
            TextBox_ReorderQty.Text = i.reorderQty.ToString();

            List<string> slist = supItemDAO.getSupplierByItem(itemID);
            List<decimal> plist = supItemDAO.getPriceByItem(itemID);
            dropdownlist_Supplier1.Text = slist[0];
            dropdownlist_Supplier2.Text = slist[1];
            dropdownlist_Supplier3.Text = slist[2];

            TextBox_price1.Text = plist[0].ToString();
            TextBox_price2.Text = plist[1].ToString();
            TextBox_price3.Text = plist[2].ToString();

        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            if ((TextBox_ReorderLevel.Text =="") || (TextBox_ReorderQty.Text == "") || (TextBox_price1.Text == "") || (TextBox_price2.Text == "") || (TextBox_price3.Text == ""))
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Alert', 'Invalid input！');</script>");
            }
            else
            {
                desc = TextBox_Description.Text;
                location = TextBox_location.Text;
                reorderLevel = Convert.ToInt32(TextBox_ReorderLevel.Text);
                reorderQty = Convert.ToInt32(TextBox_ReorderQty.Text);
                uom = dropdownlist_unitofmeasure.Text;


                iDAO.updateItem(itemID, desc, location, reorderLevel, reorderQty, uom);

                List<string> sl = new List<string>();
                sl.Add(dropdownlist_Supplier1.Text);
                sl.Add(dropdownlist_Supplier2.Text);
                sl.Add(dropdownlist_Supplier3.Text);

                List<decimal> pl = new List<decimal>();
                pl.Add(Convert.ToDecimal(TextBox_price1.Text));
                pl.Add(Convert.ToDecimal(TextBox_price2.Text));
                pl.Add(Convert.ToDecimal(TextBox_price3.Text));

                supItemDAO.updateSupplierItem(itemID, sl, pl);

                Response.Write("<script>alert('Submitted successfully')</script>");
                Response.Redirect("SM_SearchItem.aspx");
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchItem.aspx");
        }
    }
}