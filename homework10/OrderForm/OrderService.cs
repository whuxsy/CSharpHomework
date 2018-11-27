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
using System.Data.Entity;

namespace OrderForm
{

    public class OrderService
    {
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
                using(var db = new OrderDB())
                {
                    db.Order.Add(order);
                    db.SaveChanges();
                }
            }
        }


        /// <summary>
        /// remove the order in the dic
        /// </summary>
        /// <param name="order_id"></param>
        public void RemoveOrder(string order_id)
        {
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("details").SingleOrDefault(o => o.Id == order_id);
                db.OrderDetail.RemoveRange(order.details);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }


        public List<Order> GetAllOrders()
        {
            using(var db = new OrderDB())
            {
                return db.Order.Include("details").ToList<Order>();
            }
        }

        /// <summary>
        /// get the order by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Order GetOrderById(string id)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("details").
                  SingleOrDefault(o => o.Id == id);
            }
        }

        /// <summary>
        /// get the order in the dic by it's name (using Linq language)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Order> GetOrderByName(string name)
        {
            using(var db=new OrderDB())
            {
                return db.Order.Include("details")
                    .Where(od => od.details.Where(d => d.Goods.Name==name).Count()>0).ToList<Order>();
            }
        }


        /// <summary>
        /// get the order by it's Customer's name (using Linq language)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomer(string name)
        {
            using(var db=new OrderDB())
            {
                return db.Order.Include("details")
                    .Where(o => o.Customer.Name==name).ToList<Order>();
            }
        }


        /// <summary>
        /// get the order whose money >= 10000
        /// </summary>
        /// <returns></returns>
        public List<Order> GetBigOrder()
        {
           using(var db = new OrderDB())
            {
                return db.Order.Include("details")
                    .Where(o => o.OrderMoney >= 10000).ToList<Order>();
            }
        }


        /// <summary>
        /// change the order's Customer
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="newCustomer"></param>
        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.details.ForEach(
                    detail => db.Entry(detail).State = EntityState.Modified);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// XML序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public void Export(object obj, string fileName)
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
            Export(Form1.os.GetAllOrders(), @"..\..\a.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(@"..\..\a.xml");//加载xml文档

            XPathNavigator nav = xml.CreateNavigator();
            nav.MoveToRoot();//游标移动到根节点

            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@"..\..\XSLTFile1.xslt");

            FileStream outFileStream = File.OpenWrite(@"..\..\a.html");
            XmlTextWriter writer =
                new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
            xt.Transform(nav, null, writer);
        }
    }
}

