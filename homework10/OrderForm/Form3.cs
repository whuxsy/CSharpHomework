﻿using System;
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
        private Order order;
        int i;

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
            i = 1;
        }

        private void choose_Click(object sender, EventArgs e)
        {
            string s = listBox1.SelectedItem.ToString();
            if (s != "")
            {
                Goods g = new Goods(s, good[s]);
                OrderDetail od = new OrderDetail(i++.ToString(),g, uint.Parse(textBox3.Text));
                order.AddDetail(od);
            }
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = order.details;
        }

        private void establish_Click(object sender, EventArgs e)
        {
            order.Id = textBox1.Text;
            if (!checkPhone(textBox4.Text))
                throw new Exception("电话格式不正确");
            order.Customer = new Customer(textBox2.Text, textBox4.Text);
            Form1.os.Dic[order.Id] = order;
            Form1.OrderBingding.DataSource = Form1.os.Dic.Values.ToList();
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
