using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;

namespace Team09LogicU.pages
{

    public partial class DH_DelegateHeadRole : System.Web.UI.Page
    {
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        DelegateDAO delegateDAO = new DelegateDAO();
        DateTime operationDate = DateTime.Today.AddDays(6);//assume it is the current date
        string logInStaffId;
        string logInRole;
        List<Models.Delegate> dList = new List<Models.Delegate>();
        string deptID;

        protected void Page_Load(object sender, EventArgs e)
        {
            logInStaffId = (string)Session["loginID"];
            deptID = deptStaffDAO.findStaffByID(logInStaffId).deptID;

            if (!IsPostBack)
            {
                delegateDAO.updateStatusAndStaffRoleByDate(operationDate);
                displayStaffToDelegate(deptID);
                displayDelegationListAndRole(deptID);
            }
        }

        //bind staff info data
        public void displayStaffToDelegate(string deptID)
        {
            List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee(deptID);
            employee_dropList.DataSource = staffList;
            employee_dropList.DataTextField = "staffName";
            employee_dropList.DataValueField = "staffID";
            employee_dropList.DataBind();
        }

        //show latest delegation record
        public void displayDelegationListAndRole(string depID)
        {
            dList = delegateDAO.findDelegatesByDepartment(depID);
            GridView_dHistory.DataSource = dList;
            GridView_dHistory.DataBind();
        }

        //show current role
        public void showCurrentRole()
        {
            logInRole = (string)ViewState["logInRole"];
            logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
            ViewState["logInRole"] = logInRole;
            Label_logInRole.Text = ViewState["logInRole"].ToString();

            //int count = (int)ViewState["count"];    // GET
            //count++;
            //Label1.Text = count.ToString();
            //ViewState["count"] = count;              // SET
        }

        //validate the submition
        public bool IsValidSubmition(DateTime sDate, DateTime eDate)
        {
            bool isValid = true;
            //the selected date is valid
            if (sDate < eDate && sDate > operationDate)
            {
                foreach (Models.Delegate d in dList)
                {
                    if ((d.status == "active" || d.status == "On delegation") && (sDate <= d.endDate))
                    {
                        isValid = false;
                    }
                }
            }
            else
            { isValid = false; }
            return isValid;
        }

        protected void submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedStaffId = employee_dropList.SelectedValue.ToString();
                DateTime sDate = Convert.ToDateTime(textBox_startDate.Text);
                DateTime eDate = Convert.ToDateTime(textBox_endDate.Text);

                dList = delegateDAO.findDelegatesByDepartment(deptID);
                if (IsValidSubmition(sDate, eDate))
                {
                    //add a new delegation
                    delegateDAO.delegateToStaff(selectedStaffId, sDate, eDate);
                    Response.Write("<script>alert('Delegated succussfully!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Please select valid date!')</script>");
                }

            }
            catch { Response.Write("<script>alert('Failed to submit!')</script>"); }

            finally
            {
                displayDelegationListAndRole(deptID);
            }
        }

        protected void terminate_button_Click(object sender, EventArgs e)
        {
            if (GridView_dHistory.SelectedIndex != -1)
            {                
                int dID = Convert.ToInt32(GridView_dHistory.SelectedRow.Cells[1].Text.ToString());
                Models.Delegate d = delegateDAO.findDelegationById(dID);
                string status = d.status;
                if (status == "active" || status == "On delegation")
                {
                    delegateDAO.cancelDelegation(dID);                   
                    Response.Write("<script>alert('Successful!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('This delegation is already inactive')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select at least one delegation!')</script>");
            }
            displayDelegationListAndRole(deptID);
        }

        protected void GridView_dHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_dHistory.PageIndex = e.NewPageIndex;
                displayDelegationListAndRole(deptID);
                k
                TextBox tb = (TextBox)GridView_dHistory.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_dHistory.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        protected void GridView_dHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)GridView_dHistory.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_dHistory_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
    }
}


