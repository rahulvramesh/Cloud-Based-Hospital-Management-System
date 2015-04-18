using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Cloud_Based_Hospital_Management
{
    public partial class getuserdetails : Form
    {
        public FileSystemWatcher fwatcher = new FileSystemWatcher();
        public string name;
        public bool found;

        public getuserdetails()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Cloud_Database_FTP cb = new Cloud_Database_FTP();

            string[] data = new string[20]; 

            String id = textBox1.Text;

            data = cb.getPatientDetails(id);

           // MessageBox.Show(list + " ");

           userDetails ud = new userDetails(data);

            this.Hide();

            ud.Show();

            


        }

        private void getuserdetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            //Process.Start("CSharpSample.exe");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "CSharpSample.exe"
                }
            };
            process.Start();
            process.WaitForExit();

            /*fwatcher.Path = @"out\";
            fwatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            fwatcher.Changed += new FileSystemEventHandler(Changed);
            fwatcher.Filter = "*.txt";
            fwatcher.EnableRaisingEvents = true;

           // MessageBox.Show("Test");
            this.Close();*/
            StreamReader readtext = new StreamReader(@"out\out.txt");
            string readmetext = readtext.ReadLine();

            //pat_info[19] = readmetext;
            // MessageBox.Show(readmetext + " is changed!");
            name = readmetext;
            readtext.Close();

            Cloud_Database_FTP cb = new Cloud_Database_FTP();

            string[] data = new string[20];



            data = cb.getPatientDetailsByFID(name);

            // MessageBox.Show(list + " ");

            userDetails ud = new userDetails(data);
            ud.Show();
            this.Close();

            


        }

        private void Changed(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show(e.FullPath.ToString() + " is changed!");
            // fwatcher.EnableRaisingEvents = t;
            
            

            

        }
    }
}
