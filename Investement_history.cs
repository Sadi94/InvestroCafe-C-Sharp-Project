using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Login
{
    public partial class Investement_history : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Investement_history()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Investement_history_Load(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM "+ HomePage.user+" ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //dataGridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //table fit

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Investor i1 = new Investor();
            i1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hm = new HomePage();
            hm.Show();

        }
    }
}
