using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using System.Globalization;
namespace Team09LogicU.Pages
{
    public partial class SC_RO_DisbursementListHistory : System.Web.UI.Page
    {
        DepartmentDAO dDAO = new DepartmentDAO();
        DisbursementDAO disDAO = new DisbursementDAO();
        private string deptName;
        private string deptID;
        public void BindDropDownList()
        {

            deptDropDownList.DataSource = dDAO.findAllDepartmentName();
            deptDropDownList.DataBind();
        }
        public void initDisbursement (string deptID)
        {
           
           
            disburseHisGridView.DataSource = disDAO.getAllCompletedDisbursementBydeptID(deptID);
            disburseHisGridView.DataBind();
        }
        public void postBackDisbursement(DateTime from,DateTime to,string deptID)
        {
            
            disburseHisGridView.DataSource= disDAO.getAllCompletedDisbursementBydeptIDandDate(from, to, deptID);
            disburseHisGridView.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string role = Session["loginRole"].ToString();
                if (role != "clerk")
                {
                    Response.Redirect("login.aspx");
                }
                BindDropDownList();
                this.deptName = deptDropDownList.Text;
                this.deptID = dDAO.findDepartmentIdByName(this.deptName);
                
                if (Session["disfromDate"] ==null||Session["distoDate"]==null)
                {
                    fromTextBox.Text =DateTime.Today.ToString("mm/dd/yyyy", CultureInfo.InvariantCulture);
                    toTextBox.Text = DateTime.Today.ToString("mm/dd/yyyy", CultureInfo.InvariantCulture);
                    initDisbursement(this.deptID);
                }else
                {
                    DateTime from = (DateTime)Session["disfromDate"];
                    DateTime to = (DateTime)Session["distoDate"];
                    fromTextBox.Text = from.ToString();
                    toTextBox.Text = to.ToString();
                    postBackDisbursement(from, to, this.deptID);
                }
               

            }
        }

        protected void disburseHisGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = disburseHisGridView.SelectedIndex;
            Label l= disburseHisGridView.SelectedRow.FindControl("disIDLabel") as Label;
            string disID = l.Text;
            Response.Redirect("SC_RO_DisbursementListHistory_ViewDetail.aspx?"+
                "disID="+disID);
            return;
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string f = fromTextBox.Text;
            string t = toTextBox.Text;

            if (f == "" || t == "")
            {
                this.deptName = deptDropDownList.Text;
                this.deptID = dDAO.findDepartmentIdByName(this.deptName);
                disburseHisGridView.DataSource = disDAO.getAllCompletedDisbursementBydeptID(deptID);
                disburseHisGridView.DataBind();
                return;
            }


            DateTime from = Convert.ToDateTime(f);
            DateTime to = Convert.ToDateTime(t);
            if (DateTime.Compare(from, to) > 0){
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage1", "alert('Please Enter correct date range')", true);
                return;
            }

            this.deptName = deptDropDownList.Text;
            this.deptID = dDAO.findDepartmentIdByName(this.deptName);
            postBackDisbursement(from, to, this.deptID);

        }
    }
}