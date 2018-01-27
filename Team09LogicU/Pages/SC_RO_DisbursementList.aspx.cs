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
        string deptName;
        string deptid;
        
        protected void BindDropdownlist()
        {
            //dpd = new DepartmentDAO();
            deptDropDownList.DataSource = dpd.findAllDepartmentName();
            deptDropDownList.DataBind();
        }

        protected void disburseBindGrid()
        {
            deptName = deptDropDownList.SelectedItem.Text;
            deptid = dpd.findDepartmentIdByName(deptName);
            DisbursementDAO disDAO = new DisbursementDAO();
            
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
        //int disID;
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
                //Button3.Visible = false;
            }
            else
            {
                //disID = Convert.ToInt32(Session["disburseID"]);
                deptName = deptDropDownList.SelectedItem.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
                //disburseBindGrid();
               // disburseItemBindGrid(Convert.ToInt32(ViewState["disburseID"]));
            }
        }
       

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptName = deptDropDownList.SelectedItem.Text;
            //dpd = new DepartmentDAO();
            deptid = dpd.findDepartmentIdByName(deptName);
            collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
            disburseGridView.SelectedIndex = -1;//initialize the selected index
                                                /****************this is for QRcode******************/
                                                //  Button3.Visible = false;//
            Button3.Enabled = false;

            /****************end***********************************/
            disburseBindGrid();
            //disburseUpdatePanel.Update();
            disburseItemGridView.DataSource = null;
            disburseItemGridView.DataBind();
        }
        protected void disburseGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Button3.Visible = true;        
            Button3.Enabled = true;

            //int index = disburseGridView.SelectedRow.RowIndex;
            Label s = disburseGridView.SelectedRow.FindControl("disburseIDLabel") as Label;
            string a = s.Text;
            int disburseID = Convert.ToInt32(a);
            ViewState["disburseID"] = Convert.ToInt32(a);
            

            disburseItemBindGrid(disburseID);
            //disburseItemUpdatePanel.Update();


            //disburList.getDisbursementItemByDisID(disburseID);

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
                    if (i.ItemID == itemID)
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
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('u r generate the Disbursement "+disburseID+" ?')", true);
            //here should send message box yes or no

            DisbursementDAO disDAO = new DisbursementDAO();
            //disburList
            disDAO.updateDisbursementStatus(Convert.ToInt32(ViewState["disburseID"]), "Completed");
            
            
            
        }

        protected void disburseItemGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    
        }
    }
}