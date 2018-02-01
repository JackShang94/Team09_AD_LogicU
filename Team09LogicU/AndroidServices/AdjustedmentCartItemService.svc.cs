using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team09LogicU.App_Code.DAO;
using Team09LogicU.App_Code.UtilClass;
using Team09LogicU.Models;

namespace Team09LogicU.AndroidServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdjustedmentCartItemService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdjustedmentCartItemService.svc or AdjustedmentCartItemService.svc.cs at the Solution Explorer and start debugging.
    public class AdjustedmentCartItemService : IAdjustedmentCartItemService
    {
        public void addAdjVoucher(List<WCFAdjustmentVoucherCartItem> cartList)
        {
            AdjustmentVoucherDAO adjDAO = new AdjustmentVoucherDAO();
            List<AdjustmentVouchercart> adjItemCart = new List<AdjustmentVouchercart>();
            foreach (WCFAdjustmentVoucherCartItem wcfCI in cartList)
            {
                AdjustmentVouchercart cartItem = new AdjustmentVouchercart();
                cartItem.ItemID = wcfCI.ItemID;
                cartItem.Qty = wcfCI.Qty;
                cartItem.Record = wcfCI.Record;

                adjItemCart.Add(cartItem);
            }
            adjDAO.addAdjV(adjItemCart);
        }
    }
}
