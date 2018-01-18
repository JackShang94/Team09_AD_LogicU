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
        private List<cart> lcart;
        private List<Item> lcatalogue;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
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
            this.lcart = lc;

                //cartRepeater.ItemDataBound += new RepeaterItemEventHandler(cartItemDataBound);
                //cartRepeater.DataSource = lc;
                //cartRepeater.DataBind();
            
            //}
        /******************************Loading Catalogue List********************************/
         ItemDAO idao = new ItemDAO();
            //catalogueRepeater.ItemDataBound += new RepeaterItemEventHandler(addItemDataBound);
            catalogueRepeater.DataSource = idao.getItemList();
            catalogueRepeater.DataBind();

            
            
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
                this.lcatalogue = id.getItemList();
                //catalogueRepeater.DataSource = id.getItemList();
                //catalogueRepeater.DataBind();
                return;
            }
            /******************SearchByItemID!!!!*******************************/
            this.lcatalogue = id.getItemByitemID(sText);
            //catalogueRepeater.DataSource = id.getItemByitemID(sText);
            //catalogueRepeater.DataBind();
            
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
            for(int i = 0; i < lc.Count; i++)//not foreach enumeration
            {
                if (lc[i].Name == name)
                {
                    dict.Add(lc[i].ItemID, lc[i].Qty);
                    lc.RemoveAt(i);
                }
            }

            RequisitionDAO rdao = new RequisitionDAO();
            rdao.addRequisition(name, deptID, dict);

            Session["cart"] = lc;


            HttpContext.Current.Response.Redirect("Emp_MyRequisition.aspx");
        }


        /*******************************add Item******************************************/
        protected void addBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            //ItemDAO id = new ItemDAO();
            //cartRepeater.DataSource = id.getItemList() ;
            //cartRepeater.DataBind();
            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];
            string name = Session["loginID"].ToString();
            Button b = (Button)sender;
            string[] info = b.CommandArgument.ToString().Split('&');
            


            cart c = new cart
            {
                Name = name,
                ItemID = info[0],
                Description = info[1],//stupid
                Qty = 1//default
            };

            lc.Add(c);
            Session["cart"] = lc;

            b.Enabled = false;


            this.lcart = lc;
            //cartRepeater.DataSource = lc;
            //cartRepeater.DataBind();
        }
        /******************************Delete Item***********************************/
        protected void cart_deleteBtn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] info = b.CommandArgument.ToString().Split('&');//itemID and requiredQuantity

            List<cart> lc = new List<cart>();
            lc = (List<cart>)Session["cart"];

            for (int i = 0; i < lc.Count; i++)//why cannot use foreach??enumeration
            {
                if (lc[i].ItemID == info[0])
                {
                    lc.RemoveAt(i);
                }
            }
            Session["cart"] = lc;

            this.lcart = lc;
            //cartRepeater.DataSource = lc;
            //cartRepeater.DataBind();
        }



        //Test
        protected void catalogueRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName == "add")
            //{
            //    List<cart> lc = new List<cart>();
            //    lc = (List<cart>)Session["cart"];
            //    string name = Session["loginID"].ToString();

            //    string [] info = e.CommandArgument.ToString().Split('&');

          
            //    cart c = new cart
            //    {
            //        Name = name,
            //        ItemID = info[0],
            //        Description = info[1],//stupid
            //        Qty = 1
            //    };
                
            //    lc.Add(c);
            //    Session["cart"] = lc;
                
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

       
    }
}