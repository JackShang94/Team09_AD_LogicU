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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IdisbursementList" in both code and config file together.
    [ServiceContract]
    public interface IDisbursementListService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/alldept", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDept> getAllDept();
        
        [OperationContract]
        [WebGet(UriTemplate = "/Disbursement?deptID={deptID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDisbursement> getDisbursementByDeptID(string deptID);
        [OperationContract]
        [WebGet(UriTemplate = "/DisbursementByrepID?repID={repID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDisbursement> getDisbursementByRepID(string repID);

        [OperationContract]
        [WebGet(UriTemplate = "/Disbursement/{disID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDisbursementCart> getDisbursementItemByDisID(string disID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Disbursement/{disID}/update", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int updateDisbursementItemByItemID(cartList_JSON cartList_json,string disID);
        [OperationContract]
        [WebInvoke(UriTemplate = "/Disbursement/{disID}/confirm", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int confirmDisbursement(confirm_JSON confirm_json,string disID);
    }
    [DataContract]
    public class confirm_JSON
    {
       
        private string scan_date;
        private string loginID;
       
        [DataMember(Name ="scan_date")]
        public string Scan_date
        {
            get
            {
                return scan_date;
            }

            set
            {
                scan_date = value;
            }
        }
        [DataMember(Name ="loginID")]
        public string LoginID
        {
            get
            {
                return loginID;
            }

            set
            {
                loginID = value;
            }
        }
    }
    [DataContract]
    public class cartList_JSON
    {
        private List<WCFDisbursementCart> discartList;
        [DataMember(Name = "discartList")]
        public List<WCFDisbursementCart> DiscartList
        {
            get
            {
                return discartList;
            }

            set
            {
                discartList = value;
            }
        }
    }



    [DataContract]
    public class WCFDisbursement
    {
        private int disID;
        private string deptID;
        private string storeStaffID;
        private DateTime disDate;
        private string status;
        [DataMember]
        public int DisID
        {
            get
            {
                return disID;
            }

            set
            {
                disID = value;
            }
        }
        [DataMember]
        public string DeptID
        {
            get
            {
                return deptID;
            }

            set
            {
                deptID = value;
            }
        }
        [DataMember]
        public string StoreStaffID
        {
            get
            {
                return storeStaffID;
            }

            set
            {
                storeStaffID = value;
            }
        }
        [DataMember]
        public DateTime DisDate
        {
            get
            {
                return disDate;
            }

            set
            {
                disDate = value;
            }
        }
        [DataMember]
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
    [DataContract]
    public class WCFDisbursementCart
    {
        private string itemID;
        private string itemDescription;
        private int expected;
        private int actual;

        public WCFDisbursementCart(string itemID, string itemDescription, int expected, int actual)
        {
            this.itemID = itemID;
            this.itemDescription = itemDescription;
            this.expected = expected;
            this.actual = actual;
        }
        [DataMember(Name ="itemID")]
        public string ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }
        [DataMember(Name= "itemDescription")]
        public string ItemDescription
        {
            get
            {
                return itemDescription;
            }

            set
            {
                itemDescription = value;
            }
        }
        [DataMember(Name = "expected")]
        public int Expected
        {
            get
            {
                return expected;
            }

            set
            {
                expected = value;
            }
        }
        [DataMember(Name = "actual")]
        public int Actual
        {
            get
            {
                return actual;
            }

            set
            {
                actual = value;
            }
        }
    }

    [DataContract]
    public class WCFDept
    {
        private string deptID;
        private string deptName;
        private string collectionPointID;

        public WCFDept(string deptID, string deptName, string collectionPointID)
        {
            this.deptID = deptID;
            this.deptName = deptName;
            this.collectionPointID = collectionPointID;
        }
        [DataMember]
        public string DeptID
        {
            get
            {
                return deptID;
            }

            set
            {
                deptID = value;
            }
        }
        [DataMember]
        public string DeptName
        {
            get
            {
                return deptName;
            }

            set
            {
                deptName = value;
            }
        }
        [DataMember]
        public string CollectionPointID
        {
            get
            {
                return collectionPointID;
            }

            set
            {
                collectionPointID = value;
            }
        }
    }

    

   

}
