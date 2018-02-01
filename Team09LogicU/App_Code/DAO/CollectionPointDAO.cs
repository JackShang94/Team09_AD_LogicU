using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
    public class CollectionPointInformation 
    {
        public string CollectionPointDescription;
        public string NumberOfDisbursement;
    }
    public class CollectionPointDAO
    {

        SA45_Team09_LogicUEntities context = new SA45_Team09_LogicUEntities();

        //show all collectionpoints
        //
        public List<CollectionPoint> getAllCollectionPoint()
        {
            return context.CollectionPoints.ToList();
        }

        public CollectionPoint getCollectionPointByDescription(string description)
        {
            return context.CollectionPoints.Where(x => x.description == description).First();
        }
        public String getCollectionPointNameByID(string ID)
        {
            CollectionPoint c = new CollectionPoint();
            List<CollectionPoint> list = new List<CollectionPoint>();
            list = context.CollectionPoints.Where(x => x.collectionPointID == ID).ToList();
            if (list.Count > 0)
            {
                c = list.First();
            }
            return c.description;
        }
        public List<CollectionPointInformation> getCollectionPointInformation()
        {
            List<CollectionPointInformation> list = new List<CollectionPointInformation>();

            var result = from ds in context.Disbursements
                         join dp in context.Departments on ds.deptID equals dp.deptID
                         join cp in context.CollectionPoints on dp.collectionPointID equals cp.collectionPointID
                         select cp.description;
            //string sql = "select * from IntegralInfo where convert(nvarchar,getdate(),23)='{0}' and status=1 and userinfoid='{1}'";
            //sql = string.Format(sql, DateTime.Now.ToString("yyyy-MM-dd"), uid);
            //var IntegralInfoObj = context.Database.SqlQuery<IntegralInfo>(sql).FirstOrDefault();
            return list;
        }
        public void updatecollection(string storestaffID,string description)
        {
            CollectionPoint col = context.CollectionPoints.Where(x => x.description == description).First();
            col.storeStaffID = storestaffID;
            context.SaveChanges();
        }

    }
}