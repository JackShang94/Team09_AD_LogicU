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
    public partial class SM_AddSupplier : System.Web.UI.Page
    {
        SupplierDAO supplierDAO = new SupplierDAO();
        Supplier s = new Supplier();
        string supplierCode = "";
        string supplierName = "";
        string gstRegistrationNo = "";
        string address = "";
        string fax = "";
        string phone = "";
        string contactName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            supplierCode = TextBox_SupplierCode.Text;
            supplierName = TextBox_SupplierName.Text;
            gstRegistrationNo = TextBox_ContactName.Text;
            address = TextBox_Address.Text;
            fax =TextBox_Fax.Text;
            phone =TextBox_Phone.Text;
            contactName = TextBox_ContactName.Text;

            supplierDAO.addSupplier(supplierCode, supplierName, gstRegistrationNo, address, fax, phone, contactName);

            Response.Write("<script>alert('Successfully submitted!')</script>");
            Response.Redirect("SM_SearchSupplier.aspx");
        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {
            TextBox_SupplierCode.Text = "";
            TextBox_SupplierName.Text = "";
            TextBox_ContactName.Text = "";
            TextBox_GSTRegistrationNo.Text = "";
            TextBox_Phone.Text = "";
            TextBox_Fax.Text = "";
            TextBox_Address.Text = "";
        }
    }
}