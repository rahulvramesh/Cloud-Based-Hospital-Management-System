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
    public partial class Form1 : Form
    {

        public String username;
        public String password;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Database db = new Database();
            //db.OpenConnection();
            this.username = textBox1.Text;
            this.password = textBox2.Text;
            int code = db.checkLogin(username, password);

            if (code == 1)
            {
                Form2 frm = new Form2();
                this.Hide();
                frm.Show();
            }
            else
                MessageBox.Show("Wrong Username / Password.");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
