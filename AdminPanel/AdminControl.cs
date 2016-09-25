using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AdminPanel
{
    public partial class AdminControl : Form
    {
        public AdminControl()
        {
            InitializeComponent();
        }

        public void checkAdmin()
        {
            if (string.IsNullOrEmpty(user_txt.Text))
            {
                MessageBox.Show("Please type your Username");
                user_txt.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(pass_txt.Text))
            {
                MessageBox.Show("Please type your Password");
                pass_txt.Focus();
                return;
            }
            else
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select * from admin where ID='" + this.user_txt.Text + "'and pass='" + this.pass_txt.Text + "';", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and password is correct.");
                    this.Hide();
                    Adminrights ar = new Adminrights();
                    ar.Show();

                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate username and password..access denied");
                }
                else
                {
                    MessageBox.Show("Username and password is incorrect.");
                }
                sqc.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkAdmin();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
    }
}
