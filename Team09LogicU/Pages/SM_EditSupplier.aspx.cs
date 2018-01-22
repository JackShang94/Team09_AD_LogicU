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
        protected void Page_Load(object sender, EventArgs e)
        {
            supplierID = Request.QueryString["supplier"];
            s = new Supplier();
            s = sDAO.getSupplierByID(supplierID);

            if(!IsPostBack)
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

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            supplierID = TextBox_SupplierCode.Text;
            supplierName = TextBox_SupplierName.Text;
            contactName=TextBox_ContactName.Text;
            fax = TextBox_Fax.Text;
            gstNO = TextBox_GSTRegistrationNo.Text;
            phone = TextBox_Phone.Text;
            address = TextBox_Address.Text;

            sDAO.updateSupplier(supplierID, supplierName, gstNO, address,fax, phone, contactName);
            
            Response.Write("<script>alert('Successfully submitted!')</script>");
            Response.Redirect("SM_SearchSupplier.aspx");
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully Submitted!')", true);

        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_SearchSupplier.aspx");
        }
    }
}