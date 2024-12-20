using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace feladat1220
{
    internal class Program
    {
        public static Connect conn = new Connect();
        public static void GetAllData()
        {
            conn.Connection.Open();

            string sql = "SELECT * FROM `data`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {
                var user = new
                    Id = dr.GetInt32(0),
                    FirstName = dr.GetString(1),
                    LastName = dr.GetString(2),
                    CreatedTime = dr.GetDateTime(3),
             };
            Console.WriteLine($"adatok: {FirstName},{LastName},{Password}");
        }
                while (dr.Read());

            dr.Close();

            conn.Connection.Close();
            public static void AddNewUser(string FirstName, string LastName, string Password)
        {
            using (var connection = Connect.GetConnection())
            {
                string query = "INSERT INTO data (FirstName, LastName, Password) VALUES (@FirstName, @LastName, @Password);";
                using (var command = new SqlCommand(query, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Felhasználó sikeresen hozzá adva.");
                }
            }
        }

        public static void DeleteUser(int Id)
        {
            using (var connection = Connect.GetConnection())
            {
                string query = "DELETE FROM data WHERE Id = @Id;";
                using (var command = new SqlCommand(query, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Felhasználó azonosítója {Id} törölve.");
                }
            }
        }

        public static void UpdateUser(int id, string FirstName, string LastName, string Password)
        {
            using (var connection = Connect.GetConnection())
            {
                string query = "UPDATE data SET FirstName = @FirstName, LastName = @LastName, Password = @Password WHERE Id = @Id;";
                using (var command = new SqlCommand(query, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Felhasználó azonosítója {id} frissítve.");
                }
            }
        }
    }
}