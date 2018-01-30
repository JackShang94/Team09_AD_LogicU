﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "disbursementList" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select disbursementList.svc or disbursementList.svc.cs at the Solution Explorer and start debugging.
    public class DisbursementListService : IDisbursementListService
    {
        public List<WCFDept> getAllDept()
        {
            DepartmentDAO deptDAO = new DepartmentDAO();
            List<Department> ldept = deptDAO.findAll();
            List<WCFDept> ld_wcf = new List<WCFDept>();
            foreach (var i in ldept)
            {
                WCFDept wcfdept = new WCFDept(i.deptID, i.deptName, i.collectionPointID);
                ld_wcf.Add(wcfdept);
            }

            return ld_wcf;
        }
        public List<WCFDisbursement> getDisbursementByDeptID(string deptID)
        {
            List<WCFDisbursement> ldis_wcf = new List<WCFDisbursement>();
            DisbursementDAO disDAO = new DisbursementDAO();

            List<Disbursement> ldis = new List<Disbursement>();
            ldis =disDAO.getAwaitingDisbursementListByDeptID(deptID);

            foreach(var i in ldis)
            {
                WCFDisbursement wcfdis = new WCFDisbursement
                {
                    DisID=i.disbursementID,
                    DeptID = i.deptID,
                    StoreStaffID=i.storeStaffID,
                    DisDate=i.disburseDate,
                    Status=i.status
                };
                ldis_wcf.Add(wcfdis);
            }

            return ldis_wcf;
        }
        public List<WCFDisbursementCart> getDisbursementItemByDisID(string disID_s)
        {
            int disID = Convert.ToInt32(disID_s);
            List<WCFDisbursementCart> ldiscart_wcf = new List<WCFDisbursementCart>();
            DisbursementDAO disDAO = new DisbursementDAO();
            List<DisbursementCart> ldc = new List<DisbursementCart>();
            ldc = disDAO.getDisbursementItemByDisID(disID);
            foreach(var i in ldc)
            {
                WCFDisbursementCart wcfdiscart = new WCFDisbursementCart(i.ItemID, i.ItemDescription, i.Expectedc, i.Actual);
                ldiscart_wcf.Add(wcfdiscart);
            }
            return ldiscart_wcf;
        }
        public void updateDisbursementItemByItemID(WCFDisbursementCart cart)
        {
            DisbursementDAO disDAO = new DisbursementDAO();


            return;
        }
    }
}
