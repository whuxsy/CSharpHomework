using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace program2
{
    class Order
    {
        public List<OrderDetails> OrderList = new List<OrderDetails>();//订单列表
    }

    class OrderDetails
    {
        public Dictionary<int, string> dic = new Dictionary<int, string>();

        public OrderDetails(string name = "", string id = "", string cname = "", string num = "", string price = "")
        {
            dic[0] = name;//商品名
            dic[1] = id;  //商品标号
            dic[2] = cname;//客户名
            dic[3] = num;//商品数量
            dic[4] = price;//商品价格
        }
        public OrderDetails ShallowCopy()
        {
            return (OrderDetails)this.MemberwiseClone();
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            Order order = new Order();//创建订单列表
            program os = new program();
            //初始化订单
            OrderDetails od1 = new OrderDetails("C#", "001", "xsy", "10", "69");
            OrderDetails od2 = new OrderDetails("Java", "002", "ys", "12", "55");
            OrderDetails od3 = new OrderDetails("C++", "003", "theory", "42", "64");
            //添加订单
            os.AddOrder(order, od1);
            os.AddOrder(order, od2);
            os.AddOrder(order, od3);
            //删除订单
            os.DeleteOrder(order, od2);
            //查询订单
            int index = os.FindOrder(order, "C++");//查询订单，返回订单下标
            //修改订单(想修改的属性，都有对应的键值)
            os.ChangeOrder(order, index, 0, "C++实验与设计教科书");
            //打印订单
            os.PrintOrder(order);

        }

        public void AddOrder(Order order, OrderDetails od)
        {
            order.OrderList.Add(od);
        }

        public void DeleteOrder(Order order, OrderDetails od)
        {
            try
            {
                order.OrderList.Remove(od);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单列表已经为空，无法删除");
            }
        }

        public void ChangeOrder(Order order, int index, int key, string s)
        {
            try
            {
                order.OrderList[index].dic[key] = s;
            }
            catch (Exception e)
            {
                Console.WriteLine("下标或键值不合理");
            }
        }

        public int FindOrder(Order order, string s)
        {
            for (int i = 0; i < order.OrderList.Count; i++)
            {
                if (order.OrderList[i].dic[0] == s || order.OrderList[i].dic[1] == s || order.OrderList[i].dic[2] == s)
                {
                    return i;
                }
            }
            return -1;
        }

        public void PrintOrder(Order order)
        {
            foreach (OrderDetails od in order.OrderList)
            {
                Console.WriteLine(od.dic[0] + " " + od.dic[1] + " " + od.dic[2] + " " + od.dic[3] + " " + od.dic[4]);
            }
        }


    }
}
