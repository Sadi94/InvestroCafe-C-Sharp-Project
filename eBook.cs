using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Login
{
    public partial class eBook : Form
    {
        public eBook()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Investor p1 = new Investor();
            p1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentForm pa = new PaymentForm();
            pa.Show();
        }
    }
}
