using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SQL_Explorer
{
    internal class connection
    {
        private String server;
        private String port;
        private String username;
        private String password;
        private String db;
        private MySqlConnection conn;
        private bool connSuccess = false;

        public connection(string server, string port, string username, string password, string db)
        {
            //Initialize private data members
            this.server = server;
            this.port = port;
            this.username = username;
            this.password = password;
            this.db = db;

            //Creates a new MySQL connection object
            String connStr = "server=" + server + ";user=" + username + ";database=" + db + ";port=" + port + ";password=" + password;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                connSuccess = true;
            }
            catch (Exception e) { 
                Console.WriteLine(e.ToString() + "\n");
            }
        }

        //Returns connection status
        public bool getConnSuccess() { 
            return connSuccess;
        }

        //Executes the query passed into the function parameter with results
        public void query(String query) {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int count = reader.FieldCount; //Get number of columns to print each row

                    //Print the row
                    for (int i = 0; i < count; i++)
                    {
                        if (i == 0 || i == count - 1)
                        {
                            Console.Write(reader[i]);
                        }
                        else
                        {
                            Console.Write("-- " + reader[i] + " --");
                        }
                    }

                    Console.WriteLine(); //Row completed, create newline for next row
                }

                reader.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        //Manually Close MySQL connection
        public void close() { 
            conn.Close();
        }
    }
}
