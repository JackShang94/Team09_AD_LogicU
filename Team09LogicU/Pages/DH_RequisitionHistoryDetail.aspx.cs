using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.Pages
{
    public partial class DH_RequisitionHistoryDetail : System.Web.UI.Page
    {
        static int reqID;
        static string headID;
        RequisitionDAO reqDAO = new RequisitionDAO();
        RequisitionItemDAO reqItemDAO = new RequisitionItemDAO();
        DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            reqID = Int32.Parse(Request.QueryString["reqID"]);
            if (!IsPostBack)
            {
                headID = (string)Session["loginID"];
                Requisition req = reqDAO.findRequisitionByrequisitionId(reqID);
                string reqStaff = req.DeptStaff.staffName;
                DateTime reqDate = req.requisitionDate;

                lblReqID.Text = Convert.ToString(reqID);
                lblDate.Text = reqDate.ToString("dd/MM/yyyy");
                lblStaff.Text = reqStaff;
                lblRemark.Text = req.remarks.ToString();

                BindData();
            }
        }

        protected void GridView_detailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_detailList.PageIndex = e.NewPageIndex;

                BindData();
                TextBox tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_detailList.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        protected void GridView_detailList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_detailList_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        public void BindData()
        {
            List<ItemCart> reqItems = reqItemDAO.findRequisitionItemByID(reqID);
            GridView_detailList.DataSource = reqItems;
            GridView_detailList.DataBind();
        }
    }
}