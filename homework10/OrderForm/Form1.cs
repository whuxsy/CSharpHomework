using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class Form1 : Form
    {
        public static OrderService os;
        

        public Form1()
        {
            InitializeComponent();
            os = new OrderService();

            OrderBingding.DataSource = os.GetAllOrders();
        }

        /// <summary>
        /// 按订单号查询相关订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OrderBingding.DataSource =
               os.GetOrderById(textBox1.Text);
            textBox1.Text = "";
            OrderBingding.ResetBindings(false);
        }

        /// <summary>
        /// 按客户姓名查询订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OrderBingding.DataSource =
                os.GetOrderByCustomer(textBox2.Text);
            textBox2.Text = "";
            OrderBingding.ResetBindings(false);
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
            OrderBingding.ResetBindings(false);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            os.RemoveOrder(s);
            OrderBingding.Remove(os.GetOrderById(s));
            OrderBingding.DataSource = os.GetAllOrders();
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
            string name = os.GetOrderById(id).Customer.Name;
            new Form4(id, name).ShowDialog();
        }

        private void html_Click(object sender, EventArgs e)
        {
            os.XsltTransform();
        }
    }
}
