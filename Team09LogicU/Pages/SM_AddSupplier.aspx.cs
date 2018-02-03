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

        string logInRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            logInRole = (string)Session["loginRole"];
            if (logInRole != "manager")
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if ((TextBox_SupplierCode.Text.Trim() == "")||(TextBox_GSTRegistrationNo.Text.Trim() == "")||(TextBox_SupplierName.Text.Trim() == "")||(TextBox_ContactName.Text.Trim() == "")||(TextBox_Address.Text.Trim() == "")||(TextBox_Fax.Text.Trim() == "")||(TextBox_Phone.Text.Trim() == ""))
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Alert', 'Invalid input!');</script>");

            }
            else {
                supplierCode = TextBox_SupplierCode.Text;
                supplierName = TextBox_SupplierName.Text;
                gstRegistrationNo = TextBox_GSTRegistrationNo.Text;
                address = TextBox_Address.Text;
                fax = TextBox_Fax.Text;
                phone = TextBox_Phone.Text;
                contactName = TextBox_ContactName.Text;

                try
                {
                    supplierDAO.addSupplier(supplierCode, supplierName, gstRegistrationNo, address, fax, phone, contactName);
                    Response.Write("<script>alert('Successfully submitted!')</script>");
                    Response.Redirect("SM_SearchSupplier.aspx");
                }
                catch
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Alert', 'Supplier Code already exists');</script>");
                }
               
               
               }


        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchSupplier.aspx");
        }
    }
}