using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdjustedmentCartItemService" in both code and config file together.
    [ServiceContract]
    public interface IAdjustmentCartItemService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/ADJV/post/addAdj/{staffID}", Method = "POST", RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        int addAdjVoucher(WCFCart_Json cartList,string staffID);
    }


    [DataContract]
    public class WCFCart_Json
    {
        List<WCFAdjustmentVoucherCartItem> cartList;
        [DataMember(Name = "cartList")]
        public List<WCFAdjustmentVoucherCartItem> CartList
        {
            get { return cartList; }
            set
            {
                cartList = value;
            }
        }

    }
    [DataContract]
    public class WCFAdjustmentVoucherCartItem
    {
        int qty;
        string itemID;
        string record;

        public static WCFAdjustmentVoucherCartItem Make(int qty, string itemID, string record)
        {
            WCFAdjustmentVoucherCartItem adjItem = new WCFAdjustmentVoucherCartItem();
            adjItem.qty = qty;
            adjItem.itemID = itemID;
            adjItem.record = record;
            return adjItem;
        }

        [DataMember(Name = "QtyAdjusted")]
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        [DataMember(Name = "ItemID")]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember(Name = "Record")]
        public string Record
        {
            get { return record; }
            set { record = value; }
        }
    }
}
