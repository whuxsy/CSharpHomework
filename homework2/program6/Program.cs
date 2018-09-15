using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            int a = Int32.Parse(Console.ReadLine());
            int i = 2;
            while (a >= 2)
            {
                if (a % i == 0)
                {
                    a /= i;
                    if (a >= 2) Console.Write(i + "*");
                    else Console.Write(i);
                }
                else i++;            
            }
        }
    }
}
