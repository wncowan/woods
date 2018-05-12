using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using woods.Models;

namespace woods.Factories{
    public class TrailFactory
    {
        static string server = "localhost";
        static string db = "woods"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection
        {
            get
            {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        public List<Trail> ViewTrails()
        {
            using (IDbConnection dbConnection = Connection)
            {
                using (IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = "SELECT * FROM trails";
                    dbConnection.Open();
                    return dbConnection.Query<Trail>(query).ToList();
                }
            }
        }

        public Trail FindTrail(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                Console.WriteLine("pased in id:");
                Console.WriteLine(id);
                // string query = "SELECT * FROM trails WHERE id = {id}";
                dbConnection.Open();
                //return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
                return dbConnection.Query<Trail>($"SELECT * FROM trails WHERE id = {id}").FirstOrDefault();
                // return dbConnection.Query<Trail>(query).ToList();

            }
        }
        public void AddNewTrail (Trail trail)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO trails (name, description, length, elevation, longitude, latitude, created_at, updated_at) VALUES (@Name, @Description, @Length, @Elevation, @Longitude, @Latitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }
    }
}