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
    public partial class IntroPage : Form
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationPage r1 = new RegistrationPage();
            r1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs a1 = new AboutUs();
            a1.Show();
            ///about us button;

        }

        private void IntroPage_Load(object sender, EventArgs e)
        {

        }
    }
}
