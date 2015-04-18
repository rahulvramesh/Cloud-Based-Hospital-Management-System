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
    public partial class import_lab_1 : Form
    {
        private string id;
        private string type;

        public import_lab_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            type = comboBox1.Text;
            if (type == "Scan Report")
            {
                Import_Scan_Report scan = new Import_Scan_Report(id);
                scan.Show();
                this.Close();

            }
            else
            {
                import_lab_report lab = new import_lab_report(id);
                lab.Show();
                this.Close();
            }


        }

        private void import_lab_1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = comboBox2.Text;

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "CSharpSample.exe"
                }
            };
            process.Start();
            process.WaitForExit();

            StreamReader readtext = new StreamReader(@"out\out.txt");
            string readmetext = readtext.ReadLine();

            Cloud_Database_FTP cb = new Cloud_Database_FTP();

            string[] data = new string[20];

            data = cb.getPatientDetailsByFID(readmetext);
            id = data[0];

            readtext.Close();

            if (type == "Scan Report")
            {
                Import_Scan_Report scan = new Import_Scan_Report(id);
                scan.Show();
                this.Close();

            }
            else
            {
                import_lab_report lab = new import_lab_report(id);
                //MessageBox.Show(id + " ");
                lab.Show();
                this.Close();
            }

        }
    }
}
