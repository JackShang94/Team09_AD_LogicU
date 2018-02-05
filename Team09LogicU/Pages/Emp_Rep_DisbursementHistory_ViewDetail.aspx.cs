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
    public partial class Emp_Rep_DisbursementHistory_ViewDetail : System.Web.UI.Page
    {
        DisbursementDAO dDAO = new DisbursementDAO();
        DepartmentDAO deptDAO = new DepartmentDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        string logInStaffId;
        string logInRole;
        string logInDept;
        string matchingDept;
        static int disID;

        protected void Page_Load(object sender, EventArgs e)
        {
            disID = Int32.Parse(Request.QueryString["disbursementID"]);
            if (!IsPostBack)
            {
                logInStaffId = (string)Session["loginID"];

                /*Set the role and dept from login info*/

                logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
                logInDept = deptStaffDAO.findStaffByID(logInStaffId).deptID;
                matchingDept = dDAO.getDisbursmentbyId(disID).deptID;

                if (logInRole == "rep" && logInDept == matchingDept)
                {
                    DisplaySelectedDisbursementDetails(disID);
                }
            }
        }

        public void DisplaySelectedDisbursementDetails(int distributionID)
        {
            List<DisbursementCart> dCart = new List<DisbursementCart>();
            dCart = dDAO.getDisbursementItemByDisID(distributionID);
            disbursementDetail.DataSource = dCart;
            disbursementDetail.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Emp_Rep_DisbursementHistory.aspx");
        }
    }
}