using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderTest;

namespace OrderForm
{
    public partial class Form1 : Form
    {
        public static OrderService os;
        public Form1()
        {
            InitializeComponent();
            #region 初始化订单
            Customer customer1 = new Customer("Customer1");
            Customer customer2 = new Customer("Customer2");

            Goods milk = new Goods("Milk", 10);
            Goods eggs = new Goods("eggs", 20);
            Goods apple = new Goods("apple", 30);

            OrderDetail orderDetails1 = new OrderDetail(apple, 5000);
            OrderDetail orderDetails2 = new OrderDetail(eggs, 1000);
            OrderDetail orderDetails3 = new OrderDetail(milk, 20);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetail(orderDetails1);
            order1.AddDetail(orderDetails2);
            order1.AddDetail(orderDetails3);
            order2.AddDetail(orderDetails2);
            order2.AddDetail(orderDetails3);
            order3.AddDetail(orderDetails3);

            os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
            #endregion

            OrderBingding.DataSource = os.Dic.Values.ToList();      
        }

        /// <summary>
        /// 按订单号查询相关订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OrderBingding.DataSource = 
                os.Dic.Values.Where(o => o.Id == Int32.Parse(textBox1.Text));
            textBox1.Text = "";
        }

        /// <summary>
        /// 按客户姓名查询订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OrderBingding.DataSource =
                os.Dic.Values.Where(o => o.Customer.Name == textBox2.Text);
            textBox2.Text = "";
        }

        /// <summary>
        /// 按商品名查询订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OrderBingding.DataSource = os.GetOrderByName(textBox3.Text);
            textBox3.Text = "";    
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (s != "")
            {
                os.RemoveOrder(uint.Parse(s));
                OrderBingding.DataSource = os.Dic.Values.ToList();
            }
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        /// <summary>
        /// 查看选定订单的明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            uint i = uint.Parse(s);
            new Form2(i).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            new Form4(id,name).ShowDialog();
        }
    }
}
