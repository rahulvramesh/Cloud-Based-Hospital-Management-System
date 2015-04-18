using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Cloud_Based_Hospital_Management
{
    public partial class frm_view_report : Form
    {
        int type;
        int id;
        public frm_view_report(int r_type,int u_id)
        {
            InitializeComponent();
            type = r_type;
            id = u_id;
        }

        private void frm_view_report_Load(object sender, EventArgs e)
        {
            string[] row = new string[50];
            //MessageBox.Show(type + "t:" + id);
             Cloud_Database_FTP db = new Cloud_Database_FTP();
             MySqlDataReader rd = db.getReports(id, type);

             while (rd.Read())
             {
                 //MessageBox.Show(rd["r_id"].ToString());

                 string[] row1 = new string[] { rd["r_id"].ToString(), rd["title"].ToString(), rd["filename"].ToString()};
                 dataGridView1.Rows.Add(row1);

             }
             
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string file_name = "http://localhost:8587/"+dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Process.Start(file_name);

        }
    }
}
