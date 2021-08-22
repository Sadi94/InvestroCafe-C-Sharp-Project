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
    public partial class AllProposal : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public int PICTURE { get; private set; }

        public AllProposal()
        {
            InitializeComponent();
            BindGridView();
        }

        
        void BindGridView()
        {
            //Connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM All_Proposal";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            //dataGridView Details
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

            dataGridView1.RowTemplate.Height = 100;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.Show();

        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);

           
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && richTextBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into ACCEPTED_PRO values(@Title,@Nid,@Address,@AcNo,@des,@pic)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", textBox1.Text);
                cmd.Parameters.AddWithValue("@Nid", textBox2.Text);
                cmd.Parameters.AddWithValue("@Address", textBox3.Text);
                cmd.Parameters.AddWithValue("@AcNo", textBox4.Text);
                cmd.Parameters.AddWithValue("@des", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@pic", savepic());
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Proposal Accepted succsessfully !");
                    BindGridView();
                }
                else
                {
                    MessageBox.Show("Proposal is not Accepted");
                }

              
                con.Close();
                

            }
            else
            {
                MessageBox.Show("Please !Double click an specific row ","Failed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

            private byte[] savepic()
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                return ms.GetBuffer();

            }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "DELETE FROM All_Proposal WHERE Title=@Title";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nid", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox3.Text);
            cmd.Parameters.AddWithValue("@AcNo", textBox4.Text);
            cmd.Parameters.AddWithValue("@des", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@pic", savepic());
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Proposal Deleted succsessfully !");
                BindGridView();
                ResetEveryThing();
            }
            else
            {
                MessageBox.Show("Proposal is not Deleted");
            }


            con.Close();

        }

        private void ResetEveryThing()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = Properties.Resources.photoframe1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetEveryThing();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Admin ad = new Admin();
            ad.Show();
        }
    }
}
