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
    public partial class Emp_MR_RequisitionDetail : System.Web.UI.Page
    {
        private string status;
        public int reqID;
        public int reqItemID;
        public List<ReqItems_custom> lr_temp;
        public void initPendingDataGrid()
        {
            RequisitionItemDAO ridao = new RequisitionItemDAO();
            //List<RequisitionItem> lri = new List<RequisitionItem>();
            List<ReqItems_custom> lri = new List<ReqItems_custom>();
            lri = ridao.getRequisitionItem(this.reqID);
            this.lr_temp = lri;
            requisitionItemListGridView.DataSource = lri;
            requisitionItemListGridView.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
                /******************judege the role*************************/
                string s_role = Session["loginRole"].ToString();
                string s_staffID = Session["loginID"].ToString();
                if(s_role!="rep"&& s_role != "emp")
                {
                    Response.Redirect("Login.aspx");//it should alert() or redirect to an error page;
                }
                /******************Judge if the url query is empty***********************/
                int reqID = Int32.Parse(Request.QueryString["reqID"]);
            
                if (reqID.ToString() == null)
                {
                    Response.Redirect("Emp_MyRequisition.aspx");
                }
                this.reqID = reqID;
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


            initPendingDataGrid();


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

            }
            else if (e.CommandName == "delete")
            {
                int reqItemID =Int32.Parse( e.CommandArgument.ToString());// reqitemID !!! not ItemID!!!!
                //List<RequisitionItem> lri = new List<RequisitionItem>();
                List<ReqItems_custom> lri = new List<ReqItems_custom>();
                lri =this.lr_temp;
                for(int i = lri.Count - 1; i >= 0; i--)
                {
                    if (lri[i].ReqItemID == reqItemID)
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
            GridViewRow row = requisitionItemListGridView.Rows[e.RowIndex];
            Control i = row.Cells[4].Controls[1];//get the quantity control( another way.............)
            TextBox t = (TextBox)i;
            string a = t.Text;
            RequisitionItemDAO ridao = new RequisitionItemDAO();         

            int reqItemQty = Int32.Parse(a);

            ridao.updateItemQty(this.reqItemID, reqItemQty);
            requisitionItemListGridView.EditIndex = -1;
            initPendingDataGrid();


        }

        protected void requisitionItemListGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            requisitionItemListGridView.EditIndex = e.NewEditIndex;
            initPendingDataGrid();
        }

        protected void reSubmit_Click(object sender, EventArgs e)
        {
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            RequisitionDAO rdao = new RequisitionDAO();

            Requisition newRequisition = new Requisition();
            Requisition oldRequisition = rdao.findRequisitionByrequisitionId(reqID);
            if (oldRequisition.status != "pending")
            {
                newRequisition.staffID = oldRequisition.staffID;
                newRequisition.deptID = oldRequisition.deptID;
                newRequisition.requisitionDate = DateTime.Now;
                newRequisition.status = "pending";

                context.Requisitions.Add(newRequisition);

                var oldRequisitionItemsList = oldRequisition.RequisitionItems;
                foreach (RequisitionItem item in oldRequisitionItemsList)
                {
                    RequisitionItem newItem = new RequisitionItem();
                    newItem.requisitionID = newRequisition.requisitionID;
                    newItem.itemID = item.itemID;
                    newItem.requisitionQty = item.requisitionQty;

                    context.RequisitionItems.Add(newItem);
                }
                context.SaveChanges();
                Response.Redirect("Emp_MyRequisition.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Warning', 'You can not resubmit a pending requisition！');</script>");
            }

        }
    }
    
}