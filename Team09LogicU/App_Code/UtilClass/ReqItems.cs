using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team09LogicU.Models;
namespace Team09LogicU.App_Code.UtilClass
{
    public class ReqItems
    {
        private int reqID;
        private string itemID;
        private int qty;
        private string desc;
        public ReqItems()
        {

        }
        public ReqItems(int reqID, string itemID, int qty, string desc)
        {
            this.reqID = reqID;
            this.itemID = itemID;
            this.qty = qty;
            this.desc = desc;
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

        public int Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
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
    }
}