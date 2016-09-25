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
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void courseadd()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select Course from CourseDetail", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    listBox1.Items.Add(myReader[0].ToString());  
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }
        public void delCourse()
        {

            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("delete from CourseDetail where Course=" + this.listBox1.SelectedItem.ToString(), sqc);

            sqc.Open();

            
            sqc.Close();
           
          
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            courseadd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delCourse();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
    }
}
