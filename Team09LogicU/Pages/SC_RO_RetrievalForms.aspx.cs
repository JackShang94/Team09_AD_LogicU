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
    public partial class SC_RO_RetrievalForms : System.Web.UI.Page
    {
        RetrievalDAO retrievalDAO = new RetrievalDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            //*******************************this is test code****************//
            DateTime date = new DateTime(2018, 1, 28);
            //get retrivedRequisitionList
            List<Requisition> retrivedRequisitionList = retrievalDAO.getRetrievedRequisitionList(date);
            //update status
            //retrievalDAO.updateRequisitionStatusAsProcessed(retrivedRequisitionList);
            //get retrievedItemList
            List<RetrievalFormItem> retrievedItemList= retrievalDAO.getRetrievalFormByDate(date);
            
            //GridView_RetrievalForm.DataSource = ss;
            //GridView_RetrievalForm.DataBind();
            //*******************************this is tes code****************//
        }
    }
}