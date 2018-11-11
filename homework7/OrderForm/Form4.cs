﻿using System;
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
    public partial class Form4 : Form
    {
        public string Id { get; set; }
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string id,string customerName)
        {
            InitializeComponent();
            Id = label2.Text = id;
            customername.Text = customerName;
            detailsource.DataSource = Form1.os.Dic[id].list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.os.UpdateCustomer(Id, new OrderTest.Customer
                (customername.Text,Form1.os.Dic[Id].Customer.Phone));
            Form1.OrderBingding.DataSource = Form1.os.Dic.Values.ToList();
            this.Close();
        }
    }
}
