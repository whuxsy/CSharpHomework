using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Order(string orderId, Customer customer,List<OrderDetail>list)
        {
            Id = orderId;
            Customer = customer;
            details = list;
            OrderMoney = 0;
            foreach(OrderDetail od in list)
            {
                OrderMoney += od.Money;
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

