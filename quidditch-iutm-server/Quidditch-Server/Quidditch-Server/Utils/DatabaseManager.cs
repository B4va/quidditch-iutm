using Npgsql;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch_Server.Utils
{
    public class DatabaseManager
    {
        private static string Host = "127.0.0.1";
        private static string PGUser = "user";
        private static string PGDBname = "db";
        private static string PGPassword = "pass";
        private static string PGPort = "6000";

        /// <summary>
        /// Executes a query on the SQL database and returns an NpgsqlDataReader Object,
        /// which is basically an array containing the results.
        /// </summary>
        /// <param name="query">The SQL Query for the database</param>
        /// <returns>NpgsqlDataReader Object</returns>
        public static NpgsqlDataReader Query(string query)
        {
            //Gets the object used to open the connection to the database
            NpgsqlConnection conn = GetConnection();

            //Opens the connection to the database
            conn.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand(query, conn);

            //Execute the query and return the 
            NpgsqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        /// <summary>
        /// Formats the connection string used to create a NpgsqlConnection Object 
        /// which can the be used to open a connection instance to the Postgres Database.
        /// </summary>
        /// <returns>NpgsqlConnection Object</returns>
        public static NpgsqlConnection GetConnection()
        {
            //Formating the connection string for the database connection
            string connString =
                String.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    PGUser,
                    PGDBname,
                    PGPort,
                    PGPassword);

            //Creating a object used to open a connection to the database
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            return conn;
        }
    }
}
