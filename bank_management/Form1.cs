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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
              string s = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 
                           C:\Users\usman\Documents\project_database2.mdb; Persist Security Info = False";
                OleDbConnection conn = new OleDbConnection(s);
                conn.Open();
                Console.WriteLine("Connection Successfully Build!");
                string query = "SELECT USERNAME , PASS from bank_data where USERNAME = '" + textBox1.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (textBox1.Text == String.Empty)
                {
                    MessageBox.Show("Enter Username");
                }
                else if (textBox2.Text == String.Empty)
                {
                    MessageBox.Show("Enter Password");
                }
                else if(reader.Read())
                {

                    if (textBox1.Text != reader["USERNAME"].ToString())
                    {
                        MessageBox.Show("USERNAME NOT FOUND!! CREATE YOUR ACCOUNT FIRST");

                    }
                    if (textBox1.Text == reader["USERNAME"].ToString())
                    {
                        if (textBox2.Text == reader["PASS"].ToString())
                        {
                            MessageBox.Show("LOGIN SUCCESSFULL");
                            
                            Form3 obj = new Form3();
                            obj.Show();
                            this.Hide();
                            
                        }
                        
                        else
                        {
                            MessageBox.Show("WRONG PASSWORD");
                        }    
                    }
                }
                    conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();

           
        }
    }
}
