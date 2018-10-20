﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderTest
{
    

    public class Order
    {
        public List<OrderDetail> list = new List<OrderDetail>();

        #region Order's id
        public uint Id { get; set; }
        #endregion

        #region Order's customer
        public Customer Customer { get; set; }
        #endregion

        #region order's money
        public double OrderMoney { get; set; }
        #endregion

        #region OrderDetail's constructor
        public Order() { }
        public Order(uint orderId, Customer customer)
        {
            Id = orderId;
            Customer = customer;
            OrderMoney = 0;
        }
        #endregion

        #region add the OrderDtail
        public void AddDetail(OrderDetail od)
        {
            if (!list.Contains(od))
            {
                list.Add(od);
                OrderMoney += od.Money;
            }
            else
            {
                throw new Exception($"orderdetails {od.Id} has exist!");
            }
        }
        #endregion

        #region remove the OrderDetail
        public void RemoveDetail(uint detail_id)
        {
            foreach (OrderDetail od in list)
            {
                if (od.Id == detail_id)
                {
                    OrderMoney -= od.Money;
                    list.Remove(od);
                }
            }
        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            string result = "\n";
            result += $"orderId:{Id}, customer:({Customer})";
            list.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
        #endregion
    }
}

