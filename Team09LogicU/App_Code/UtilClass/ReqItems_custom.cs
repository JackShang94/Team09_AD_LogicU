using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.UtilClass
{
    public class ReqItems_custom
    {
        private int reqItemID;
        private int reqID;
        private string itemID;
        private int requisitionQty;
        private string desc;
        private string unit;
        public ReqItems_custom()
        {

        }
        public ReqItems_custom(int reqItemID,int reqID, string itemID, int qty, string desc,string unit)
        {
            this.reqItemID = ReqItemID;
            this.reqID = reqID;
            this.itemID = itemID;
            this.requisitionQty = qty;
            this.desc = desc;
            this.Unit = unit;
        }

        public int ReqID
        {
            get
            {
                return reqID;
            }

            set
            {
                reqID = value;
            }
        }

        public string ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }

        public int RequisitionQty
        {
            get
            {
                return requisitionQty;
            }

            set
            {
                requisitionQty = value;
            }
        }

        public string Desc
        {
            get
            {
                return desc;
            }

            set
            {
                desc = value;
            }
        }

        public int ReqItemID
        {
            get
            {
                return reqItemID;
            }

            set
            {
                reqItemID = value;
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }
    }
}