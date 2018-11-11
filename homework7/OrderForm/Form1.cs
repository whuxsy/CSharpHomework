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
            Customer customer1 = new Customer("Customer1","15445884526");
            Customer customer2 = new Customer("Customer2","14865585566");

            Goods milk = new Goods("Milk", 10);
            Goods eggs = new Goods("eggs", 20);
            Goods apple = new Goods("apple", 30);

            OrderDetail orderDetails1 = new OrderDetail(apple, 5000);
            OrderDetail orderDetails2 = new OrderDetail(eggs, 1000);
            OrderDetail orderDetails3 = new OrderDetail(milk, 20);

            Order order1 = new Order("20181111001", customer1);
            Order order2 = new Order("20181111002", customer2);
            Order order3 = new Order("20181111003", customer2);
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
                os.Dic.Values.Where(o => o.Id == textBox1.Text);
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
                os.RemoveOrder(s);
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
            new Form2(s).Show();
        }
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = os.Dic[id].Customer.Name;
            new Form4(id,name).ShowDialog();
        }

        private void html_Click(object sender, EventArgs e)
        {
            os.XsltTransform();
        }
    }
}
