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
    public partial class SC_ViewAdjustmentVoucher : System.Web.UI.Page
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
            list = adjvdao.getAdjustmentVoucherList();

            int adjvid;
            if (!int.TryParse(TextBox_SearchById.Text, out adjvid))
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please input correct number！');</script>");
            }
            else
            {
             
                    list = adjvdao.getAdjustmentVoucherListByID(adjvid);
                
                GridView_ViewAdjustmentVoucher.DataSource = list;
                GridView_ViewAdjustmentVoucher.DataBind();
            }
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
            string clerkID = (string)Session["loginID"];
           
            string status = "pending";
            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
            list = adjvdao.getAdjustmentVoucherList();
            GridView_ViewAdjustmentVoucher.DataSource = list;
            if (list.Count == 0)
            {
                lblMessage.Text = "No pending Adjustment Voucher now.";
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
                Response.Redirect("SC_Inv_AdjVoucherDetail.aspx?adjvID=" + adjvID);
            }
        }
    }
}