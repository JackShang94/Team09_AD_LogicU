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

        public List<CollectionPointInformation> getCollectionPointInformation()
        {
            List<CollectionPointInformation> list = new List<CollectionPointInformation>();

            //var m = from p in context.CollectionPoints
            //        join q in context.Departments on p.collectionPointID equals q.collectionPointID
            //        join r in context.Disbursements on q.deptID equals r.deptID
            //        where r.status == "Awaiting Delivery"
            //        select p.description;

            //var s = from c in context.CollectionPoints
            //        group c by c.description  as 
                    

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