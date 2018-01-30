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
    public partial class SC_ViewAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
        List<AdjustmentVoucher> adjvlist ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               // string status = "pending";
                //this.BindGrid();
                this.showItemInfo();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
            string Status = DropDownList_cat.Text;
            string clerkID = (string)Session["loginID"];

            string from = txtFrom.Text;
            string to = txtTo.Text;

            if ((from == "" || to == "") && Status == "--All--")
            {
                list = adjvdao.getAdjustmentVoucherListByStaffID(clerkID);
            }

            if (Status == "--All--" && (from != "" && to != ""))
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                list = adjvdao.findadjvbyDateandStaffID(dateFrom, dateTo, clerkID);
            }


            if ((from == "" || to == "") && Status != "--All--")
            {
                list = adjvdao.getadjvByStaffIDandStatus(clerkID,Status);
            }
            if (from != "" && to != "" && Status != "--All--")
            {
                DateTime dateFrom = Convert.ToDateTime(from);
                DateTime dateTo = Convert.ToDateTime(to);
                list = adjvdao.findadjvbyStatusandDateStaffID(dateFrom, dateTo, Status,clerkID);
            }
            if (list.Count == 0)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'There is no adjustment voucher!');</script>");
            }
           
                GridView_ViewAdjustmentVoucher.DataSource = list;
                GridView_ViewAdjustmentVoucher.DataBind();
            
        }


        public void dropDownList_bindCatInfo()
        {
            DropDownList_cat.AppendDataBoundItems = true;
            DropDownList_cat.Items.Insert(0, new ListItem("--All--"));
            DropDownList_cat.DataBind();
        }

        //protected void DropDownList_cat_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    UpdateGridviewByDropdownList();
        //}
       
        //protected void UpdateGridviewByDropdownList()
        //{
        //    string clerkID = (string)Session["loginID"];
        //    if (DropDownList_cat.Text == "--All--")
        //    {
        //        adjvlist = adjvdao.getAdjustmentVoucherListByStaffID(clerkID);//all items
        //    }
        //    else
        //    {
        //        string status = DropDownList_cat.Text;
        //        adjvlist = adjvdao.getadjvByStaffIDandStatus(clerkID,status);//items with specific CAT
        //    }
           
        //    GridView_ViewAdjustmentVoucher.DataSource = adjvlist;
        //    GridView_ViewAdjustmentVoucher.DataBind();
           
        //}
        public void showItemInfo()
        {
            string clerkID = (string)Session["loginID"];
            adjvlist = adjvdao.getAdjustmentVoucherListByStaffID(clerkID);
            GridView_ViewAdjustmentVoucher.DataSource = adjvlist;
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
        //protected void BindGrid()
        //{
        //    List<AdjustmentVoucher> list = new List<AdjustmentVoucher>();
        //    list = adjvdao.getAdjustmentVoucherList();
        //    GridView_ViewAdjustmentVoucher.DataSource = list;
        //    GridView_ViewAdjustmentVoucher.DataBind();
        //}

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