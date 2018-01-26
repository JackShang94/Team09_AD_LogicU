using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

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
                //lblMessage.Text = "Access Denied!";
                //Label1.Visible = false;
                //Label2.Visible = false;
                //Label3.Visible = false;
                //lblCurrentCP.Visible = false;
                //ddlCP.Visible = false;
                //btnUpdateCP.Visible = false;
            }
        }

        public void DisplayDepartmentDisbursementList(string logInDept)
        {
            /*Display specific department disbursement history*/

            List<Disbursement> dList = new List<Disbursement>();

            dList = dDAO.deptDisbursementHistory(logInDept);

            deptDisbursementList.DataSource = dList;
            //ddlCP.AppendDataBoundItems = true;
            //ddlCP.Items.Insert(0, new ListItem("---Select Collection Point---"));
            deptDisbursementList.DataBind();

        }

        protected void deptDisbursementList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void LinkButton_View_Click(object sender, EventArgs e)
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            //string poID = "";
            //if (row != null)
            //{
            //    poID = (row.FindControl("lblpoID") as Label).Text;
            //    Response.Redirect("SC_PurchaseOrderHistoryDetail.aspx?poID=" + poID);
            //}
        }
    }
}