using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    //class used in PieChart
    public class PieChartData
    {
        public string catagory;
        public  int  qtyOnHand;
    }

    //class used in Department rep chart
    public class DeptRepChartData
    {
        public string deptID;
        public string repName;
        public string email;
    }

    //class used in outstanding chart
    public class OutstandingChartData
    {
        public string itemID;
        public string itemName;
        public int reorderLevel;
        public int outstandingQty; 
    }

    public class DashBoardDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        public List<OutstandingChartData> getOutstandingChartData(string depid)
        {
            bool IsNewItem = true;
            List<OutstandingChartData> ocList = new List<OutstandingChartData>();
            List<Outstanding> oList = context.Outstandings.Where(x => x.deptID == depid).ToList();
            foreach (Outstanding outstanding in oList)
            {
                foreach (OutstandingItem outitem in outstanding.OutstandingItems)
                {
                    IsNewItem = true;//reset boolean
                    foreach (OutstandingChartData item in ocList)
                    {
                        if (outitem.itemID == item.itemID)//not new item
                        {
                            IsNewItem = false;
                            item.outstandingQty = item.outstandingQty + outitem.expectedQty;
                        }
                    }
                    if (IsNewItem)//is a new item
                    {
                        OutstandingChartData newItem = new OutstandingChartData();
                        newItem.itemID = outitem.itemID;
                        newItem.itemName = outitem.Item.description;
                        newItem.reorderLevel = outitem.Item.reorderLevel;
                        newItem.outstandingQty = outitem.expectedQty;

                        ocList.Add(newItem);
                    }
                }
            }

            return ocList;
        }

        public List<PieChartData> getPieChartData()
        {
            List<PieChartData> plist = new List<PieChartData>();
            List<Category> clist = context.Categories.ToList();
            foreach (Category item in clist)//set clist value
            {
                int qtyOnhand = context.Items.Where(x => x.categoryID == item.categoryID).Select(x => x.qtyOnHand).Sum();
                PieChartData pItem = new PieChartData();
                pItem.catagory = item.categoryID;
                pItem.qtyOnHand =  qtyOnhand;
                plist.Add(pItem);
            }
            return plist;
        }

        public List<DeptRepChartData> getDeptRepChartData()
        {
            List<DeptRepChartData> dRepList = new List<DeptRepChartData>();
            List<Department> dList = context.Departments.ToList();

            foreach (Department item in dList)//set dlist value
            {
                DeptRepChartData dRepItem = new DeptRepChartData();
                dRepItem.deptID = item.deptName;
                dRepItem.repName = context.DeptStaffs.Where(x => x.staffID == item.repStaffID).Select(x => x.staffName).ToList().First();
                dRepItem.email = context.DeptStaffs.Where(x => x.staffID == item.repStaffID).Select(x => x.email).ToList().First();

                dRepList.Add(dRepItem);
            }

            return dRepList;
        }
    }
}