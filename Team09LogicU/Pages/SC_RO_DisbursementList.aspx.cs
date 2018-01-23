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
            List<DisbursementItem> disburItems = new List<DisbursementItem>();
            foreach (int s in disburIds)
            {
                disburItems = disburItems.Union(disburItem.getDisbursementItemsByDisbursementId(s)).ToList<DisbursementItem>();
            }
            GridView1.DataSource = disburItems;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            depName = DropDownList1.SelectedItem.Text;
            dpd = new DepartmentDAO();
            depid = dpd.findDepartmentIdByName(depName);
            BindGrid();
        }
    }
}