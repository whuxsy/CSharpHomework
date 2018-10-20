using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace OrderTest
{

    public class OrderService
    {
        private Dictionary<uint, Order> dic;

        public Dictionary<uint, Order> Dic
        {
            get { return dic; }
        }

        #region Constructor
        public OrderService()
        {
            dic = new Dictionary<uint, Order>();
        }
        #endregion

        /// <summary>
        /// add order to the dic
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            if (dic.ContainsKey(order.Id))
                throw new Exception($"the order {order.Id} has exist!");
            else
            {
                dic[order.Id] = order;
            }
        }
        

        /// <summary>
        /// remove the order in the dic
        /// </summary>
        /// <param name="order_id"></param>
        public void RemoveOrder(uint order_id)
        {
            if (dic.ContainsKey(order_id))
                dic.Remove(order_id);
            else
            {
                throw new Exception($"the order {order_id} didn't exist!");
            }
        }
        

       /// <summary>
       /// get the order by it's id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public Order GetOrderById(uint id)
        {
            if (dic.ContainsKey(id))
                return dic[id];
            else
            {
                throw new Exception($"the order {id} didn't exist!");
            }
        }
        
        /// <summary>
        /// get the order in the dic by it's name (using Linq language)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Order> GetOrderByName(string name)
        {
            var query = from s in dic.Values
                        from d in s.list
                        where d.Goods.Name == name
                        select s;
            return query.ToList();
        }
        

        /// <summary>
        /// get the order by it's Customer's name (using Linq language)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomer(string name)
        {
            var query = dic.Values
                .Where(s => s.Customer.Name == name);
            return query.ToList();
        }
       

        /// <summary>
        /// get the order whose money >= 10000
        /// </summary>
        /// <returns></returns>
        public List<Order> GetBigOrder()
        {
            var query = dic.Values
                .Where(s => s.OrderMoney >= 10000);
            return query.ToList();
        }
        

        /// <summary>
        /// change the order's Customer
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newCustomer"></param>
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
        

       /// <summary>
       /// XML序列化
       /// </summary>
       /// <param name="obj"></param>
       /// <param name="fileName"></param>
        public void Export(XmlSerializer ser,object obj,string fileName)
        {
            try
            {        
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    ser.Serialize(fs, obj);
                }
            }catch(IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public object Import(XmlSerializer ser,string fileName)
        {
            try
            {       
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    object obj2 = ser.Deserialize(fs);
                    return obj2;
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine($"找不到{fileName}！");
                return null;
            }catch(IOException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}

