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
        
        DepartmentDAO dpd;
        string depName;
        string depid;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindDropdownlist();
                depName = DropDownList1.Text;
                depid = dpd.findDepartmentIdByName(depName);
                Label2.Text = dpd.getCollectionPointbyDepartmentId(depid);
                BindGrid();
            }

        }
        protected void BindDropdownlist()
        {
            dpd = new DepartmentDAO();
            DropDownList1.DataSource = dpd.findAllDepartmentName();
            DropDownList1.DataBind();
        }
      
        protected void BindGrid()
        {
            DisbursementListDAO disburList = new DisbursementListDAO();
            List<int> disburIds = disburList.getCurrentDisbursementsId("Awaiting For Deliver", depid);
            DisbursementItemDAO disburItem = new DisbursementItemDAO();
            List<DisbursementCart> disburItems = new List<DisbursementCart>();
            foreach (int s in disburIds)
            {
                disburItems = disburItems.Union(disburItem.getDisbursementCartItem(s)).ToList<DisbursementCart>();

            }
            GridView1.DataSource = disburItems;
            GridView1.DataBind();
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            depName = DropDownList1.SelectedItem.Text;
            dpd = new DepartmentDAO();
            depid = dpd.findDepartmentIdByName(depName);
            Label2.Text = dpd.getCollectionPointbyDepartmentId(depid);
            BindGrid();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            
        }
    }
}