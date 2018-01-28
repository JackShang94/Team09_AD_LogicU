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
        //[OperationContract]
        //[WebGet(UriTemplate = "/Disbursement",ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json )]
        //List<WCFDisbursement> getDisbursementByDeptID()
        [OperationContract]
        [WebInvoke(UriTemplate = "/Disbursement", Method ="POST" , BodyStyle =WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json,RequestFormat = WebMessageFormat.Json )]
        List<WCFDisbursement> getDisbursementByDeptID(string deptID);

        [OperationContract]
        [WebGet(UriTemplate = "/Disbursement/{disID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFDisbursementCart> getDisbursementItemByDisID(string disID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Disbursement/update", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void updateDisbursementItemByItemID(string itemID, int qty);

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
        private int expectedc;
        private int actual;

        public WCFDisbursementCart(string itemID, string itemDescription, int expectedc, int actual)
        {
            this.itemID = itemID;
            this.itemDescription = itemDescription;
            this.expectedc = expectedc;
            this.actual = actual;
        }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public int Expectedc
        {
            get
            {
                return expectedc;
            }

            set
            {
                expectedc = value;
            }
        }
        [DataMember]
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
