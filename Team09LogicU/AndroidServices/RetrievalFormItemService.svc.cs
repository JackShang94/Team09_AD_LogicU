using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
using System.IO;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RetrievalFormItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RetrievalFormItemService.svc or RetrievalFormItemService.svc.cs at the Solution Explorer and start debugging.
    public class RetrievalFormItemService : IRetrievalFormItemService
    {
        RetrievalDAO reDAO = new RetrievalDAO();
        public string HelloWorld()
        {
            return "Hello World";
        }

        public List<RetrievalFormItemData> findRetrievalFormItemDate()
        {
            List<RetrievalFormItemData> DataList = new List<RetrievalFormItemData>();

            List<RetrievalFormItem> list = new List<RetrievalFormItem>();
            list = reDAO.getRetrievalFormByDate(DateTime.Now);

            for (int i = 0; i < list.Count(); i++)
            {
                DataList.Add(new RetrievalFormItemData());

                List<BreakdownByDepartment> breaklist = list[i].BreakdownByDepartmentList;
                List<BreakdownByDepartmentData> breakDataList = new List<BreakdownByDepartmentData>();
                for (int j = 0; j < breaklist.Count(); j++)// initialize breakDatalist
                {
                    breakDataList.Add(new BreakdownByDepartmentData());
                    breakDataList[j].deptID = breaklist[j].DeptID;
                    breakDataList[j].needed = breaklist[j].Needed;
                    breakDataList[j].actual = breaklist[j].Actual;
                }
                DataList[i] = RetrievalFormItemData.Make(list[i].ItemID, list[i].ItemDescription, list[i].Location, list[i].Needed, list[i].Actual, breakDataList);
            }
            return DataList;
        }

    }
}
