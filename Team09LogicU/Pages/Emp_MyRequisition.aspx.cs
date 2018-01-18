using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.App_Code.DAO;
namespace Team09LogicU.pages
{
    public partial class Emp_MyRequisition : System.Web.UI.Page
    {
        public List<Requisition> lr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //for session judgment
            //
            SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
            RequisitionDAO rdao = new RequisitionDAO();

            lr = rdao.getRequisitionList();
        }
    }
}