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
    public partial class SC_Inv_AdjustmentVoucher : System.Web.UI.Page
    {
        ItemDAO itemDAO = new ItemDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        List<Item> itemList;
        public string staffID;
        TextBox tb = new TextBox();
        string strPageNum = "";
        public void updateCart(List<AdjustmentVouchercart> lac)
        {
            Session["adjvcart"] = lac;
            cartRepeater.DataSource = lac;
            cartRepeater.DataBind();
        }
        public void updateCatalogue(List<Item> li)
        {
            DataTable iTable = new DataTable("itemTable");
            iTable.Columns.Add(new DataColumn("itemID", typeof(string)));
            iTable.Columns.Add(new DataColumn("categoryID", typeof(string)));
            iTable.Columns.Add(new DataColumn("description", typeof(string)));
            iTable.Columns.Add(new DataColumn("unitOfMeasure", typeof(string)));
          
            foreach (Item i in li)
            {
                DataRow dr = iTable.NewRow();
                dr["itemID"] = i.itemID;
                dr["categoryID"] = i.categoryID;
                dr["description"] = i.description;
                dr["unitOfMeasure"] = i.unitOfMeasure;
            
                iTable.Rows.Add(dr);
            }
            GridView_CatalogList.DataSource = iTable;
            GridView_CatalogList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {
                dropDownList_bindCatInfo();
                //this.BindGrid();
                if (Session["adjvcart"] == null)
                {
                    Session["adjvcart"] = new List<AdjustmentVouchercart>();
                }
                /**********************Loading Cart List************************************/

                //string name = Session["loginID"].ToString();
                string name = Session["loginID"].ToString();
                this.staffID = name;
                if (this.staffID == null)
                {
                    Response.Redirect("login.aspx");

                }

                string role = Session["loginRole"].ToString();
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
                if (role != "clerk" )
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                List<AdjustmentVouchercart> lac = (List<AdjustmentVouchercart>)Session["adjvcart"];



                updateCart(lac);
                ItemDAO idao = new ItemDAO();
            }
        }

        public void dropDownList_bindCatInfo()
        {
            List<Category> catList = categoryDAO.getCategoryList();
            DropDownList_cat.DataSource = catList;
            DropDownList_cat.DataTextField = "categoryID";
            DropDownList_cat.DataValueField = "categoryID";
            DropDownList_cat.AppendDataBoundItems = true;
            DropDownList_cat.Items.Insert(0, new ListItem("--All--"));
            DropDownList_cat.DataBind();
        }

        protected void DropDownList_cat_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateGridviewByDropdownList();



        }
        protected void UpdateGridviewByDropdownList()
        {
            updateGV();
        }               

       protected void Submit_Click(object sender, EventArgs e)
        {
            string name = this.staffID;
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
            lac = (List<AdjustmentVouchercart>)Session["adjvcart"];
            if (lac.Count > 0)
            {
                int num = 0;
                foreach (Control i in cartRepeater.Items)//get Quantity
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get quantity
                    TextBox cartrecord = i.FindControl("cart_recordTextBox") as TextBox;//get record
                    lac[num].ItemID = deletebtn.CommandArgument.ToString();
                    if (cartqty.Text.ToString() == null)
                    {
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Input quanqtity！');</script>");
                        break;
                    }
                    lac[num].Qty = Int32.Parse(cartqty.Text.ToString());
                    if (lac[num].Qty % 1 != 0)
                    {
                        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Input must be integer！');</script>");
                        break;
                    }
                    lac[num].Record = cartrecord.Text; 
                    num++;
                }

                AdjustmentVoucherDAO adjvdao = new AdjustmentVoucherDAO();
                adjvdao.addAdjustmentVoucher(name, lac);
                lac = new List<AdjustmentVouchercart>();//clear the cart session
                Session["adjvcart"] = lac;

                //send email and notification to rep 
                SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
                string clerkName = Session["loginName"].ToString();
                StoreStaff supervisor = context.StoreStaffs.Where(x => x.role == "supervisor").ToList().First();
                string supervisorID = supervisor.storeStaffID;
                string supervisorName = supervisor.storeStaffName;

                string confirmDate = DateTime.Now.ToShortDateString();
                NotificationDAO nDAO = new NotificationDAO();
                nDAO.addDeptNotification(supervisorID, clerkName+" has send an adjustment voucher!" + confirmDate, DateTime.Now);

                Email email = new Email();
                email.sendAdjustmentEmailToSupervisor(clerkName,supervisorName);

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
           
            if (e.CommandName == "Add")
            {
                List<AdjustmentVouchercart> lac = new List<AdjustmentVouchercart>();
                lac = (List<AdjustmentVouchercart>)Session["adjvcart"];//get cart from Session
                string name = this.staffID;
                string itemid = e.CommandArgument.ToString();
                int alert = 0;
                foreach (Control i in cartRepeater.Items)//get Quantity from the cart
                {
                    LinkButton deletebtn = i.FindControl("cart_deleteButton") as LinkButton;//get itemID
                    TextBox cartqty = i.FindControl("cart_qtyTextBox") as TextBox;//get currrent quantity
                    TextBox cartrecord = i.FindControl("cart_recordTextBox") as TextBox;//get record
                    string a = cartqty.Text;
                    if (a == null)
                    {
                        a = "1";
                    }
                    string b = cartrecord.Text;
                    foreach (var k in lac)
                    {
                        if (k.ItemID == deletebtn.CommandArgument.ToString())
                        {
                            k.Record = b;
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
                                j.Record = b;
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
                    Qty = 1//default
                };

                lac.Add(c);
                Session["adjvcart"] = lac;
                cartUpdatePanel.Update();
                updateCart(lac);
            }
            if (e.CommandName == "go")
            {
                tb = (TextBox)GridView_CatalogList.BottomPagerRow.FindControl("inPageNum");

            }

            try
            {

                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                GridView_CatalogList_PageIndexChanging(null, ea);
            }
            catch
            {
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
                TextBox cartrecord = cartRepeater.Items[i].FindControl("cart_recordTextBox") as TextBox;//get current record
                string a = cartqty.Text;
                string c= cartrecord.Text;
                if (lac[i].ItemID == info)
                {
                    lac.RemoveAt(i);
                    continue;
                }
                lac[i].Qty = Int32.Parse(a);
                lac[i].Record = c;

            }

            Session["adjvcart"] = lac;
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
        protected void updateGV()
        {
            string keyword = DropDownList_cat.Text;


            ItemDAO idao = new ItemDAO();
            string sText = DropDownList_cat.Text.ToString();
            if (sText == "--All--")
            {             
                updateCatalogue(idao.getItemList());           
            }
            else
            {
                updateCatalogue(idao.getItemByCategory(sText));
            }
        }
        protected void cart_qtyTextBox_TextChanged(object sender, EventArgs e)
            {

            }

        protected void GridView_CatalogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                tb = (TextBox)GridView_CatalogList.BottomPagerRow.FindControl("inPageNum");
                GridView_CatalogList.PageIndex = e.NewPageIndex;
                tb.Text = (GridView_CatalogList.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                updateGV();


            }
            catch
            {
            }
        }
    }
}