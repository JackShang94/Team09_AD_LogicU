using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRetrievalFormItemService" in both code and config file together.
    [ServiceContract]
    public interface IRetrievalFormItemService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/helloworld/", ResponseFormat = WebMessageFormat.Json)]
        string HelloWorld();

        [OperationContract]
        [WebGet(UriTemplate = "/RetrievalFormItem/get/", ResponseFormat = WebMessageFormat.Json)]
        List<RetrievalFormItemData> findRetrievalFormItemDate();

        [OperationContract]
        [WebInvoke(UriTemplate = "/RetrievalFormItem/post/update", Method = "POST", BodyStyle=WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void updateRetrievalFormItemData(List<RetrievalFormItemData> datalist, DateTime date);
    }

    [DataContract]
    public class RetrievalFormItemData
    {
        public RetrievalFormItemData() { }

        [DataMember]
        public string itemID { get; set; }

        [DataMember]
        public string itemDescription { get; set; }

        [DataMember]
        public string itemLocation { get; set; }

        [DataMember]
        public int itemNeeded { get; set; }

        [DataMember]
        public int itemActual { get; set; }

        [DataMember]
        public List<BreakdownByDepartment> breakList { get; set; }

        public static RetrievalFormItemData Make(string itemID, string description, string itemLocation, int itemNeeded, int itemActual, List<BreakdownByDepartment> breakList )
        {
            RetrievalFormItemData data = new RetrievalFormItemData();
            data.itemID = itemID;
            data.itemDescription = description;
            data.itemLocation = itemLocation;
            data.itemNeeded = itemNeeded;
            data.itemActual = itemActual;
            data.breakList = breakList;

            return data;
        }

    }
}
