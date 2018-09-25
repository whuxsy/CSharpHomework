using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    interface MyGraph
    {
        void showArea();
    }

    class Triangel :MyGraph
    {
        private double h, w;
        public Triangel()
        {
            Console.WriteLine("输入三角形高：");
            this.h = Double.Parse(Console.ReadLine());
            Console.WriteLine("输入三角形底：");
            this.w = Double.Parse(Console.ReadLine());
        }
        void MyGraph.showArea()
        {
            Console.WriteLine("三角形面积为：" + (h * w));
        }
           
    }

    class Circle : MyGraph
    {
        private double R;
        public Circle()
        {
            Console.WriteLine("请输入圆形的半径L：");
            this.R = Convert.ToDouble(Console.ReadLine());      
        }
        void MyGraph.showArea()
        {
            Console.WriteLine("圆形的面积："+ (3.14*R*R));
        }
    }

    class squre : MyGraph
    {
        private double l;
        public squre()
        {
            Console.WriteLine("请输入正方形的边长：");
            this.l = Double.Parse(Console.ReadLine());        
        }
        void MyGraph.showArea()
        {
            Console.WriteLine("正方形的面积为：" + (l * l));
        }
    }

    class Rectangle : MyGraph
    {
        private double a,b;
        public Rectangle()
        {
            Console.WriteLine("请输入长方形的长为：");
            this.a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入长方形的宽为：");
            this.b = Convert.ToDouble(Console.ReadLine());
        }
        void MyGraph.showArea()
        {
            Console.WriteLine("长方形的面积为：" + (a * b));
        }
    }

    class GraphFactory
    {
        public static MyGraph GetMyGraph(String type)
        {
            MyGraph myGraph = null;
            if(type.Equals("三角形"))
            {
                myGraph = new Triangel();
                Console.WriteLine("初始化三角形");
            }
            else if(type.Equals("正方形"))
            {
                myGraph = new squre();
                Console.WriteLine("初始化正方形");
            }
            else if(type.Equals("长方形"))
            {
                myGraph = new Rectangle();
                Console.WriteLine("初始化长方形");
            }
            else if(type.Equals("圆形"))
            {
                myGraph = new Circle();
                Console.WriteLine("初始化圆形");
            }
            return myGraph;
        }
    }

    class client
    {
        static void Main(string[] args)
        {
            MyGraph myGraph = GraphFactory.GetMyGraph("长方形");
            myGraph.showArea();
        }
    }
}
