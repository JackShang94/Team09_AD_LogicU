using System;
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
        
        public void updateCart(List<cart> lc)
        {
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
                List<cart> lc = new List<cart>();

                foreach (var i in (List<cart>)Session["cart"])
                {
                    if (i.Name == name)
                    {
                        lc.Add(i);
                    }
                }
                //this.lcart = lc;

                //cartRepeater.ItemDataBound += new RepeaterItemEventHandler(cartItemDataBound);
                updateCart(lc);
                /******************************Loading Catalogue List********************************/
                ItemDAO idao = new ItemDAO();
                //this.lcatalogue = idao.getItemList();
                //   //catalogueRepeater.ItemDataBound += new RepeaterItemEventHandler(addItemDataBound);
                List<Item> li = idao.getItemList();
                updateCatalogue(li);//when model is being used,cannot get from it;

            }
            else
            {
                string name = Session["loginID"].ToString();
                List<cart> lc = new List<cart>();

                foreach (var i in (List<cart>)Session["cart"])
                {
                    if (i.Name == name)
                    {
                        lc.Add(i);
                    }
                }
                //this.lcart = lc;

                //cartRepeater.ItemDataBound += new RepeaterItemEventHandler(cartItemDataBound);
                updateCart(lc);
                ItemDAO idao = new ItemDAO();
                //this.lcatalogue = idao.getItemList();
                //   //catalogueRepeater.ItemDataBound += new RepeaterItemEventHandler(addItemDataBound);
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
        //void addItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    var btn = e.Item.FindControl("addBtn");
        //    btn.ClientIDMode = ClientIDMode.Static;
        //    btn.ID = "addBtn" + (e.Item.ItemIndex );

        //}

        //void cartItemDataBound(object sender,RepeaterItemEventArgs e)
        //{
        //    var btn = e.Item.FindControl("cart_deleteBtn");
        //    btn.ClientIDMode = ClientIDMode.Static;
        //    btn.ID = "cart_deleteBtn" + (e.Item.ItemIndex + 1);
        //}


        /****************************Search Button****************************/
        protected void item_searchBtn_Click(object sender, EventArgs e)
        {
            ItemDAO id = new ItemDAO();
            string sText = item_searchText.Text.ToString();
            if (string.IsNullOrWhiteSpace(sText))
            {
                //this.lcatalogue = id.getItemList();
                

                catalogueRepeater.DataSource = id.getItemList();
                catalogueRepeater.DataBind();
                catalogueUpdatePanel.Update();
                
                return;
            }
            /******************SearchByItemID!!!!*******************************/
            //this.lcatalogue = id.getItemByitemID(sText);
            
            catalogueRepeater.DataSource = id.getItemByitemID(sText);
            catalogueRepeater.DataBind();
            catalogueUpdatePanel.Update();


        }


      
        /************************************Submit Requisition*************************************/
        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = Session["loginID"].ToString();
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            ///should use DAO
            string deptID = m.DeptStaffs.Where(x => x.staffID == name).Select(y => y.deptID ).First().ToString();
            ///
            List<cart> lc = new List<cart>();
            lc =(List < cart >) Session["cart"];

            //add requisition items
            Dictionary<string, int> dict = new Dictionary<string, int>();

            List<string> ls = new List<string>();

            string j;
            foreach(Control  i in cartRepeater.Items)//get Quantity
            {
                Button deletebtn = i.FindControl("cart_deleteButton") as Button;//get itemID
                TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                dict.Add(deletebtn.CommandArgument.ToString(), Int32.Parse(cartqty.Text.ToString()));
                
            }


            
            //for (int i =lc.Count- 1; i >= 0; i--)//not foreach enumeration
            //{
            //    if (lc[i].Name == name)
            //    {
            //        lc.RemoveAt(i);
            //    }
            //}

            RequisitionDAO rdao = new RequisitionDAO();
            rdao.addRequisition(name, deptID, dict);
            lc = new List<cart>();//clear the cart session
            Session["cart"] = lc;


            HttpContext.Current.Response.Redirect("Emp_MyRequisition.aspx");
        }


        /*******************************add Item******************************************/
        protected void addBtn_Click(object sender, EventArgs e)
        {

            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];//get cart from Session
            string name = Session["loginID"].ToString();//get name from Session
            Button b = (Button)sender;//get this Button

            string[] info = b.CommandArgument.ToString().Split('&');

            foreach (Control i in cartRepeater.Items)//get Quantity
            {
                Button deletebtn = i.FindControl("cart_deleteButton") as Button;//get itemID
                TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                if (deletebtn.CommandArgument.ToString() == info[0])
                {
                    foreach (var j in lc)
                    {
                        if (j.ItemID == info[0])
                        {
                            j.Qty = Int32.Parse(cartqty.Text.ToString());//store quantity into session
                        }
                    }
                }
            }

            //wocao
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
            Button b = (Button)sender;
            string info = b.CommandArgument.ToString();//itemID and requiredQuantity

            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];
            

            for (int i =lc.Count-1; i >=0; i--)//remove session cart
            {
                if (lc[i].ItemID == info)
                {
                    lc.RemoveAt(i);
                }
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