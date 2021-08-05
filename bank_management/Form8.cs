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
    public partial class Form8 : Form
    {
        public Form8()
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

        private void Form8_Load(object sender, EventArgs e)
        {

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
                string slctuser = "SELECT USERNAME , PASS from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd = new OleDbCommand(slctuser, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("USER FOUND");
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
                string slctuser = "SELECT USERNAME , PASS from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd = new OleDbCommand(slctuser, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string updtuser = "UPDATE bank_data set USERNAME='" + textBox1.Text + "' where USERNAME = '" + textBox6.Text + "'";
                    OleDbCommand cmd1 = new OleDbCommand(updtuser, conn);
                    OleDbDataReader sr = cmd1.ExecuteReader();
                    string updtpass = "UPDATE bank_data set PASS='" + textBox2.Text + "' where USERNAME = '" + textBox6.Text + "'";
                    OleDbCommand cmd2 = new OleDbCommand(updtpass, conn);
                    OleDbDataReader ar = cmd2.ExecuteReader();
                    MessageBox.Show("USER AND PASSWORD SUCCESSFULLY UPDATED");
                    textBox6.Text = String.Empty;
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;

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
    }
}
