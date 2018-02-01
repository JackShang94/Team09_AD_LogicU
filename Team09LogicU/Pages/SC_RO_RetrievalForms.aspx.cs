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
    public partial class SC_RO_RetrievalForms : System.Web.UI.Page
    {
        RetrievalDAO retrievalDAO = new RetrievalDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Session["loginID"].ToString();
                string role = Session["loginRole"].ToString();
                if (name == null)
                {
                    Response.Redirect("login.aspx");
                }
                if (role != "clerk")
                {
                    Response.Redirect("login.aspx");
                }

                if (ViewState["itemID"] == null)
                {
                    ViewState["itemID"] = "";
                }
                if (ViewState["lrfi"] == null)
                {
                    ViewState["lrfi"] = new List<RetrievalFormItem>();
                }
                List<RetrievalFormItem> lrfi = new List<RetrievalFormItem>();
                DateTime a = DateTime.Now;
                dateLablel.Text = a.ToString();
                lrfi = retrievalDAO.getRetrievalFormByDate(a);
                ViewState["lrfi"] = lrfi;
                retrievalGridView.DataSource = lrfi;
                retrievalGridView.DataBind();
                breakdownGridView.DataSource = null;
                breakdownGridView.DataBind();
            }
        }

        protected void retrievalGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void retrievalGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void retrievalGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = retrievalGridView.SelectedRow.RowIndex;
            Label s =retrievalGridView.SelectedRow.FindControl("itemIDLabel") as Label;
            string a =s.Text;
            
            ViewState["itemID"] = a;

            breakdownGridView.Visible = true;
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>)ViewState["lrfi"];
            breakdownGridView.DataSource = lrfi[index].BreakdownByDepartmentList;
            breakdownGridView.DataBind();
            breakdownUpdatePanel.Update();
        }

     
        protected void breakdownGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //trigger first
            breakdownGridView.EditIndex= e.NewEditIndex;
            List<RetrievalFormItem> lrfi = new List<RetrievalFormItem>();
            lrfi = (List<RetrievalFormItem>) ViewState["lrfi"];
            string itemID = ViewState["itemID"].ToString();
            breakdownGridView.DataSource = lrfi.First(x => x.ItemID == itemID).BreakdownByDepartmentList;
            breakdownGridView.DataBind();

        }

        protected void breakdownGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = breakdownGridView.Rows[e.RowIndex];
            TextBox t = row.Cells[2].Controls[1] as TextBox;
            string s = t.Text;
            int a = Convert.ToInt32(s);// get the changed quantity
            string deptID = (breakdownGridView.Rows[e.RowIndex].FindControl("deptID") as Label).Text;
            string itemID = ViewState["itemID"].ToString();
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>) ViewState["lrfi"];
            int sum=0;
            var x = lrfi[0].BreakdownByDepartmentList;

            /**********************To find out the editing row and save it to lrfi**********************/
            for (int i=0;i<lrfi.Count;i++)
            {
                if (lrfi[i].ItemID == itemID)
                {
                   
                    for (int j=0;j<lrfi[i].BreakdownByDepartmentList.Count;j++)
                    {
                        if (lrfi[i].BreakdownByDepartmentList[j].DeptID == deptID)
                        {
                            lrfi[i].BreakdownByDepartmentList[j].Actual = a;
                            
                            x = lrfi[i].BreakdownByDepartmentList;
                        }
                        sum += lrfi[i].BreakdownByDepartmentList[j].Actual;
                    }
                    lrfi[i].Actual = sum;
                    break;
                }
            }

            List<RetrievalFormItem> lrfi2 = (List<RetrievalFormItem>)ViewState["lrfi"];//actually here is useless    
           
            breakdownGridView.EditIndex = -1;
            breakdownGridView.DataSource =x;
            breakdownGridView.DataBind();

            retrievalGridView.DataSource =(List<RetrievalFormItem>) ViewState["lrfi"];
            retrievalGridView.DataBind();
            retrievalUpdatePanel.Update();
        }

        protected void breakdownGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            breakdownGridView.EditIndex = -1;
            int a = e.RowIndex;
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>)ViewState["lrfi"];
            string itemID = ViewState["itemID"].ToString();        
            breakdownGridView.DataSource= lrfi.First(x=>x.ItemID==itemID).BreakdownByDepartmentList;
            breakdownGridView.DataBind();
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            if (((List<RetrievalFormItem>)ViewState["lrfi"]).Count != 0)
            {
                // what to confirm???? what if the lrfi change after changing 
                //here it should pop up the yes or no warning instead of an alert
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('change something')", true);
            }
            
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>)ViewState["lrfi"];
            if (lrfi.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Nothing to Confirm!')", true);
                return;
            }
            retrievalDAO.ConfirmRetrieval(lrfi, DateTime.Today);

            HttpContext.Current.Response.Redirect("SC_RO_DisbursementList.aspx");
        }

        protected void breakdownGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {//doens't be triggered???
            
        }

   
    }
}