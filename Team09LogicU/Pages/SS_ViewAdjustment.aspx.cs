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
    public partial class SS_ViewAdjustment : System.Web.UI.Page
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
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("adjVID", typeof(string)));
            iTable.Columns.Add(new DataColumn("storeStaffID", typeof(string)));
            iTable.Columns.Add(new DataColumn("authorisedBy", typeof(string)));
            iTable.Columns.Add(new DataColumn("adjDate", typeof(string)));
            iTable.Columns.Add(new DataColumn("status", typeof(string)));
            foreach (AdjustmentVoucher i in list)
            {
                DataRow dr = iTable.NewRow();
                dr["adjVID"] = i.adjVID;
                dr["storeStaffID"] = i.storeStaffID;
                dr["authorisedBy"] = i.authorisedBy;
                dr["adjDate"] = i.adjDate;
                dr["status"] = i.status;
                iTable.Rows.Add(dr);
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
            string supervisorID = (string)Session["loginID"];
            string status = "pending";
            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
            list = adjvdao.getAdjustmentVoucherList();

            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("adjVID", typeof(string)));
            iTable.Columns.Add(new DataColumn("storeStaffID", typeof(string)));
            iTable.Columns.Add(new DataColumn("authorisedBy", typeof(string)));
            iTable.Columns.Add(new DataColumn("adjDate", typeof(string)));
            iTable.Columns.Add(new DataColumn("status", typeof(string)));
            foreach (AdjustmentVoucher i in list)
            {
                DataRow dr = iTable.NewRow();
                dr["adjVID"] = i.adjVID;
                dr["storeStaffID"] = i.storeStaffID;
                dr["authorisedBy"] = i.authorisedBy;
                dr["adjDate"] = i.adjDate;
                dr["status"] = i.status;
                iTable.Rows.Add(dr);
            }

                GridView_ViewAdjustmentVoucher.DataSource = list;          
            GridView_ViewAdjustmentVoucher.DataBind();
        }

        protected void LinkButton_View_Click(object sender, EventArgs e)  //To Navigate to Approve ADJV Detail on clicking 'View'
        {
            LinkButton View = (LinkButton)sender;
            GridViewRow row = (GridViewRow)View.NamingContainer;
            string adjVID = "";
            if (row != null)
            {
                adjVID = (row.FindControl("label_ADJVID") as Label).Text;
                Response.Redirect("SS_ViewAdjustmentDetail.aspx?adjvID=" + adjVID);
            }
        }
    }
}