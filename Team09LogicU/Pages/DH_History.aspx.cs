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
    public partial class DH_History : System.Web.UI.Page
    {
        RequisitionDAO reqDAO = new RequisitionDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDDL();
                this.BindGrid();
            }

        }

        protected void BindDDL()
        {
            string headID = (string)Session["loginID"];
            string deptID = deptStaffDAO.findStaffByID(headID).deptID;

            List<DeptStaff> staffList = deptStaffDAO.findEmployeeAndRep(deptID);
            List<string> avaliableName = new List<string>();
            foreach (DeptStaff s in staffList)
            {
                avaliableName.Add(s.staffName);
            }
            ddlStaff.Items.Clear();
            ddlStaff.DataSource = avaliableName;
            ddlStaff.AppendDataBoundItems = true;
            ddlStaff.Items.Insert(0, new ListItem("---Select Name---"));
            ddlStaff.DataBind();
        }

        protected void BindGrid()
        {
            string headID = (string)Session["loginID"];
            string deptID = deptStaffDAO.findStaffByID(headID).deptID;
            List<RequisitionByStaffCart> list = new List<RequisitionByStaffCart>();
            list = reqDAO.findRequisitionByDeptID(deptID);

            for (int i = 0; i < list.Count; i++)
            {
                RequisitionByStaffCart reqByStaffCart = new RequisitionByStaffCart();
                reqByStaffCart = list[i];
                if (reqByStaffCart.Status == "pending")
                {
                    list.RemoveAt(i);
                }
            }

            GridView_ReqHistory.DataSource = list;
            GridView_ReqHistory.DataBind();
        }

        protected void LinkButton_View_Click(object sender, EventArgs e)  //To Navigate to Approve Requisition Detail on clicking 'View'
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string reqID = "";
            if (row != null)
            {
                reqID = (row.FindControl("lblReqID") as Label).Text;
                Response.Redirect("DH_RequisitionHistoryDetail.aspx?reqID=" + reqID);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string headID = (string)Session["loginID"];
            string deptID = deptStaffDAO.findStaffByID(headID).deptID;

            List<RequisitionByStaffCart> list = new List<RequisitionByStaffCart>();

            string ReqStaffName = ddlStaff.Text;
            

            string from = txtFrom.Text;
            string to = txtTo.Text;

            if ((from == "" || to == "") && ReqStaffName == "---Select Name---")
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please input your searching condition!')</script>");
            }

            if (ReqStaffName == "---Select Name---" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                list = reqDAO.findRequisitionByDate(dateFrom,dateTo);
            }
            if ((from == "" || to == "") && ReqStaffName != "---Select Name---")
            {
                string ReqStaffID = deptStaffDAO.findStaffByName(ReqStaffName).staffID;
                list = reqDAO.findRequisitionByStaffID(ReqStaffID);
            }
            if (from != "" && to != "" && ReqStaffName != "---Select Name---")
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                string ReqStaffID = deptStaffDAO.findStaffByName(ReqStaffName).staffID;
                list = reqDAO.findRequisitionByDateAndStaffID(dateFrom, dateTo, ReqStaffID);
            }

            GridView_ReqHistory.DataSource = list;
            GridView_ReqHistory.DataBind();
        }
    }
}