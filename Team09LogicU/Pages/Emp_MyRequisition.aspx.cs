using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.App_Code.DAO;
namespace Team09LogicU.pages
{
    public partial class Emp_MyRequisition : System.Web.UI.Page
    {
        public List<Requisition> lr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //for session judgment
            //

            Session["loginID"] = "emp006";
            string role = Session["loginRole"].ToString();
            role = "emp";
            //SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            if (role != "emp")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "function(){"
                //        + "alert('NOT EMP!!!'); document.location.href='/login.aspx';} ", true);
                HttpContext.Current.Response.Redirect("login.aspx");
                return;
            }
            List<Requisition> lr_h = new List<Requisition>();//finally store stuffs without pending
            List<Requisition> lr = new List<Requisition>();//to store the pending 
            RequisitionDAO rdao = new RequisitionDAO();
            string name = Session["loginID"].ToString();
            name = "emp006";
            lr_h = rdao.getRequisitionByStaffID(name);

            for(int i = lr_h.Count - 1; i >= 0; i--)
            {
                if (lr_h[i].status == "pending")
                {
                    lr.Add(lr_h[i]);
                    lr_h.RemoveAt(i);
                }
            }
            /**************send pending list*******************/
            requisitionListGridView.DataSource = lr;
            requisitionListGridView.DataBind();


            /***************send history************************/
            requisitionHistoryGridView.DataSource = lr_h;
            requisitionHistoryGridView.DataBind();


        }

        

        protected void requisitionListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "delete")
            {
                int req =Int32.Parse( e.CommandArgument.ToString());
                //int req = Int32.Parse(requisitionListGridView.DataKeys[e.RowIndex].Values["requisitionID"].ToString());//Get the requisition id;
                RequisitionDAO rdao = new RequisitionDAO();
                rdao.removeRequisition(req);
                string name = Session["loginID"].ToString();
                this.lr = rdao.getRequisitionByStaffID(name);
                
                requisitionListGridView.DataSource = rdao.getReqByStaffIDandStatus(name,"pending");
                requisitionListGridView.DataBind();
            }
        }

        protected void editReqDetailBtn_Click(object sender, EventArgs e)
        {
            LinkButton b = (LinkButton)sender;
            string c = b.CommandArgument.ToString();
            HttpContext.Current.Response.Redirect("Emp_MR_RequisitionDetail.aspx?" +
                "reqID=" + c);
            return;

        }
        protected void requisitionListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //leave it blank
        }
        protected void viewReqDetailBtn_h_Click(object sender, EventArgs e)
        {
            LinkButton viewBtn=(LinkButton)sender;
            string c =  viewBtn.CommandArgument.ToString();
            HttpContext.Current.Response.Redirect("Emp_MR_RequisitionDetail.aspx?" +
                   "reqID=" + c);
        }
    }
}