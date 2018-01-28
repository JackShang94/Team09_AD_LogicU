using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreStaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StoreStaffService.svc or StoreStaffService.svc.cs at the Solution Explorer and start debugging.
    public class StoreStaffService : IStoreStaffService
    {
        StoreStaffDAO sDAO = new StoreStaffDAO();
        public WCFStoreStaff GetStoreStaffById(string storeStaffID)
        {
            
            StoreStaff s = sDAO.getStoreStaffInfoById(storeStaffID);
            return new WCFStoreStaff(s.storeStaffID, s.storeStaffName, s.role, s.email, s.phone, s.password);
        }

        public List<WCFStoreStaff> List()
        {
            List<WCFStoreStaff> wcfStoreStaffList = new List<WCFStoreStaff>();
            List<StoreStaff> slist =sDAO.getallStoreStaff();
            foreach (StoreStaff s in slist)
            {
                wcfStoreStaffList.Add(new WCFStoreStaff(s.storeStaffID, s.storeStaffName, s.role, s.email, s.phone, s.password));
            }
            return wcfStoreStaffList ;
        }
    }
}
