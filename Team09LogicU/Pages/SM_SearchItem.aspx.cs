﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.Pages
{
    public partial class SM_SearchItem : System.Web.UI.Page
    {

        ItemDAO iDAO = new ItemDAO();
        List<Item> iList = new List<Item>();
        TextBox tb = new TextBox();
        string strPageNum = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                showItemListInfo();
            }

            tb.Text = strPageNum;

        }
        public void showItemListInfo()
        {
            iList = iDAO.getItemList();
            GridView_itemList.DataSource = iList;
            GridView_itemList.DataBind();
        }
        protected void Button_search_Click(object sender, EventArgs e)
        {
            updateGV();
        }

        protected void updateGV()
        {
            string keyword = textbox_Search.Text;
            iList = iDAO.getItemBySearch(keyword);
            GridView_itemList.DataSource = iList;
            GridView_itemList.DataBind();

        }
        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SM_AddItem.aspx");
        }


        protected void GridView_itemList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int i = e.NewEditIndex;
            string itemID = GridView_itemList.Rows[i].Cells[1].Text.ToString();
            Response.Redirect("SM_EditItem.aspx?itemID=" + itemID);
            
        }

        protected void GridView_itemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                tb = (TextBox)GridView_itemList.BottomPagerRow.FindControl("inPageNum");
                GridView_itemList.PageIndex = e.NewPageIndex;
                tb.Text = (GridView_itemList.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                updateGV();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }

        protected void GridView_itemList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                tb = (TextBox)GridView_itemList.BottomPagerRow.FindControl("inPageNum");
                
            }

            try
            {
                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView_itemList_PageIndexChanging(null, ea);              
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }
    }
}