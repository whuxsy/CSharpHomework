using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class Form3 : Form
    {
        public Dictionary<string, double> good = new Dictionary<string, double>();
        private List<OrderDetail> odlist = new List<OrderDetail>();
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
            bindingSource1.DataSource = null;
        }

        private void choose_Click(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            if (s != "")
            {
                Goods g = new Goods(s, good[s]);
                OrderDetail od = new OrderDetail();
                od.Goods = g;
                od.Quantity = uint.Parse(textBox3.Text);
                od.Money = od.Quantity * od.Goods.Price;
                odlist.Add(od);
            }
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = odlist;
        }

        private void establish_Click(object sender, EventArgs e)
        {
            if (!checkPhone(textBox4.Text))
                throw new Exception("电话格式不正确");
            order = new Order(textBox1.Text, new Customer(textBox2.Text, textBox4.Text), odlist);
            Form1.os.AddOrder(order);
            Form1.OrderBingding.Add(order);           
            Form1.OrderBingding.ResetBindings(false);
            this.Close();
        }


        public bool checkPhone(string phone)
        {
            Regex regex = new Regex(@"^[1]+[3456789]+\d{9}$");
            if (regex.IsMatch(phone))
                return true;
            return false;
        }
    }
}
