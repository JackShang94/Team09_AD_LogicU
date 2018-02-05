using System;
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
                ld_wcf.Add(wcfdept);// add in department list
            }

            return ld_wcf;
        }
        public List<WCFDisbursement> getDisbursementByDeptID(string deptID)
        {

            List<WCFDisbursement> ldis_wcf = new List<WCFDisbursement>();
            DisbursementDAO disDAO = new DisbursementDAO();

            List<Disbursement> ldis = new List<Disbursement>();
            ldis = disDAO.getAwaitingDisbursementListByDeptID(deptID);

            foreach (var i in ldis)//add in disbursement list
            {
                WCFDisbursement wcfdis = new WCFDisbursement
                {
                    DisID = i.disbursementID,
                    DeptID = i.deptID,
                    StoreStaffID = i.storeStaffID,
                    DisDate = i.disburseDate,
                    Status = i.status
                };
                ldis_wcf.Add(wcfdis);
            }

            return ldis_wcf;
        }

        public List<WCFDisbursement> getDisbursementByRepID(string repID)
        {
            DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
            string deptID = deptStaffDAO.getDeptIDByStaffID(repID);
            return getDisbursementByDeptID(deptID);
        }

        public List<WCFDisbursementCart> getDisbursementItemByDisID(string disID_s)
        {
            int disID = Convert.ToInt32(disID_s);
            List<WCFDisbursementCart> ldiscart_wcf = new List<WCFDisbursementCart>();
            DisbursementDAO disDAO = new DisbursementDAO();
            List<DisbursementCart> ldc = new List<DisbursementCart>();
            ldc = disDAO.getDisbursementItemByDisID(disID);
            foreach (var i in ldc)
            {
                WCFDisbursementCart wcfdiscart = new WCFDisbursementCart(i.ID, i.Description, i.Expected, i.Actual);
                ldiscart_wcf.Add(wcfdiscart);
            }
            return ldiscart_wcf;
        }

        public int updateDisbursementItemByItemID(cartList_JSON cart_JSON, string disID)
        {
            List<WCFDisbursementCart> cart_wcf = cart_JSON.DiscartList;
            int disID_int = Int32.Parse(disID);
            using (SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities())
            {
                List<DisbursementItem> ldisitem = context.DisbursementItems.Where(x => x.disbursementID == (disID_int)).ToList();
                for (int i = 0; i < cart_wcf.Count; i++)
                {
                    foreach (var j in ldisitem)
                    {
                        if (j.itemID == cart_wcf[i].ItemID)
                        {
                            j.actualQty = cart_wcf[i].Actual;
                            break;
                        }
                    }
                }
                try
                {
                    context.SaveChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
        }

        public int confirmDisbursement(confirm_JSON confirm_json, string disID_url)
        {
            int disID = Int32.Parse(disID_url);
            string date_s = confirm_json.Scan_date;//put here in case
            string staffID = confirm_json.LoginID;
            DisbursementDAO disDAO = new DisbursementDAO();
            try
            {
                disDAO.updateDisbursementStatus(disID, "Completed");
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
