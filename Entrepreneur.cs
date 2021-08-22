using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Project_Login
{

    public partial class Entrepreneur : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public int PICTURE { get; private set; }
        // List<Proposal> proposalList = new List<Proposal>();
        /* public class Proposal
         {
             public string title { get; set; }
             public string nid { get; set; }
             public string address { get; set; }
             public string acc { get; set; }
             public string dec { get; set; }
             public byte img { get; set; }
         }*/


        public HomePage hm;
        public Entrepreneur()
        {
            InitializeComponent();
            BindGridView();
            //    proposalList = new List<Proposal>();
            // Load += new EventHandler(init_Load);
        }

        /* public void updateProposal()
         {
             listBox1.Items.Clear();
             SqlConnection con = new SqlConnection(cs);
             con.Open();
             string query = "SELECT * FROM All_Proposal";
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataReader reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 Proposal proposal = new Proposal()
                 {
                     title = reader["Title"].ToString(),
                     dec = reader["DESCRIPSION"].ToString(),
                     address = reader["ADDRES"].ToString(),
                     //img = Convert.ToByte(reader["PICTURE"])
                 };
                 proposalList.Add(proposal);
             }

             foreach (Proposal proposal in proposalList)
             {
                 listBox1.Items.Add(proposal.title);
             }


         }*/

        /*private void init_Load(object sender, System.EventArgs e)
        {
            updateProposal();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedname = listBox1.SelectedItem.ToString();
            Proposal selectedProposal = new Proposal();
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "SELECT * FROM All_Proposal WHERE title= '" + selectedname + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Proposal proposal = new Proposal()
                {
                    title = reader["Title"].ToString(),
                    dec = reader["DESCRIPSION"].ToString(),
                    address = reader["ADDRES"].ToString(),
                    //img = reader["PICTURE"] 
                };
                selectedProposal = proposal;
            }
            textBox1.Text = selectedProposal.title;
            textBox2.Text = selectedProposal.address;
            textBox3.Text = selectedProposal.dec;

        }*/


        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "DELETE FROM All_Proposal WHERE Title=@Title";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", textBox1.Text);
            // cmd.Parameters.AddWithValue("@Nid", textBox2.Text);
            cmd.Parameters.AddWithValue("@Address", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);
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
            //textBox5.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = Properties.Resources.default_image;
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

            dataGridView1.RowTemplate.Height = 40;
        }

        private object savepic()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }


        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Entreprenur_Details ed = new Entreprenur_Details();
            ed.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Add_Proposal add_Proposal = new Add_Proposal();
            add_Proposal.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();


            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }



            else
            {
                if (textBox1.Text == textBox1.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "UPDATE All_Proposal SET  ADDRES=@add,ACCOUNT_NO=@amount, Title=@title,NID=@nid, DESCRIPSION=@dec WHERE Title=@title";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@add", textBox2.Text);
                    cmd.Parameters.AddWithValue("@dec", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@amount", textBox3.Text);
                    cmd.Parameters.AddWithValue("@nid", textBox4.Text);
                    // cmd.Parameters.AddWithValue("@bac", textBox4.Text);
                    // cmd.Parameters.AddWithValue("@img", savepic());

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("UPDATE SUCCESSFULLY", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("User Not Matched", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    // con.Close();
                }
                else
                {
                    MessageBox.Show("Proposal Not Matched", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            //textBox5.Clear();
            richTextBox1.Clear();
            pictureBox1.Image = Properties.Resources.default_image;
        }

        private void Entrepreneur_Load(object sender, EventArgs e)
        {

        }
    }
}
