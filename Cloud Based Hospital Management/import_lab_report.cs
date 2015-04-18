using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Cloud_Based_Hospital_Management
{
    public partial class import_lab_report : Form
    {
        private string id;
        private string filename;
        private string filepath;

        public import_lab_report(string p_id)
        {
            InitializeComponent();
            id = p_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Import PDF File";
            dlg.Filter = "PDF files (*.pdf)|*.pdf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                // pat_info[10] = dlg.FileName;
                //pat_info[11] = Path.GetFileName(dlg.FileName);

                filename = Path.GetFileName(dlg.FileName);
                filepath = dlg.FileName;

                textBox2.Text = filename;

                button2.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void import_lab_report_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] data = new string[10];

            data[0] = this.id;
            data[1] = textBox1.Text;
            data[2] = dateTimePicker1.Text;
            data[3] = this.filename;
            data[4] = this.filepath;
            data[5] = "0";

            Cloud_Database_FTP fm = new Cloud_Database_FTP();
            if (fm.storeReport2Cloud(data) > 0)
            {
                MessageBox.Show("Report Stored");
            }



         }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
