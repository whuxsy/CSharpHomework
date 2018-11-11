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
            Customer customer1 = new Customer("Customer1","11111111111");
            Customer customer2 = new Customer("Customer2","22222222222");

            Goods milk = new Goods("Milk", 69.9);
            Goods eggs = new Goods("eggs", 4.99);
            Goods apple = new Goods("apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(apple, 5000);
            OrderDetail orderDetails2 = new OrderDetail(eggs, 1000);
            OrderDetail orderDetails3 = new OrderDetail(milk, 20);

            Order order1 = new Order("20181111001", customer1);
            Order order2 = new Order("20181111002", customer2);
            Order order3 = new Order("20181111003", customer2);
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

            try
            {
                os.XsltTransform();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }
}

