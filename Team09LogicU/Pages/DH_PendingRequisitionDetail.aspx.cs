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
            Response.Redirect("./DH_ViewPendingRequisition.aspx");
        }

        protected void Btn_Reject_Click(object sender, EventArgs e)
        {
            string remark = TextBox_Remarks.Text;
            Requisition req = reqDAO.findRequisitionByrequisitionId(reqID);
            reqDAO.updateRequisition(req, remark,"Rejected");
            Response.Redirect("./DH_ViewPendingRequisition.aspx");
        }
    }
}