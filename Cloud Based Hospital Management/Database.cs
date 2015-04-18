using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Cloud_Based_Hospital_Management
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public  Database()
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

        public int checkLogin(String name, String pass)
        {
            string query = "SELECT count(*) FROM `users` WHERE `username` = '"+name+"' AND `password` = '"+pass+"'";
            int Count = -1;
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }

        }

        public void getPatById(int ID)
        {

        }

        public void getDocs()
        {
            string[] data = new string[20];
            String query = "SELECT * FROM  `doctor` ";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (this.OpenConnection() == true)
            {
                int i = 0;
                while (dataReader.Read())
                {
                    
                    data[i] = dataReader["name"].ToString();
                    MessageBox.Show(data[i]+"");
                    i++;
           
                }

               
                
              
            }

            

            
        }

        public MySqlDataReader getAppoinments(string dr)
        {
            /* string[] row = new string[50];
             String query = "SELECT * FROM `appointments` WHERE `finished` = 1";
             MySqlCommand cmd = new MySqlCommand(query, connection);
             MySqlDataReader dataReader = cmd.ExecuteReader();
            
             if (this.OpenConnection() == true)
             {
                // return dataReader;

                 while (dataReader.Read())
                 {
                     MessageBox.Show(dataReader["id"].ToString());
                 }
             }
            // return dataReader;

             MessageBox.Show("Error");*/

            


            string query = "SELECT * FROM `appointments` WHERE `finished` = 0 AND `dr_name` ="+ dr ;

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

        public void addAppo(string[] data)
        {
            string query = "INSERT INTO `appointments` (`id`, `dr_name`, `p_id`, `p_name`, `date`) VALUES ('','" + data[3] + "', '" + data[0] + "', '" + data[1] + "', CURDATE())";
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
                MessageBox.Show("Appoinment Fixed , Ur Id Is :"+id);

                
            }
        }

        // Store Patient Details

        

    }
}
