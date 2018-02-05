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
        public string staffID;
        const int FixedRowCount = 4;
        public List<Requisition> lr_h;
        TextBox tb = new TextBox();
        string strPageNum = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //for session judgment
            string role = Session["loginRole"].ToString();
            if (!IsPostBack)
            {
                if (role != "rep" && role != "emp")
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }
                List<Requisition> lr_h = new List<Requisition>();//finally store stuffs without pending
                List<Requisition> lr = new List<Requisition>();//to store the pending 
                RequisitionDAO rdao = new RequisitionDAO();
                string name = Session["loginID"].ToString();
                /***************send history************************/
                updateGV();
                tb.Text = strPageNum;
            }

        }

        protected void requisitionListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "delete")
            {
                string a = e.CommandArgument.ToString();
                int req = Int32.Parse(e.CommandArgument.ToString());

                RequisitionDAO rdao = new RequisitionDAO();
                string name = Session["loginID"].ToString();
                rdao.removeRequisition(req);
                this.lr = rdao.getRequisitionByStaffID(name);

                requisitionListGridView.DataSource = rdao.getReqByStaffIDandStatus(name, "pending");
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
            LinkButton viewBtn = (LinkButton)sender;
            string c = viewBtn.CommandArgument.ToString();
            HttpContext.Current.Response.Redirect("Emp_MR_RequisitionDetail.aspx?" +
                   "reqID=" + c);
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            updateGV();
        }

        protected void updateGV()
        {
            /**************send pending list*******************/
            RequisitionDAO rdao = new RequisitionDAO();
            string name = Session["loginID"].ToString();
            lr = new List<Requisition>();//to store the pending 
            if ((fromDate.Text == "") && (toDate.Text == ""))
            {
                lr_h = rdao.getRequisitionByStaffID(name);

                for (int i = lr_h.Count - 1; i >= 0; i--)
                {
                    if (lr_h[i].status == "pending")
                    {
                        lr.Add(lr_h[i]);
                        lr_h.RemoveAt(i);
                    }
                }
            }
            else
            {
                if ((fromDate.Text == "") || (toDate.Text == ""))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage1", "alert('Plz Enter correct date range')", true);
                    return;
                }
                DateTime from = Convert.ToDateTime(fromDate.Text);
                DateTime to = Convert.ToDateTime(toDate.Text);
                if (DateTime.Compare(from, to) > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('Start Date should be greater than end Date')", true);
                    return;
                }
                if ((fromDate.Text != "") && (toDate.Text != ""))
                {
                    lr_h = rdao.findRequisitionByDateIndividual(from, to, name);

                    for (int i = lr_h.Count - 1; i >= 0; i--)
                    {
                        if (lr_h[i].status == "pending")
                        {
                            lr.Add(lr_h[i]);
                            lr_h.RemoveAt(i);
                        }
                    }
                }
            }
            requisitionListGridView.DataSource = lr;
            requisitionListGridView.DataBind();
            ShowRequisition(lr_h);
        }
        public void ShowRequisition(List<Requisition> lr_h)
        {
            requisitionHistoryGridView.DataSource = lr_h;
            requisitionHistoryGridView.DataBind();
        }

        protected void requisitionHistoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                tb = (TextBox)requisitionHistoryGridView.BottomPagerRow.FindControl("inPageNum");

                try
                {
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    requisitionHistoryGridView_PageIndexChanging(null, ea);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
                }
            }
        }

        protected void requisitionHistoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                tb = (TextBox)requisitionHistoryGridView.BottomPagerRow.FindControl("inPageNum");
                requisitionHistoryGridView.PageIndex = e.NewPageIndex;
                tb.Text = (requisitionHistoryGridView.PageIndex + 1).ToString();
                strPageNum = tb.Text;
                updateGV();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Page Number')", true);
            }
        }
    }
}
