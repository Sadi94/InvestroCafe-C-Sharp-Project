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
    public partial class FifaInvest : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public int total = 0;
        public FifaInvest()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InvestmentProposal ip = new InvestmentProposal();
            ip.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            total += int.Parse(textBox1.Text);
            textBox2.Text = total.ToString();



            ///////
            SqlConnection con = new SqlConnection(cs);
            string query = "DELETE FROM FIFA WHERE NID=@Nid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@Nid", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("@add", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            cmd.Parameters.AddWithValue("@acc", dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            cmd.Parameters.AddWithValue("@amount", dataGridView1.SelectedRows[0].Cells[4].Value.ToString());

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Amount Added succsessfully !");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Amount Added unsuccsessful");
            }


            con.Close();
            /////
        }

        private void BindGridView()
        {
            //connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM FIFA";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //dataGridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //table fit

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Amount send to Entreprenurs..." + textBox2.Text);
            textBox1.Clear();
            textBox2.Clear();
        }

        private void FifaInvest_Load(object sender, EventArgs e)
        {
            //connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM FIFA";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //dataGridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //table fit

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
