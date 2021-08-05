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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
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
                textBox3.Enabled = false;
                if (reader.Read())
                {
                    textBox3.Text = reader["AMOUNT"].ToString();
                    
                    if (Convert.ToInt32(textBox3.Text) == 0)
                    {
                        MessageBox.Show("You Cannot Transfer Null AMOUNT\nPlease Deposit Some Amount in your Account");
                    }
                    else if (Convert.ToInt32(textBox3.Text) < Convert.ToInt32(textBox1.Text))
                    {
                        MessageBox.Show("You Do not have Sufficient Balance to Transfer");
                        textBox1.Text = String.Empty;
                    }
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string s = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 
                           C:\Users\usman\Documents\project_database2.mdb; Persist Security Info = False";
                OleDbConnection conn = new OleDbConnection(s);
                conn.Open();
                Console.WriteLine("Connection Successfully Build!"); 
                string finduser = "SELECT USERNAME , AMOUNT from bank_data where USERNAME = '" + textBox2.Text + "'";
                OleDbCommand cmd = new OleDbCommand(finduser, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int a = Convert.ToInt32(textBox3.Text);
                    int b = Convert.ToInt32(textBox1.Text);
                    int c = a - b;
                    string sub = "UPDATE bank_data set AMOUNT='" + c.ToString() + "' where USERNAME = '" + textBox6.Text + "'";
                    OleDbCommand cmd1 = new OleDbCommand(sub, conn);
                    OleDbDataReader sr = cmd1.ExecuteReader();
                    int x = Convert.ToInt32(textBox1.Text);
                    int y = Convert.ToInt32(reader["AMOUNT"]);
                    int z = x + y;
                    string add = "UPDATE bank_data set AMOUNT='" + z.ToString() + "' where USERNAME = '" + textBox2.Text + "'";
                    OleDbCommand cmd2 = new OleDbCommand(add, conn);
                    OleDbDataReader ar = cmd2.ExecuteReader();
                    MessageBox.Show("Successfully Transfered");
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                    textBox6.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("INVALID USERNAME");
                    textBox2.Text = String.Empty;
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
