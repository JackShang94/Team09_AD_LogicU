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
    public partial class SC_Inv_AdjustmentVoucher : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
         
        public string staffID;
        public void updateCart(List<AdjustmentVouchercart> lac)
        {
            Session["adjvcart"] = lac;
            cartRepeater.DataSource = lac;
            cartRepeater.DataBind();
        }
        public void updateCatalogue(List<Item> li)
        {
            GridView_CatalogList.DataSource = li;
            GridView_CatalogList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {

               
                this.BindGrid();


                if (Session["adjvcart"] == null)
                {
                    Session["adjvcart"] = new List<AdjustmentVouchercart>();
                }



                /**********************Loading Cart List************************************/

                //string name = Session["loginID"].ToString();

                string name = Session["loginID"].ToString();
                this.staffID = name;
                //name = "emp006";
                //Session["loginID"] = name;
                if (this.staffID == null)
                {
                    Response.Redirect("login.aspx");

                }

                string role = Session["loginRole"].ToString();
                //role = "emp";
                //Session["loginRole"] = role;
                if (role != "clerk" )
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
                List<AdjustmentVouchercart> lac_session = (List<AdjustmentVouchercart>)Session["adjvcart"];
                foreach (var i in lac_session)
                {
                    if (i.Name == name)
                    {
                        lac.Add(i);
                    }
                }
                updateCart(lac);
                /******************************Loading Catalogue List********************************/
                ItemDAO idao = new ItemDAO();
                List<Item> li = idao.getItemList();
                updateCatalogue(li);//when model is being used,cannot get from it;

            }
            else
            {

                string name = Session["loginID"].ToString();
                this.staffID = name;
                string role = Session["loginRole"].ToString();
                //role = "emp";
                //Session["loginRole"] = role;
                if (role != "clerk" )
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                //string name = Session["loginID"].ToString();
                List<AdjustmentVouchercart> lac = (List<AdjustmentVouchercart>)Session["adjvcart"];



                updateCart(lac);
                ItemDAO idao = new ItemDAO();

                string sText = textbox_Search.Text.ToString();
                if (string.IsNullOrWhiteSpace(sText))
                {
                    updateCatalogue(idao.getItemList());
                }
                else
                {
                    updateCatalogue(idao.getItemByDesc(sText));
                }
            }
        }


        protected void BindGrid()
        {
            List<Item> itemlist = new List<Item>();
            itemlist = itemDAO.getItemList();
            GridView_CatalogList.DataSource = itemlist;
            GridView_CatalogList.DataBind();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //List<Item> list = new List<Item>();

            //string itemID = textbox_Search.Text;

            //if (itemID == "")
            //{

            //    list = itemDAO.getItemList();
            //}
            //else
            //{
            //    list = itemDAO.getItemByitemID(itemID);
            //}
            //GridView_CatalogList.DataSource = list;
            //GridView_CatalogList.DataBind();
            ItemDAO idao = new ItemDAO();
            string sText = textbox_Search.Text.ToString();
            if (string.IsNullOrWhiteSpace(sText))
            {
                //this.lcatalogue = id.getItemList();


                updateCatalogue(idao.getItemList());
                //catalogueUpdatePanel.Update();

                return;
            }
            /******************SearchByItemID!!!!*******************************/
            //this.lcatalogue = id.getItemByitemID(sText);


            updateCatalogue(idao.getItemByDesc(sText));
            //catalogueUpdatePanel.Update();
        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            //string name = Session["loginID"].ToString();
            string name = this.staffID;
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            ///should use DAO
            //string deptID = m.DeptStaffs.Where(x => x.staffID == name).Select(y => y.deptID).First().ToString();//supposed to be in DepartmentDAO
            ///
            List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
            lac = (List<AdjustmentVouchercart>)Session["adjvcart"];
            if (lac.Count > 0)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                foreach (Control i in cartRepeater.Items)//get Quantity
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                    dict.Add(deletebtn.CommandArgument.ToString(), Int32.Parse(cartqty.Text.ToString()));

                }
                AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
                adjvdao.addAdjustmentVoucher(name, dict);

                lac = new List<AdjustmentVouchercart>();//clear the cart session
                Session["adjvcart"] = lac;
                HttpContext.Current.Response.Redirect("SC_ViewAdjustmentVoucher.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('Nothing in cart')", true);
                return;
            }

        }

        protected void GridView_CatalogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //if (e.CommandName == "Add")
            //{
            //    string itemid = e.CommandArgument.ToString();
            //    //label.Text = itemid;
            //}

           
            if (e.CommandName == "Add")
            {
                List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
                lac = (List<AdjustmentVouchercart>)Session["adjvcart"];//get cart from Session

                //string name = Session["loginID"].ToString();//get name from Session
                string name = this.staffID;
                string itemid = e.CommandArgument.ToString();
                // LinkButton b = (LinkButton)sender;//get this Button
                //  string[] info = b.CommandArgument.ToString().Split('&');//only get this add button
                int alert = 0;
                foreach (Control i in cartRepeater.Items)//get Quantity from the cart
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get currrent quantity
                    string a = cartqty.Text;
                    foreach (var k in lac)
                    {
                        if (k.ItemID == deletebtn.CommandArgument.ToString())
                        {
                            k.Qty = Int32.Parse(a);
                        }

                    }
                    if (deletebtn.CommandArgument.ToString() == itemid)//Just get the corresponding itemID
                    {
                        foreach (var j in lac)//find in cart
                        {

                            if (j.ItemID == itemid)//only for banning add repeated items
                            {
                                j.Qty = Int32.Parse(a);//store current quantity into session
                                alert = 1;
                                break;
                            }
                        }
                    }
                }
                //If this item was in the cart ,then alert!!!!
                if (alert == 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Already in your cart')", true);
                    return;
                }
                //If this item not in the cart ,then add it to the cart
                AdjustmentVouchercart c = new AdjustmentVouchercart
                {
                    Name = name,
                    ItemID = itemid,
                   //Description = info[1],//stupid
                    Qty = 1//default
                };

                lac.Add(c);
                Session["adjvcart"] = lac;
                //this.lcart = lc;
                cartUpdatePanel.Update();
                updateCart(lac);
            }
        }


        protected void cart_deleteBtn_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string info = b.CommandArgument.ToString();//itemID and requiredQuantity

            List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
            lac = (List<AdjustmentVouchercart>)Session["adjvcart"];


            for (int i = cartRepeater.Items.Count - 1; i >= 0; i--)//get Quantity from the cart
            {
                LinkButton deletebtn = cartRepeater.Items[i].FindControl("cart_deleteButton") as LinkButton;//get itemID
                TextBox cartqty = cartRepeater.Items[i].FindControl("cart_qtyTextBox") as TextBox;//get currrent quantity
                string a = cartqty.Text;
                //find the item u wanna delete
                //for (int j = lc.Count - 1; j >= 0; j--)
                //{
                if (lac[i].ItemID == info)
                {
                    lac.RemoveAt(i);
                    continue;
                }
                lac[i].Qty = Int32.Parse(a);


            }

            Session["adjvcart"] = lac;

            //this.lcart = lc;
            updateCart(lac);
        }





            
            //cart delete
            protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
            if (e.CommandName == "delete")
            {
                string[] info = e.CommandArgument.ToString().Split('&');
                string itemID = info[0];
                List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
                lac = (List<AdjustmentVouchercart>)Session["adjvcart"];

                foreach (var i in lac)
                {
                    if (i.ItemID == itemID)
                    {
                        lac.Remove(i);
                    }
                }

                cartRepeater.DataSource = lac;
                cartRepeater.DataBind();

            }
        }

            protected void cart_qtyTextBox_TextChanged(object sender, EventArgs e)
            {

            }
    }
}