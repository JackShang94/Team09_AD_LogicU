using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team09LogicU.App_Code.UtilClass
{
    public class AdjustmentVoucherItemcart
    {
        private string name;
        private string itemID;
        private string record;
        private int qty;
        public AdjustmentVoucherItemcart()
        {

        }
        public AdjustmentVoucherItemcart(string name, string itemID, string record, int qty)
        {
            this.name = name;
            this.itemID = itemID;
            this.record = record;
            this.qty = qty;
        }

        public string Name
        {
            get; set;
        }
        public string ItemID
        {
            get; set;
        }
        public string Record
        {
            get; set;
        }
        public int Qty
        {
            get; set;
        }




    }
}