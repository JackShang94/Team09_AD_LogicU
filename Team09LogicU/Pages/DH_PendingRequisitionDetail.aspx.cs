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
    public partial class DH_PendingRequisitionDetail : System.Web.UI.Page
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
                BindData();
            }
        }

        protected void GridView_detailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_detailList.PageIndex = e.NewPageIndex;
            BindData();

            TextBox tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
            tb.Text = (GridView_detailList.PageIndex + 1).ToString();
        }

        protected void GridView_detailList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                TextBox tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView_detailList_PageIndexChanging(null, ea);
            }
        }

        public void BindData()
        {
            List<ItemCart> reqItems = reqItemDAO.findRequisitionItemByID(reqID);
            GridView_detailList.DataSource = reqItems;
            GridView_detailList.DataBind();
        }

        protected void Btn_Approve_Click(object sender, EventArgs e)
        {
            string remark = TextBox_Remarks.Text;
            Requisition req = reqDAO.findRequisitionByrequisitionId(reqID);
            reqDAO.updateRequisition(req, remark, "Approved");
            //send feedback email and notification to employee 
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            string headID = Session["loginID"].ToString();
            string headName = Session["loginName"].ToString();
            string staffID = req.staffID;
            string staffName = context.DeptStaffs.Where(x => x.staffID == staffID).Select(x => x.staffName).ToList().First();
            string requisitionDate = req.requisitionDate.ToString();
       
            NotificationDAO nDAO = new NotificationDAO();
            nDAO.addDeptNotification(staffID, headName + " approved your requisition on "+ requisitionDate, DateTime.Now);

            Email email = new Email();
            email.sendFeedBackEmailToEmployee(staffName, headName, requisitionDate, "Approved");

            Response.Redirect("./DH_ViewPendingRequisition.aspx");                
        }

        protected void Btn_Reject_Click(object sender, EventArgs e)
        {
            string remark = TextBox_Remarks.Text;
            Requisition req = reqDAO.findRequisitionByrequisitionId(reqID);
            reqDAO.updateRequisition(req, remark,"Rejected");
            //send feedback email and notification to employee 
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            string headID = Session["loginID"].ToString();
            string headName = Session["loginName"].ToString();
            string staffID = req.staffID;
            string staffName = context.DeptStaffs.Where(x => x.staffID == staffID).Select(x => x.staffName).ToList().First();
            string requisitionDate = req.requisitionDate.ToString();

            NotificationDAO nDAO = new NotificationDAO();
            nDAO.addDeptNotification(staffID, headName + " rejected your requisition on " + requisitionDate, DateTime.Now);

            Email email = new Email();
            email.sendFeedBackEmailToEmployee(staffName, headName, requisitionDate, "Rejected");

            Response.Redirect("./DH_ViewPendingRequisition.aspx");
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("./DH_ViewPendingRequisition.aspx");
        }
    }
}