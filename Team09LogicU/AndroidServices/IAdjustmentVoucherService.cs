using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdjustmentVoucherService" in both code and config file together.

    [ServiceContract]
    public interface IAdjustmentVoucherService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/Adj/post/addAdj", Method = "POST", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        void addAdjVoucher(List<WCFAdjustmentVoucherItem> adjVItemList);

        [OperationContract]
        [WebGet(UriTemplate = "/Adj", ResponseFormat = WebMessageFormat.Json)]
        List<WCFAdjustmentVoucher> findAllAdjVoucher();

        [OperationContract]
        [WebGet(UriTemplate = "/Adj/{from}/{to}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFAdjustmentVoucher> findAdjByDate(DateTime from,DateTime to);
    }

    [DataContract]
    public class WCFAdjustmentVoucher
    {
        int adjVID;
        string storeStaffID;
        string authorisedBy;
        DateTime adjDate;
        string status;

        List<WCFAdjustmentVoucherItem> adjList;

        public static WCFAdjustmentVoucher Make(int adjVID, string storeStaffID,string authorisedBy, DateTime adjDate,string status)
        {
            WCFAdjustmentVoucher adj = new WCFAdjustmentVoucher();
            adj.adjVID= adjVID;
            adj.storeStaffID = storeStaffID;
            adj.adjDate = adjDate;
            adj.authorisedBy = authorisedBy;
            adj.status = status;
            return adj;
        }

        [DataMember]
        public int AdjVID
        {
            get { return adjVID; }
            set { adjVID = value; }
        }

        [DataMember]
        public string StoreStaffID
        {
            get { return storeStaffID; }
            set { storeStaffID = value; }
        }

        [DataMember]
        public string AuthorisedBy
        {
            get { return authorisedBy; }
            set { authorisedBy = value; }
        }

        [DataMember]
        public DateTime AdjDate
        {
            get { return adjDate; }
            set { adjDate= value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public List<WCFAdjustmentVoucherItem> AdjList
        {
            get { return adjList;}
            set { adjList = value; }
        }
    }
}
