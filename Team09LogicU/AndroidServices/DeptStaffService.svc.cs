using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.AndroidServices;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DeptStaffService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DeptStaffService.svc or DeptStaffService.svc.cs at the Solution Explorer and start debugging.
    public class DeptStaffService : IDeptStaffService
    {
        public WCFDeptStaff GetDeptStaffById(string id)
        {
            DeptStaffDAO dDAO = new DeptStaffDAO();
            DeptStaff d = dDAO.findStaffByID(id);
            return new WCFDeptStaff(d.staffID, d.staffName, d.role, d.deptID, d.password, d.email, d.address);
        }

        public List<WCFDeptStaff> List()
        {
            throw new NotImplementedException();
        }




        //public List<WCFDeptStaff> List()
        //{
        //    List<WCFDeptStaff> wcfDeptStaffList = new List<WCFDeptStaff>();
        //    List<DeptStaff> dlist = DeptStaffDAO.;
        //    foreach (DeptStaff d in dlist)
        //    {
        //        wcfDeptStaffList.Add(new WCFDeptStaffd.staffID, d.staffName, d.role, d.deptID, d.password, d.email, d.address));
        //    }
        //    return wcfDeptStaffList;
        //}
    }
}
