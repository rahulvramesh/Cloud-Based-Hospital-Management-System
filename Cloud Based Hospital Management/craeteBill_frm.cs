using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Microsoft.VisualBasic;

namespace Cloud_Based_Hospital_Management
{
    public partial class craeteBill_frm : Form
    {
        public craeteBill_frm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void craeteBill_frm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text.PadRight(30) + textBox3.Text);
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(createInvoice); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
        }

        public void createInvoice(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int total = 0;
            float cash = int.Parse(textBox4.Text);
            float change = 0.00f;

            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(" XYZ Hospital , Trivandrum", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            string top = "Name".PadRight(30) + "Fee";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            float totalprice = 0.00f;

            foreach (string item in listBox1.Items)
            {
                //create the string to print on the reciept
                string productDescription = item;
                string productTotal = item.Substring(item.Length - 6, 6);
                float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

                //MessageBox.Show(item.Substring(item.Length - 5, 5) + "PROD TOTAL: " + productTotal);


                totalprice += productPrice;

                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }

            change = (cash - totalprice);

            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Total to Pay ".PadRight(30) + "Rs." + totalprice, new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("CASH ".PadRight(30) + "Rs."+ cash, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            //graphic.DrawString("Name : ".PadRight(30) + , font, new SolidBrush(Color.Black), startX, startY + offset);
           // offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("Name : " + textBox1.Text.PadRight(10) + "Date : " + dateTimePicker1.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
         
            graphic.DrawString("Thank You - Stay Safe", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("", font, new SolidBrush(Color.Black), startX, startY + offset);
        }
    }
}
