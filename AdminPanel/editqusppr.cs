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
    public partial class editqusppr : Form
    {
        public editqusppr()
        {
            InitializeComponent();
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

        public void showStudentdetail()
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\QuestionPaper.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("select * from " + comboBox2.SelectedItem.ToString(), sqc);
            try
            {
                OleDbDataAdapter sdr = new OleDbDataAdapter();
                sdr.SelectCommand = cmd;
                DataTable dbdataset = new DataTable();
                sdr.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                sdr.Update(dbdataset);
                visibleOn();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }

        }
        public void visibleOn()
        {
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            textBox1.Visible = true;
            richTextBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            comboBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
        }

        private void editqusppr_Load(object sender, EventArgs e)
        {
            addtable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showStudentdetail();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["qId"].Value.ToString();
                richTextBox1.Text = row.Cells["qus"].Value.ToString();
                textBox3.Text = row.Cells["opt1"].Value.ToString();
                textBox4.Text = row.Cells["opt2"].Value.ToString();
                textBox5.Text = row.Cells["opt3"].Value.ToString();
                textBox6.Text = row.Cells["opt4"].Value.ToString();
                comboBox1.Text = row.Cells["ans"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\QuestionPaper.accdb";
            OleDbConnection sqc = new OleDbConnection(conn);
            OleDbCommand cmd = new OleDbCommand("delete from questionPaper where qId=" + this.textBox1.Text, sqc);

            sqc.Open();

            int c = cmd.ExecuteNonQuery();
            sqc.Close();

            if (c > 0)
            {
                MessageBox.Show("Question is Deleted.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\inshu\Documents\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("update questionPaper set [qId]='" + this.textBox1.Text + "',[qus]='" + this.richTextBox1.Text + "',[opt1]='" + this.textBox3.Text + "',[opt2]='" + this.textBox4.Text + "',[opt3]='" + this.textBox5.Text + "',[opt4]='" + this.textBox6.Text + "' ,[ans]='" + this.comboBox1.Text + "' where [qId]='" + textBox1.Text + "'", sqc);

                sqc.Open();

                int b = cmd.ExecuteNonQuery();
                sqc.Close();

                if (b > 0)
                {
                    MessageBox.Show("Question is Updated");
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
