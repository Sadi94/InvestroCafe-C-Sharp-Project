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
    public partial class Add_Proposal : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Add_Proposal()
        {
            InitializeComponent();
        }

        Entrepreneur entrepreneur;
        // HomePage hm;

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "INSERT INTO All_Proposal VALUES(@title,@nid,@location,@amount,@dec,@img)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@title", textBox1.Text);
            cmd.Parameters.AddWithValue("@dec", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@img", savepic());
            cmd.Parameters.AddWithValue("@nid", textBox4.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@amount", textBox3.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Insert successfully.");
                BindGridView();

            }
            else
            {

                MessageBox.Show("Invalid insert. ");
            }
            con.Close();

        }

        private void BindGridView()
        {
            //connection
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM All_Proposal";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
        }

        private object savepic()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Files *.* | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Entrepreneur ed = new Entrepreneur();
            ed.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            //   textBox4.Clear();
            // textBox5.Clear();
            pictureBox1.Image = Properties.Resources.default_image;
        }
    }
}
