using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.Sql
{
    public class SqlNurseRepository : INurseRepository
    {
        private readonly string _connectionString;
        public SqlNurseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from Nurses where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Nurse> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Nurses where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Nurse> nurses = new List<Nurse>();

                    while (reader.Read())
                    {
                        Nurse nurse = GetNurses(reader);
                        nurses.Add(nurse);
                    }
                    return nurses;
                }
            }
        }

        public Nurse GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Nurses where Id = @id and IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Nurse nurse = GetNurses(reader);
                    return nurse;
                }
            }
        }

        public int Insert(Nurse nurse)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"insert into Nurses output inserted.id values(@id,@positionid,@firstname,@lastname,@gender,
                                 @birthdate,@pin,@email,@phonenumber,@salary,@isdelete,@creationdate,@modifieddate
                                 @creatorid,@modifierid)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, nurse);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Nurse nurse)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"update Nurses set PositionId=@positionid, FirstName=@firstname, LastName=@lastname,
                                 Gender=@gender, BirthDate=@birthdate, PIN=@pin, Email=@email, PhoneNumber=@phonenumber,
                                 Salary=@salary, IsDelete=@isdelete, CreationDate=@creationdate, ModifiedDate=@modifieddate,
                                 CreatorId=@creatorid, ModifierId=@modifierid where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id",nurse.Id);
                    AddParameters(command, nurse);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        private Nurse GetNurses(SqlDataReader reader)
        {
            Nurse nurse = new Nurse();
            nurse.Id = reader.GetInt32(reader.GetOrdinal("Id"));
            nurse.PositionId = reader.GetInt32(reader.GetOrdinal("PositionId"));
            nurse.ModifierId = reader.GetInt32(reader.GetOrdinal("ModifierId"));
            nurse.CreatorId = reader.GetInt32(reader.GetOrdinal("CreatorId"));
            nurse.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            nurse.LastName = reader.GetString(reader.GetOrdinal("LastName"));
            nurse.Gender = reader.GetBoolean(reader.GetOrdinal("Gender"));
            nurse.PIN = reader.GetString(reader.GetOrdinal("PIN"));
            nurse.Email = reader.GetString(reader.GetOrdinal("Email"));
            nurse.Phonenumber = reader.GetString(reader.GetOrdinal("Phonenumber"));
            nurse.BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
            nurse.Salary = reader.GetDecimal(reader.GetOrdinal("Salary"));
            nurse.CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate"));
            nurse.ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));
            nurse.IsDelete = reader.GetBoolean(reader.GetOrdinal("IsDelete"));

            return nurse;
        }

        private void AddParameters(SqlCommand command, Nurse nurse)
        {
            command.Parameters.AddWithValue("id", nurse.Id);
            command.Parameters.AddWithValue("positionid", nurse.PositionId);
            command.Parameters.AddWithValue("firstname", nurse.FirstName);
            command.Parameters.AddWithValue("lirstname", nurse.LastName);
            command.Parameters.AddWithValue("gender", nurse.Gender);
            command.Parameters.AddWithValue("birthdate", nurse.BirthDate);
            command.Parameters.AddWithValue("pin", nurse.PIN);
            command.Parameters.AddWithValue("email", nurse.Email);
            command.Parameters.AddWithValue("phonenumber", nurse.Phonenumber);
            command.Parameters.AddWithValue("salary", nurse.Salary);
            command.Parameters.AddWithValue("isdelete", nurse.IsDelete);
            command.Parameters.AddWithValue("creationdate", nurse.CreationDate);
            command.Parameters.AddWithValue("modifieddate", nurse.ModifiedDate);
            command.Parameters.AddWithValue("creatorid", nurse.CreatorId);
            command.Parameters.AddWithValue("modifierid", nurse.ModifierId);
        }
    }
}
