using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    class OrderService
    {
        private Dictionary<uint, Order> dic;

        #region Constructor
        public OrderService()
        {
            dic = new Dictionary<uint, Order>();  
        }
        #endregion

        #region Add Order
        public void AddOrder(Order order)
        {
            if (dic.ContainsKey(order.Id))
                throw new Exception($"the order {order.Id} has exist!");
            else
            {
                dic[order.Id] = order;
            }
        }
        #endregion

        #region remove the order
        public void RemoveOrder(uint order_id)
        {
            if (dic.ContainsKey(order_id))
                dic.Remove(order_id);
            else
            {
                throw new Exception($"the order {order_id} didn't exist!");
            }
        }
        #endregion

        #region get the order by ID
        public Order GetOrderById(uint id)
        {
            return dic[id];
        }
        #endregion

        #region get the order by goods'name (LINQ)
        public List<Order> GetOrderByName(string name)
        {
            var query = from s in dic.Values
                        from d in s.list
                        where d.Goods.Name == name
                        select s;
            return query.ToList();          
        }
        #endregion

        #region get the order by customer's name (LINQ)
        public List<Order> GetOrderByCustomer(string name)
        {
            var query = dic.Values
                .Where(s => s.Customer.Name == name);
            return query.ToList();            
        }
        #endregion

        #region get the order whose money >= 10000
        public List<Order> GetBigOrder()
        {
            var query = dic.Values
                .Where(s => s.OrderMoney >= 10000);
            return query.ToList();
        }
        #endregion

        #region update the customer
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (dic.ContainsKey(orderId))
            {
                dic[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"the " +
                    $"order {orderId} is not existed!");
            }
        }
        #endregion

    }
}
