using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class Adminrights : Form
    {
        public Adminrights()
        {
            InitializeComponent();
        }
        StudentReg sr;
        CourseForm c2;
        questionPaper q2;
        ArrangeExamForm a2;
        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (c2 == null)
            {
                c2 = new CourseForm();
                c2.MdiParent = this;
                c2.Show();
            }
            else
            {
                c2.Focus();
            }
            c2.FormClosing += c2_FormClosing;
        }

        void c2_FormClosing(object sender, FormClosingEventArgs e)
        {
            c2 = null;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sr == null)
            {
                sr = new StudentReg();
                sr.MdiParent = this;
                sr.Show();
            }
            else
            {
                sr.Focus();
            }

            sr.FormClosing += sr_FormClosing;
        }

        void sr_FormClosing(object sender, FormClosingEventArgs e)
        {
            sr = null;
        }

        private void questionPaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (q2 == null)
            {
                q2 = new questionPaper();
                q2.MdiParent = this;
                q2.Show();
            }
            else
            {
                q2.Focus();
            }
            q2.FormClosing += q2_FormClosing;
        }

        void q2_FormClosing(object sender, FormClosingEventArgs e)
        {
            q2 = null;
        }

        private void arrangeExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (a2 == null)
            {
                a2 = new ArrangeExamForm();
                a2.MdiParent = this;
                a2.Show();
            }
            else
            {
                a2.Focus();
            }
            a2.FormClosing += a2_FormClosing;
        }

        void a2_FormClosing(object sender, FormClosingEventArgs e)
        {
            a2 = null;
        }
        
        
    }
}
