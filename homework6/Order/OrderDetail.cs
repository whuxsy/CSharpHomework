using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    public class OrderDetail
    {
        #region OrderDetails'id
        public uint Id { get; set; }
        #endregion

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
        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            Id = id;
            Goods = goods;
            Quantity = quantity;
            Money = Goods.Price * Quantity;
        }
        #endregion

        #region override the Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var od = obj as OrderDetail;
            return od != null && Goods.Id == od.Goods.Id && Quantity == od.Quantity;
        }

        public override int GetHashCode()
        {
            var hashcode = 12345;
            hashcode = hashcode * hashcode + Goods.GetHashCode();
            hashcode = hashcode * hashcode + Quantity.GetHashCode();
            return hashcode;
        }
        #endregion

        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }
    }
}
