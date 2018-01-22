﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;

namespace Team09LogicU.pages
{
    public partial class Emp_Rep_SelectCollection : System.Web.UI.Page
    {
        DepartmentDAO deptDAO = new DepartmentDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        CollectionPointDAO cDAO = new CollectionPointDAO();

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
                    DisplayCurrentCP(logInDept);
                    DisplayAvaliableCP();
                }
                else
                {
                    lblMessage.Text = "Access Denied!";
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    lblCurrentCP.Visible = false;
                    ddlCP.Visible = false;
                    btnUpdateCP.Visible = false;
                }
            }
        }

        public void DisplayCurrentCP(string logInDept)
        {
            /*Display current collection Point*/

            lblCurrentCP.Text = deptDAO.findByDeptId(logInDept).CollectionPoint.description;
        }

        public void DisplayAvaliableCP()
        {
            /*Display all the available collection point into dropdown list*/

            List<CollectionPoint> cpList = cDAO.getAllCollectionPoint();

            List<string> avaliableDescription = new List<string>();
            foreach (CollectionPoint cp in cpList)
            {
                avaliableDescription.Add(cp.description);
            }
           

            ddlCP.Items.Clear();
            ddlCP.DataSource = avaliableDescription;
            ddlCP.AppendDataBoundItems = true;
            ddlCP.Items.Insert(0, new ListItem("---Select Collection Point---"));
            ddlCP.DataBind();
        }

        protected void btnUpdateCP_Click(object sender, EventArgs e)
        {
            string newCPName = ddlCP.SelectedValue;
            CollectionPoint newCP = cDAO.getCollectionPointByDescription(newCPName);

            logInStaffId = (string)Session["loginID"];
            logInDept = deptStaffDAO.findStaffByID(logInStaffId).deptID;
            Department dept = deptDAO.findByDeptId(logInDept);

            deptDAO.UpdateCollectionPoint(dept,newCP);

            DisplayCurrentCP(logInDept);

        }
    }
}