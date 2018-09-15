using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 3, 2, 6, 8, 7, 10, 9, 4, 5 };
            Array.Sort(a);
            Console.WriteLine("最大值：" + a[a.Length - 1]);
            Console.WriteLine("最小值：" + a[0]);
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            double n = (double)sum / a.Length;
            Console.WriteLine("平均值：" + n);
            Console.WriteLine("所有元素的和：" + sum);
        }
    }
}
