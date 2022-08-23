using System;
using System.Data.SqlClient;
namespace TaskMap1.Models
{
    internal class SaveDB : ConnectDB, ISaveChange
    {
        public SaveDB() : base(@"STRIPA101\SQLEXPRESS", "gmaptask")
        {
        }

        public System.Collections.Generic.IEnumerable<Equipment> SetAll
        {
            set
            {
                foreach (var item in value)
                {
                    String command = $"update geographical_coordinates_tb set x=@X, y=@Y where id=@ID;";
                    using (SqlCommand sqlCommand = new SqlCommand(command, _connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@X", item.X);
                        sqlCommand.Parameters.AddWithValue("@Y", item.Y);
                        sqlCommand.Parameters.AddWithValue("@ID", item.Id);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
