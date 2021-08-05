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
    public partial class Form9 : Form
    {
        public Form9()
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
            textBox1.Enabled = false;
            try
            {
                string s = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 
                           C:\Users\usman\Documents\project_database2.mdb; Persist Security Info = False";
                OleDbConnection conn = new OleDbConnection(s);
                conn.Open();
                Console.WriteLine("Connection Successfully Build!");
                string query = "SELECT USERNAME from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox1.Text = "USERNAME FOUND";
                }
                else
                {
                    textBox1.Text = "INVALID USERNAME";
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
                string query = "DELETE * from bank_data where USERNAME = '" + textBox6.Text + "'";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("ACCOUNT HAS BEEN DEACTIVATED");
                textBox1.Text = String.Empty;
                textBox6.Text = String.Empty;
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
                conn.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
