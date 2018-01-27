using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using System.Globalization;
namespace Team09LogicU.Pages
{
    public partial class SC_RO_DisbursementListHistory_ViewDetail : System.Web.UI.Page
    {
        DisbursementDAO disDAO = new DisbursementDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                string disID_url = Request.QueryString["disID"];
                if (disID_url.ToString() == null)
                {
                    Response.Redirect("SC_RO_DisbursementListHistory.aspx");
                }
               
                int disID = Convert.ToInt32(disID_url);
                disburseItem_HisGridView.DataSource = disDAO.getDisbursementItemByDisID(disID);
                disburseItem_HisGridView.DataBind();
            //}
            backButton.Attributes["href"] = "javascript:history.go(-1)";
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}