using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数：");
            string s = Console.ReadLine();
            double a = Double.Parse(s);
            s = Console.ReadLine();
            double b = Double.Parse(s);
            Console.WriteLine("乘积为：" + (a * b));
        }
    }
}
