using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
namespace Team09LogicU.pages
{
    public partial class SC_RO_OutstandingRequisition : System.Web.UI.Page
    {
        DepartmentDAO dpd = new DepartmentDAO();
        OutstandingItemDAO oidao = new OutstandingItemDAO();
        private string deptName;
        private string deptid;
        protected void outstandingBindGrid()
        {
            //depName = ;
            //this.deptid = dpd.findDepartmentIdByName(depName);
          
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loc"] != null)
                {
                    List<OutstandingCart> loc = new List<OutstandingCart>();
                    Session["loc"] = loc;
                }
                deptDropDownList.DataSource = dpd.findAllDepartmentName();
                deptDropDownList.DataBind();
                deptDropDownList.SelectedIndex=0;
                this.deptName = deptDropDownList.SelectedItem.Text;
                this.deptid = dpd.findDepartmentIdByName(this.deptName);
                outstandingGridView.DataSource = (List<OutstandingCart>)Session["loc"];
                outstandingGridView.DataBind();
            }
            else
            {
                this.deptName = deptDropDownList.SelectedItem.Text;
                this.deptid = dpd.findDepartmentIdByName(deptName);
                outstandingGridView.DataSource =(List<OutstandingCart>)Session["loc"];
                outstandingGridView.DataBind();
            }

        }

        protected void deptDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deptName = deptDropDownList.SelectedItem.Text;
            this.deptid = dpd.findDepartmentIdByName(this.deptName);
            //collectionpointLabel.Text = dpd.getCollectionPointbyDepartmentId(this.deptid);

        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            List<OutstandingCart> loc = new List<OutstandingCart>();
            loc = oidao.getPendingOutstandingCartByDeptID(this.deptid, "Pending");
            Session["loc"] = loc;
            outstandingGridView.DataSource = loc;
            outstandingGridView.DataBind();
        }
    }
}