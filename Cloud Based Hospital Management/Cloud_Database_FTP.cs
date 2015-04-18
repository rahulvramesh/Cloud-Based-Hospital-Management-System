using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net;
using FtpLib;

namespace Cloud_Based_Hospital_Management
{
    class Cloud_Database_FTP
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Cloud_Database_FTP()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "CBHMS";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                // MessageBox.Show("Connected");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int storeToCloud(String[] arg,int size)
        {
            /*
             *  pat_info[0] = first_name = txt_firstname.Text;
            pat_info[1] = last_name = txt_secondname.Text;
            pat_info[2] = sex = txt_sex.Text;
            pat_info[3] = Phone = textBox1.Text;
            pat_info[4] = email = textBox2.Text;
            pat_info[5] = Address = textBox3.Text;
            pat_info[6] = city = textBox4.Text;
            pat_info[7] = sate = textBox5.Text;
            pat_info[8] = zip = textBox6.Text;
            pat_info[9] = note = textBox7.Text;
             */
            DateTime dt = new DateTime();
            String.Format("{0:M-d-yyyy}", dt);
            String query = "INSERT INTO `patients` (`id`, `fname`, `lname`, `sex`, `phone`, `email`, `address`, `city`, `state`, `zip`, `note`, `pic`, `date`,`dob`, `f_id`) VALUES ('', '" + arg[0] + "', '" + arg[1] + "', '" + arg[2] + "', '" + arg[3] + "', '" + arg[4] + "', '" + arg[5] + "', '" + arg[6] + "', '" + arg[7] + "', '" + arg[8] + "', '" + arg[9] + "', '" + arg[11] + "', CURDATE(),'" + arg[12] + "', '" + arg[19] + "')";
            int id = s2DB(query);

            

                //MessageBox.Show("Data Stored To Cloud");
            s2FTP(arg[10], arg[11]);
            
            //Call FTP

           


            //Call DB

            return id;
        }

        public int storePreToCloud(String[] arg)
        {
           
            DateTime dt = new DateTime();
            String.Format("{0:M-d-yyyy}", dt);
            String query = "INSERT INTO `prescription` (`pre_id`, `p_id`, `date`, `test`, `drugs`, `dr_id`, `notes`) VALUES ('', '" + arg[0] + "', '"+arg[2]+"', '" + arg[3] + "', '" + arg[4] + "', '" + arg[1] + "', '" + arg[5] + "');";
            
            int id = s2DB(query);



            return id;
        }

        public int storeReport2Cloud(String[] arg)
        {

            DateTime dt = new DateTime();
            String.Format("{0:M-d-yyyy}", dt);
            String query = "INSERT INTO `reports` (`r_id`, `title`, `date`, `filename`, `type`, `p_id`) VALUES (NULL, '"+arg[1]+"', '"+arg[2]+"', '"+arg[3]+"', '"+arg[5]+"', '"+arg[0]+"')";

            int id = s2DB(query);

            s2FTP(arg[4], arg[3]);



            return id;
        }

        public MySqlDataReader getReports(int u_id,int type)
        {
           




            string query = "SELECT * FROM `reports` WHERE `p_id` = "+u_id+" AND `type` = "+type;
            //string query = "SELECT * FROM `reports` WHERE `p_id` = 47 AND `type` = 1";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                // while (dataReader.Read())
                //{
                //   list[0].Add(dataReader["id"] + "");
                //  MessageBox.Show(dataReader["id"].ToString() + " ");
                // }


                return dataReader;

                //close Data Reader
                //dataReader.Close();

            }
            return null;

        }

        public int s2DB(String query)
        {
            if (this.OpenConnection() == true)
            {
                int id;
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                //SELECT last_insert_id()

                String query1 = "SELECT last_insert_id()";

                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                id = int.Parse(cmd1.ExecuteScalar() + "");
                //close connection


                this.CloseConnection();

                return id;
            }

            else
                return 0;

        }



        // Function to store ftp

        public bool s2FTP(String url,String name)
        {

            using (FtpConnection ftp = new FtpConnection("127.0.0.1", "rahul", "rahul"))
            {; /* Open the FTP connection */
                
                ftp.Open(); /* Login using previously provided credentials */
                ftp.Login();
                try
                {
                    ftp.SetCurrentDirectory("/");
                    ftp.PutFile(@url, name); /* upload c:\localfile.txt to the current ftp directory as file.txt */
                }
                catch (FtpException e)
                {
                    Console.WriteLine(String.Format("FTP Error: {0} {1}", e.ErrorCode, e.Message));
                }

            }

            return true;
        }

        public string[] getPatientDetails(String id)
        {
            string query = "SELECT * FROM `patients` WHERE `id` = "+id;

            string[] data = new string[20];
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    data[0] = dataReader["id"].ToString();
                    data[1] = dataReader["fname"].ToString();
                    data[2] = dataReader["lname"].ToString();
                    data[3] = dataReader["sex"].ToString();
                    data[4] = dataReader["phone"].ToString();
                    data[5] = dataReader["email"].ToString();
                    data[6] = dataReader["address"].ToString();
                    data[7] = dataReader["city"].ToString();
                    data[8] = dataReader["state"].ToString();
                    data[9] = dataReader["zip"].ToString();
                    data[10] = dataReader["note"].ToString();
                    data[11] = dataReader["pic"].ToString();
                    data[12] = dataReader["date"].ToString();
                    data[13] = dataReader["dob"].ToString();
                }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //MessageBox.Show(data[1] + "");

                    //return list to be displayed
                    return data;
                }
            
            else
            {
                return data;
            }
        }


        public string[] getPatientDetailsByFID(String id)
        {
            string query = "SELECT * FROM `patients` WHERE `f_id` = " + id;

            string[] data = new string[20];
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    data[0] = dataReader["id"].ToString();
                    data[1] = dataReader["fname"].ToString();
                    data[2] = dataReader["lname"].ToString();
                    data[3] = dataReader["sex"].ToString();
                    data[4] = dataReader["phone"].ToString();
                    data[5] = dataReader["email"].ToString();
                    data[6] = dataReader["address"].ToString();
                    data[7] = dataReader["city"].ToString();
                    data[8] = dataReader["state"].ToString();
                    data[9] = dataReader["zip"].ToString();
                    data[10] = dataReader["note"].ToString();
                    data[11] = dataReader["pic"].ToString();
                    data[12] = dataReader["date"].ToString();
                    data[13] = dataReader["dob"].ToString();
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //MessageBox.Show(data[1] + "");

                //return list to be displayed
                return data;
            }

            else
            {
                return data;
            }
        }



    }
}
