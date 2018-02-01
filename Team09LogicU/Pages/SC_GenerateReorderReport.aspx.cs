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
    public partial class SC_GenerateReorderReport : System.Web.UI.Page
    {
        StoreStaffDAO storeStaffDAO = new StoreStaffDAO();
        ItemDAO itemDAO = new ItemDAO();
        SupplierDAO supDAO = new SupplierDAO();
        SupplierItemDAO supItemDAO = new SupplierItemDAO();
        PurchaseOrderDAO PoDAO = new PurchaseOrderDAO();
        PurchaseOrderItemDAO POItemDAO = new PurchaseOrderItemDAO();
        PurchaseOrder po = new PurchaseOrder();
        ReorderReportDAO reportDAO = new ReorderReportDAO();
        List<int> poIDlist;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            string strTime = txtMonth.Text;
            if (strTime != "")
            {
                DateTime time = Convert.ToDateTime(strTime);
                poIDlist = PoDAO.findPOIDbyMonth(time);
                List<PurchaseOrderItem> PurchaseOrderItemList = new List<PurchaseOrderItem>();
                for (int i = 0; i < poIDlist.Count; i++)
                {
                    PurchaseOrderItemList.AddRange(POItemDAO.findPOItembypoID(poIDlist[i]));
                }


                List<MonthlyReorderItem> monthlyItemList = new List<MonthlyReorderItem>();
                decimal total = 0;
                string supID;
                for (int i = 0; i < PurchaseOrderItemList.Count(); i++)
                {
                    monthlyItemList.Add(new MonthlyReorderItem());
                    monthlyItemList[i].PoID = PurchaseOrderItemList[i].poID;
                    DateTime orderDate = PoDAO.findOrderDatebyPOid(PurchaseOrderItemList[i].poID);
                    monthlyItemList[i].OrderDate = orderDate.ToShortDateString();
                    monthlyItemList[i].ItemID = PurchaseOrderItemList[i].itemID;
                    monthlyItemList[i].OrderQty = PurchaseOrderItemList[i].quantity;
                    monthlyItemList[i].Description = PurchaseOrderItemList[i].Item.description;
                    supID = PoDAO.findSupplierIDbyPOid(PurchaseOrderItemList[i].poID);
                    monthlyItemList[i].Price = supItemDAO.getPriceByItemIDAndSupplierID(PurchaseOrderItemList[i].itemID, supID);
                    monthlyItemList[i].TotalAmount = monthlyItemList[i].Price * monthlyItemList[i].OrderQty;
                }
                for (int i = 0; i < monthlyItemList.Count(); i++)
                {
                    total = monthlyItemList[i].TotalAmount + total;
                }


                //////////////google chart data
                string columnChartData = reportDAO.getGoogleColumnChartData(monthlyItemList);
                string tableChartData = reportDAO.getGoogleTableChartData(monthlyItemList);



                chartData.InnerHtml = "<script>var columnChartData =" + columnChartData + " ; var tableChartData = " + tableChartData + ";</script>";
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>win.alert('Notice', 'Please select the month！');</script>");
            }
        }

    }
}