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
    public partial class addAppoinment : Form
    {
        public string[] appo = new string[20];
        public addAppoinment(string id, string name)
        {
            InitializeComponent();
            label2.Text = id;
            label4.Text = name;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // billing button needs to be added
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            appo[0] = label2.Text;
            appo[1] = label4.Text;
            appo[2] = dateTimePicker1.Text;
           // appo[3] = comboBox1.Text;
            appo[3] = comboBox1.SelectedIndex.ToString();

            Database db = new Database();
            db.addAppo(appo);



        }

        private void addAppoinment_Load(object sender, EventArgs e)
        {

          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(comboBox1.SelectedIndex + " ");
           
        }
    }
}
