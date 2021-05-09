using Npgsql;
using Quidditch_Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public NpgsqlDataReader Reader { get; private set; }

        public DatabaseManager()
        {

        }

        /// <summary>
        /// Executes a query on the SQL database and returns an NpgsqlDataReader Object,
        /// which is basically an array containing the results.
        /// </summary>
        /// <param name="query">The SQL Query for the database</param>
        /// <param name="function">Must return the query result converted to a C# Object</param>
        public List<T> QueryListResult<T>(string query, Func<T> function)
        {
            List<T> list = new List<T>();

            //Get an instance of the NpgsqlConnection object
            var connection = GetConnection();

            //Open the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            //Execute the query
            Reader = command.ExecuteReader();

            //Read result of the query
            while (Reader.Read())
            {
                list.Add(function());
            }

            //Close connection to the database
            connection.Close();

            return list;
        }

        public T QuerySingleObjectResult<T>(string query, Func<T> function)
        {
            return QueryListResult<T>(query, function).FirstOrDefault();
        }

        public int QueryIntResult(string query)
        {
            int i = 0;

            //Get an instance of the NpgsqlConnection object
            var connection = GetConnection();

            //Open the connection to the database
            connection.Open();

            //Defines a query for the connected database
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            //Execute the query
            Reader = command.ExecuteReader();

            //Read result of the query
            if (Reader.Read())
            {
                i = int.Parse(this.Reader[0].ToString());
            }

            //Close connection to the database
            connection.Close();

            return i;
        }

        /// <summary>
        /// Formats the connection string used to create a NpgsqlConnection Object 
        /// which can the be used to open a connection instance to the Postgres Database.
        /// </summary>
        /// <returns>NpgsqlConnection Object</returns>
        private NpgsqlConnection GetConnection()
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
