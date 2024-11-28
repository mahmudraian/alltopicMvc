using alltopicMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;

namespace alltopicMvc.DataAccess
{
    public class UserAccess
    {
        private readonly string _connectionString;

        public UserAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SpGetUsers";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while(reader.Read())
                    {
                        User user = new User();
                        user.Id = Convert.ToInt32(reader["id"]);
                        user.Name = reader["name"].ToString();
                        user.Email = reader["email"].ToString();
                        user.Password = reader["password"].ToString();
                        user.created_at = Convert.ToDateTime(reader["create_at"]);

                        users.Add(user);
                    }

                }
            }
            return users;
        }


        public int insertuser(string name,string  email,string password, int is_admin)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SpInsertUser";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;

                    sqlCommand.Parameters.AddWithValue("@name",name);
                    sqlCommand.Parameters.AddWithValue("@email",email);
                    sqlCommand.Parameters.AddWithValue("@password",password);
                    sqlCommand.Parameters.AddWithValue("@is_admin", is_admin);
                    

                    result = sqlCommand.ExecuteNonQuery();
                }

            }

            return result;

        }



    }
}