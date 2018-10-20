using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace OrderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 初始化订单
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 5000);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 1000);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 20);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetail(orderDetails1);
            order1.AddDetail(orderDetails2);
            order1.AddDetail(orderDetails3);
            order2.AddDetail(orderDetails2);
            order2.AddDetail(orderDetails3);
            order3.AddDetail(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            #endregion

            Order[] orders = new Order[10];
            int i = 0;
            foreach(Order od in os.Dic.Values)
            {
                orders[i++] = od;
            }

            XmlSerializer ser = new XmlSerializer(typeof(Order[]));
            //XML序列化
            os.Export(ser,orders,"a.xml");

            //显示xml文本
            string s = File.ReadAllText("a.xml");
            Console.WriteLine(s);

            //XML反序列化
            Order[] orders2 = os.Import(ser,"a.xml") as Order[];

            //打印订单
            foreach(Order od in orders2)
            {
                Console.WriteLine(od);
            }
        }

        
    }
}

