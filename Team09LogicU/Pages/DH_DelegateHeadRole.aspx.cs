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
        DateTime operationDate = DateTime.Now;//assume it is the current date

        string logInStaffId;
        string logInRole;
        List<Models.Delegate> dList = new List<Models.Delegate>();
        string deptID;
        DeptStaff headStaff;

        protected void Page_Load(object sender, EventArgs e)
        {        
            logInRole = (string)Session["loginRole"];
            if (logInRole == "head" || logInRole == "outOfOfficeHead")
            {
                logInStaffId = (string)Session["loginID"];
                headStaff = deptStaffDAO.findStaffByID(logInStaffId);
                deptID = headStaff.deptID;
            
                List<Models.Delegate> dList = delegateDAO.findDelegatesByDepartment(deptID);             
                headStaff = deptStaffDAO.findStaffByID(logInStaffId);
                Label_logInRole.Text = headStaff.role;
                if (!IsPostBack)
                {
                    delegateDAO.updateDelegateStatus(dList, operationDate);
                    Label_logInRole.Text = headStaff.role;
                    bindData(deptID);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        private void bindData(string deptID)
        {
            //bind dropdownlist
            List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee(deptID);
            employee_dropList.DataSource = staffList;
            employee_dropList.DataTextField = "staffName";
            employee_dropList.DataValueField = "staffID";
            employee_dropList.DataBind();
            //bind gridview
            dList = delegateDAO.findDelegatesByDepartment(deptID);
            GridView_dHistory.DataSource = dList;
            GridView_dHistory.DataBind();
        }
        protected void submit_button_Click(object sender, EventArgs e)
        {
            string selectedStaffId = employee_dropList.SelectedValue.ToString();
            if (textBox_startDate.Text!=""|| textBox_endDate.Text!="")
            {
                DateTime sDate = Convert.ToDateTime(textBox_startDate.Text);
                DateTime eDate = Convert.ToDateTime(textBox_endDate.Text);
                if (IsValidDate(sDate, eDate))
                {
                    delegateDAO.addDelegate(selectedStaffId,sDate,eDate);
                    bindData(deptID);
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Delegated succussfully!');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please select valid date!');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please select valid date!');</script>");
            }
        }

        protected bool IsValidDate(DateTime sDate,DateTime eDate)
        {
            bool IsValideDate = false;
            if (sDate>operationDate && eDate> sDate)
            {
                IsValideDate = true;
            }
            return IsValideDate;
        }
        protected void terminate_button_Click(object sender, EventArgs e)
        {
            if (GridView_dHistory.SelectedIndex != -1)
            {
                int dID = Convert.ToInt32(GridView_dHistory.SelectedRow.Cells[1].Text.ToString());
                Models.Delegate delegateItem = delegateDAO.findDelegationById(dID);
                if (delegateItem.status == "active" || delegateItem.status == "On delegation")
                {
                    delegateDAO.terminateDelegate(delegateItem);
                    bindData(deptID);
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Successful!');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'This delegation is already inactive!');</script>");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please select at least one delegation!');</script>");
            }
        }

        protected void GridView_dHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                GridView_dHistory.PageIndex = e.NewPageIndex;
                bindData(deptID);
                TextBox tb = (TextBox)GridView_dHistory.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_dHistory.PageIndex + 1).ToString();
        }

        protected void GridView_dHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            { 
                TextBox tb = (TextBox)GridView_dHistory.BottomPagerRow.FindControl("inPageNum");
                if (tb.Text!="")
                {
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_dHistory_PageIndexChanging(null, ea);
                }
            }
        }
    }
}


