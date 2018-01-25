using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.Pages
{
    public partial class SC_ViewDepartment : System.Web.UI.Page
    {
        DepartmentDAO depDAO = new DepartmentDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }
        protected void BindGrid()
        {
           
            List<Department> deplist = new List<Department>();
            deplist = depDAO.findAll();
            GridView_DepList.DataSource = deplist;
            GridView_DepList.DataBind();
        }

    }
}