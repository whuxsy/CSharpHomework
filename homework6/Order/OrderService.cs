using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Xml.XPath;

namespace OrderTest
{

    public class OrderService
    {
        private Dictionary<string, Order> dic;

        public Dictionary<string, Order> Dic
        {
            get { return dic; }
        }

        #region Constructor
        public OrderService()
        {
            dic = new Dictionary<string, Order>();
        }
        #endregion

        /// <summary>
        /// add order to the dic
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            if (!CheckId(order.Id))
                throw new Exception($"订单 {order.Id} 不合法!");
            else
            {
                dic[order.Id] = order;
            }
        }
        

        /// <summary>
        /// remove the order in the dic
        /// </summary>
        /// <param name="order_id"></param>
        public void RemoveOrder(string order_id)
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
        public Order GetOrderById(string id)
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
        public void UpdateCustomer(string orderId, Customer newCustomer)
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
        public void Export(object obj,string fileName)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
                   
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
               ser.Serialize(fs, obj);
            }
            
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public object Import(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Order[]));
                
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                object obj2 = ser.Deserialize(fs);
                return obj2;
            }          
        }

        /// <summary>
        /// 正则表达式检验id是否合格
        /// </summary>
        /// <param name="testid"></param>
        /// <returns></returns>
        public bool CheckId(string testid)
        {
            //分成31,30,28天进行讨论
            string[] ss = {@"((19|20)\d{2})(0?[13578]|1[02])(0?[1-9]|[12]\d|(30|31))(\d{3})",
                        @"((19|20)\d{2})(0?[469]|11)(0?[1-9]|[12]\d|30)(\d{3})",
                        @"((19|20)\d{2})(0?2)(0?[1-9]|1\d|2[0-8])(\d{3}))"};
            foreach (string s in ss)
            {
                Regex regex = new Regex(s);
                if (regex.IsMatch(testid))
                {
                    if (Dic.ContainsKey(testid))
                        return false;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// XML文件转化为html文件
        /// </summary>
        public void XsltTransform()
        {
            Export(dic.Values.ToList(), @"..\..\a.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(@"..\..\a.xml");//加载xml文档

            XPathNavigator nav = xml.CreateNavigator();
            nav.MoveToRoot();//游标移动到根节点

            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@"..\..\a.xslt");

            FileStream outFileStream = File.OpenWrite(@"..\..\a.html");
            XmlTextWriter writer =
                new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
            xt.Transform(nav, null, writer);
        }
    }
}

