using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace Project_Login
{
    public partial class RegistrationPage : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
       
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (radioButton2.Checked==true)
            {
                if(textBox1.Text!=""&& textBox2.Text!=""&&textBox3.Text!=""&&textBox4.Text!=""&&textBox5.Text!=""&&textBox6.Text!=""&&textBox7.Text!=""&& textBox8.Text!="")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into INTER_DETAILS values(@name,@user,@pass,@mail,@contract,@nid,@add,@pic,@bid)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name",textBox1.Text);
                    cmd.Parameters.AddWithValue("@user", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@contract", textBox5.Text);
                    cmd.Parameters.AddWithValue("@nid", textBox6.Text);
                    cmd.Parameters.AddWithValue("@add", textBox7.Text);
                    cmd.Parameters.AddWithValue("@pic", savepic());
                      cmd.Parameters.AddWithValue("@bid", textBox8.Text);

                      con.Open();
                      int a = cmd.ExecuteNonQuery();
                      if (a > 0)
                      {
                          MessageBox.Show("Data inserted succsessfully !");
                      }
                      else
                      {
                          MessageBox.Show("Data is not inserted");
                      }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please Fillup all textbox", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (radioButton1.Checked==true)
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into INVEST_DETAILS values(@name,@user,@pass,@mail,@contract,@nid,@add,@pic,@bid)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@user", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@contract", textBox5.Text);
                    cmd.Parameters.AddWithValue("@nid", textBox6.Text);
                    cmd.Parameters.AddWithValue("@add", textBox7.Text);
                    cmd.Parameters.AddWithValue("@pic", savepic());
                    cmd.Parameters.AddWithValue("@bid", textBox8.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a>0)
                    {
                        MessageBox.Show("Data inserted succsessfully !");
                    }
                    else
                    {
                        MessageBox.Show("Data is not inserted");
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Please Fillup all textbox", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if(radioButton3.Checked==true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into ADMIN_DETAILS values(@name,@user,@pass,@mail,@contract,@nid,@add,@pic,@bid)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@user", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox3.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox4.Text);
                    cmd.Parameters.AddWithValue("@contract", textBox5.Text);
                    cmd.Parameters.AddWithValue("@nid", textBox6.Text);
                    cmd.Parameters.AddWithValue("@add", textBox7.Text);
                    cmd.Parameters.AddWithValue("@pic", savepic());
                    cmd.Parameters.AddWithValue("@bid", textBox8.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Data inserted succsessfully !");
                    }
                    else
                    {
                        MessageBox.Show("Data is not inserted");
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Please Fillup all textbox", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please Select Admin or Investor or Entereprenur option","Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Hide();
            HomePage hm = new HomePage();
            hm.Show();
        }

        private byte[] savepic()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Files (*.*) | *.*";
          //  ofd.ShowDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

    
    }
}
