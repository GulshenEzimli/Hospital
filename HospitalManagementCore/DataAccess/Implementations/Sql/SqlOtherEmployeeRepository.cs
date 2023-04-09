using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.Sql
{
    public class SqlOtherEmployeeRepository : IOtherEmployeeRepository
    {
        private readonly string _connectionString;
        public SqlOtherEmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from OtherEmployees where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<OtherEmployee> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from OtherEmployees where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<OtherEmployee> otherEmployees = new List<OtherEmployee>();

                    while (reader.Read())
                    {
                        OtherEmployee otherEmployee = GetOtherEmployees(reader);
                        otherEmployees.Add(otherEmployee);
                    }
                    return otherEmployees;
                }
            }
        }

        public OtherEmployee GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from OtherEmployees where Id = @id and IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    OtherEmployee otherEmployee = GetOtherEmployees(reader);
                    return otherEmployee;
                }
            }
        }

        public int Insert(OtherEmployee otherEmployee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"insert into OtherEmployees output inserted.id values(@id,@positionid,@firstname,@lastname,@gender,
                                 @birthdate,@pin,@email,@phonenumber,@salary,@isdelete,@creationdate,@modifieddate
                                 @creatorid,@modifierid)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, otherEmployee);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(OtherEmployee otherEmployee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"update OtherEmployees set PositionId=@positionid, FirstName=@firstname, LastName=@lastname,
                                 Gender=@gender, BirthDate=@birthdate, PIN=@pin, Email=@email, PhoneNumber=@phonenumber,
                                 Salary=@salary, IsDelete=@isdelete, CreationDate=@creationdate, ModifiedDate=@modifieddate,
                                 CreatorId=@creatorid, ModifierId=@modifierid where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", otherEmployee.Id);
                    AddParameters(command, otherEmployee);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        private OtherEmployee GetOtherEmployees(SqlDataReader reader)
        {
            OtherEmployee otherEmployee = new OtherEmployee();

            otherEmployee.Id = reader.GetInt32("Id");
            otherEmployee.PositionId = reader.GetInt32("PositionId");
            otherEmployee.ModifierId = reader.GetInt32("ModifierId");
            otherEmployee.CreatorId = reader.GetInt32("CreatorId");
            otherEmployee.FirstName = reader.GetString("FirstName");
            otherEmployee.LastName = reader.GetString("LastName");
            otherEmployee.Gender = reader.GetBoolean("Gender");
            otherEmployee.PIN = reader.GetString("PIN");
            otherEmployee.Email = reader.GetString("Email");
            otherEmployee.Phonenumber = reader.GetString("Phonenumber");
            otherEmployee.BirthDate = reader.GetDateTime("BirthDate");
            otherEmployee.Salary = reader.GetDecimal("Salary");
            otherEmployee.CreationDate = reader.GetDateTime("CreationDate");
            otherEmployee.ModifiedDate = reader.GetDateTime("ModifiedDate");
            otherEmployee.IsDelete = reader.GetBoolean("IsDelete");

            return otherEmployee;
        }

        private void AddParameters(SqlCommand command, OtherEmployee otherEmployee)
        {
            command.Parameters.AddWithValue("id", otherEmployee.Id);
            command.Parameters.AddWithValue("positionid", otherEmployee.PositionId);
            command.Parameters.AddWithValue("firstname", otherEmployee.FirstName);
            command.Parameters.AddWithValue("lirstname", otherEmployee.LastName);
            command.Parameters.AddWithValue("gender", otherEmployee.Gender);
            command.Parameters.AddWithValue("birthdate", otherEmployee.BirthDate);
            command.Parameters.AddWithValue("pin", otherEmployee.PIN);
            command.Parameters.AddWithValue("email", otherEmployee.Email);
            command.Parameters.AddWithValue("phonenumber", otherEmployee.Phonenumber);
            command.Parameters.AddWithValue("salary", otherEmployee.Salary);
            command.Parameters.AddWithValue("isdelete", otherEmployee.IsDelete);
            command.Parameters.AddWithValue("creationdate", otherEmployee.CreationDate);
            command.Parameters.AddWithValue("modifieddate", otherEmployee.ModifiedDate);
            command.Parameters.AddWithValue("creatorid", otherEmployee.CreatorId);
            command.Parameters.AddWithValue("modifierid", otherEmployee.ModifierId);
        }
    }
}
