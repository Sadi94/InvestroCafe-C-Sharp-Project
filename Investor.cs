using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Login
{
    public partial class Investor : Form
    {
        //database connection
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Investor()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Investor_Details I_D = new Investor_Details();
            I_D.Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            BindGridView();
            //this.Hide();
            //proposal p1 = new proposal();
            //p1.Show();
        }
        void BindGridView()
        {
            //connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM ACCEPTED_PRO";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //dataGridView Display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //Image Column Fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //table fit

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Image Height

            dataGridView1.RowTemplate.Height =  100;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
           // textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           // textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           // textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "COD")
            {
                this.Hide();
                COD c1 = new COD();
                c1.Show();

            }
            else if (textBox1.Text == "EBOOK")
            {
                this.Hide();
                eBook e1 = new eBook();
                e1.Show();

            }
            else if (textBox1.Text == "FIFA")
            {
                this.Hide();
                FIFA f1 = new FIFA();
                f1.Show();

            }
            else
            {
                MessageBox.Show("! Did not find any Proposal.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Investement_history iv = new Investement_history();
            iv.Show();

        }
     
    }
}
