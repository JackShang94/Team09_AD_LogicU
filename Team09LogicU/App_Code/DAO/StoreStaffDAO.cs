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

        public string getStoreStaffIDbyName(string name)
        {
            StoreStaff s = context.StoreStaffs.Where(x => x.storeStaffName == name).First();
            return s.storeStaffID;
        }

        public string getStoreStaffNameByID(string ID)
        {
            List<StoreStaff> list = new List<StoreStaff>();
            StoreStaff s = new StoreStaff();
            list = context.StoreStaffs.Where(x => x.storeStaffID==ID).ToList();
            if (list.Count() > 0)
            {
                s = list.First();
            }
            return s.storeStaffName;
        }

        public List<StoreStaff> getStallStoreStaff()
        {
            return context.StoreStaffs.ToList();
        }

        public StoreStaff getstorestaffbyrole(string role)
        {
            return context.StoreStaffs.Find(role);
        }
    }

}