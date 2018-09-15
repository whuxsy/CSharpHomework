using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = this.textBox1.Text;
            string s2 = this.textBox2.Text;
            double a = Double.Parse(s1);
            double b = Double.Parse(s2);
            this.textBox3.Text = (a * b).ToString();
        }
    }
}
