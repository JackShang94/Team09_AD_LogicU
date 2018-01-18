using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.App_Code.DAO
{
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

    }
}