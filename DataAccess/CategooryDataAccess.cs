using alltopicMvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace alltopicMvc.DataAccess
{
    public class CategooryDataAccess
    {
        private readonly string _connectionString;

        public CategooryDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SpGetCategories";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.Id = Convert.ToInt32(reader["id"]);
                        category.Name = reader["name"].ToString();
                        category.Title = reader["title"].ToString();    
                        category.Description = reader["description"].ToString();
                        category.Image = reader["image"].ToString();
                        category.created_at = Convert.ToDateTime(reader["create_at"]);

                        categories.Add(category);
                    }

                }
            }
            return categories;
        }


        public int insertCategory(string name, string title, string description, string image)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "SpInsertCategory";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 0;

                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@title", title);
                    sqlCommand.Parameters.AddWithValue("@description", description);
                    sqlCommand.Parameters.AddWithValue("@image", image);

                    result = sqlCommand.ExecuteNonQuery();
                }
            }
            return result;
        }


    }
}