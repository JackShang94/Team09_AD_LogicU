using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Team09LogicU.AndroidServices;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDeptStaffService" in both code and config file together.
    [ServiceContract]
    public interface IDeptStaffService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/DeptStaff/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCFDeptStaff GetDeptStaffById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/DeptStaffs", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDeptStaff> List();
    }

    [DataContract]
    public class WCFDeptStaff
    {
        [DataMember]
        public string staffID;

        [DataMember]
        public string staffName;

        [DataMember]
        public string role;

        [DataMember]
        public string deptID;

        [DataMember]
        public string password;

        [DataMember]
        public string email;

        [DataMember]
        public string address;

        public WCFDeptStaff(string staffID, string staffName, string role, string deptID, string password, string email,string address)
        {
            this.staffID = staffID;
            this.staffName = staffName;
            this.role = role;
            this.deptID = deptID;
            this.password = password;
            this.email = email;
            this.address = address;
        }
    }
}
