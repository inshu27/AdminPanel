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
    public partial class questionPaper : Form
    {
        public questionPaper()
        {
            InitializeComponent();
        }
        string tableName;
        string path;

        public void getConStr()
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+"\\info.accdb");
            OleDbCommand cmd = new OleDbCommand("SELECT val FROM loc WHERE ID=1", conn);
            conn.Open();
            OleDbDataReader odr = cmd.ExecuteReader();

            while (odr.Read())
            {
                path = odr[0].ToString();
            }
            conn.Close();

            MessageBox.Show(path);

        }

        public void createTablewithqusId()
        {
            try
            {
                tableName = "[" + coursecombo.SelectedItem.ToString() + "-" + id_txtbox.Text.ToString() + "]";

                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\QuestionPaper.accdb";
                conn.Open();

                OleDbCommand cmmd = new OleDbCommand("", conn);
                cmmd.CommandText = "CREATE TABLE " + tableName + "( [qId] Counter Primary Key, [qus] Text, [opt1] Text, [opt2] Text, [opt3] Text, [opt4] Text, [ans] Text, [totalqus] Text, [eachqusMarks] Text, [time] Text)";
                if (conn.State == ConnectionState.Open)
                {
                    try
                    {
                        cmmd.ExecuteNonQuery();
                        MessageBox.Show("Question Paper Id" + tableName + " is Generated.");
                       
                        conn.Close();
                        visibleoff();
                        papertiming();
                        visibleon();
                        combofillwithAns();
                        textBox1.Text = "1".ToString();
                    }
                    catch (OleDbException expe)
                    {
                        MessageBox.Show(expe.Message);
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            catch (Exception q)
            {
                MessageBox.Show(q.Message);
            }
        }

        public void combofillwithAns()
        {
            ans_combo.Items.Add("A");
            ans_combo.Items.Add("B");
            ans_combo.Items.Add("C");
            ans_combo.Items.Add("D");


        }
        public void visibleoff()
        {
            qId_lbl.Visible = false;
            coursecombo.Visible = false;
            id_txtbox.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            marks_txt.Visible = false;
            totalqus_txt.Visible = false;
            time_txt.Visible = false;
            gen_pprbtn.Visible = false;
        }

        public void visibleon()
        {
            id_showlbl.Visible = true;
            id_showlbl.Text = tableName;
            qusEntry_lbl.Visible = true;
            qno_lbl.Visible = true;
            qus_lbl.Visible = true;
            optA_lbl.Visible = true;
            optB_lbl.Visible = true;
            optC_lbl.Visible = true;
            optD_lbl.Visible = true;
            ans_lbl.Visible = true;
            textBox1.Visible = true;
            richTextBox1.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            ans_combo.Visible = true;
            Savequs_btn.Visible = true;
        }

        public void papertiming()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into PaperTiming ([ID],[Noofqus],[eachQusmarks],[time]) values ('" + tableName + "','" + this.totalqus_txt.Text + "','" + this.marks_txt.Text + "','" + this.time_txt.Text + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    MessageBox.Show("Total Qus , Marks ans Time is Saved");
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }


        }

        public void maxQId()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select max(qId)+1 from "+tableName, sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    textBox1.Text = myReader[0].ToString();
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }

        public void courseadd()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\online_exam.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("select Course from CourseDetail", sqc);
                OleDbDataReader myReader;
                sqc.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    coursecombo.Items.Add(myReader[0].ToString());
                }
                sqc.Close();
            }
            catch (Exception)
            {

            }
        }
        public void validationID()
        {
            if (coursecombo.Text=="Select Course")
            {
                MessageBox.Show("Enter Select Course Name");
                coursecombo.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(id_txtbox.Text))
            {
                MessageBox.Show("Enter Paper Id");
                id_txtbox.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(totalqus_txt.Text))
            {
                MessageBox.Show("Enter Total Question");
                totalqus_txt.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(marks_txt.Text))
            {
                MessageBox.Show("Enter Each Question Marks");
                marks_txt.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(time_txt.Text))
            {
                MessageBox.Show("Enter Time Of Exam");
                time_txt.Focus();
                return;
            }
            else
            {
                createTablewithqusId();
               
            }
        }

        public void validationQuestion()
        {

        }

        public void savequs()
        {
            try
            {
                string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\QuestionPaper.accdb";
                OleDbConnection sqc = new OleDbConnection(conn);
                OleDbCommand cmd = new OleDbCommand("insert into " + tableName + " ([qId],[qus],[opt1],[opt2],[opt3],[opt4],[ans]) values ('" + this.textBox1.Text + "','" + this.richTextBox1.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.ans_combo.Text + "')", sqc);

                sqc.Open();

                int a = cmd.ExecuteNonQuery();
                sqc.Close();

                if (a > 0)
                {
                    label5.Text = "Question is Saved.";
                    label5.Text = " ";
                }
            }
            catch
            {

            }
            
        }

        private void questionPaper_Load(object sender, EventArgs e)
        {
            getConStr();
            courseadd();
        }

        private void gen_pprbtn_Click(object sender, EventArgs e)
        {
            validationID();
           
        }

        private void Savequs_btn_Click(object sender, EventArgs e)
        {
            savequs();
            maxQId();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qusEntry_lbl_Click(object sender, EventArgs e)
        {
            savequs();
        }

        private void qno_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void qus_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void optA_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void optB_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void optC_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void optD_lbl_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ans_lbl_Click(object sender, EventArgs e)
        {

        }

        private void ans_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
