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
            if (TextBox_SupplierCode.Text != "")
            {
                supplierCode = TextBox_SupplierCode.Text;
                supplierName = TextBox_SupplierName.Text;
                gstRegistrationNo = TextBox_ContactName.Text;
                address = TextBox_Address.Text;
                fax = TextBox_Fax.Text;
                phone = TextBox_Phone.Text;
                contactName = TextBox_ContactName.Text;

                try
                {
                    supplierDAO.addSupplier(supplierCode, supplierName, gstRegistrationNo, address, fax, phone, contactName);
                }
                catch
                {
                    Response.Write("<script>alert('Supplier Code already exists!')</script>");
                }
                Response.Write("<script>alert('Successfully submitted!')</script>");
                Response.Redirect("SM_SearchSupplier.aspx");
            }
            else { Response.Write("<script>alert('Supplier code can't be empty!')</script>"); }


        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchSupplier.aspx");
        }
    }
}