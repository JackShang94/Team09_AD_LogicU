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
    public partial class DH_ChangeDepartmentRepresentative : System.Web.UI.Page
    {
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        DepartmentDAO deptDAO = new DepartmentDAO();

        string logInStaffId;
        string logInRole;
        string logInDept;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logInStaffId = (string)Session["loginID"];
                logInRole = (string)Session["loginRole"];
                if (logInRole == "head" || logInRole == "delegateHead")
                {
                    /*Set the role and dept from login info*/

                    logInRole = deptStaffDAO.findStaffByID(logInStaffId).role;
                    logInDept = deptStaffDAO.findStaffByID(logInStaffId).deptID;

                    if (logInRole == "head")
                    {
                        DisplayCurrentRep(logInDept);
                        DisplayAvaliableEmp(logInDept);
                    }
                }
                else
                {
                    lblMessage.Text = "Access Denided";
                    lblDisplay1.Visible = false;
                    lblDisplay2.Visible = false;
                    lblCurrentRep.Visible = false;
                    ddlEmp.Visible = false;
                    btnUpdateRep.Visible = false;
                }
            }

        }






        public void DisplayCurrentRep(string logInDept)
        {
            /*Display current rep*/

            lblCurrentRep.Text = deptStaffDAO.findDeptRep(logInDept).staffName.ToString();
        }


        public void DisplayAvaliableEmp(string logInDept)
        {
            /*Display the avaliable employee in the department into dropdown list*/

            List<DeptStaff> staffList = deptStaffDAO.findOnlyEmployee(logInDept);
            List<string> avaliableName = new List<string>();
            foreach (DeptStaff s in staffList)
            {
                avaliableName.Add(s.staffName);
            }
            ddlEmp.Items.Clear();
            ddlEmp.DataSource = avaliableName;
            ddlEmp.AppendDataBoundItems = true;
            ddlEmp.Items.Insert(0, new ListItem("---Select Name---"));
            ddlEmp.DataBind();
        }

        protected void btnUpdateRep_Click(object sender, EventArgs e)
        {
            //Update 
            string newRepName = ddlEmp.SelectedValue;
            DeptStaff newRep = deptStaffDAO.findStaffByName(newRepName);
            logInDept = newRep.deptID;
            Department dept = deptDAO.findByDeptId(logInDept);
            DeptStaff oldRep = deptStaffDAO.findDeptRep(logInDept);
            deptStaffDAO.updateRepName(newRep,oldRep);
            deptDAO.UpdateDeptRep(dept,newRep);

            //Refesh display
            DisplayCurrentRep(logInDept);
            DisplayAvaliableEmp(logInDept);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('', 'Successful！');</script>");
        }
    }

}