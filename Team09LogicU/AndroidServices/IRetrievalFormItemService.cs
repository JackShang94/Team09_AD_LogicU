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
        [WebGet(UriTemplate = "/helloworld", ResponseFormat = WebMessageFormat.Json)]
        string HelloWorld();

        [OperationContract]
        [WebGet(UriTemplate = "/RetrievalFormItem/get", ResponseFormat = WebMessageFormat.Json)]
        List<RetrievalFormItemData> findRetrievalFormItemDate();
    }

    [DataContract]
    public class RetrievalFormItemData
    {

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


        private List<BreakdownByDepartmentData> breakdownByDepartmentListData;
        [DataMember(Name = "breakdownByDepartmentListData")]
        public List<BreakdownByDepartmentData> BreakdownByDepartmentListData
        {
            get
            {
                return breakdownByDepartmentListData;
            }

            set
            {
                breakdownByDepartmentListData = value;
            }

        }
        public RetrievalFormItemData()
        {
            
        }

        public static RetrievalFormItemData Make(string itemID, string description, string itemLocation, int itemNeeded, int itemActual, List<BreakdownByDepartmentData> breakdownByDepartmentListData)
        {
            RetrievalFormItemData data = new RetrievalFormItemData();
            data.itemID = itemID;
            data.itemDescription = description;
            data.itemLocation = itemLocation;
            data.itemNeeded = itemNeeded;
            data.itemActual = itemActual;
            data.breakdownByDepartmentListData = breakdownByDepartmentListData;

            return data;
        }

    }

    [DataContract]
    public class BreakdownByDepartmentData
    {
        public BreakdownByDepartmentData() { }

        [DataMember]
        public string deptID { get; set; }

        [DataMember]
        public int needed { get; set; }

        [DataMember]
        public int actual { get; set; }
    }

}




