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
        DataTable dHistory = new DataTable();
        string logInStaffId;
        string logInRole;
        string currentHeadId;
        List<Models.Delegate> dList;
        string deptId;

        protected void Page_Load(object sender, EventArgs e)
        {
            logInStaffId = Session["loginID"].ToString();
            deptId = deptStaffDAO.findStaffByID(logInStaffId).deptID;
            dHistory = new DataTable();
            dHistory.Columns.Add(new DataColumn("DelegateID", typeof(int)));
            dHistory.Columns.Add(new DataColumn("StaffID", typeof(string)));
            dHistory.Columns.Add(new DataColumn("Start Date", typeof(DateTime)));
            dHistory.Columns.Add(new DataColumn("End Date", typeof(DateTime)));
            dHistory.Columns.Add(new DataColumn("Status", typeof(string)));

            if (!IsPostBack)
            {
                List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee(deptId);
                employee_dropList.DataSource = staffList;
                employee_dropList.DataTextField = "staffName";
                employee_dropList.DataValueField = "staffID";
                employee_dropList.DataBind();
                delegateStf_label.Text = employee_dropList.Text;

                showLatestDelegation();
                showCurrentRole();
            }
        }

        //show latest delegation status
        public void showLatestDelegation()
        {
            dList = delegateDAO.findDelegatesByDepartment(deptId);
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

        //get delegation status
        public string delegateStatus(Models.Delegate d)
        {
            DateTime now = DateTime.Today;
            if (d.endDate > now)
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
            try
            {
                string selectedStaffId = employee_dropList.SelectedValue.ToString();
                DateTime sDate = Convert.ToDateTime(textBox_startDate.Text);
                DateTime eDate = Convert.ToDateTime(textBox_endDate.Text);

                //make sure the correct selection of date
                if (sDate < eDate && sDate >= DateTime.Today)
                {
                    //add a new delegation
                    delegateDAO.delegateToStaff(selectedStaffId, sDate, eDate);

                    //change the role of current head to "out of office head"
                    currentHeadId = deptStaffDAO.findStaffByID(logInStaffId).Department.headStaffID;
                    delegateDAO.disableHead(currentHeadId);

                    //update delegation status
                    Response.Write("<script>alert('Delegated succussfully!')</script>");
                    Panel_submitDelegate.Visible = false;
                   
                    
                }
                else
                {
                    Response.Write("<script>alert('Please select valid date!')</script>");
                }
            }

            catch { Response.Write("<script>alert('Failed to submit!')</script>"); }

            finally
            {
                showLatestDelegation();
                showCurrentRole();
            }


        }

        protected void terminate_button_Click(object sender, EventArgs e)
        {
            if (GridView_dHistory.SelectedIndex != -1)
            {
                int dID = Convert.ToInt32(GridView_dHistory.SelectedRow.Cells[1].Text.ToString());
                bool IsActiveDelegate = delegateDAO.isActiveDelegate(dID);
                logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
                if (logInRole == "outOfOfficeHead" || logInRole == "head")
                {
                    if (IsActiveDelegate)
                    {
                        delegateDAO.terminateDelegate(dID);
                        Response.Write("<script>alert('Successfully terminated!')</script>");
                        Panel_submitDelegate.Visible = true;
                        
                    }
                    else
                    {
                        Response.Write("<script>alert('This delegation has already been terminated')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('You have no access to this ')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select at least one delegation!')</script>");
            }
            showCurrentRole();
            showLatestDelegation();

        }

    }
}