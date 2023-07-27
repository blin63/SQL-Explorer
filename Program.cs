using System;

namespace SQL_Explorer {
    class program { 
        static void Main()
        {
            //Connection variables
            String server;
            String port;
            String username;
            String password;
            String db;
            bool connSuccess = false; //Check if connection successful

            //Program Header
            Console.WriteLine(" ----- SQL Explorer ----- ");
            Console.WriteLine(" ---- By: blin63 (Reflow) ---");

            while (!connSuccess) {
                //Get connection input
                Console.Write("Server: ");
                server = Console.ReadLine();

                Console.Write("Port: ");
                port = Console.ReadLine();

                Console.Write("Username: ");
                username = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();

                Console.Write("Database: ");
                db = Console.ReadLine();

                //Create connection object
                Console.WriteLine("Connecting to MySQL Server...");

                connection sql = new connection(server, port, username, password, db);
                connSuccess = sql.getConnSuccess();

                //Proceed to SQL Console if connection successful
                if (connSuccess) {
                    sqlConsole(sql);
                    sql.close(); //Close connection when user exits program
                }
            }

            Console.WriteLine("SQL Connection closed. Bye!");
        }

        static void sqlConsole(connection sql) {
            //User input query string
            String query = "";

            //Get queries from user until they type "quit"
            Console.WriteLine("Connection successful. Welcome to SQL Explorer");
            Console.WriteLine("Enter your SQL queries below. To exit program type quit");

            while (!query.Equals("quit", StringComparison.OrdinalIgnoreCase) &&
                !query.Equals("quit;", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("> ");
                query = Console.ReadLine();

                if (!query.Equals("quit", StringComparison.OrdinalIgnoreCase) &&
                    !query.Equals("quit;", StringComparison.OrdinalIgnoreCase)) {
                    sql.query(query);
                }               
            }
        }
    }
}