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
    public partial class SM_ApproveAdjustmentDetail : System.Web.UI.Page
    {
        static int adjvID;
        static string managerID;
        ItemDAO itemdao = new ItemDAO();
        AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
        AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
        TextBox tb = new TextBox();
        string strPageNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            adjvID = Int32.Parse(Request.QueryString["adjvID"]);
            managerID = (string)Session["loginID"];

            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvID);

            string staffName = adjv.StoreStaff.storeStaffName;
            string authorisedby = adjv.authorisedBy;
            string status = adjv.status;
            DateTime adjvDate = adjv.adjDate;
            //if (authorisedby == "")
            //{
            //    LabeltxtAutBy.Style.Value = " display:none;";
            //    Label_Authorisedby.Style.Value = " display:none;";
            //}
            if (adjv.status != "PendingForManager")
            {
                TextBox_Remarks.Style.Value= " display:none;";
                button_Reject.Style.Value = " display:none;";
                button_Approve.Style.Value = " display:none;";
            }
            Label_StoreStafID.Text = staffName;
            lblDate.Text = adjvDate.ToString("dd/MM/yyyy");
            lblAdjvID.Text = Convert.ToString(adjvID); ;
            Label_Authorisedby.Text = authorisedby;
            lblStatus.Text = status;
            BindData();
        }
        protected void GridView_detailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
                GridView_detailList.PageIndex = e.NewPageIndex;
                tb.Text = (GridView_detailList.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                BindData();


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
            List<AdjustmentVoucherItem> adjItems = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvID);
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("ID", typeof(int)));
            iTable.Columns.Add(new DataColumn("Item Description", typeof(string)));
            iTable.Columns.Add(new DataColumn("Quantity", typeof(int)));

            foreach (AdjustmentVoucherItem i in adjItems)
            {
                DataRow dr = iTable.NewRow();
                dr["ID"] = i.adjVItemID;
                dr["Item Description"] = i.Item.description;
                dr["Quantity"] = i.quantity;
                iTable.Rows.Add(dr);
            }
           
            GridView_detailList.DataSource = iTable;
            GridView_detailList.DataBind();
        }
        protected void btn_Back_Click(object sender, EventArgs e)
        {

            Response.Redirect("./SM_ApproveAdjustment.aspx");
        }

        protected void btn_Approve_Click(object sender, EventArgs e)
        {
            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvID);
            adjvdao.ApproveAdjustmentVoucherStatus(adjv, managerID);

            List<AdjustmentVoucherItem> adjvilist = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvID);
            itemdao.updateStockCardAndItemQuantity(adjvilist);
            Response.Redirect("./SM_ApproveAdjustment.aspx");
        }
        protected void btn_Reject_Click(object sender, EventArgs e)
        {
            AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvID);
            adjvdao.RejectAdjustmentVoucherStatus(adjv, managerID);
            Response.Redirect("./SM_ApproveAdjustment.aspx");
        }

         

    }

}