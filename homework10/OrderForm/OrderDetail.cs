using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderForm
{
    public class OrderDetail
    {
        [Key]
        public string Id { get; set; }
        public uint Quantity { get; set; }
        public double Money { get; set; }
        public Goods Goods { get; set; }

        public OrderDetail() {
            Id = Guid.NewGuid().ToString();
        }
        public OrderDetail(string id,Goods goods, uint quantity)
        {
            Id = id;
            Goods = goods;
            Quantity = quantity;
            Money = Goods.Price * Quantity;
        }

        #region override the Equals() and GetHashCode()
        public override bool Equals(object obj)
        {
            var od = obj as OrderDetail;
            return od != null && od.Goods.Name == Goods.Name && Quantity == od.Quantity;
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
            result += (Id + Goods + $", quantity:{Quantity}");
            return result;
        }
    }
}
