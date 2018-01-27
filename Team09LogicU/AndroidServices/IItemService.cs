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
        [WebGet(UriTemplate = "/Item/{cat}", ResponseFormat = WebMessageFormat.Json)]
        List<WCFItem> findItemByCat(string cat);
    }

    [DataContract]
    public class WCFItem
    {
        string itemID;
        string categoryID;
        string description;


        public static WCFItem Make(string itemID, string categoryID, string description)
        {
            WCFItem i = new WCFItem();
            i.itemID = itemID;
            i.categoryID = categoryID;
            i.description = description;
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
    }
}
