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
    public partial class StudentReg : Form
    {
        public StudentReg()
        {
            InitializeComponent();
        }
        int reg;
        int Year, Month, Day;
        int birthYear;
        int diffAge;
        string courses1 = "";
        public void regId()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select max(ID)+1 from Studentdetail", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    reg= Convert.ToInt32(myReader[0].ToString());
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }

        }
        public void displayregId()
        {
            reg_txt.Text = "R" + Year.ToString() + Month.ToString() + Day.ToString() + reg.ToString();

        }

        public void showCoursecomb()
        {

            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select Course from CourseDetail", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    courseCombo.Items.Add(myReader[0].ToString());
                }
                sqc.Close();

        }

        public void datefix()
        {
            Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            Month = Convert.ToInt32(DateTime.Now.Month.ToString());
            Day = Convert.ToInt32(DateTime.Now.Day.ToString());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateFields();
        }

        public void afterregclear()
        {
            reg_txt.Clear();
            name_txt.Clear();
            parent_txt.Clear();
            dateTimePicker1.Text = DateTime.Now.ToString();
            age_txt.Clear();
            


        }

        public void calcAge()
        {
            Year = Convert.ToInt32(DateTime.Now.Year.ToString());
            birthYear = Convert.ToInt32(dateTimePicker1.Value.Year.ToString());
            diffAge = Year - birthYear;
            age_txt.Text = diffAge.ToString();
        }

        public void ValidateFields()
        {
            if (string.IsNullOrEmpty(name_txt.Text))
            {
                MessageBox.Show("Please type Student Name");
                name_txt.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(parent_txt.Text))
            {
                MessageBox.Show("Please type Guardian Name");
                parent_txt.Focus();
                return;
            }
            else
            {
                insertDetail();
            }

        }
        public void insertDetail()
        {

            for (int x = 0; x <= listBox1.Items.Count - 1; x++)
            {
                courses1 = courses1 + listBox1.Items[x].ToString() + " | ";
            }

            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into Studentdetail ([RegId],[Name],[ParentName],[dateOfBirth],[Age],[Course]) values ('" + this.reg_txt.Text + "','" + this.name_txt.Text + "','" +this.mrmrs_combo.Text+ this.parent_txt.Text + "','" + this.dateTimePicker1.Text + "','" + this.age_txt.Text + "','" + courses1 + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    MessageBox.Show("Student is Registered.");
                }
            }
            catch (Exception)
            {

            }

        }
        private void StudentReg_Load(object sender, EventArgs e)
        {
            regId();
            datefix();
            displayregId();
            mrmrs_combo.Items.Add("Mr.").ToString();
            mrmrs_combo.Items.Add("Mrs.").ToString();
            showCoursecomb();
            listBox1.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calcAge();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            int flg = 0;
            for (int x = 0; x <= listBox1.Items.Count - 1; x++)
            {
                if (courseCombo.Text == listBox1.Items[x].ToString())
                {
                    flg = 1;
                }
            }
            if (flg == 0)
            {
                listBox1.Items.Add(courseCombo.Text);
            }
        }
    }
}
