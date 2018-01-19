using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;

namespace Team09LogicU.Pages
{
    public partial class SM_AddSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SupplierDAO supplierDAO = new SupplierDAO();
            string supplierCode="";
            string supplierName= "";
            string gstRegistrationNo= "";
            string address= "";
            string fax= "";
            string phone= "";
            string contactName= "";
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_Clear_Click(object sender, EventArgs e)
        {

        }
    }
}