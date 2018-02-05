using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.DAO
{
    public class RequisitionItemDAO
    {
        SA45_Team09_LogicUEntities m = new DBEntities().getDBInstance();
        public List<string> getAllRequisitionItemID(int requisitionID)
        {
            List<string> lAitemID = new List<string>();
            List<RequisitionItem> lri = new List<RequisitionItem>();

            lri = m.RequisitionItems.Where(x => x.requisitionID == requisitionID).ToList();
            foreach (var i in lri)
            {
                lAitemID.Add(i.itemID);
            }

            return lAitemID;
        }

        public List<RequisitionItem> getItemByreqItemID(int reqItemID)
        {
            return m.RequisitionItems.Where(x => x.reqItemID == reqItemID).ToList();
        }

        public List<ItemCart> findRequisitionItemByID(int requisitionID)
        {
            List<ItemCart> list = m.RequisitionItems.
                Where(x => x.requisitionID == requisitionID).Select(x => new ItemCart { Description = x.Item.description, Quantity = x.requisitionQty, UnitOfMeasure = x.Item.unitOfMeasure }).ToList<ItemCart>();
            return list;
        }

        public void updateItemQty(RequisitionItem rI, int qty)
        {
            if (rI.requisitionQty == 0)
            {
                removeItem(rI);
            }
            else if (rI.requisitionQty > 0)
            {
                rI.requisitionQty = qty;
            }
        }

        public void updateItemQty(int reqItemID, int qty)
        {
            if (qty <= 0)
            {
                removeItemByReqItemID(reqItemID);
            }
            else
            {
                List<RequisitionItem> lr = new List<RequisitionItem>();

                lr = m.RequisitionItems.Where(x => x.reqItemID == reqItemID).ToList();
                lr.First().requisitionQty = qty;

                m.SaveChanges();
            }

        }

        /***********add one Item to Requisition***********/
        public RequisitionItem addItem(int requisitionID, string itemID, int requisitionQty)
        {
            RequisitionItem reqI = new RequisitionItem();
            reqI.requisitionID = requisitionID;
            reqI.itemID = itemID;
            reqI.requisitionQty = requisitionQty;
            return reqI;

        }

        public void removeItem(RequisitionItem rI)//call through id or object???
        {
            m.RequisitionItems.Remove(rI);
            m.SaveChanges();
        }

        public void removeItemByReqItemID(int reqIID)
        {
            var requisitionItem = m.RequisitionItems.FirstOrDefault(x => x.reqItemID == reqIID);
            if (requisitionItem != null)
            {
                m.RequisitionItems.Remove(requisitionItem);
                m.SaveChanges();
            }

        }

        public List<ReqItems_custom> getRequisitionItem(int reqID)
        {
            List<ReqItems_custom> lri_c = new List<ReqItems_custom>();

            ItemDAO idao = new ItemDAO();

            var a = from ri in m.RequisitionItems
                    join i in m.Items on ri.itemID equals i.itemID
                    where ri.requisitionID == reqID
                    select new ReqItems_custom
                    {
                        ReqItemID = ri.reqItemID,
                        ReqID = ri.requisitionID,
                        ItemID = ri.itemID,
                        RequisitionQty = ri.requisitionQty,
                        Desc = i.description,
                        Unit = i.unitOfMeasure
                    };
            if (a == null)
            {
                return lri_c;
            }
            lri_c = (List<ReqItems_custom>)a.ToList();

            return lri_c;
        }
    }

}