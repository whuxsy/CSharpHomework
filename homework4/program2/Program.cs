using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace program2
{
    class Order
    {
        public string id;
        public List<OrderDetails> OrderList = new List<OrderDetails>();//订单列表

        public Order(string id)
        {
            this.id = id;
        }
        public void AddOrderDetails(OrderDetails od)//增加条目
        {
            this.OrderList.Add(od);
        }

        public void DeleteOrderDetails(OrderDetails od)//删除条目
        {
            try
            {
                this.OrderList.Remove(od);
            }
            catch (Exception e)
            {
                Console.WriteLine("订单列表已经为空，无法删除");
            }
        }

        public int FindOrderDetails(string s)
        {
            for(int i = 0;i<this.OrderList.Count;i++)
            {
                if (this.OrderList[i].dic[0] == s || this.OrderList[i].dic[1] == s)
                    return i;
            }
            return -1;
        }

        public void PrintOrderDetails()//打印条目
        {
            foreach (OrderDetails od in this.OrderList)
            {
                Console.WriteLine(od.dic[0] + " " + od.dic[1] + " " + od.dic[2] + " " + od.dic[3]);
            }
        }

    }

    class OrderDetails
    {
        public Dictionary<int, string> dic = new Dictionary<int, string>();

        public OrderDetails(string name = "",string cname = "", string num = "", string price = "")
        {
            dic[0] = name;//商品名
            dic[1] = cname;//客户名
            dic[2] = num;//商品数量
            dic[3] = price;//商品价格
        }
    }

    class program
    {
        static void Main(string[] args)
        {
            List<Order> list = new List<Order>();//订单列表

            program os = new program();
            //初始化条目
            OrderDetails od1 = new OrderDetails("C#","xsy", "10", "69");
            OrderDetails od2 = new OrderDetails("Java","ys", "12", "55");
            OrderDetails od3 = new OrderDetails("C++","theory", "42", "64");
            //初始化订单
            Order order1 = new Order("001");
            Order order2 = new Order("002");
            order1.AddOrderDetails(od1);
            order1.AddOrderDetails(od2);
            order2.AddOrderDetails(od3);
            //增加订单
            os.AddOrder(list, order1);
            os.AddOrder(list, order2);
            //删除订单
            os.DeleteOrder(list, order2);
            //查询订单
            int index = os.FindOrder(list, "Java");//订单下标
            int i = list[index].FindOrderDetails("Java");//订单中条目下标
            //修改订单
            os.ChangeOrder(list, index, i, 0, "Java实验与设计");
            //打印订单
            foreach(Order od in list)
            {
                od.PrintOrderDetails();
            }
        }

        public void AddOrder(List<Order>list,Order order)//增加订单
        {
            list.Add(order);
        }

        public void DeleteOrder(List<Order> list, Order order)//增加订单
        {
            try
            {
                list.Remove(order);
            }
            catch(Exception e)
            {
                Console.WriteLine("订单数为0，无法删除");
            }
        }

        public int FindOrder(List<Order> list,string s)//查询订单，返回下标
        {
            for(int i = 0;i<list.Count;i++)
            {
                if (s == list[i].id)
                    return i;
                foreach(OrderDetails od in list[i].OrderList)
                {
                    if(od.dic[0]==s||od.dic[1]==s)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void ChangeOrder(List<Order>list,int index,int i,int j,string s)//修改index订单第i条目第j属性
        {
            try
            {
                list[index].OrderList[i].dic[j] = s;
            }
            catch(Exception e)
            {
                Console.WriteLine("无法修改");
            }
        }
    }
}
