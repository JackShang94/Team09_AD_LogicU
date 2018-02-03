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
    public partial class SM_EditSupplier : System.Web.UI.Page
    {
        SupplierDAO sDAO = new SupplierDAO();
        Supplier s;
        string supplierID;
        string supplierName;
        string contactName;
        string fax;
        string gstNO;
        string phone;
        string address;

        string logInRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            supplierID = Request.QueryString["supplier"];
            s = new Supplier();
            s = sDAO.getSupplierByID(supplierID);

            logInRole = (string)Session["loginRole"];
            if (logInRole == "manager")
            {
                if (!IsPostBack)
                {
                    TextBox_SupplierCode.Text = supplierID;
                    TextBox_SupplierName.Text = s.supplierName;
                    TextBox_ContactName.Text = s.contactName;
                    TextBox_Fax.Text = s.fax;
                    TextBox_GSTRegistrationNo.Text = s.gstRegistrationNo;
                    TextBox_Phone.Text = s.phone;
                    TextBox_Address.Text = s.address;
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if ( (TextBox_GSTRegistrationNo.Text.Trim() == "")  || (TextBox_ContactName.Text.Trim() == "") || (TextBox_Address.Text.Trim() == "") || (TextBox_Fax.Text.Trim() == "") || (TextBox_Phone.Text.Trim() == ""))
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Alert', 'Invalid input!');</script>");

            }
            else
            {
                contactName = TextBox_ContactName.Text;
                fax = TextBox_Fax.Text;
                gstNO = TextBox_GSTRegistrationNo.Text;
                phone = TextBox_Phone.Text;
                address = TextBox_Address.Text;

                sDAO.updateSupplier(supplierID, gstNO, address, fax, phone, contactName);

                Response.Write("<script>alert('Successfully submitted!')</script>");
                Response.Redirect("SM_SearchSupplier.aspx");
            }
          
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchSupplier.aspx");
        }
    }
}