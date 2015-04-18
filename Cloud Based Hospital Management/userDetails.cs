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
    public partial class userDetails : Form
    {

        public string id;
        public string name;

        public userDetails(string[] list)
        {
            InitializeComponent();
            txt_firstname.Text = list[1];
            txt_secondname.Text =  list[2];
            txt_sex.Text =  list[3];
            textBox1.Text =  list[4];
            textBox2.Text = list[5];
            textBox3.Text = list[6];
            textBox4.Text = list[7];
            textBox5.Text = list[8];
            textBox6.Text = list[9];
            textBox7.Text = list[13];

            id = list[0];
            name = list[1]+ " " +list[2];

            //txt_date.Text  = list[12].ToString();

            /*
             * list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["fname"] + "");
                    list[2].Add(dataReader["lname"] + "");
                    list[3].Add(dataReader["sex"] + "");
                    list[4].Add(dataReader["phone"] + "");
                    list[5].Add(dataReader["email"] + "");
                    list[6].Add(dataReader["address"] + "");
                    list[7].Add(dataReader["city"] + "");
                    list[8].Add(dataReader["state"] + "");
                    list[9].Add(dataReader["zip"] + "");
                    list[10].Add(dataReader["note"] + "");
                    list[11].Add(dataReader["pic"] + "");
                    list[12].Add(dataReader["date"] + "");
                    list[13].Add(dataReader["dob"] + "");*/

            pictureBox1.ImageLocation = "http://localhost:8587/"+list[11];

        }

        private void userDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addAppoinment fm = new addAppoinment(id,name);
            fm.Show();
            this.Close();


        }
    }
}
