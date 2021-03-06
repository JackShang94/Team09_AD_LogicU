﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;
using System.Data;

namespace Team09LogicU.pages
{
    public partial class Emp_SubmitRequisition : System.Web.UI.Page
    {
        List<Item> li;
        public string staffID;
        PagedDataSource pds = new PagedDataSource();
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
                string name = Session["loginID"].ToString();
                this.staffID = name;
                if (this.staffID == null)
                {
                    Response.Redirect("login.aspx");                  
                }

                string role = Session["loginRole"].ToString();
                if (role !="rep"&& role!="emp")
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                List<cart> lc = new List<cart>();
                List<cart> lc_session=( List<cart>)Session["cart"];
                if (lc_session.Count > 0)
                {
                    updateCart(lc_session);
                }else
                {
                    foreach (var i in lc_session)
                    {
                        if (i.Name == name)
                        {
                            lc.Add(i);
                        }
                    }
                    updateCart(lc);
                }
               
                /******************************Loading Catalogue List********************************/
                ItemDAO idao = new ItemDAO();
                 li = idao.getItemList();
                updateCatalogue(li);//when model is being used,cannot get from it;

        }
            else
            {
                List<cart> lc = (List<cart>)Session["cart"];
                updateCart(lc);
                ItemDAO idao = new ItemDAO();

                string sText = item_searchText.Text.ToString();
                if (string.IsNullOrWhiteSpace(sText))
                {
                    updateCatalogue(idao.getItemList());
                }else
                {
                    updateCatalogue(idao.getItemByDesc(sText));
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
                updateCatalogue(idao.getItemList());              
                return;
            }
            /******************SearchByItemID!!!!*******************************/            
            updateCatalogue(idao.getItemByDesc(sText));           
        }


      
        /************************************Submit Requisition*************************************/
        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = Session["loginID"].ToString();
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            ///should use DAO
            string deptID = m.DeptStaffs.Where(x => x.staffID == name).Select(y => y.deptID ).First().ToString();//supposed to be in DepartmentDAO
            List<cart> lc = new List<cart>();
            lc =(List < cart >) Session["cart"];
            if (lc.Count>0)
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                int judge = 0;
                int num = 0;
                foreach (Control i in cartRepeater.Items)//get Quantity
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                    if (cartqty.Text.Trim() == "")
                    {
                        judge = 1;
                        break;
                    }
                    try
                    {
                        lc[num].Qty = Int32.Parse(cartqty.Text.ToString());
                    }
                    catch
                    {
                        judge = 1;
                        break;
                    }

                    if ((lc[num].Qty % 1 != 0)||(lc[num].Qty<=0))
                    {
                        judge = 1;
                        break;
                    }
                    dict.Add(deletebtn.CommandArgument.ToString(), Int32.Parse(cartqty.Text.ToString()));
                    num++;
                }
                if (judge == 0)
                {
                    RequisitionDAO rdao = new RequisitionDAO();
                    rdao.addRequisition(name, deptID, dict);

                    lc = new List<cart>();//clear the cart session
                    Session["cart"] = lc;

                    //send email and notification to head 
                    string headID = m.Departments.Where(x => x.deptID == deptID).Select(x => x.headStaffID).ToList().First();
                    string headName = m.DeptStaffs.Where(x => x.staffID == headID).Select(x => x.staffName).ToList().First();
                    string staffName = Session["loginName"].ToString();
                    string staffID = Session["loginID"].ToString();
                    NotificationDAO nDAO = new NotificationDAO();
                    nDAO.addDeptNotification(headID, staffName + " send a new requisition!", DateTime.Now);

                    Email email = new Email();
                    email.sendNewReqEmailToHead(staffName, headName);

                    HttpContext.Current.Response.Redirect("Emp_MyRequisition.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Input must be integer！');</script>");
                }
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
                    if(lc[i].ItemID == info)
                    {
                        lc.RemoveAt(i);
                        continue;
                    }
                    lc[i].Qty = Int32.Parse(a);             
            }
            Session["cart"] = lc;
            updateCart(lc);
        }



        //Test
        protected void catalogueRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
                 
        }
        //cart delete
        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {         
        }

        protected void cart_qtyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}