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
        string depName;
        string depid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindDropdownlist();               
            }
            depName = DropDownList1.Text;
            depid = dpd.findDepartmentIdByName(depName);
            Label2.Text = dpd.getCollectionPointbyDepartmentId(depid);
            BindGrid();

        }
        protected void BindDropdownlist()
        {
            //dpd = new DepartmentDAO();
            DropDownList1.DataSource = dpd.findAllDepartmentName();
            DropDownList1.DataBind();
        }
      
        protected void BindGrid()
        {
            depName = DropDownList1.Text;
            depid = dpd.findDepartmentIdByName(depName);
            DisbursementListDAO disburList = new DisbursementListDAO();
            List<int> disburIds = disburList.getCurrentDisbursementsId("Awaiting For Deliver", depid);
            DisbursementItemDAO disburItem = new DisbursementItemDAO();
            List<DisbursementCart> disburItems = new List<DisbursementCart>();
            foreach (int s in disburIds)
            {
                disburItems = disburItems.Union(disburItem.getDisbursementCartItem(s)).ToList<DisbursementCart>();

            }
            Session["list"] = disburItems;
            GridView1.DataSource = disburItems;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            depName = DropDownList1.SelectedItem.Text;
            //dpd = new DepartmentDAO();
            depid = dpd.findDepartmentIdByName(depName);
            Label2.Text = dpd.getCollectionPointbyDepartmentId(depid);
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource =(List<DisbursementCart>)Session["list"];
            GridView1.DataBind();
        }
          
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int actual = Int32.Parse((row.FindControl("Actual") as TextBox).Text);
            List<DisbursementCart> updateList = (List<DisbursementCart>)Session["list"];
            foreach(DisbursementCart s in updateList)
            {
                s.Actual = actual;
            }
            GridView1.EditIndex = -1;
            Session["list"] = updateList;
            GridView1.DataSource = updateList;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = (List<DisbursementCart>)Session["list"];
            GridView1.DataBind();
        }
    }
}