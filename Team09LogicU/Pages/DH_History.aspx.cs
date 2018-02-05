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
        TextBox tb = new TextBox();
        string strPageNum = "";
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

            for (int i = list.Count - 1; i >= 0; i--)
            {
                RequisitionByStaffCart reqByStaffCart = new RequisitionByStaffCart();
                reqByStaffCart = list[i];
                string reqStatus = reqByStaffCart.Status;
                if (reqStatus == "pending")
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

        protected void GridView_ReqHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            
                tb = (TextBox)GridView_ReqHistory.BottomPagerRow.FindControl("inPageNum");
                GridView_ReqHistory.PageIndex = e.NewPageIndex;
                tb.Text = (GridView_ReqHistory.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                BindGrid();
            
        }


        protected void GridView_ReqHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    tb = (TextBox)GridView_ReqHistory.BottomPagerRow.FindControl("inPageNum");


                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_ReqHistory_PageIndexChanging(null, ea);
                }
                catch { ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true); }

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
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please input condition！');</script>");
            }

            if (ReqStaffName == "---Select Name---" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                list = reqDAO.findRequisitionByDate(dateFrom, dateTo, deptID);
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

            for (int i = list.Count - 1; i >= 0; i--)
            {
                RequisitionByStaffCart reqByStaffCart = new RequisitionByStaffCart();
                reqByStaffCart = list[i];
                string reqStatus = reqByStaffCart.Status;
                if (reqStatus == "pending")
                {
                    list.RemoveAt(i);
                }
            }

            GridView_ReqHistory.DataSource = list;
            GridView_ReqHistory.DataBind();
        }

    }
}