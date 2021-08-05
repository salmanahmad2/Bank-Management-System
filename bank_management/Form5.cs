using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_sem5_bank_management
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            try
            {
                string s = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 
                           C:\Users\usman\Documents\project_database2.mdb; Persist Security Info = False";
                OleDbConnection conn = new OleDbConnection(s);
                conn.Open();
                Console.WriteLine("Connection Successfully Build!");
                string query = "SELECT USERNAME , AMOUNT from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = reader["AMOUNT"].ToString();
                }
                else
                {
                    MessageBox.Show("INVALID USERNAME");
                    textBox6.Text = String.Empty;
                }
                conn.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string s = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 
                           C:\Users\usman\Documents\project_database2.mdb; Persist Security Info = False";
                OleDbConnection conn = new OleDbConnection(s);
                conn.Open();
                Console.WriteLine("Connection Successfully Build!");
                int a = Convert.ToInt32(textBox2.Text);
                int b = Convert.ToInt32(textBox1.Text);
                int c = b - a;
                string query = "UPDATE bank_data set AMOUNT='" + c.ToString() + "' where USERNAME = '" + textBox6.Text + "'";
                string query1 = "Select AMOUNT from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd1 = new OleDbCommand(query1, conn);
                OleDbDataReader readerr = cmd1.ExecuteReader();
                if (b >= a)
                {
                    if (Convert.ToInt32(readerr["AMOUNT"]) < 0)
                    {
                        MessageBox.Show("Can't Withdraw Money");
                        textBox2.Text = String.Empty;
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        MessageBox.Show("Withdraw Sucessfull");
                        textBox2.Text = String.Empty;
                        textBox6.Text = String.Empty;
                        textBox1.Text = String.Empty;
                    }
                }
                else if (b==0)
                {
                    MessageBox.Show("Insufficient Balance");
                    textBox2.Text = String.Empty;
                }
                else 
                {
                    MessageBox.Show("Can't Withdraw Money");
                    textBox2.Text = String.Empty;
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (textBox6.Text == String.Empty)
                {
                    MessageBox.Show("Enter Username");
                }
                else
                {
                    MessageBox.Show("Enter Amount");
                }
            }
        }
    }
}

