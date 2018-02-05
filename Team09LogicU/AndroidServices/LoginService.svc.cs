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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();
        public string Login(WCFAccount wcf_account)
        {//only accept Dept rep and Store clerk
            LoginDAO loginDAO = new LoginDAO();
            DeptStaffDAO deptStaffDAO = new DeptStaffDAO();
            string email = wcf_account.Email;
            string password = wcf_account.Password;
            string info = "";
            string hashString = new Encrypt().encryptString(password);
            string[] result = loginDAO.getUser(email);
            string deptID = "";
            if (hashString == result[2])
            {
                if (result[1] == "rep")//its department
                {
                    deptID = deptStaffDAO.getDeptIDByStaffID(result[0]);
                }
                info = result[0] + "&" + result[1] + "&" + deptID;//result[0] is loginID,result[1] is role
            }
            return info;
        }
    }
}
