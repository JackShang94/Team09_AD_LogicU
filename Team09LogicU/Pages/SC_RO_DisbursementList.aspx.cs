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
        }
        protected void disburseItemBindGrid(int disburseID)
        {
            DisbursementDAO disburList = new DisbursementDAO();
            List<DisbursementCart> disburseItems = disburList.getDisbursementItemByDisID(disburseID);
            ViewState["list"] = disburseItems;
            disburseItemGridView.DataSource = disburseItems;
            disburseItemGridView.DataBind();
        }
        //int disID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownlist();
                ViewState["list"] = new List<DisbursementCart>();

                deptName = deptDropDownList.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
                disburseBindGrid();
                ViewState["disburseID"] = 0;

                Button3.Visible = false;
            }
            else
            {
                //disID = Convert.ToInt32(Session["disburseID"]);
                deptName = deptDropDownList.SelectedItem.Text;
                deptid = dpd.findDepartmentIdByName(deptName);
                collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
                disburseBindGrid();
            }
        }
       

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptName = deptDropDownList.SelectedItem.Text;
            //dpd = new DepartmentDAO();
            deptid = dpd.findDepartmentIdByName(deptName);
            collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(deptid);
            disburseBindGrid();
        }

        protected void disburseItemGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            disburseItemGridView.EditIndex = e.NewEditIndex;
            disburseItemGridView.DataSource =(List<DisbursementCart>)ViewState["list"];
            disburseItemGridView.DataBind();
        }
          
        protected void disburseItemGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = disburseItemGridView.Rows[e.RowIndex];
            int actual = Int32.Parse((row.FindControl("Actual") as TextBox).Text);

            DisbursementDAO disDAO = new DisbursementDAO();
            Button b = sender as Button;
            string[] info = b.CommandArgument.Split('&');
            string itemID = info[0];
            int originActual = Convert.ToInt32(info[1]);

            if (originActual == actual)
            {
                disburseItemGridView.EditIndex = -1;
                disburseItemGridView.DataSource = (List<DisbursementCart>)ViewState["list"];
                disburseItemGridView.DataBind();
            }
            else
            {
                //List<DisbursementCart> updateList = (List<DisbursementCart>)ViewState["list"];
                disDAO.savingActualQty(Convert.ToInt32(ViewState["disburseID"]), itemID, actual);
                disburseItemGridView.EditIndex = -1;

                disburseItemGridView.DataSource = (List<DisbursementCart>)ViewState["list"];
                disburseItemGridView.DataBind();
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


            DisbursementDAO disDAO = new DisbursementDAO();
            //disburList
            disDAO.updateDisbursementStatus(Convert.ToInt32(ViewState["disburseID"]), "Completed");
            
            
            
        }

        protected void disburseGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = disburseGridView.SelectedRow.RowIndex;
            Label s = disburseGridView.SelectedRow.FindControl("disburseIDLabel") as Label;
            string a = s.Text;
            int disburseID = Convert.ToInt32(a);
            //ViewState["disburseID"] = Convert.ToInt32(a);
            
            DisbursementDAO disDAO = new DisbursementDAO();
            disburseItemBindGrid(disburseID);
            //disburList.getDisbursementItemByDisID(disburseID);

        }
    }
}