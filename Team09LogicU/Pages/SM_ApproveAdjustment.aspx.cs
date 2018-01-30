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
    public partial class SM_ApproveAdjustment : System.Web.UI.Page
    {
        AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.BindGrid();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
            string Status = ddlStatus.Text;


            string from = txtFrom.Text;
            string to = txtTo.Text;

            if ((from == "" || to == "") && Status == "all")
            {
                list = adjvdao.getAdjustmentVoucherList();
            }

            if (Status == "all" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                list = adjvdao.findadjvbyDate(dateFrom, dateTo);
            }


            if ((from == "" || to == "") && Status != "all")
            {
                list = adjvdao.findadjvbyStatus(Status);
            }
            if (from != "" && to != "" && Status != "all")
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to); 
                list = adjvdao.findadjvbyStatusandDate(dateFrom, dateTo, Status);
            }

                GridView_ViewAdjustmentVoucher.DataSource = list;
                GridView_ViewAdjustmentVoucher.DataBind();
        }
        protected void GridView_ViewAdjustmentVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_ViewAdjustmentVoucher.PageIndex = e.NewPageIndex;

                TextBox tb = (TextBox)GridView_ViewAdjustmentVoucher.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_ViewAdjustmentVoucher.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        protected void GridView_ViewAdjustmentVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)GridView_ViewAdjustmentVoucher.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    GridView_ViewAdjustmentVoucher_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void BindGrid()
        {
            string mangerID = (string)Session["loginID"];
            string status = "pending";
            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
            list = adjvdao.getAdjustmentVoucherList();
            GridView_ViewAdjustmentVoucher.DataSource = list;
            if (list.Count == 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'No pending adjustment Voucher!');</script>");
            }
            GridView_ViewAdjustmentVoucher.DataBind();
        }

        protected void LinkButton_View_Click(object sender, EventArgs e)  //To Navigate to Approve ADJV Detail on clicking 'View'
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string adjvID = "";
            if (row != null)
            {
                adjvID = (row.FindControl("label_ADJVID") as Label).Text;
                Response.Redirect("SM_ApproveAdjustmentDetail.aspx?adjvID=" + adjvID);
            }
        }
    }
}