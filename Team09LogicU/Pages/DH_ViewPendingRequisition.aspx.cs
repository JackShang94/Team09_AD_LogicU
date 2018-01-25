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
    public partial class DH_ViewPendingRequisition : System.Web.UI.Page
    {
        RequisitionDAO reqDAO = new RequisitionDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }


        protected void GridView_PendingReqList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_PendingReqList.PageIndex = e.NewPageIndex;
      
                TextBox tb = (TextBox)GridView_PendingReqList.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_PendingReqList.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        protected void GridView_PendingReqList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)GridView_PendingReqList.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_PendingReqList_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void BindGrid()
        {
            string headID = (string)Session["loginID"];
            string deptID = deptStaffDAO.findStaffByID(headID).deptID;
            string status = "pending";
            List<RequisitionByStaffCart> list = new List<RequisitionByStaffCart>();
            list = reqDAO.findRequisitionByDeptIdAndStatus(deptID, status);
            GridView_PendingReqList.DataSource = list;
            if (list.Count==0)
            {
                lblMessage.Text = "No pending requisition now.";
            }
            GridView_PendingReqList.DataBind();
        }

        protected void LinkButton_View_Click(object sender, EventArgs e)  //To Navigate to Approve Requisition Detail on clicking 'View'
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string reqID = "";
            if (row != null)
            {
                reqID = (row.FindControl("lblReqID") as Label).Text;
                Response.Redirect("DH_PendingRequisitionDetail.aspx?reqID=" + reqID);
            }
        }
    }
}