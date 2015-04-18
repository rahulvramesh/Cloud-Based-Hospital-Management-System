using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cloud_Based_Hospital_Management
{
    public partial class appo_view_new : Form
    {
        public string doc;
        public appo_view_new(string dr)
        {
            InitializeComponent();
            doc = dr;
        }

        private void appo_Viewer_Load(object sender, EventArgs e)
        {
            string[] row = new string[50];
            //dataGridView1.Rows.Add(row);
            Database db = new Database();
            MySqlDataReader rd = db.getAppoinments(doc);

            while (rd.Read())
            {



                // MessageBox.Show(rd["p_name"].ToString());
                // row[0] = rd["id"].ToString();
                //row[1] = rd["name"].ToString();
                // row[2] = rd["date"].ToString();
                string[] row1 = new string[] { rd["id"].ToString(), rd["p_name"].ToString(), rd["date"].ToString() };
                dataGridView1.Rows.Add(row1);

            }


            /* while (rd.Read())
            {
                MessageBox.Show(rd["id"].ToString());
                row[0] = rd["id"].ToString();
                row[1] = rd["name"].ToString();
                row[2] = rd["date"].ToString();
                dataGridView1.Rows.Add(row);
            }*/

            //db.getAppoinments(doc);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.RowIndex.ToString());
            
            string id;
            string name;
            string date_s;
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            date_s = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           // MessageBox.Show(id);
            Prescription fm = new Prescription(name,doc,date_s,id);
            fm.Show();
            this.Close();
        }
    }
}
