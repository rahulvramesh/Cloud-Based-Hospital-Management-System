using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Neurotec.Biometrics;

namespace Cloud_Based_Hospital_Management
{
    public partial class newUser_frm : Form
    {

        

        private String first_name;
        private String last_name;
        private String sex;
        private String DOB;
        private String Phone;
        private String email;
        private String Address;
        private String city;
        private String sate;
        private String zip;
        private String note;
        private String pat_pic_name;
        private String[] pat_info = new String[20];
        public FileSystemWatcher fwatcher = new FileSystemWatcher();


        public newUser_frm()
        {
            InitializeComponent();
        }

        private void newUser_frm_Load(object sender, EventArgs e)
        {
            //save_record_btn.Enabled = false;

            

        }

        private void save_record_btn_Click(object sender, EventArgs e)
        {
            pat_info[0] = txt_firstname.Text;
            pat_info[1] = last_name = txt_secondname.Text;
            pat_info[2] = sex = txt_sex.Text;
            pat_info[3] = Phone = textBox1.Text;
            pat_info[4] = email = textBox2.Text;
            pat_info[5] = Address = textBox3.Text;
            pat_info[6] = city = textBox4.Text;
            pat_info[7] = sate = textBox5.Text;
            pat_info[8] = zip = textBox6.Text;
            pat_info[9] = note = textBox7.Text;
            pat_info[12] = txt_date.Text;

            //MessageBox.Show(pat_info[11]);

            int abc;
            Cloud_Database_FTP cb = new Cloud_Database_FTP();
            abc = cb.storeToCloud(pat_info, 20);

           
                MessageBox.Show("Details Stored To Cloud , Please Note User Id : "+abc);
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            //dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(dlg.FileName);
            }

            pat_info[10] = dlg.FileName;
            pat_info[11] = Path.GetFileName(dlg.FileName);
            //MessageBox.Show(pat_pic_name);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //


            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "CSharpSample.exe"
                }
            };
            process.Start();
            process.WaitForExit();

            StreamReader readtext = new StreamReader(@"in\in.txt");
            string readmetext = readtext.ReadLine();

            pat_info[19] = readmetext;
           
            readtext.Close();

            MessageBox.Show("Fingerprint Added");
            this.TopMost = true;

         




        }
        private void Changed(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show(e.FullPath.ToString() + " is changed!");
           // fwatcher.EnableRaisingEvents = t;
           
             
        }

        
           
        
    }
}
