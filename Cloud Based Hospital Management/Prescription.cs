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

   
    public partial class Prescription : Form
    {
        string p_name;
        string u_id;
        string id;
        string dr;
        string d_id;

        public Prescription(string name,string id,string dr,string uid)
        {
            string[] doc = new string[] { "Dr. Aamod Rao", "Dr. Sanjay Borude", "Dr. Ramneek Mahajan", "Dr. Ashim Desai", "Dr. Pranay R. Shah", "Dr. Lalit Panchal" };
            InitializeComponent();
            this.p_name = name;

            this.id = doc[int.Parse(id)];
            this.dr = dr;
            this.d_id = id;
            this.u_id = uid;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Prescription_Load(object sender, EventArgs e)
        {
            textBox1.Text = p_name;
            textBox2.Text = dr;
            textBox3.Text = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = new string[10];

            data[0] = this.u_id;
            data[1] = this.d_id;
            data[2] = textBox2.Text;
            data[3] = textBox5.Text;
            data[4] = textBox6.Text;
            data[5] = textBox4.Text;

            Cloud_Database_FTP db = new Cloud_Database_FTP();
            if (db.storePreToCloud(data) > 0)
            {
                MessageBox.Show("Data Stored");
            }


        }
    }
}
