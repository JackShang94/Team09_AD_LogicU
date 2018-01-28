using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RetrievalFormService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RetrievalFormService.svc or RetrievalFormService.svc.cs at the Solution Explorer and start debugging.
    public class RetrievalFormService : IRetrievalFormService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }

    }
}
