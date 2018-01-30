using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
using System.Data;

namespace Team09LogicU.Pages
{
    public partial class SS_ViewAdjustmentDetail : System.Web.UI.Page
    {
        static int adjvoucherID;
        static string supervisorID;
        AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
        AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
        ItemDAO itemdao = new ItemDAO();
        StockCardDAO stockcdao = new StockCardDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            adjvoucherID = Int32.Parse(Request.QueryString["adjVID"]);
            supervisorID = (string)Session["loginID"];

            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvoucherID);

            List <AdjustmentVoucherItem> adjvi =  adjvidao.getAdjustmentVoucherItemListByADJVID(adjvoucherID);

            string authorisedby = adjv.authorisedBy;
            string status = adjv.status;
            DateTime adjvDate = adjv.adjDate;

            if (adjvdao.price(adjvoucherID) == 1)
            {
                button_SendtoManager.Style.Value = " display:block;";
                TextBox_Remarks.Style.Value = " display:none;";
                button_Reject.Style.Value = " display:none;";
                button_Approve.Style.Value = " display:none;";
            }
            if (adjv.status != "pending")
            {
                TextBox_Remarks.Style.Value = " display:none;";
                button_Reject.Style.Value = " display:none;";
                button_Approve.Style.Value = " display:none;";
              
            }
            


            Label_StoreStafID.Text = supervisorID;
            lblDate.Text = adjvDate.ToString("dd/MM/yyyy");
            lblAdjvID.Text = Convert.ToString(adjvoucherID); ;
            Label_Authorisedby.Text = authorisedby;
            lblStatus.Text = status;
            BindData();
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
            List<AdjustmentVoucherItem> adjItems = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvoucherID);
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("adjVItemID", typeof(string)));
            iTable.Columns.Add(new DataColumn("itemDescription", typeof(string)));
            iTable.Columns.Add(new DataColumn("quantity", typeof(string)));

            foreach (AdjustmentVoucherItem i in adjItems)
            {
                DataRow dr = iTable.NewRow();
                dr["adjVItemID"] = i.adjVItemID;
                dr["itemDescription"] = i.Item.description;
                dr["quantity"] = i.quantity;
                iTable.Rows.Add(dr);
            }
            GridView_detailList.DataSource = iTable;
            GridView_detailList.DataBind();
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {

            Response.Redirect("./SS_ViewAdjustment.aspx");
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvoucherID);
            adjvdao.ApproveAdjustmentVoucherStatus(adjv, supervisorID);
            List<AdjustmentVoucherItem> adjvilist = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvoucherID);

            itemdao.updateStockCardAndItemQuantity(adjvilist);
            
            Response.Redirect("./SS_ViewAdjustment.aspx");
        }
        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvoucherID);
            adjvdao.RejectAdjustmentVoucherStatus(adjv, supervisorID);
            Response.Redirect("./SS_ViewAdjustment.aspx");
        }

        protected void btn_SendToManager_Click(object sender, EventArgs e)
        {
            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvoucherID);

            adjvdao.SendtoManageranother(adjv);//Method2

            //send email and notification to rep 
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            string supervisorName = Session["loginName"].ToString();
            StoreStaff manager = context.StoreStaffs.Where(x => x.role == "manager").ToList().First();
            string managerID = manager.storeStaffID;
            string managerName = manager.storeStaffName;

            string confirmDate = DateTime.Now.ToShortDateString();
            NotificationDAO nDAO = new NotificationDAO();
            nDAO.addDeptNotification(managerID, supervisorName + " has send an adjustment voucher!" + confirmDate, DateTime.Now);

            Email email = new Email();
            email.sendAdjustmentEmailToManager(supervisorName, managerName);

            Response.Redirect("./SS_ViewAdjustment.aspx");
        }

    }
}