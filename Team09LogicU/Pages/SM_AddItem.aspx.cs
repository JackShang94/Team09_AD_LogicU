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
    public partial class SM_AddItem : System.Web.UI.Page
    {
        ItemDAO iDAO = new ItemDAO();
        CategoryDAO catDAO = new CategoryDAO();
        SupplierDAO supDAO = new SupplierDAO();
        string itemID;
        string desc;
        string location;
        string category;
        int reorderLevel;
        int reorderQty;
        string uom;
        int qtyOnHand;
        List<string> supplierList = new List<string>();
        List<decimal> priceList = new List<decimal>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dropDownList_bindInfo();
            }
        }

        public void dropDownList_bindInfo()
        {
            List<Category> catList = catDAO.getCategoryList();
            dropdownlist_Catagory.DataSource = catList;
            dropdownlist_Catagory.DataTextField = "description";
            dropdownlist_Catagory.DataValueField = "categoryID";
            dropdownlist_Catagory.DataBind();

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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_ItemNumber.Text != "")
                {
                    itemID = TextBox_ItemNumber.Text;
                    desc = TextBox_Description.Text;
                    location = TextBox_location.Text;
                    category = dropdownlist_Catagory.Text;
                    reorderLevel = Convert.ToInt32(TextBox_ReorderLevel.Text);
                    reorderQty = Convert.ToInt32(TextBox_ReorderQty.Text);
                    uom = dropdownlist_unitofmeasure.Text;
                    qtyOnHand = Convert.ToInt32(TextBox_qty.Text);

                    supplierList.Add(dropdownlist_Supplier1.Text);
                    supplierList.Add(dropdownlist_Supplier2.Text);
                    supplierList.Add(dropdownlist_Supplier3.Text);

                    priceList.Add(Convert.ToDecimal(TextBox_price1.Text));
                    priceList.Add(Convert.ToDecimal(TextBox_price2.Text));
                    priceList.Add(Convert.ToDecimal(TextBox_price3.Text));
                    //iDAO.addItem(itemID, desc, location, category, priceList, reorderLevel, reorderQty, uom, supplierList, qtyOnHand);
                    Response.Write("<script>alert('Successfully submitted!')</script>");
                    //Response.Redirect("SM_SearchItem.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Item code can't be empty!')</script>");
                }
            }

            catch
            {
                Label1.Text = "Error";
                Response.Write("<script>alert('Item Code already exists!')</script>");
            }


        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchItem.aspx");
        }
    }
}