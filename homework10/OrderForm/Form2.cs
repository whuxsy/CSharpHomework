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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string id) : this()
        {
            this.Text = $"订单{id}";
            orderBindingSource.DataSource = Form1.os.GetOrderById(id);
            orderdetailbindingSource.DataSource = Form1.os.GetOrderById(id).details;
        }
    }
}
