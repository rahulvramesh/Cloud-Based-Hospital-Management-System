using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Cloud_Based_Hospital_Management
{
    public partial class frm_view_record_scan : Form
    {
        public frm_view_record_scan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string type = comboBox2.Text;
            int r_type;



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
            string name;
            name = readmetext;
            readtext.Close();

            Cloud_Database_FTP cb = new Cloud_Database_FTP();

            string[] data = new string[20];



            data = cb.getPatientDetailsByFID(name);

            if (type == "Scan Report")
            {
                r_type = 1;
            }
            else
            {
                r_type = 0;
            }

            frm_view_report fm = new frm_view_report(r_type, int.Parse(data[0]));
            fm.Show();


            // MessageBox.Show(list + " ");

           // userDetails ud = new userDetails(data);
            //ud.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cloud_Database_FTP cb = new Cloud_Database_FTP();

            string[] data = new string[20];

            String id = textBox1.Text;

            data = cb.getPatientDetails(id);



            // MessageBox.Show(list + " ");

            //userDetails ud = new userDetails(data);

            this.Hide();

            //ud.Show();
        }
    }
}
