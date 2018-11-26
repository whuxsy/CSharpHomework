using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace OrderForm
{


    public class Order
    {
        [Key]
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public double OrderMoney { get; set; }
        public List<OrderDetail> details { get; set; }


        #region OrderDetail's constructor
        public Order() {
            details = new List<OrderDetail>();
        }
        public Order(string orderId, Customer customer):base()
        {
            Id = orderId;
            Customer = customer;
            OrderMoney = 0;
        }
        #endregion

        #region add the OrderDtail
        public void AddDetail(OrderDetail od)
        {
            if (!details.Contains(od))
            {
                details.Add(od);
                OrderMoney += od.Money;
            }
            else
            {
                throw new Exception($"the orderdetails has exist!");
            }
        }
        #endregion

        #region remove the OrderDetail
        public void RemoveDetail(string goodsname)
        {
            foreach (OrderDetail od in details)
            {
                if (goodsname == od.Goods.Name)
                {
                    OrderMoney -= od.Money;
                    details.Remove(od);
                }
            }
        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            string result = "\n";
            result += $"orderId:{Id}, customer:{Customer}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
        #endregion
    }
}

