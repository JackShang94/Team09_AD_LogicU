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
        DataTable dHistory;
        string logInStaffId;
        string logInRole;
        string currentHeadId;

        protected void Page_Load(object sender, EventArgs e)
        {
            logInStaffId = Session["loginID"].ToString();
            string deptId = deptStaffDAO.findStaffByID(logInStaffId).deptID;
            logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
            Label_logInRole.Text = logInRole;

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
                    Panel_submitDelegate.Visible = false;
                    employee_dropList.Visible = false;
                    textBox_startDate.Visible = false;
                    textBox_endDate.Visible = false;
                    submit_button.Visible = false;
                    delegateStf_label.Text = "You are not allowed to delegate now.";
                }
            }

            //delegate history
            dHistory = new DataTable();
            dHistory.Columns.Add(new DataColumn("DelegateID", typeof(int)));
            dHistory.Columns.Add(new DataColumn("StaffID", typeof(string)));
            dHistory.Columns.Add(new DataColumn("Start Date", typeof(DateTime)));
            dHistory.Columns.Add(new DataColumn("End Date", typeof(DateTime)));
            dHistory.Columns.Add(new DataColumn("Status", typeof(string)));

            List<Models.Delegate> dList = delegateDAO.findDelegatesByDepartment(deptId);
            foreach (Models.Delegate item in dList)
            {
                DataRow dr = dHistory.NewRow();
                dr["DelegateID"] = item.delegateID;
                dr["StaffID"] = item.staffID;
                dr["Start Date"] = item.startDate;
                dr["End Date"] = item.endDate;
                dr["Status"] = this.delegateStatus(item);
                
                dHistory.Rows.Add(dr);
            }
            GridView_dHistory.DataSource = dHistory;
            GridView_dHistory.DataBind();


        }
       
        public string delegateStatus(Models.Delegate d)
        {
            DateTime now = DateTime.Today;
            if (d.endDate >= now)
            {
                return "Active";
            }
            else
            {
                return "Expired";
            }
        }
        protected void submit_button_Click(object sender, EventArgs e)
        {
            //add new delegate record
            string staffId = employee_dropList.SelectedValue.ToString();
            DateTime sDate = Convert.ToDateTime(textBox_startDate.Text);
            DateTime eDate = Convert.ToDateTime(textBox_endDate.Text);
            delegateDAO.delegateToStaff(staffId, sDate, eDate);

            //change the role of relevant staff
            currentHeadId = deptStaffDAO.findStaffByID(staffId).Department.headStaffID;
            delegateDAO.disableHead(currentHeadId);

            delegateStatus_Label.Text = "Delegated successfully!";
        }

        protected void terminate_button_Click(object sender, EventArgs e)
        {

            int dID = Convert.ToInt32(GridView_dHistory.SelectedRow.Cells[1].Text.ToString());
            bool IsActiveDelegate = delegateDAO.isActiveDelegate(dID);

            if (logInRole == "outOfOfficeHead" && IsActiveDelegate)
            {
                delegateDAO.terminateDelegate(dID);
                label_terminateDlgt.Text = "Terminated succussfully";
            }
            else if (!IsActiveDelegate)
            {
                label_terminateDlgt.Text = "This delegate has already been terminated";
            }
            else if (logInRole != "outOfOfficeHead")
            {
                label_terminateDlgt.Text = "You have no access to this";
            }
        }

        protected void GridView_dHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}