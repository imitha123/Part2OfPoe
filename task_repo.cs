using System.Data.SqlClient;
using System;
namespace Part2OfPoe
{
    public class task_repo
    {
        string connection = @"Data Source=(localdb)\MSSQLLocalDB;
                              Initial Catalog=task;
                              Integrated Security=True;";

        public void add_task(string title, string description, DateTime? reminder)
        {
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = "INSERT INTO tasks " +
                               "VALUES (@title, @description, @reminder)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                
                if(reminder == null)
                {
                    cmd.Parameters.AddWithValue("@reminder", DBNull.Value);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@reminder", reminder);
                    
                }

                cmd.ExecuteNonQuery();
            }
        }
    }
}

