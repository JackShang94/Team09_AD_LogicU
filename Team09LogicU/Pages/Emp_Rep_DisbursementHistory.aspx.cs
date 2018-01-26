using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.pages
{
    public partial class Emp_Rep_RequisitionHistory : System.Web.UI.Page
    {
        DepartmentDAO deptDAO = new DepartmentDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        DisbursementDAO dDAO = new DisbursementDAO();
        string logInStaffId;
        string logInRole;
        string logInDept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInStaffId = (string)Session["loginID"];

            /*Set the role and dept from login info*/

                logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
                logInDept = deptStaffDAO.findStaffByID(logInStaffId).deptID;

                if (logInRole == "rep")
                {
                    DisplayDepartmentDisbursementList(logInDept);
                }
                else
                {
                    lblMessage.Text = "Access Denied!";

                }
            }
        }

        public void DisplayDepartmentDisbursementList(string logInDept)
        {
            /*Display specific department disbursement history*/

            List<Disbursement> dList = new List<Disbursement>();

            dList = dDAO.deptDisbursementHistory(logInDept);

            deptDisbursementList.DataSource = dList;
            deptDisbursementList.DataBind();

        }

        protected void LinkButton_View_Click(object sender, EventArgs e)
        {
            /*Sends viewer to the specific disbursment detail page*/
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string disbursementID = "";
            if (row != null)
            {
                disbursementID = (row.FindControl("disbID") as Label).Text;
                Response.Redirect("Emp_Rep_DisbursementHistory_ViewDetail.aspx?disbursementID=" + disbursementID);
            }
        }

        protected void deptDisbursementList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}