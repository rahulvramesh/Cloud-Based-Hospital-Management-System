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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users a = new Users();
            a.addUser();
        }

        private void patientFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            getuserdetails P_ID = new getuserdetails();
            P_ID.Show();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void addDrAppoinmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getuserdetails P_ID = new getuserdetails();
            P_ID.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact ct = new Contact();
            ct.Show();
        }

        private void newAppoinmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getuserdetails P_ID = new getuserdetails();
            P_ID.Show();
        }

        private void createBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            craeteBill_frm bill = new craeteBill_frm();

            bill.Show();
        }

        private void importLabReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            import_lab_1 fm = new import_lab_1();
            fm.Show();
            
        }

        private void viewAppoinmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            selectDoctor dr = new selectDoctor();
            dr.Show();

        }

        private void importScanReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            import_lab_1 fm = new import_lab_1();
            fm.Show();

        }

        private void viewReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_view_record_scan fm = new frm_view_record_scan();
            fm.Show();
        }

       

     
       

       
    }
}
