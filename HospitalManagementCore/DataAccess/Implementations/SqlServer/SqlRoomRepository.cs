using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlRoomRepository : IRoomRepository
    {

        private readonly string _connectionString;
        public SqlRoomRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from Rooms where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Room> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Room> rooms = new List<Room>();

                    while (reader.Read())
                    {
                        Room room = GetRoom(reader);
                        rooms.Add(room);
                    }
                    return rooms;
                }
            }
         
        }

        public Room GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Room room = GetRoom(reader);
                    return room;
                }
            }
        }

        public int Insert(Room room)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, room);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Room room)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", room.Id);
                    AddParameters(command, room);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        private Room GetRoom(SqlDataReader reader)
        {
            Room room = new Room();
            room.Id = reader.GetInt32("id");
            room.Number = reader.GetInt32("number");
            room.BlockFloor = reader.GetInt32("blockFloor");
            room.IsAvailable = reader.GetBoolean("IsAvailable");
            room.Type = reader.GetByte("type");


            return room;

        }

        private void AddParameters(SqlCommand command, Room room)
        {
            command.Parameters.AddWithValue("id", room.Id);
            command.Parameters.AddWithValue ("number", room.Number);
            command.Parameters.AddWithValue("blockFloor", room.BlockFloor);
            command.Parameters.AddWithValue("isAvailable",room.IsAvailable);    
            command.Parameters.AddWithValue("type",room.Type);

        }
    }
}
