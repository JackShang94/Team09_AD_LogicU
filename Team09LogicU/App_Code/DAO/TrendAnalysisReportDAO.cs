using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class TrendAnalysisItem
    {
        public string itemID;
        public string ItemName;
        public int month1Quantity;
        public int month2Quantity;
        public int month3Quantity;
    }

    public class TrendAnalysisReportDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
        public List<TrendAnalysisItem> getTrendAnalysisItems(string deptID, DateTime dateTime)
        {
            bool IsNewItem = true;
            List<TrendAnalysisItem> trendAnalysisItemList = new List<TrendAnalysisItem>();
            ///add this month disbursement items
            List<Disbursement> month1List = getThisMonthDisbursementListByDept(deptID, dateTime);
            foreach (Disbursement disBursement in month1List)
            {
                foreach (DisbursementItem disitem in disBursement.DisbursementItems)
                {
                    IsNewItem = true;
                    foreach (TrendAnalysisItem item in trendAnalysisItemList)
                    {
                        if (disitem.itemID == item.itemID)//not new item
                        {
                            IsNewItem = false;
                            item.month1Quantity = item.month1Quantity + disitem.actualQty;
                        }
                    }
                    if (IsNewItem)
                    {
                        TrendAnalysisItem newItem = new TrendAnalysisItem();
                        newItem.itemID = disitem.itemID;
                        newItem.ItemName = disitem.Item.description;
                        newItem.month1Quantity = disitem.actualQty;
                        newItem.month2Quantity = 0;
                        newItem.month3Quantity = 0;

                        trendAnalysisItemList.Add(newItem);
                    }
                }
            }
            ///add past1 month disbursement items
            List<Disbursement> month2List = getPast1MonthDisbursementListByDept(deptID, dateTime);
            foreach (Disbursement disBursement in month2List)
            {
                foreach (DisbursementItem disitem in disBursement.DisbursementItems)
                {
                    IsNewItem = true;
                    foreach (TrendAnalysisItem item in trendAnalysisItemList)
                    {
                        if (disitem.itemID == item.itemID)//not new item
                        {
                            IsNewItem = false;
                            item.month2Quantity = item.month2Quantity + disitem.actualQty;
                        }
                    }
                    if (IsNewItem)
                    {
                        TrendAnalysisItem newItem = new TrendAnalysisItem();
                        newItem.itemID = disitem.itemID;
                        newItem.ItemName = disitem.Item.description;
                        newItem.month1Quantity = 0;
                        newItem.month2Quantity = disitem.actualQty;
                        newItem.month3Quantity = 0;

                        trendAnalysisItemList.Add(newItem);
                    }
                }
            }
            ///add past2 month disbursement items
            List<Disbursement> month3List = getPast2MonthDisbursementListByDept(deptID, dateTime);
            foreach (Disbursement disBursement in month3List)
            {
                foreach (DisbursementItem disitem in disBursement.DisbursementItems)
                {
                    IsNewItem = true;
                    foreach (TrendAnalysisItem item in trendAnalysisItemList)
                    {
                        if (disitem.itemID == item.itemID)//not new item
                        {
                            IsNewItem = false;
                            item.month3Quantity = item.month3Quantity + disitem.actualQty;
                        }
                    }
                    if (IsNewItem)
                    {
                        TrendAnalysisItem newItem = new TrendAnalysisItem();
                        newItem.itemID = disitem.itemID;
                        newItem.ItemName = disitem.Item.description;
                        newItem.month1Quantity = 0;
                        newItem.month2Quantity = 0;
                        newItem.month3Quantity = disitem.actualQty;

                        trendAnalysisItemList.Add(newItem);
                    }
                }
            }
            return trendAnalysisItemList;
        }

        public List<Disbursement> getThisMonthDisbursementListByDept(string deptID, DateTime dateTime)
        {
            DateTime startDate = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime endDate = dateTime;
            List<Disbursement> dList = new List<Disbursement>();
            dList = context.Disbursements.Where(x => x.disburseDate >= startDate && x.disburseDate < endDate && x.status == "Completed"&&x.deptID==deptID).ToList();
            return dList;
        }

        public List<Disbursement> getPast1MonthDisbursementListByDept(string deptID,DateTime dateTime)
        {
            DateTime startDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1);
            DateTime endDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddDays(-1);
            List<Disbursement> dList = new List<Disbursement>();
            dList = context.Disbursements.Where(x => x.disburseDate >= startDate && x.disburseDate < endDate && x.status == "Completed" && x.deptID == deptID).ToList();
            return dList;
        }

        public List<Disbursement> getPast2MonthDisbursementListByDept(string deptID, DateTime dateTime)
        {
            DateTime startDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-2);
            DateTime endDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(-1).AddDays(-1);
            List<Disbursement> dList = new List<Disbursement>();
            dList = context.Disbursements.Where(x => x.disburseDate >= startDate && x.disburseDate< endDate && x.status == "Completed" && x.deptID == deptID).ToList();
            return dList;
        }

    }
}