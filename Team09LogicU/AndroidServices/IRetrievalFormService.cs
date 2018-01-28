using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRetrievalFormService" in both code and config file together.
    [ServiceContract]
    public interface IRetrievalFormService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/helloworld/", ResponseFormat = WebMessageFormat.Json)]
        string HelloWorld();
    }

    [DataContract]
    public class RetrievalFormData
    {
        public RetrievalFormData(){}

        [DataMember]
        public int retrievalID { get; set; }

        [DataMember]
        public DateTime retrievalDate { get; set; }

    }
}
