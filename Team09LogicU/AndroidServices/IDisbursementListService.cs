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
        [WebGet(UriTemplate = "/Disbursement", ResponseFormat = WebMessageFormat.Json)]
        void DoWork();
    }

   

}
