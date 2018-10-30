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
    public partial class Form4 : Form
    {
        private uint _id;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string id,string customerName)
        {
            InitializeComponent();
            label2.Text = id;
            customername.Text = customerName;
            _id = uint.Parse(id);
            detailsource.DataSource = Form1.os.Dic[_id].list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.os.UpdateCustomer(_id, new OrderTest.Customer(customername.Text));
            Form1.OrderBingding.DataSource = Form1.os.Dic.Values.ToList();
            this.Close();
        }
    }
}
