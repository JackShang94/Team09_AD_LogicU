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

            //updateRequisitionStatusAsProcessed(reqlist);// should be put into the confirmBtn ???

            List<Outstanding> outlist = getOutStandingList(date);

            //updateOutStandingStatusAsProcessed(outlist);//comment it in order to test

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
        private List<Requisition> getRetrievedRequisitionList(DateTime date)
        {
            List<Requisition> reql = new List<Requisition>();
            reql = context.Requisitions. 
                Where(x=>(x.approvedDate<=date)
                && x.status == "Approved").ToList();
            return reql;
        }

        //get outstanding requisitions from database
        private List<Outstanding> getOutStandingList(DateTime date)
        {        
            List<Outstanding> outstandinglist = new List<Outstanding>();
            outstandinglist = context.Outstandings.
                Where(x => (x.disburseDate.Year <= date.Year && x.disburseDate.Month <= date.Month && x.disburseDate.Day <= date.Day)
                && x.status == "Pending").ToList();
            return outstandinglist;
        }

        //Update  Requisition status as "Processed"
        private void updateRequisitionStatusAsProcessed(List<Requisition> reql)
        {
            foreach (Requisition req in reql)
            {
                req.status = "Processed";
            }
            context.SaveChanges();
        }

        //Update outStanding status as "Processed"
        private void updateOutStandingStatusAsProcessed(List<Outstanding> outl)
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

        public void ConfirmRetrieval(List<RetrievalFormItem> reflist,DateTime date)
        {
            List<RetrievalFormItem> result = UpdateActualQuantity(reflist);

            saveRetrieval(result);

            List<Disbursement> dislist = generateDisbersementList(result);

            saveDisbursement(dislist);

            List<Requisition> reqlist2 = getRetrievedRequisitionList(date);
            List<Outstanding> outlist2 = getOutStandingList(date);
            updateRequisitionStatusAsProcessed(reqlist2);
            updateOutStandingStatusAsProcessed(outlist2);

            List<Outstanding> outlist = generateOutstandingList(dislist);

            saveOutstanding(outlist);

            updateStockCardAndItemQuantity(result);


        }

        private void updateStockCardAndItemQuantity(List<RetrievalFormItem> reflist)
        {
            foreach (RetrievalFormItem refitem in reflist)
            {
                foreach (BreakdownByDepartment breakitem in refitem.BreakList)
                {
                    //update item quantity
                    Item item;
                    List<Item> resultlist = context.Items.Where(x => x.itemID == refitem.ItemID).ToList();
                    if (resultlist.Count > 0)// not null
                    {
                        item = resultlist.First();
                        item.qtyOnHand = item.qtyOnHand - breakitem.Actual;
                        //update stock card
                        StockCard st = new StockCard();
                        st.itemID = refitem.ItemID;
                        st.date = DateTime.Now;
                        st.quantity = -breakitem.Actual;
                        st.balance = item.qtyOnHand;
                        st.record = breakitem.DeptID + " Department";

                        context.StockCards.Add(st);
                    }
                }
            }
            context.SaveChanges();
        }

        private void updateWarehouseItemQuantity(List<RetrievalFormItem> reflist)
        {
            foreach (RetrievalFormItem refitem in reflist)
            {
                List<Item> resultlist = context.Items.Where(x => x.itemID == refitem.ItemID).ToList();
                if (resultlist.Count>0)
                {
                    Item item = resultlist.First();
                    item.qtyOnHand = item.qtyOnHand - refitem.Actual;
                }
            }
            context.SaveChanges();
        }

        private void saveOutstanding(List<Outstanding> outlist)
        {
            foreach (Outstanding outs in outlist)
            {
                context.Outstandings.Add(outs);
                foreach (OutstandingItem item in outs.OutstandingItems)
                {
                    item.outstandingID = outs.outstandingID;
                    context.OutstandingItems.Add(item);
                }
            }
            context.SaveChanges();
        }

        private List<Outstanding> generateOutstandingList(List<Disbursement> dislist)
        {
            List<Outstanding> outlist = new List<Outstanding>();
            bool IsNewDepartment = true;
            foreach (Disbursement dept in dislist)// each department
            {
                foreach (DisbursementItem item in dept.DisbursementItems)
                {
                    if (item.expectedQty > item.actualQty)// outstanding
                    {
                        foreach (Outstanding  outsdept in outlist)
                        {
                            IsNewDepartment = true;
                            if (outsdept.deptID == dept.deptID)//not a new department in outstanding
                            {
                                IsNewDepartment = false;
                                OutstandingItem outitem = new OutstandingItem();
                                outitem.itemID = item.itemID;
                                outitem.expectedQty = item.expectedQty - item.actualQty;
                                outitem.actualQty = outitem.expectedQty;

                                outsdept.OutstandingItems.Add(outitem);
                                break;
                            }
                        }
                        if (IsNewDepartment)//add a new department in outstading
                        {
                            Outstanding outs = new Outstanding();
                            outs.deptID = dept.deptID;
                            outs.disburseDate = dept.disburseDate;
                            outs.storeStaffID = dept.storeStaffID;
                            outs.status = "Pending";

                            OutstandingItem outitem = new OutstandingItem();
                            outitem.itemID = item.itemID;
                            outitem.expectedQty = item.expectedQty - item.actualQty;
                            outitem.actualQty = outitem.expectedQty;

                            outs.OutstandingItems.Add(outitem);
                            outlist.Add(outs);
                        }
                    }
                }
            }

            return outlist;
        }

        private void saveRetrieval(List<RetrievalFormItem> reflist )
        {
            if (reflist.Count>0)
            {
                Retrieval r = new Retrieval();
                r.retrievalDate = DateTime.Now;
                context.Retrievals.Add(r);
                foreach (RetrievalFormItem refitem in reflist)
                {
                    RetrievalItem item = new RetrievalItem();
                    item.retrievalID = r.retrievalID;
                    item.itemID = refitem.ItemID;
                    item.expectedQty = refitem.Needed;
                    item.actualQty = refitem.Actual;

                    context.RetrievalItems.Add(item);               
                }
                context.SaveChanges();
            }
        }

        private void saveDisbursement(List<Disbursement> dislist)
        {
            foreach (Disbursement dept in dislist)
            {
                context.Disbursements.Add(dept);            
                foreach (DisbursementItem item in dept.DisbursementItems)
                {
                    item.disbursementID = dept.disbursementID;
                    context.DisbursementItems.Add(item);                
                }
            }
            context.SaveChanges();
        }

        private List<Disbursement> generateDisbersementList(List<RetrievalFormItem> reflist)
        {
            bool IsNewDepartment = true;
            bool IsNewItem = true;
            List<Disbursement> dislist = new List<Disbursement>();
            foreach (RetrievalFormItem refitem in reflist)
            {
                foreach (BreakdownByDepartment breaklist in refitem.BreakList)
                {
                    IsNewDepartment = true;//reset boolean
                    foreach (Disbursement dept in dislist)
                    {                    
                        if (dept.deptID == breaklist.DeptID)//not a new department
                        {
                            IsNewDepartment = false;
                            IsNewItem = true;
                            foreach (DisbursementItem item in dept.DisbursementItems)
                            {                              
                                if (item.itemID == refitem.ItemID)// not a new item
                                {
                                    IsNewItem = false;
                                    item.expectedQty = item.expectedQty + breaklist.Needed;
                                    item.actualQty = item.actualQty+ breaklist.Actual;
                                    break;
                                }
                            }
                            if (IsNewItem)// add a new item in disbursementItems
                            {
                                DisbursementItem item = new DisbursementItem();
                                //item.disbursementID = dept.disbursementID;
                                item.itemID = refitem.ItemID;
                                item.expectedQty = breaklist.Needed;
                                item.actualQty = breaklist.Actual;

                                dept.DisbursementItems.Add(item);
                            }
                        }
                    }
                    if (IsNewDepartment)//add a new department in disbursement
                    {
                        Disbursement dept = new Disbursement();
                        dept.deptID = breaklist.DeptID;
                        dept.storeStaffID = (string)HttpContext.Current.Session["loginID"];
                        dept.disburseDate = DateTime.Now;
                        dept.status = "Awaiting Delivery";

                        DisbursementItem item = new DisbursementItem();
                        item.itemID = refitem.ItemID;
                        item.expectedQty = breaklist.Needed;
                        item.actualQty = breaklist.Actual;
                        dept.DisbursementItems.Add(item);

                        dislist.Add(dept);
                    }
                }
            }
            return dislist;
        }

        //Update  reflist Actual Quantity According to UI TextBox input
        private List<RetrievalFormItem>  UpdateActualQuantity(List<RetrievalFormItem> reflist)
        {            
            //********************************
            //*********************************
            //*********************************
            //*********************************
            //*********************************
            //*********************************
            return reflist;
        }      
    }
}