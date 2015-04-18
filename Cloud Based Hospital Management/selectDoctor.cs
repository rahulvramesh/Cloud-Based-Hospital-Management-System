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
    public partial class selectDoctor : Form
    {
        public selectDoctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(comboBox1.SelectedIndex+ " ");

            appo_view_new dr = new appo_view_new(comboBox1.SelectedIndex.ToString());

            dr.Show();

            this.Close();
        }
    }
}
