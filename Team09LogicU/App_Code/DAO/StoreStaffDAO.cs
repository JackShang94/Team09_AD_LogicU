using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class StoreStaffDAO
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        public StoreStaff getStoreStaffInfoById(string storeStaffID)
        {
            return context.StoreStaffs.Where(x => x.storeStaffID == storeStaffID).First();
        }
        public List<StoreStaff> getallStoreStaff()
        {
            return context.StoreStaffs.ToList();
        }
    }

}