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
    public partial class InvestmentProposal : Form
    {
        public InvestmentProposal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CODInvest ci = new CODInvest();
            ci.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            eBookInvest ci = new eBookInvest();
            ci.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FifaInvest ci = new FifaInvest();
            ci.Show();
        }
    }
}
