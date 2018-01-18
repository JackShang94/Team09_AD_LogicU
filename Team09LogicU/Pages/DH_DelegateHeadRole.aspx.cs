using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;

namespace Team09LogicU.pages
{
    public partial class DH_DelegateHeadRole : System.Web.UI.Page
    {
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        DelegateDAO delegateDAO = new DelegateDAO();
        DepartmentDAO deptDAO = new DepartmentDAO();
        string logInStaffId;
        string logInRole;
        string currentHeadId;
        string selectedEmpName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInStaffId = "emp001";//this is assumption
                logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
                if (logInRole == "head")
                {
                    List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee("ZOOL");//assume it is zool department
                    employee_dropList.DataSource = staffList;
                    employee_dropList.DataTextField = "staffName";
                    employee_dropList.DataValueField = "staffID";
                    employee_dropList.DataBind();
                    delegateStf_label.Text = employee_dropList.Text;

                    startDate_textBox.Text = DateTime.Today.ToString();
                    endDate_textBox.Text = DateTime.Today.AddDays(2).ToString();
                }
                else
                {
                    employee_dropList.Visible = false;
                    startDate_textBox.Visible = false;
                    endDate_textBox.Visible = false;
                    delegateStf_label.Text = "You are not allowed to delegate now.";
                    submit_button.Visible = false;

                }
                //delegate history
                string deptId = deptStaffDAO.findStaffByID(logInStaffId).deptID;
                List<Models.Delegate> dList = delegateDAO.findDelegatesByDepartment(deptId);
                delegateHistory_ListBox.DataSource = dList;
                delegateHistory_ListBox.DataTextField = "staffID";
                delegateHistory_ListBox.DataValueField = "delegateID";
                delegateHistory_ListBox.DataBind();


            }
            
        }
        protected void submit_button_Click(object sender, EventArgs e)
        {
            
            string staffId = employee_dropList.SelectedValue;
            DateTime sDate = Convert.ToDateTime(startDate_textBox.Text);
            DateTime eDate = Convert.ToDateTime(endDate_textBox.Text);
            delegateDAO.delegateToStaff(staffId, sDate, eDate);

            currentHeadId =deptStaffDAO.findStaffByID(staffId).Department.headStaffID;
            delegateDAO.disableHead(currentHeadId);
            delegateStatus_Label.Text = "Delegated successfully!";
        }

        protected void terminate_button_Click(object sender, EventArgs e)
        {
            if (logInRole == "outOfOfficeHead")
            {

            }
        }
    }
}