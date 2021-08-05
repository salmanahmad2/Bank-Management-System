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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            comboBox1.Text = String.Empty;
            dateTimePicker1.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
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
                string query = "INSERT INTO bank_data(NAME,AGE,GENDER,DOB,EMAIL,USERNAME,PASS,AMOUNT) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "', '" + comboBox1.Text + "' , '" + dateTimePicker1.Text + "' , '" + textBox5.Text + "' , '" + textBox6.Text + "' , '" + textBox7.Text + "' , 0)";
                string query1 = "Select USERNAME from bank_data";

                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader readerr = cmd.ExecuteReader();
                OleDbCommand cmd1 = new OleDbCommand(query1, conn);
                OleDbDataReader reader = cmd1.ExecuteReader();
                if (textBox1.Text == String.Empty)
                {
                    MessageBox.Show("Enter Name");
                }
                else if (textBox2.Text == String.Empty)
                {
                    MessageBox.Show("Enter Age");
                }
                else if (comboBox1.Text == String.Empty)
                {
                    MessageBox.Show("Enter Gender");
                }
                else if (dateTimePicker1.Text == String.Empty)
                {
                    MessageBox.Show("Enter Date of Birth");
                }
                else if (textBox5.Text == String.Empty)
                {
                    MessageBox.Show("Enter Email");
                }
                else if (textBox6.Text == String.Empty)
                {
                    MessageBox.Show("Enter Username");
                }
                else if (textBox7.Text == String.Empty)
                {
                    MessageBox.Show("Enter Password");
                }
                else if (textBox7.Text != textBox8.Text)
                {
                    MessageBox.Show("Password Doesn't Match");
                    textBox7.Text = String.Empty;
                     textBox8.Text = String.Empty;
                }
                else if (Convert.ToInt32(textBox2.Text) < 15)
                {
                    MessageBox.Show("Your age doesn't require the current standard \nAbove 15!!!");
                }    
                else if (reader.Read())
                {
                        MessageBox.Show("Account Successfully Created");
                        Form1 obj = new Form1();
                        obj.Show();
                        this.Hide();
                        conn.Close();
                }
                
                
            }
            catch (Exception)
            {
                
                MessageBox.Show("USERNAME ALREADY TAKEN");
                textBox6.Text = String.Empty;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

