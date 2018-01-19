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
        
        string logInStaffId="head003";              //assumption
        string logInRole;
        string currentHeadId;
        public List<Models.Delegate> dList;

        protected void Page_Load(object sender, EventArgs e)
        {
            string deptId = deptStaffDAO.findStaffByID(logInStaffId).deptID;
            logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
            Label1.Text = logInRole;
            if (!IsPostBack)
            {
                if (logInRole == "head")
                {
                    List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee(deptId);//assume it is zool department
                    employee_dropList.DataSource = staffList;
                    employee_dropList.DataTextField = "staffName";
                    employee_dropList.DataValueField = "staffID";
                    employee_dropList.DataBind();
                    delegateStf_label.Text = employee_dropList.Text;

                    textBox_startDate.Text = DateTime.Today.ToString();
                    textBox_endDate.Text = DateTime.Today.AddDays(2).ToString();
                }
                else
                {
                    employee_dropList.Visible = false;
                    textBox_startDate.Visible = false;
                    textBox_endDate.Visible = false;
                    delegateStf_label.Text = "You are not allowed to delegate now.";
                    submit_button.Visible = false;
                }
            }
            //delegate history
             dList = delegateDAO.findDelegatesByDepartment(deptId);
            //ListBox_delegateHistory.DataSource = dList;
            //ListBox_delegateHistory.DataMember = "Delegate";
            //ListBox_delegateHistory.DataTextField = "staffID";
            //ListBox_delegateHistory.DataValueField = "delegateID";
            //ListBox_delegateHistory.DataBind();


        }
        protected void submit_button_Click(object sender, EventArgs e)
        {
            //add new delegate record
            string staffId = employee_dropList.SelectedValue.ToString();
            DateTime sDate = Convert.ToDateTime(textBox_startDate.Text);
            DateTime eDate = Convert.ToDateTime(textBox_endDate.Text);
            delegateDAO.delegateToStaff(staffId, sDate, eDate);

            //change the role of relevant staff
            currentHeadId =deptStaffDAO.findStaffByID(staffId).Department.headStaffID;
            delegateDAO.disableHead(currentHeadId);

            delegateStatus_Label.Text = "Delegated successfully!";
        }

        protected void terminate_button_Click(object sender, EventArgs e)
        {
            //int dID = Convert.ToInt16(ListBox_delegateHistory.SelectedValue);
            //bool IsActiveDelegate = delegateDAO.isActiveDelegate(dID);
            //if (logInRole == "outOfOfficeHead"&&IsActiveDelegate)
            //{
            //     delegateDAO.terminateDelegate(dID);
            //     label_terminateDlgt.Text = "Terminated succussfully";
            //}
            //else if(!IsActiveDelegate)
            //{
            //    label_terminateDlgt.Text = "This delegate has already been terminated";
            //}
            //else if (logInRole!= "outOfOfficeHead")
            //{
            //    label_terminateDlgt.Text = "You have no access to this";
            //}
        }
    }
}