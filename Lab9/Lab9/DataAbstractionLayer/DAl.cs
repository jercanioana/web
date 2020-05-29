using Lab9.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab9.DataAbstractionLayer
{
    public class DAL
    {
        public List<URL> GetURLByCategory(string category, int pageNumber)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                List<URL> filteredURLs = new List<URL>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlCommand totalRows = new MySqlCommand();
                totalRows.Connection = conn;
                totalRows.CommandText = "SELECT COUNT(*) FROM URLs";
                Int32 result = Convert.ToInt32(totalRows.ExecuteScalar());
                float r = (float)result / 4;
                double totalPages = Math.Ceiling(r);
                int start = (pageNumber - 1) * 4;


                cmd.CommandText = "select * from URLs WHERE category = '" + category + "' LIMIT " + start + "," + 4;

                MySqlDataReader myreader = cmd.ExecuteReader();

                
                while (myreader.Read())
                {
                    URL url = new URL();
                    url.Id = myreader.GetInt32("idURLs");
                    url.link = myreader.GetString("link");
                    url.description = myreader.GetString("description");
                    url.category = myreader.GetString("category");
                    filteredURLs.Add(url);
                }
                myreader.Close();
                return filteredURLs;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return null;

        }

        public double getTotalPages()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";
            double totalPages;

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlCommand totalRows = new MySqlCommand();
                totalRows.Connection = conn;
                totalRows.CommandText = "SELECT COUNT(*) FROM URLs";
                Int32 result = Convert.ToInt32(totalRows.ExecuteScalar());

                float r = (float)result / 4;
                totalPages = Math.Ceiling(r);
                return totalPages;
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<URL> GetAllURLs(int pageNumber)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";
            List<URL> urls = new List<URL>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlCommand totalRows = new MySqlCommand();
                totalRows.Connection = conn;
                totalRows.CommandText = "SELECT COUNT(*) FROM URLs";
                Int32 result = Convert.ToInt32(totalRows.ExecuteScalar());
                
                float r = (float)result / 4;
                double totalPages = Math.Ceiling(r);
                if (pageNumber >= totalPages)
                {
                    pageNumber = (int)totalPages;
                }
                int start = (pageNumber - 1) * 4;


                cmd.CommandText = "select * from URLs LIMIT " + start + "," + 4;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    URL url = new URL();
                    url.Id = myreader.GetInt32("idURLs");
                    url.link = myreader.GetString("link");
                    url.description = myreader.GetString("description");
                    url.category = myreader.GetString("category");
                    urls.Add(url);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return urls;

        }

        

        public bool SaveURL(URL url)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into URLs values(" + 0 + ",'" + url.link + "','" + url.description + "','" + url.category + "')";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }

        public bool Authenticate(LoginModel model)
        {
            string connstring = "server=localhost;uid=root;pwd=1234;database=Lab9";
            var connection = new MySqlConnection(connstring);
            connection.Open();

            string query = "SELECT * FROM users WHERE username='" + model.Username + "' AND password='" + model.Password + "'";
            var cmd = new MySqlCommand(query, connection);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                return true;
            }
            

            connection.Close();
            return false;

        }

        public bool DeleteURL(URL url)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM URLs WHERE idURLs = " + url.Id;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }

        public bool UpdateURL(URL url)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=Lab9;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlCommand cmd1 = new MySqlCommand();
                
                cmd.CommandText = "UPDATE URLs SET link = '" + url.link + "', description = '" + url.description + "', category = '" + url.category + "' WHERE idURLs = " + url.Id;
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }


    }
}
