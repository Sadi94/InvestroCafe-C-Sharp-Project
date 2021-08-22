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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                this.Hide();
                AllProposal ap = new AllProposal();
                ap.Show();

            }
            else
            {
                
                MessageBox.Show("Please! Select Invest History");
                this.Hide();
                Admin ad = new Admin();
                ad.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin_Details ad = new Admin_Details();
            ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.Hide();
                InvestmentProposal ip = new InvestmentProposal();
                ip.Show();

            }
            else
            {
                
                MessageBox.Show("Please! Select Review Proposal");
                this.Hide();
                Admin ad = new Admin();
                ad.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaymentForm pf = new PaymentForm();
            pf.Show();
            
        }
    }
}
