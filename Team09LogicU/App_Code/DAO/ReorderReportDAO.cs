using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class ReorderReportDAO
    {
        public string getGoogleColumnChartData(List<MonthlyReorderItem> monthlyItemList)
        {
            string ColumnChartdata = "[" +
            "['Element', 'Quantity'],";
            foreach (MonthlyReorderItem item in monthlyItemList)
            {
                ColumnChartdata = ColumnChartdata + "['" + item.Description + "'," + item.OrderQty + "],";
            }
            return ColumnChartdata = ColumnChartdata + "]";
        }

        public string getGoogleTableChartData(List<MonthlyReorderItem> monthlyItemList)
        {
            string TableChartdata = "[" +
            "['Order Date', 'Item ID','Description','Order Quantity','Price','Total Amount'],";
            foreach (MonthlyReorderItem item in monthlyItemList)
            {
                TableChartdata = TableChartdata + "['" + 
                    item.OrderDate + "','" + item.ItemID + "','" + item.Description + "'," + item.OrderQty + "," + item.Price + "," + item.TotalAmount 
                    + "],";
            }
            return TableChartdata = TableChartdata + "]";
        }

    }
}