using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class LoginDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();
        string[] result = new string[] {"","","" };
        private DeptStaff getDeptStaffByUsername(string username)
        {
            List<DeptStaff> staffl = context.DeptStaffs.Where(x => x.email == username).ToList();
            DeptStaff staff = new DeptStaff();
            staff.staffID = "";          
            if (staffl.Count>0)
            {
                staff = staffl.First();             
            }
            return staff;
        }
        private StoreStaff getStoreStaffByUsername(string username)
        {
            List<StoreStaff> staffl = context.StoreStaffs.Where(x => x.email == username).ToList();
            StoreStaff staff = new StoreStaff();
            staff.storeStaffID = "";
            if (staffl.Count>0)
            {
                staff = staffl.First();            
            }
            return staff;
        }
        public string[] getUser(string username)
        {
            if(getDeptStaffByUsername(username).staffID !="")
            {
                DeptStaff staff = getDeptStaffByUsername(username);
                result[0] = staff.staffID;
                result[1] = staff.role;
                result[2] = staff.password;                            
            }
            else if(getStoreStaffByUsername(username).storeStaffID!="")
            {
                StoreStaff staff = getStoreStaffByUsername(username);
                result[0] = staff.storeStaffID;
                result[1] = staff.role;
                result[2] = staff.password;
            }
            return result;
        }
    }
}