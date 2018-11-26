using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                if (MessageBox.Show(null, e.Message, "出错了", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}
