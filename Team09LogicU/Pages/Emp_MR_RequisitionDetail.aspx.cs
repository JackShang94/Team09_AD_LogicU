using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
namespace Team09LogicU.Pages
{
    public partial class Emp_MR_RequisitionDetail : System.Web.UI.Page
    {
        private string status;
        public int reqID;
        public int reqItemID;
        public List<RequisitionItem> lr_temp;
        public void initPendingDataGrid()
        {
            RequisitionItemDAO ridao = new RequisitionItemDAO();
            List<RequisitionItem> lri = new List<RequisitionItem>();
            lri = ridao.getRequisitionItem(this.reqID);
            lr_temp = lri;
            requisitionItemListGridView.DataSource = lri;
            requisitionItemListGridView.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                /******************judege the role*************************/
                string s_role = Session["loginRole"].ToString();
                string s_staffID = Session["loginID"].ToString();
                if(s_role!="req"&& s_role != "emp")
                {
                    Response.Redirect("Login.aspx");//it should alert() or redirect to an error page;
                }
                /******************Judge if the url query is empty***********************/
                int reqID = Int32.Parse(Request.QueryString["reqID"]);
                if (reqID.ToString() == null)
                {
                    Response.Redirect("Emp_MyRequisition.aspx");
                }

                /****************judge the staffID************************/
                RequisitionDAO rdao = new RequisitionDAO();
                string url_staffID = rdao.getStaffIDByReqID(reqID);
                if (url_staffID == null)
                {
                    Response.Redirect("Emp_MyRequisition");
                }
                if (url_staffID!= s_staffID)
                {
                    Response.Redirect("Login.aspx");//it should alert() or redirect to an error page;
                }
                

                //this.reqID = Int32.Parse(Request.QueryString["reqID"]);
                RequisitionItemDAO ridao = new RequisitionItemDAO();
                string status = rdao.getStatusByReqID(reqID);//get status
                if (status ==null)//this requisition doesn't exist
                {
                    Response.Redirect("Emp_MyRequisition.aspx");
                }
                this.status = status;

                List<RequisitionItem> lri = new List<RequisitionItem>();
                lri = ridao.getRequisitionItem(reqID);
                
                lr_temp = lri;//when loading page,save the detail list into the session
                requisitionItemListGridView.DataSource = lri;
                requisitionItemListGridView.DataBind();
            //}
            //else
            //{
            //    /******************judege the role*************************/
            //    string s_role = Session["loginRole"].ToString();
            //    string s_staffID = Session["loginID"].ToString();
            //    if (s_role != "req" && s_role != "emp")
            //    {
            //        Response.Redirect("Login.aspx");//it should alert() or redirect to an error page;
            //    }
            //    /******************Judge if the url query is empty***********************/
            //    int reqID = Int32.Parse(Request.QueryString["reqID"]);
            //    if (reqID.ToString() == null)
            //    {
            //        Response.Redirect("Emp_MyRequisition.aspx");
            //    }

            //    /****************judge the staffID************************/
            //    RequisitionDAO rdao = new RequisitionDAO();
            //    string url_staffID = rdao.getStaffIDByReqID(reqID);
            //    if (url_staffID != s_staffID)
            //    {
            //        Response.Redirect("Login.aspx");//it should alert() or redirect to an error page;
            //    }


            //    this.reqID = Int32.Parse(Request.QueryString["reqID"]);
            //    RequisitionItemDAO ridao = new RequisitionItemDAO();
            //    string status = rdao.getStatusByReqID(reqID);//get status
            //    this.status = status;

            //    List<RequisitionItem> lri = new List<RequisitionItem>();
            //    lri = ridao.getRequisitionItem(reqID);
            //    lr_temp = lri;//when loading page,save the detail list into the session
            //    requisitionItemListGridView.DataSource = lri;
            //    requisitionItemListGridView.DataBind();
            //}



    }


        
        protected void requisitionItemListGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*********************IF this is history page*************************************/
            if (this.status != "pending")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton a = (LinkButton)e.Row.FindControl("reqDetailEdit");
                    LinkButton b = (LinkButton)e.Row.FindControl("reqDetailDelete");
                    a.Visible = false;
                    b.Visible = false;
                }
            }

        }

        protected void backToReqBtn_Click(object sender, EventArgs e)
        {

            HttpContext.Current.Response.Redirect("Emp_MyRequisition.aspx");
        }

        protected void requisitionItemListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                //int reqItemID = Int32.Parse(e.CommandArgument.ToString());
                //GridViewRow gRow = (GridViewRow) (((LinkButton)e.CommandSource).NamingContainer );//get row index
                //TextBox t =(TextBox)gRow.FindControl("editQty");
                //t.ReadOnly = false;

            }
            else if (e.CommandName == "delete")
            {
                int reqItemID =Int32.Parse( e.CommandArgument.ToString());// reqitemID !!! not ItemID!!!!
                List<RequisitionItem> lri = new List<RequisitionItem>();

                lri =this.lr_temp;
                for(int i = lri.Count - 1; i >= 0; i--)
                {
                    if (lri[i].reqItemID == reqItemID)
                    {
                        lri.RemoveAt(i);
                    }
                }
                this.lr_temp = lri;
                if (lri.Count == 0)//IF deleting the last reqItem,DELETE this req
                {
                    RequisitionDAO rdao = new RequisitionDAO();
                    rdao.removeRequisition(this.reqID);
                    Response.Redirect("Emp_MyRequisition.aspx");
                    
                }
                RequisitionItemDAO ridao = new RequisitionItemDAO();
                ridao.removeItemByReqItemID(reqItemID);
                requisitionItemListGridView.DataSource = lri;
                requisitionItemListGridView.DataBind();
            }else if(e.CommandName=="Update"){
                this.reqItemID = Int32.Parse(e.CommandArgument.ToString());
                //int reqItemID = Int32.Parse(e.CommandArgument.ToString());
                //GridViewRow gRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);//get row index
                //TextBox t = (TextBox)gRow.FindControl("editQty");
                //LinkButton lb = (LinkButton)gRow.FindControl("reqDetailUpdate");
                //string a = t.Text;
                //t.ReadOnly = true;
            }else if (e.CommandName == "cancel")
            {

            }
        }
      
        protected void requisitionItemListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

                //blank here just in case of exception
        }
        protected void requisitionItemListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            requisitionItemListGridView.EditIndex = -1;
            initPendingDataGrid();

        }

        protected void requisitionItemListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow row = requisitionItemListGridView.Rows[e.RowIndex];
            //Control i = row.Cells[2].Controls[0];//get the quantity control( another way.............)
            //TextBox t = (TextBox)i;
            //string a = t.Text;
            RequisitionItemDAO ridao = new RequisitionItemDAO();
            string a = e.NewValues["requisitionQty"].ToString();//Here it cannt get changed value???

            int reqItemQty = Int32.Parse(a);
            //if (reqItemQty < 0)
            //{
                
            //    return;
            //}
            ridao.updateItemQty(this.reqItemID, reqItemQty);
            requisitionItemListGridView.EditIndex = -1;
            initPendingDataGrid();


        }

        protected void requisitionItemListGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            requisitionItemListGridView.EditIndex = e.NewEditIndex;
            initPendingDataGrid();
        }


    }
    
}