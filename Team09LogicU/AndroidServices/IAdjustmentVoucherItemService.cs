using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdjustmentVoucherItemService" in both code and config file together.
    [ServiceContract]
    public interface IAdjustmentVoucherItemService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/AdjItem/{adjID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFAdjustmentVoucherItem> findAdjItemListByAdjID(string adjID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/AdjItem/post/addAdjItem", Method = "POST", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json)]
        void addAdjVoucherItem(WCFAdjustmentVoucherItem wcfAdjItem);
    }

    [DataContract]
    public class WCFAdjustmentVoucherItem
    {
        int adjVItemID;
        int adjVID;
        int qty;
        string itemID;
        string record;


        public static WCFAdjustmentVoucherItem Make(int adjVItemID, int adjVID, int qty, string itemID, string record)
        {
            WCFAdjustmentVoucherItem adjItem = new WCFAdjustmentVoucherItem();
            adjItem.adjVItemID = adjVItemID;
            adjItem.adjVID = adjVID;
            adjItem.qty = qty;
            adjItem.itemID = itemID;
            adjItem.record = record;
            return adjItem;
        }

        [DataMember]
        public int AdjItemVID
        {
            get { return adjVItemID; }
            set { adjVItemID = value; }
        }

        [DataMember]
        public int AdjVID
        {
            get { return adjVID; }
            set { adjVID = value; }
        }
        [DataMember]
        public int Qty
        {
            get { return qty; }
            set { qty= value; }
        }
        [DataMember]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember]
        public string Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
    
