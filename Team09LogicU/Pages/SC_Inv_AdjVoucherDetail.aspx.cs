﻿using System;
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
    public partial class SC_Inv_AdjVoucherDetail : System.Web.UI.Page
    {
        static int adjvID;
        static string clerkID;
        AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
        AdjustmentVoucherItemDAO adjvidao = new AdjustmentVoucherItemDAO();
        StoreStaffDAO sDAO = new StoreStaffDAO();
        TextBox tb = new TextBox();
        List<AdjustmentVoucherItem> adjItems;
        string strPageNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                adjvID = Int32.Parse(Request.QueryString["adjvID"]);
                clerkID = (string)Session["loginID"];

                AdjustmentVoucher adjv = adjvdao.findAdjustmentVoucherByadjvId(adjvID);
                string authorisedby = sDAO.getStoreStaffNameByID(adjv.authorisedBy);
                string status = adjv.status;
                DateTime adjvDate = adjv.adjDate;

                Label_StoreStafID.Text = sDAO.getStoreStaffNameByID(clerkID);
                lblDate.Text = adjvDate.ToString("dd/MM/yyyy");
                lblAdjvID.Text = Convert.ToString(adjvID); ;
                Label_Authorisedby.Text = authorisedby;
                lblStatus.Text = status;
                adjItems = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvID);

                GridView_detailList.DataSource = adjItems;
                GridView_detailList.DataBind();
            }
        }

        protected void GridView_detailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView_detailList.PageIndex = e.NewPageIndex;
                TextBox tb = (TextBox)GridView_detailList.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView_detailList.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                adjItems = adjvidao.getAdjustmentVoucherItemListByADJVID(adjvID);

                GridView_detailList.DataSource = adjItems;
                GridView_detailList.DataBind();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
                }
            }
        }
        protected void Btn_Back_Click(object sender, EventArgs e)
        {    
            Response.Redirect("./SC_ViewAdjustmentVoucher.aspx");
        }
    }
}