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
        StoreStaffDAO sDAO = new StoreStaffDAO();
        List<AdjustmentVoucher> adjvlist ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string clerkID = (string)Session["loginID"];
                adjvlist = adjvdao.getAdjustmentVoucherListByStaffID(clerkID);
                updateGV();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            updateGV();
        }
        protected void  updateGV()
        {
            adjvlist = new List<AdjustmentVoucher>();
            string Status = "--All--";

            if (DropDownList_cat.Text == "Pending(Supervisor)")
            {
                Status = "pending";
            }

            if (DropDownList_cat.Text == "Approved")
            {
                Status = "Approved";
            }

            if (DropDownList_cat.Text == "Rejected")
            {
                Status = "Rejected";
            }
            if (DropDownList_cat.Text == "Pending(Manager)")
            {
                Status = "PendingForManager";
            }
            string clerkID = (string)Session["loginID"];

            string from = txtFrom.Text;
            string to = txtTo.Text;

            if ((from == "" || to == "") && Status == "--All--")
            {
                adjvlist = adjvdao.getAdjustmentVoucherListByStaffID(clerkID);
            }

            if (Status == "--All--" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                adjvlist = adjvdao.findadjvbyDateandStaffID(dateFrom, dateTo, clerkID);
            }


            if ((from == "" || to == "") && Status != "--All--")
            {
                adjvlist = adjvdao.getadjvByStaffIDandStatus(clerkID, Status);
            }
            if (from != "" && to != "" && Status != "--All--")
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                adjvlist = adjvdao.findadjvbyStatusandDateStaffID(dateFrom, dateTo, Status, clerkID);
            }
            if (adjvlist.Count == 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'There is no adjustment voucher!');</script>");
            }
            showItemInfo(adjvlist);


        }

        public void dropDownList_bindCatInfo()
        {
            DropDownList_cat.AppendDataBoundItems = true;
            DropDownList_cat.Items.Insert(0, new ListItem("--All--"));
            DropDownList_cat.DataBind();
        }

        public void showItemInfo(List<AdjustmentVoucher> adjvlist)
        {
            List<AdjustmentVoucherCart> finalList = new List<AdjustmentVoucherCart>();
            for (int i = 0; i < adjvlist.Count(); i++)
            {
                finalList.Add(new AdjustmentVoucherCart());
                finalList[i].AdjvID = adjvlist[i].adjVID;
                finalList[i].ClerkName = sDAO.getStoreStaffNameByID(adjvlist[i].storeStaffID);
                finalList[i].Date = adjvlist[i].adjDate;
                finalList[i].AuthorisedBy = sDAO.getStoreStaffNameByID(adjvlist[i].authorisedBy);
                finalList[i].Status = adjvlist[i].status;
            }
            GridView_ViewAdjustmentVoucher.DataSource = finalList;
            GridView_ViewAdjustmentVoucher.DataBind();   

        }
            protected void GridView_ViewAdjustmentVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_ViewAdjustmentVoucher.PageIndex = e.NewPageIndex;
                TextBox tb = (TextBox)GridView_ViewAdjustmentVoucher.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_ViewAdjustmentVoucher.PageIndex + 1).ToString();
                updateGV();
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