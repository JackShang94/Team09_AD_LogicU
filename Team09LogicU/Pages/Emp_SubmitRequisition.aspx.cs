﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.pages
{
    public partial class Emp_SubmitRequisition : System.Web.UI.Page
    {
        //public List<cart> lcart;
        //public List<Item> lcatalogue;
        public string staffID;
        public void updateCart(List<cart> lc)
        {
            Session["cart"] = lc;
            cartRepeater.DataSource = lc;
            cartRepeater.DataBind();
        }
        public void updateCatalogue(List<Item> li)
        {
            catalogueRepeater.DataSource = li;
            catalogueRepeater.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                if (role !="rep"&& role!="emp")
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                List<cart> lc = new List<cart>();

                foreach (var i in (List<cart>)Session["cart"])
                {
                    if (i.Name == name)
                    {
                        lc.Add(i);
                    }
                }
                updateCart(lc);
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
                if (role != "emp"&& role!="rep")
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                //string name = Session["loginID"].ToString();
                List<cart> lc = (List<cart>)Session["cart"];

                //foreach (var i in lc)
                //{
                //    if (i.Name == name)
                //    {
                //        lc.Add(i);
                //    }
                //}

                updateCart(lc);
                ItemDAO idao = new ItemDAO();

                string sText = item_searchText.Text.ToString();
                if (string.IsNullOrWhiteSpace(sText))
                {
                    updateCatalogue(idao.getItemList());
                }else
                {
                    updateCatalogue(idao.getItemByitemID(sText));
                }
            }

        }



        /****************************Search Button****************************/
        protected void item_searchBtn_Click(object sender, EventArgs e)
        {
            ItemDAO idao = new ItemDAO();
            string sText = item_searchText.Text.ToString();
            if (string.IsNullOrWhiteSpace(sText))
            {
                //this.lcatalogue = id.getItemList();
                

                //catalogueRepeater.DataSource = idao.getItemList();
                //catalogueRepeater.DataBind();
                updateCatalogue(idao.getItemList());
                //catalogueUpdatePanel.Update();
                
                return;
            }
            /******************SearchByItemID!!!!*******************************/
            //this.lcatalogue = id.getItemByitemID(sText);
            
            //catalogueRepeater.DataSource = idao.getItemByDesc(sText);
            //catalogueRepeater.DataBind();
            updateCatalogue(idao.getItemByDesc(sText));
            //catalogueUpdatePanel.Update();


        }


      
        /************************************Submit Requisition*************************************/
        protected void Submit_Click(object sender, EventArgs e)
        {
            //string name = Session["loginID"].ToString();

            string name = this.staffID;
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            ///should use DAO
            string deptID = m.DeptStaffs.Where(x => x.staffID == name).Select(y => y.deptID ).First().ToString();//supposed to be in DepartmentDAO
            ///
            List<cart> lc = new List<cart>();
            lc =(List < cart >) Session["cart"];
            if (lc.Count>0)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();


                foreach (Control i in cartRepeater.Items)//get Quantity
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                    dict.Add(deletebtn.CommandArgument.ToString(), Int32.Parse(cartqty.Text.ToString()));

                }
                RequisitionDAO rdao = new RequisitionDAO();
                rdao.addRequisition(name, deptID, dict);

                lc = new List<cart>();//clear the cart session
                Session["cart"] = lc;
                HttpContext.Current.Response.Redirect("Emp_MyRequisition.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('Nothing in cart')", true);
                return;
            } 
            
        }


        /*******************************add Item******************************************/
        protected void addBtn_Click(object sender, EventArgs e)
        {

            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];//get cart from Session

            //string name = Session["loginID"].ToString();//get name from Session
            string name = this.staffID;
            Button b = (Button)sender;//get this Button

            string[] info = b.CommandArgument.ToString().Split('&');//only get this add button
            int alert = 0;
            foreach (Control i in cartRepeater.Items)//get Quantity from the cart
            {
                LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get currrent quantity
                string a = cartqty.Text;
                foreach(var k in lc)
                {
                    if (k.ItemID == deletebtn.CommandArgument.ToString())
                    {
                        k.Qty = Int32.Parse(a);
                    }
                    
                }
                if (deletebtn.CommandArgument.ToString() == info[0])//Just get the corresponding itemID
                {
                    foreach (var j in lc)//find in cart
                    {
                        
                        if (j.ItemID == info[0])//only for banning add repeated items
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
            cart c = new cart
            {
                Name = name,
                ItemID = info[0],
                Description = info[1],//stupid
                Qty = 1//default
            };

            lc.Add(c);
            Session["cart"] = lc;
            //this.lcart = lc;
            cartUpdatePanel.Update();
            updateCart(lc);
        }
        /******************************Delete Item***********************************/
        protected void cart_deleteBtn_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string info = b.CommandArgument.ToString();//itemID and requiredQuantity

            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];


            for (int i = cartRepeater.Items.Count - 1;i >= 0; i--)//get Quantity from the cart
            {
                LinkButton deletebtn = cartRepeater.Items[i].FindControl("cart_deleteButton") as LinkButton;//get itemID
                TextBox cartqty = cartRepeater.Items[i].FindControl("cart_qtyTextBox") as TextBox;//get currrent quantity
                string a = cartqty.Text;
                //find the item u wanna delete
                //for (int j = lc.Count - 1; j >= 0; j--)
                //{
                    if(lc[i].ItemID == info)
                    {
                        lc.RemoveAt(i);
                        continue;
                    }
                    lc[i].Qty = Int32.Parse(a);

              
            }

            Session["cart"] = lc;

            //this.lcart = lc;
            updateCart(lc);
        }



        //Test
        protected void catalogueRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
            //if (e.CommandName == "add")
            //{
            //    List<cart> lc = new List<cart>();
            //    lc = (List<cart>)Session["cart"];//get cart from Session
            //    string name = Session["loginID"].ToString();//get name from Session

            //    string[] info = e.CommandArgument.ToString().Split('&');

            //    foreach(var i in lc)
            //    {
            //        if (i.ItemID == info[0])
            //        {
            //            string radalertscript = "<script language='javascript'>alert('Already In!!!')</script>";
            //            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);
            //            return;
            //        }
            //    }
              

            //    cart c = new cart
            //    {
            //        Name = name,
            //        ItemID = info[0],
            //        Description = info[1],//stupid
            //        Qty = 1//default
            //    };

            //    lc.Add(c);
            //    Session["cart"] = lc;              
           


            //    //this.lcart = lc;
            //    cartUpdatePanel.Update();
            //    cartRepeater.DataSource = lc;
            //    cartRepeater.DataBind();
            //}
            

            
        }
        //cart delete
        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "delete")
            //{
            //    string[] info = e.CommandArgument.ToString().Split('&');
            //    string itemID = info[0];
            //    List<cart> lc = new List<cart>();
            //    lc = (List<cart>)Session["cart"];

            //    foreach(var i in lc)
            //    {
            //        if (i.ItemID == itemID)
            //        {
            //            lc.Remove(i);
            //        }
            //    }

            //    cartRepeater.DataSource = lc;
            //    cartRepeater.DataBind();

            //}
        }

        protected void cart_qtyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}