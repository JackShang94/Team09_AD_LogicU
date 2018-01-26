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
        //private static List<RetrievalFormItem> lrfi;
        //private static string itemID;
        //private static string deptID;
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
                if (ViewState["date"] == null)
                {
                    ViewState["date"] = new DateTime();
                }

            }
            else
            {
                
                //retrievalGridView.DataSource = SC_RO_RetrievalForms.lrfi;
                //retrievalGridView.DataBind();
                //retrievalUpdatePanel.Update();
            }
           
            //*******************************this is test code****************//
            //DateTime date = new DateTime(2018, 1, 21);

            //get retrievedItemList
           // List<RetrievalFormItem> retrievedItemList= retrievalDAO.getRetrievalFormByDate(date);

            //confirm retrieval
            //retrievalDAO.ConfirmRetrieval(retrievedItemList);
            //*******************************this is tes code****************//

        }

        protected void retrievalGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            List<RetrievalFormItem> lrfi = new List<RetrievalFormItem>();
            string a = beforeDate.Text;
            if (a == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please pick correct date')", true);
                return;
            }
            ViewState["date"] = Convert.ToDateTime(a);
            lrfi = retrievalDAO.getRetrievalFormByDate(Convert.ToDateTime(a));
           
            ViewState["lrfi"] = lrfi;
            
           
            //SC_RO_RetrievalForms.lrfi = lrfi;
            retrievalGridView.DataSource = lrfi;
            retrievalGridView.DataBind();
            breakdownGridView.DataSource = null;
            breakdownGridView.DataBind();
        }

        protected void retrievalGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView gv = sender as GridView;
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    // Hiding the Select Button Cell in Header Row.
            //    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            //}
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    // Hiding the Select Button Cells showing for each Data Row. 
            //    e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            //    // Attaching one onclick event for the entire row, so that it will
            //    // fire SelectedIndexChanged, while we click anywhere on the row.
            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gv, "Select$" + e.Row.RowIndex);
                
            //}
        }

        protected void retrievalGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName.ToString() == "edit")
            //{
               
            //    SC_RO_RetrievalForms.deptID = e.CommandArgument.ToString();
            //}
        }

        protected void retrievalGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = retrievalGridView.SelectedRow.RowIndex;
            //var lllll = retrievalGridView.SelectedRow.Cell[];//???????why cannot get this cell's value
            Label s =retrievalGridView.SelectedRow.FindControl("itemIDLabel") as Label;
            string a =s.Text;
            
            ViewState["itemID"] = a;
            //SC_RO_RetrievalForms.itemID = a;

            breakdownGridView.Visible = true;
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>)ViewState["lrfi"];
            //List<BreakdownByDepartment> lbbd = SC_RO_RetrievalForms.lrfi[index].BreakList;
            breakdownGridView.DataSource = lrfi[index].BreakList;
            breakdownGridView.DataBind();
            breakdownUpdatePanel.Update();
        }

     
        protected void breakdownGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {//trigger first
            breakdownGridView.EditIndex= e.NewEditIndex;
            List<RetrievalFormItem> lrfi = new List<RetrievalFormItem>();
            lrfi = (List<RetrievalFormItem>) ViewState["lrfi"];
            string itemID = ViewState["itemID"].ToString();
            breakdownGridView.DataSource = lrfi.First(x => x.ItemID == itemID).BreakList;
            breakdownGridView.DataBind();
            //SC_RO_RetrievalForms.lrfi.
        }

        protected void breakdownGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = breakdownGridView.Rows[e.RowIndex];
            TextBox t = row.Cells[2].Controls[1] as TextBox;
            string s = t.Text;
            int a = Convert.ToInt32(s);// get the changed quantity
            //int a =Convert.ToInt32( e.NewValues["actual"].ToString());
            string deptID = (breakdownGridView.Rows[e.RowIndex].FindControl("deptID") as Label).Text;
            //string itemID = SC_RO_RetrievalForms.itemID;
            string itemID = ViewState["itemID"].ToString();
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>) ViewState["lrfi"];
            int sum=0;
            var x = lrfi[0].BreakList;

            /**********************To find out the editing row and save it to lrfi**********************/
            for (int i=0;i<lrfi.Count;i++)
            {
                if (lrfi[i].ItemID == itemID)
                {
                   
                    for (int j=0;j<lrfi[i].BreakList.Count;j++)
                    {
                        if (lrfi[i].BreakList[j].DeptID == deptID)
                        {
                            lrfi[i].BreakList[j].Actual = a;
                            
                            x = lrfi[i].BreakList;
                            //break;
                        }
                        sum += lrfi[i].BreakList[j].Actual;
                    }
                    lrfi[i].Actual = sum;
                    break;
                }
            }

            List<RetrievalFormItem> lrfi2 = (List<RetrievalFormItem>)ViewState["lrfi"];//actually here is useless
            //ViewState["lrfi"] = lrfi;
           
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
            //string s = (breakdownGridView.SelectedRow.Cells[0].FindControl("deptID") as Label).Text;
            breakdownGridView.DataSource= lrfi.First(x=>x.ItemID==itemID).BreakList;
            breakdownGridView.DataBind();
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            if (((List<RetrievalFormItem>)ViewState["lrfi"]).Count != 0)
            {// what to confirm???? what if the lrfi change after changing 
                //here it should pop up the yes or no warning instead of an alert
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('change something?')", true);
            }
            List<RetrievalFormItem> lrfi = (List<RetrievalFormItem>)ViewState["lrfi"];
            retrievalDAO.ConfirmRetrieval(lrfi,(DateTime)ViewState["date"]);//haven't been tested
            HttpContext.Current.Response.Redirect("SC_RO_DisbursementList.aspx");//who the hell may know 
        }

        protected void breakdownGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {//doens't be triggered???
            
        }

   
    }
}