using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;

namespace Team09LogicU.App_Code.DAO
{
    public class RetrievalDAO
    {
        SA45_Team09_LogicUEntities context = new DBEntities().getDBInstance();

        public List<RetrievalFormItem> getRetrievalFormByDate(DateTime date)
        {
            List<Requisition> reqlist = getRetrievedRequisitionList(date);
            List<Outstanding> outlist = getOutStandingList(date);
            List<RetrievalFormItem> reflist = new List<RetrievalFormItem>();

            if (outlist.Count>0)
            {
                getRetrievalFormItemList(reflist, reqlist,outlist);
            }
            else
            {
                getRetrievalFormItemList(reflist, reqlist);
            }

            return reflist;
        }
        //******************************************************Method 01 I am a code master***********************************************************//
        //get item total quantity from requisitions(without outstading)
        private void getRetrievalFormItemList(List<RetrievalFormItem> refl,List<Requisition> reql)
        {
            bool IsNewItem = true;
            bool IsNewDepartment = true;
            if (reql.Count>0)
            {
                foreach (Requisition req in reql)
                {
                    foreach (RequisitionItem reqitem in req.RequisitionItems)
                    {
                        IsNewItem = true;//reset bool for every new item
                        foreach (RetrievalFormItem refitem in refl)
                        {
                            if (refitem.ItemID == reqitem.itemID)//not a new item for RequisitionFormList
                            {
                                IsNewItem = false;//set bool
                                refitem.Needed = refitem.Needed + reqitem.requisitionQty;
                                refitem.Actual = refitem.Needed;
                                IsNewDepartment = true;//reset bool for every new item
                                foreach (BreakdownByDepartment dept in refitem.BreakList)
                                {                                 
                                    if (dept.DeptID == req.deptID)// not a new department for BreakdownByDepartment
                                    {
                                        IsNewDepartment = false;
                                        dept.Needed = dept.Needed + reqitem.requisitionQty;
                                        dept.Actual = dept.Needed;
                                        break;
                                    }                                   
                                }
                                if (IsNewDepartment)//add new dept in refitem.BreakList
                                {
                                    BreakdownByDepartment b = new BreakdownByDepartment();
                                    b.DeptID = req.deptID;
                                    b.Needed = reqitem.requisitionQty;
                                    b.Actual = b.Needed;
                                    refitem.BreakList.Add(b);
                                }
                                break;
                            }                       
                        }
                        if (IsNewItem)//add new item in RequisitionFormList
                        {
                            RetrievalFormItem r = new RetrievalFormItem();
                            r.ItemID = reqitem.itemID;
                            r.ItemDescription = reqitem.Item.description;
                            r.Localtion = reqitem.Item.location;
                            r.Needed = reqitem.requisitionQty;
                            r.Actual = r.Needed;

                            BreakdownByDepartment b = new BreakdownByDepartment();
                            b.DeptID = req.deptID;
                            b.Needed = reqitem.requisitionQty;
                            b.Actual = b.Needed;
                            r.BreakList.Add(b);
                            
                            refl.Add(r);
                        }
                    }
                }
            }
        }

        //get item total quantity from requisitions with outstanding
        private void getRetrievalFormItemList(List<RetrievalFormItem> refl, List<Requisition> reql,List<Outstanding> outl)
        {
            //Add requisitions in RetrievalForm
            getRetrievalFormItemList(refl, reql);
            //Add outstandings in RetrievalForm
            bool IsNewItem = true;
            bool IsNewDepartment = true;
            if (outl.Count > 0)
            {
                foreach (Outstanding outreq in outl)
                {
                    foreach (OutstandingItem outitem in outreq.OutstandingItems)
                    {
                        IsNewItem = true;//reset bool for every new item
                        foreach (RetrievalFormItem refitem in refl)
                        {
                            if (refitem.ItemID == outitem.itemID)//not a new item for RequisitionFormList
                            {
                                IsNewItem = false;//set bool
                                refitem.Needed = refitem.Needed + outitem.expectedQty;
                                refitem.Actual = refitem.Needed;
                                IsNewDepartment = true;//reset bool for every new item
                                foreach (BreakdownByDepartment dept in refitem.BreakList)
                                {
                                    if (dept.DeptID == outreq.deptID)// not a new department for BreakdownByDepartment
                                    {
                                        IsNewDepartment = false;
                                        dept.Needed = dept.Needed + outitem.expectedQty;
                                        dept.Actual = dept.Needed;
                                        break;
                                    }
                                }
                                if (IsNewDepartment)//add new dept in refitem.BreakList
                                {
                                    BreakdownByDepartment b = new BreakdownByDepartment();
                                    b.DeptID = outreq.deptID;
                                    b.Needed = outitem.expectedQty;
                                    b.Actual = b.Needed;
                                    refitem.BreakList.Add(b);
                                }
                                break;
                            }
                        }
                        if (IsNewItem)//add new item in RequisitionFormList
                        {
                            RetrievalFormItem r = new RetrievalFormItem();
                            r.ItemID = outitem.itemID;
                            r.ItemDescription = outitem.Item.description;
                            r.Localtion = outitem.Item.location;
                            r.Needed = outitem.expectedQty;
                            r.Actual = r.Needed;

                            BreakdownByDepartment b = new BreakdownByDepartment();
                            b.DeptID = outreq.deptID;
                            b.Needed = outitem.expectedQty;
                            b.Actual = b.Needed;
                            r.BreakList.Add(b);

                            refl.Add(r);
                        }
                    }
                }
            }
        }

        //get  requisitions from database
        public List<Requisition> getRetrievedRequisitionList(DateTime date)
        {
            List<Requisition> reql = new List<Requisition>();
            reql = context.Requisitions.
                Where(x => (x.requisitionDate.Year <= date.Year && x.requisitionDate.Month <= date.Month && x.requisitionDate.Day <= date.Day)
                && x.status == "Approved").ToList();
            return reql;
        }

        //get outstanding requisitions from database
        public List<Outstanding> getOutStandingList(DateTime date)
        {        
            List<Outstanding> outstandinglist = new List<Outstanding>();
            outstandinglist = context.Outstandings.
                Where(x => (x.disburseDate.Year <= date.Year && x.disburseDate.Month <= date.Month && x.disburseDate.Day <= date.Day)
                && x.status == "Pending").ToList();
            return outstandinglist;
        }

        //Update  Requisition status as "Processed"
        public void updateRequisitionStatusAsProcessed(List<Requisition> reql)
        {
            foreach (Requisition req in reql)
            {
                req.status = "Processed";
            }
            context.SaveChanges();
        }

        //Update outStanding status as "Processed"
        public void updateOutStandingStatusAsProcessed(List<Outstanding> outl)
        {
            foreach (Outstanding item in outl)
            {
                item.status = "Processed";
            }
            context.SaveChanges();
        }

        //******************************************************Method 02 I am a SQL master**********************************************************//
        //select distinct itemID,sum(requisitionQty)  from RequisitionItem
        //where requisitionID in(
        //select requisitionID from Requisition
        //where status='Approved' and and approvedDate <= '2018-1-21'  )
        //group by itemID

        
    }
}