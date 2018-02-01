using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoginService" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        
        [WebInvoke(UriTemplate = "/Login", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Login(WCFAccount wcf_account);
    }
    [DataContract]
    public class AccountList
    {
        private List<WCFAccount> account_List;
        [DataMember(Name ="accountList")]
        public List<WCFAccount> Account_List
        {
            get
            {
                return account_List;
            }

            set
            {
                account_List = value;
            }
        }
    }
    [DataContract]
    public class WCFAccount {
        private string email;
        private string password;
        private string role;
        [DataMember(Name ="email")]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        [DataMember(Name ="password")]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        [DataMember(Name ="role")]
        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
    }

}
