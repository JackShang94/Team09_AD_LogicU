using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.pages
{
    public partial class SC_RO_DisbursementList : System.Web.UI.Page
    {
        
        DepartmentDAO dpd=new DepartmentDAO();
        DisbursementDAO disDAO = new DisbursementDAO();
        string deptName;
        string deptid;
        
        protected void BindDropdownlist()
        {
            deptDropDownList.DataSource = dpd.findAllDepartmentName();
            deptDropDownList.DataBind();
        }

        protected void disburseBindGrid()
        {
            deptName = deptDropDownList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            disburseGridView.DataSource= disDAO.getAwaitingDisbursementListByDeptID(deptid);
            disburseGridView.DataBind();
        }
        protected void disburseItemBindGrid(int disburseID)
        {
            DisbursementDAO disDAO = new DisbursementDAO();
            List<DisbursementCart> disburseItems = disDAO.getDisbursementItemByDisID(disburseID);
            ViewState["list"] = disburseItems;
            disburseItemGridView.DataSource = disburseItems;
            disburseItemGridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string role = Session["loginRole"].ToString();

                if (role != "clerk")
                {
                    HttpContext.Current.Response.Redirect("login.aspx");
                    return;
                }

                BindDropdownlist();
                ViewState["list"] = new List<DisbursementCart>();

                deptName = deptDropDownList.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
                disburseBindGrid();
                ViewState["disburseID"] = 0;
                ViewState["originQty"] = 0;
            }
            else
            {
                deptName = deptDropDownList.SelectedItem.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
            }
        }
       

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptName = deptDropDownList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
            disburseGridView.SelectedIndex = -1;//initialize the selected index
            /****************this is for QRcode******************/
            ConfirmBtn.Enabled = false;
            NotifyButton.Enabled = false;
            /****************end***********************************/
            disburseBindGrid();
            
            disburseItemGridView.DataSource = null;
            disburseItemGridView.DataBind();
            disburseItemUpdatePanel.Update();
        }
        protected void disburseGridView_SelectedIndexChanged(object sender, EventArgs e)
        { 
            ConfirmBtn.Enabled = true;
            NotifyButton.Enabled = true;
            Label s = disburseGridView.SelectedRow.FindControl("disburseIDLabel") as Label;
            string a = s.Text;
            int disburseID = Convert.ToInt32(a);
            ViewState["disburseID"] = Convert.ToInt32(a);
            

            disburseItemBindGrid(disburseID);
            disburseItemUpdatePanel.Update();

        }
        protected void disburseItemGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            int s = e.NewEditIndex;
            Label b = disburseItemGridView.Rows[e.NewEditIndex].FindControl("lblActual") as Label;
            int originActual = Convert.ToInt32(b.Text);
            ViewState["originQty"] = originActual;

            disburseItemGridView.EditIndex = e.NewEditIndex;
            disburseItemGridView.DataSource =(List<DisbursementCart>)ViewState["list"];
            disburseItemGridView.DataBind();
        }
          
        protected void disburseItemGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = disburseItemGridView.Rows[e.RowIndex];
            int actual = Int32.Parse((row.FindControl("Actual") as TextBox).Text);


            string itemID = (row.FindControl("itemIDLabel") as Label).Text;
          

            if (Convert.ToInt32(ViewState["originQty"]) == actual)
            {
                disburseItemGridView.EditIndex = -1;
                disburseItemGridView.DataSource = (List<DisbursementCart>)ViewState["list"];
                disburseItemGridView.DataBind();
            }
            else
            {
                DisbursementDAO disDAO = new DisbursementDAO();
                //List<DisbursementCart> updateList = (List<DisbursementCart>)ViewState["list"];
                disDAO.savingActualQty(Convert.ToInt32(ViewState["disburseID"]),itemID, actual);
                disburseItemGridView.EditIndex = -1;
                List<DisbursementCart> ldc = (List<DisbursementCart>)ViewState["list"];
                foreach(var i in ldc)
                {
                    if (i.ID == itemID)
                    {
                        i.Actual = actual;
                        break;
                    }
                }
                disburseItemGridView.DataSource = (List<DisbursementCart>)ViewState["list"];
                disburseItemGridView.DataBind();
                //disburseUpdatePanel.Update();
            }
          
        }

        protected void disburseItemGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            disburseItemGridView.EditIndex = -1;
            disburseItemBindGrid(Convert.ToInt32(ViewState["disburseID"]));
            
        }


        /***********************this confirm button simulates the scene after scanning QRcode (only for Test)**********************************/
        /**********************To confirm specified dept disbursement**************************************************************/
        protected void Button3_Click(object sender, EventArgs e)
        {
            int disburseID = Convert.ToInt32(ViewState["disburseID"]);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you are generate the Disbursement " + disburseID + " ?')", true);
            //here should send message box yes or no

            DisbursementDAO disDAO = new DisbursementDAO();
            
            //disburList
            ConfirmBtn.Enabled = false;
            disDAO.updateDisbursementStatus(Convert.ToInt32(ViewState["disburseID"]), "Completed");
            disburseGridView.SelectedIndex = -1;
            disburseBindGrid();
            disburseUpdatePanel.Update();
            disburseItemGridView.DataSource = null;
            disburseItemGridView.DataBind();

            //send email and notification to rep 
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            string repID = context.Departments.Where(x => x.deptID == deptid).Select(x => x.repStaffID).ToList().First();
            string repName = context.DeptStaffs.Where(x => x.staffID == repID).Select(x => x.staffName).ToList().First();
            string confirmDate = DateTime.Now.ToShortDateString();
            NotificationDAO nDAO = new NotificationDAO();
            nDAO.addDeptNotification(repID, "Disbursement "+ disburseID+" is confirmed on "+ confirmDate, DateTime.Now);

            Email email = new Email();
            email.sendConfirmedDisbursementEmailToRep(repName, confirmDate, disburseID.ToString());


        }

        protected void disburseItemGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    
        }

        protected void NotifyButton_Click(object sender, EventArgs e)
        {
            NotifyButton.Enabled = false ;
            //send email and notification to rep 
            Label s = disburseGridView.SelectedRow.FindControl("disburseIDLabel") as Label;
            string a = s.Text;
            int disburseID = Convert.ToInt32(a);
            SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
            Disbursement disbursement = disDAO.getDisbursmentbyId(disburseID);
            string deptid = disbursement.deptID;
            string repID = context.Departments.Where(x => x.deptID == deptid).Select(x => x.repStaffID).ToList().First();
            string repName = context.DeptStaffs.Where(x => x.staffID == repID).Select(x => x.staffName).ToList().First();
            string disbursementDate = disbursement.disburseDate.ToShortDateString();
            string collectionPointID = context.Departments.Where(x => x.deptID == deptid).Select(x => x.collectionPointID).ToList().First();
            string collectionPoint = context.CollectionPoints.Where(x => x.collectionPointID == collectionPointID).Select(x => x.description).ToList().First();
            NotificationDAO nDAO = new NotificationDAO();
            nDAO.addDeptNotification(repID, "Disbursement " + disbursement.disbursementID + " is confirmed on " + disbursementDate, DateTime.Now);

            Email email = new Email();
            email.sendDisbursementEmailToRep(repName, disbursementDate, collectionPoint);
        }
    }
}