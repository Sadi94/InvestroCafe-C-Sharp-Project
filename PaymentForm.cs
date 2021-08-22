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

    public partial class PaymentForm : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public static string propName;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && (radioButton1.Checked == true || radioButton2.Checked == true)) 
            {

                propName = textBox3.Text;
                if (propName == "COD")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "insert into COD values(@Name, @NID, @ADDRES, @ACCOUNT_NO, @AMOUNT)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", HomePage.user);
                    cmd.Parameters.AddWithValue("@NID", HomePage.nid);
                    cmd.Parameters.AddWithValue("@ADDRES", HomePage.address);
                    cmd.Parameters.AddWithValue("@ACCOUNT_NO", HomePage.bankacc);
                    cmd.Parameters.AddWithValue("@AMOUNT", textBox1.Text);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Payment Successfully");

                        con.Close();


                        if (HomePage.user == "sadi")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into sadi values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Ibrahim")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Ibrahim values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Shariful")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Shariful values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();



                        }
                    }
                    else
                    {
                        MessageBox.Show("Payment Unsuccessful");
                        this.Hide();
                        Investor ip = new Investor();
                        ip.Show();

                    }
                    con.Close();





                }
                else if (propName == "EBOOK")
                {
                    SqlConnection con1 = new SqlConnection(cs);
                    string query1 = "insert into EBOOK values(@Name, @NID, @ADDRES, @ACCOUNT_NO, @AMOUNT)";
                    SqlCommand cmd2 = new SqlCommand(query1, con1);
                    cmd2.Parameters.AddWithValue("@Name", HomePage.user);
                    cmd2.Parameters.AddWithValue("@NID", HomePage.nid);
                    cmd2.Parameters.AddWithValue("@ADDRES", HomePage.address);
                    cmd2.Parameters.AddWithValue("@ACCOUNT_NO", HomePage.bankacc);
                    cmd2.Parameters.AddWithValue("@AMOUNT", textBox1.Text);

                    con1.Open();
                    int a1 = cmd2.ExecuteNonQuery();
                    if (a1 > 0)
                    {
                        MessageBox.Show("Payment Successfully");
                        con1.Close();

                        if (HomePage.user == "sadi")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into sadi values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Ibrahim")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Ibrahim values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Shariful")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Shariful values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Payment Unsuccessful");
                    }
                    con1.Close();





                }
                else if (propName == "FIFA")
                {
                    SqlConnection con3 = new SqlConnection(cs);
                    string Query3 = "insert into FIFA values(@Name, @NID, @ADDRES, @ACCOUNT_NO, @AMOUNT)";
                    SqlCommand cmd3 = new SqlCommand(Query3, con3);
                    cmd3.Parameters.AddWithValue("@Name", HomePage.user);
                    cmd3.Parameters.AddWithValue("@NID", HomePage.nid);
                    cmd3.Parameters.AddWithValue("@ADDRES", HomePage.address);
                    cmd3.Parameters.AddWithValue("@ACCOUNT_NO", HomePage.bankacc);
                    cmd3.Parameters.AddWithValue("@AMOUNT", textBox1.Text);

                    con3.Open();
                    int a3 = cmd3.ExecuteNonQuery();
                    if (a3 > 0)
                    {
                        MessageBox.Show("Payment Successfully");
                        con3.Close();





                        if (HomePage.user == "sadi")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into sadi values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Ibrahim")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Ibrahim values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();
                        }
                        else if (HomePage.user == "Shariful")
                        {
                            SqlConnection conn = new SqlConnection(cs);
                            string Query = "insert into Shariful values(@pTitle, @AMOUNT)";
                            SqlCommand cmd1 = new SqlCommand(Query, conn);

                            cmd1.Parameters.AddWithValue("@pTitle", propName);
                            cmd1.Parameters.AddWithValue("@AMOUNT", textBox1.Text);
                            conn.Open();
                            int aa = cmd1.ExecuteNonQuery();
                            if (aa > 0)
                            {
                                MessageBox.Show("Data Saved");

                            }
                            else
                            {
                                MessageBox.Show("Data is not Saved");
                            }
                            conn.Close();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Payment Unsuccessful");
                    }
                    con3.Close();



                }
                else
                {
                    MessageBox.Show("Please Enter Proposal name Correctly");

                }
            }
            else
            {
                MessageBox.Show("Please select any payment method or Enter amount for the payment !");
            }


        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Investor p1 = new Investor();
            p1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}

