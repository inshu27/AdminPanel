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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int tm = 0;
        public void imagegif()
        {
            Image img = Image.FromFile("C:/Users/inshu/Downloads/sand.gif");
            pictureBox1.Image=img;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity = this.Opacity + 0.05;

            if (this.Opacity >= 1)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tm = tm + 1;
            
            if (tm == 1)
            {
                label1.Text = "loading Skins.";

               
            }

            if (tm == 12)
            {
                label1.Text = "Creating Windows..";
              
            }

            if (tm == 25)
            {
                label1.Text = "Connecting to database...";
               
            }

            if (tm == 47)
            {
                label1.Text = "Analysing....";
               
            }

            if (tm == 72)
            {
                label1.Text = "Starting Services.....";
               
            }

            if (tm == 100)
            {
                label1.Text = "Load Completed!";
               

                timer2.Enabled = false;
                this.Hide();
                open_new();

            }

            

        }
        public void open_new()
        {
            AdminControl a2 = new AdminControl();
            a2.ShowDialog();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            imagegif();
        }
    }
}
