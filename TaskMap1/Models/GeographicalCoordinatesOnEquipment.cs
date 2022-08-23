using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace TaskMap1.Models
{
    internal class GeographicalCoordinatesOnEquipment : ConnectDB, IEquipmentRepository
    {
        public GeographicalCoordinatesOnEquipment() : base(@"STRIPA101\SQLEXPRESS", "gmaptask")
        {
        }
        public IEnumerable<Equipment> GetAll
        {
            get
            {
                List<Equipment> list = new List<Equipment>();
                String command = "select [x],[y],[name],geographical_coordinates_tb.[id] from  geographical_coordinates_tb inner join geographical_to_equipment on  geographical_coordinates_tb.id=geographical_to_equipment.fk_geographical inner join equipment_tb on equipment_tb.id=geographical_to_equipment.fk_equipment;";
                using (SqlCommand sqlCommand = new SqlCommand(command, _connection))
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Equipment equipment = new Equipment();
                        equipment.X = reader.GetDecimal(0);
                        equipment.Y = reader.GetDecimal(1);
                        equipment.Name = reader.GetString(2);
                        equipment.Id = reader.GetInt32(3);
                        list.Add(equipment);
                    }
                }
                return list;
            }
        }
    }
}
