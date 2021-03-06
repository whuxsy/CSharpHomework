﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
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

                Console.WriteLine("订单金额大于10000的订单如下：");
                foreach(Order order in os.GetBigOrder())
                {
                    Console.WriteLine(order);
                }

                Console.WriteLine("\n\n含有牛奶的订单如下：");
                foreach (Order order in os.GetOrderByName("Milk"))
                {
                    Console.WriteLine(order);
                }

                Console.WriteLine("\n\n客户名为Customer1的订单如下：");
                foreach (Order order in os.GetOrderByCustomer("Customer1"))
                {
                    Console.WriteLine(order);
                }

                Console.WriteLine("\n\n订单号为2的订单如下：");                
                Console.WriteLine(os.GetOrderById(2));
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
