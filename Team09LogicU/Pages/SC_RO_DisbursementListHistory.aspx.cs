using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;
using System.Globalization;

namespace Team09LogicU.Pages
{
    public partial class SC_RO_DisbursementListHistory : System.Web.UI.Page
    {
        DepartmentDAO dDAO = new DepartmentDAO();
        DisbursementDAO disDAO = new DisbursementDAO();
        StoreStaffDAO sDAO = new StoreStaffDAO();
        private string deptName;
        private string deptID;
        public void BindDropDownList()
        {
            deptDropDownList.DataSource = dDAO.findAllDepartmentName();
            deptDropDownList.DataBind();
        }
        public void initDisbursement (string deptID)
        {

            List<Disbursement> list = new List<Disbursement>();
            list = disDAO.getAllCompletedDisbursementBydeptID(deptID);

            List<DisbursementHistory> finalList = new List<DisbursementHistory>();
            for (int i = 0; i < list.Count(); i++)
            {
                finalList.Add(new DisbursementHistory());
                finalList[i].DisbursementID = list[i].disbursementID;
                finalList[i].StaffName = sDAO.getStoreStaffNameByID(list[i].storeStaffID);
                finalList[i].Date = list[i].disburseDate;
            }
            disburseHisGridView.DataSource = finalList;
            disburseHisGridView.DataBind();
        }
        public void postBackDisbursement(DateTime from,DateTime to,string deptID)
        {
            List<Disbursement> list = new List<Disbursement>();
            list = disDAO.getAllCompletedDisbursementBydeptIDandDate(from, to, deptID);

            List<DisbursementHistory> finalList = new List<DisbursementHistory>();
            for (int i = 0; i < list.Count(); i++)
            {
                finalList.Add(new DisbursementHistory());
                finalList[i].DisbursementID = list[i].disbursementID;
                finalList[i].StaffName = sDAO.getStoreStaffNameByID(list[i].storeStaffID);
                finalList[i].Date = list[i].disburseDate;
            }
            disburseHisGridView.DataSource= finalList;
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
                List<Disbursement> list = new List<Disbursement>();
                list = disDAO.getAllCompletedDisbursementBydeptID(deptID);

                List<DisbursementHistory> finalList = new List<DisbursementHistory>();
                for (int i = 0; i < list.Count(); i++)
                {
                    finalList.Add(new DisbursementHistory());
                    finalList[i].DisbursementID = list[i].disbursementID;
                    finalList[i].StaffName = sDAO.getStoreStaffNameByID(list[i].storeStaffID);
                    finalList[i].Date = list[i].disburseDate;
                }
                disburseHisGridView.DataSource = finalList;
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