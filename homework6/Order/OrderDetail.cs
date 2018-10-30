using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    public class OrderDetail
    {
        #region OrderDetails'Goods
        public Goods Goods { get; set; }
        #endregion

        #region OrderDetails'quantity
        public uint Quantity { get; set; }
        #endregion

        #region OrderDetail's money
        public double Money { get; set; }
        #endregion

        #region OrderDetails'constructor
        public OrderDetail() { }
        public OrderDetail(Goods goods, uint quantity)
        {
            Goods = goods;
            Quantity = quantity;
            Money = Goods.Price * Quantity;
        }
        #endregion

        #region override the Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var od = obj as OrderDetail;
            return od != null && od.Goods.Name==Goods.Name&&Quantity == od.Quantity;
        }

        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }
    }
}
