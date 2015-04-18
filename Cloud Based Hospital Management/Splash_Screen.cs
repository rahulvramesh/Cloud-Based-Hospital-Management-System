using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cloud_Based_Hospital_Management
{
    public partial class Splash_Screen : Form
    {
        Timer timer = new Timer();
        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void Splash_Screen_Load(object sender, EventArgs e)
        {
            
            timer.Interval = 1000;
            timer.Tick += new EventHandler(displayLogin);
            timer.Start();
            
        }

        public void displayLogin(object sender, EventArgs e)
        {
            timer.Stop();

            Form1 fm = new Form1();
            fm.Show();
            this.Hide();

        }

    }
}
