using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team09LogicU.Models;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreStaffService" in both code and config file together.
    [ServiceContract]
    public interface IStoreStaffService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/StoreStaff/{storeStaffID}", ResponseFormat = WebMessageFormat.Json)]
        WCFStoreStaff GetStoreStaffById(string storeStaffID);

        [OperationContract]
        [WebGet(UriTemplate = "/StoreStaffs", ResponseFormat = WebMessageFormat.Json)]
        List<WCFStoreStaff> List();

    }

    [DataContract]
    public class WCFStoreStaff
    {
        [DataMember]
        public string storeStaffID;

        [DataMember]
        public string storeStaffName;

        [DataMember]
        public string role;

        [DataMember]
        public string email;

        [DataMember]
        public string phone;

        [DataMember]
        public string password;

        public WCFStoreStaff(string storeStaffID, string storeStaffName, string role, string email, string phone, string password)
        {
            this.storeStaffID = storeStaffID;
            this.storeStaffName = storeStaffName;
            this.role = role;
            this.email = email;
            this.phone = phone;
            this.password = password;
        }
    }
}

    
