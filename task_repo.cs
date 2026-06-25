using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Part2OfPoe
{
    public class task_repo
    {
        public readonly string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=task_db;Integrated Security=True";

        public void add_task(string title, string description,DateTime? reminder)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string query = @"INSERT INTO tasks (task_title, task_description, reminder_time) VALUES (@title, @description, @reminder)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);

                if (reminder == null)
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
        public List<task> get_tasks()
        {
            List<task> tasks = new List<task>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string query = @"SELECT * FROM tasks";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   tasks.Add(new task
                   {
                       task_title = reader["task_title"].ToString(),
                       task_description = reader["task_description"].ToString(),
                       reminder_time = reader["reminder_time"] == DBNull.Value ? null : reader["reminder_time"].ToString()
                   });
                }

            }

                return tasks;
        }
        public void delete_task(int taskid)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                string query = @"DELETE FROM tasks WHERE task_id = @taskid";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@taskid", taskid);

                cmd.ExecuteNonQuery();
            }
        }
}

}