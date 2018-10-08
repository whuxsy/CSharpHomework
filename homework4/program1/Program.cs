using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace program1
{
    public class ClockEventArgs : EventArgs
    {

    }

    public delegate void ClockEventHandle(object obj, ClockEventArgs Args);//委托声明

    public class Clock
    {
        public event ClockEventHandle Clocking;//声明事件
        public void Response()
        {
            if (Clocking != null)
            {
                ClockEventArgs args = new ClockEventArgs();
                Clocking(this, args);//每触发一次事件，通知一次外界
            }
        }
    }

    class program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("请输入闹钟小时：");
            string h = Console.ReadLine();
            while (true)
            {
                try
                {
                    while (Int32.Parse(h) > 23 || Int32.Parse(h) < 0)
                    {
                        Console.WriteLine("输入不合理，请重新输入小时：");
                        h = Console.ReadLine();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("输入不合理，请重新输入小时：");
                    h = Console.ReadLine();
                }
            }
            Console.WriteLine("请输入闹钟分钟: ");
            string m = Console.ReadLine();
            while (true)
            {
                try
                {
                    if (m.Length == 1)
                        m = "0" + m;
                    while (Int32.Parse(m) > 59 || Int32.Parse(m) < 0)
                    {
                        Console.WriteLine("输入不合理，请重新输入分钟：");
                        m = Console.ReadLine();
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("输入不合理，请重新输入分钟：");
                    m = Console.ReadLine();
                }
            }
            string s = h + ":" + m;


            var clock = new Clock();//注册一个闹钟
            string now_t = DateTime.Now.ToShortTimeString().ToString();
            Console.WriteLine("现在是：" + now_t);
            while (now_t != s)
            {
                Thread.Sleep(60000);//每一分钟求一次当前时间
                now_t = DateTime.Now.ToShortTimeString().ToString();
                Console.WriteLine("现在是：" + now_t);
            }
            clock.Clocking += Ring;
            clock.Response();
        }
        static void Ring(object sender, ClockEventArgs e)
        {
            Console.WriteLine("~~~~响铃啦~~~~");
        }

    }
}
