using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        public int Login(WCFAccount wcf_account,string section)
        {
            string email = wcf_account.Email;
            string passsword = wcf_account.Password;
            string role = wcf_account.Role;
            if (section == "dept")
            {
                
            }else if (section == "store")
            {

            }
            return 0;
        }
    }
}
