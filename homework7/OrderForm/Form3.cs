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
    public partial class Form3 : Form
    {
        public Dictionary<string, double> good = new Dictionary<string, double>();
        private Order order;

        public Form3()
        {
            InitializeComponent();
            good["Milk"] = 10;
            good["eggs"] = 20;
            good["apple"] = 30;
            good["banana"] = 40;
            good["book"] = 50;
            good["fish"] = 60;
            order = new Order();
            bindingSource1.DataSource = null;
        }

        private void choose_Click(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            if (s!="")
            {
                Goods g = new Goods(s, good[s]);
                OrderDetail od = new OrderDetail(g, uint.Parse(textBox3.Text));
                order.AddDetail(od);
            }
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = order.list;
        }

        private void establish_Click(object sender, EventArgs e)
        {
            order.Id = uint.Parse(textBox1.Text);
            order.Customer = new Customer(textBox2.Text);
            Form1.os.AddOrder(order);
            Form1.OrderBingding.DataSource = Form1.os.Dic.Values.ToList();
        }

    }
}
