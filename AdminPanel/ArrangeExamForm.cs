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
    public partial class ArrangeExamForm : Form
    {
        public ArrangeExamForm()
        {
            InitializeComponent();
        }
        string name;
        private void ArrangeExamForm_Load(object sender, EventArgs e)
        {
            getallIdstu();
            addtable();
        }

        public void getallIdstu()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\online_exam.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select RegId from Studentdetail", sqc);

            OleDbDataReader myReader;
            sqc.Open();
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                comboBox1.Items.Add(myReader[0].ToString());

            }
            sqc.Close();
        }

        public void getstuNameintxt()
        {
            try
            {
                name = comboBox1.SelectedItem.ToString();
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select Name from Studentdetail WHERE RegId = '" + name + "'", sqc);
               
                
                sqc.Open();
               OleDbDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    arg_name_txt.Text = odr[0].ToString();

                }
                sqc.Close();
            }
            catch (Exception ef)
            {
                MessageBox.Show(ef.Message);
            }
        }

        int i;
        public void addtable()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\QuestionPaper.accdb";
            OleDbConnection connection = new OleDbConnection(conn);
            connection.Open();
            System.Data.DataTable dt = null;
            dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in dt.Rows)
            {
                string strSheetTableName = row["TABLE_NAME"].ToString();
                if (row["TABLE_TYPE"].ToString() == "TABLE")

                    comboBox2.Items.Add(strSheetTableName);

                i++;
            }
        }

        public void arrangeExam()
        {
            
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into arrangeExam ([stuId],[name],[qusPapercode],[date]) values ('" + comboBox1.Text + "','" + this.arg_name_txt.Text + "','" + comboBox2.Text + "','" + this.dateTimePicker1.Text + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    MessageBox.Show("Exam is Arranged");
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message);
            }  
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getstuNameintxt();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void arng_btn_Click(object sender, EventArgs e)
        {
            arrangeExam();
        }
    }
}
