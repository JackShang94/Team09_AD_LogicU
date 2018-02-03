using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.Models;
using System.ServiceModel.Web;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Items", ResponseFormat = WebMessageFormat.Json)]
        List<WCFItem> findAll();

        [OperationContract]
        [WebGet(UriTemplate = "/Items/{keyword}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFItem> findItemBySearch(string keyword);

        [OperationContract]
        [WebGet(UriTemplate = "/Item/{itemID}", ResponseFormat = WebMessageFormat.Json)]
        WCFItem getItemByID(string itemID);
    }

    [DataContract]
    public class WCFItem
    {
        string itemID;
        string categoryID;
        string description;
        string location;
        string unitOfMeasure;
        int reorderLevel;
        int reorderQty;
        int qtyOnHand;

        public static WCFItem Make(string itemID, string categoryID, string description, string location,string unitOfMeasure,int reorderLevel,int reorderQty,int qtyOnHand)
        {
            WCFItem i = new WCFItem();
            i.itemID = itemID;
            i.categoryID = categoryID;
            i.description = description;
            i.location = location;
            i.unitOfMeasure = unitOfMeasure;
            i.reorderLevel = reorderLevel;
            i.reorderQty = reorderQty;
            i.qtyOnHand = qtyOnHand;
            return i;
        }

        [DataMember]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember]
        public string CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string UnitOfMeasure
        {
            get { return unitOfMeasure; }
            set { unitOfMeasure = value; }
        }

        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [DataMember]
        public int ReorderLevel
        {
            get { return reorderLevel; }
            set { reorderLevel = value; }
        }

        [DataMember]
        public int ReorderQty
        {
            get { return reorderQty; }
            set { reorderQty = value; }
        }

        [DataMember]
        public int QtyOnHand
        {
            get { return qtyOnHand; }
            set {   qtyOnHand = value; }
        }
    }
}
