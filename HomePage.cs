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

namespace Project_Login
{
    public partial class HomePage : Form
    {
     string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
     public static string user,contract,nid,bankacc,address;
     public static byte[] image;
        public HomePage()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            IntroPage ip = new IntroPage();
            ip.Show();

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the field first!");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the field first!");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////was registration button
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && radioButton1.Checked==true)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from ADMIN_DETAILS where us_name=@name and pass=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        if (dr.GetValue(1).ToString() == textBox1.Text)
                        {
                            if (dr.GetValue(2).ToString() == textBox2.Text)
                            {
                                user = dr.GetValue(1).ToString();
                                contract = dr.GetValue(4).ToString();
                                nid = dr.GetValue(5).ToString();
                                bankacc = dr.GetValue(8).ToString();
                                address = dr.GetValue(6).ToString();
                                image = ((byte[])dr.GetValue(7));

                            }


                            MessageBox.Show("Welcome "+user , "Sucsessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Admin a1 = new Admin();
                            a1.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
       

            else if (textBox1.Text != "" && textBox2.Text != "" && radioButton2.Checked == true)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from INVEST_DETAILS where us_name=@name and pass=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        if (dr.GetValue(1).ToString() == textBox1.Text)
                        {
                            if (dr.GetValue(2).ToString() == textBox2.Text)
                            {
                                user = dr.GetValue(1).ToString();
                                contract = dr.GetValue(4).ToString();
                                nid = dr.GetValue(5).ToString();
                                bankacc = dr.GetValue(8).ToString();
                                address = dr.GetValue(6).ToString();
                                image = ((byte[])dr.GetValue(7));

                            }


                            MessageBox.Show("Welcome " + user, " Sucsessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Investor i = new Investor();
                            i.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
             
            }

            else if (textBox1.Text != "" && textBox2.Text != "" && radioButton3.Checked == true)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from INTER_DETAILS where us_name=@name and pass=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        if (dr.GetValue(1).ToString() == textBox1.Text)
                        {
                            if (dr.GetValue(2).ToString() == textBox2.Text)
                            {
                                user = dr.GetValue(1).ToString();
                                contract = dr.GetValue(4).ToString();
                                nid = dr.GetValue(5).ToString();
                                bankacc = dr.GetValue(8).ToString();
                                address = dr.GetValue(6).ToString();
                                image = ((byte[])dr.GetValue(7));

                            }


                            MessageBox.Show("Welcome "+user ," Sucsessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Entrepreneur e1 = new Entrepreneur();
                            e1.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
               
            }
            else
            {
                MessageBox.Show("Please Fillup Username and Password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        
    }
}
