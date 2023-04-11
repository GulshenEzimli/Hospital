using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Interfaces;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
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
                string cmdText = @"select Nurses.Id as NurseId,DoctorPositions.Id as PositionId,Departments.Id as  
                                DepartmentId, CreatorId, ModifierId, FirstName,LastName,Gender, BirthDate, PIN,
                                Email,Phonenumber, Salary,CreationDate, ModifiedDate,IsDelete,PositionName, DepartmentName 
                                from Nurses inner join DoctorPositions on Nurses.PositionId = DoctorPositions.Id
                                inner join Departments on DoctorPositions.DepartmentId= Departments.Id where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Nurse> nurses = new List<Nurse>();

                    while (reader.Read())
                    {
                        Nurse nurse = GetNurse(reader);
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
                string cmdText = @"select Nurses.Id as NurseId,DoctorPositions.Id as PositionId,Departments.Id as  
                                DepartmentId, CreatorId, ModifierId, FirstName,LastName,Gender, BirthDate, PIN,
                                Email,Phonenumber, Salary,CreationDate, ModifiedDate,IsDelete,PositionName, DepartmentName 
                                from Nurses inner join DoctorPositions on Nurses.PositionId = DoctorPositions.Id
                                inner join Departments on DoctorPositions.DepartmentId= Departments.Id 
                                where Id=@id and IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Nurse nurse = GetNurse(reader);
                    return nurse;
                }
            }
        }

        public int Insert(Nurse nurse)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"insert into Nurses output inserted.id values(
                                 Positionid = (select Id from DoctorPositions where PositionName = @positionname),
                                 @firstname,@lastname,@gender,
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
                string cmdText = @"update Nurses set PositionId=(select Id from DoctorPositions where PositionName = @positionname), 
                                 FirstName=@firstname, LastName=@lastname,
                                 Gender=@gender, BirthDate=@birthdate, PIN=@pin, Email=@email, PhoneNumber=@phonenumber,
                                 Salary=@salary, IsDelete=@isdelete, CreationDate=@creationdate, ModifiedDate=@modifieddate,
                                 CreatorId=@creatorid, ModifierId=@modifierid where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", nurse.Id);
                    AddParameters(command, nurse);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        private Nurse GetNurse(SqlDataReader reader)
        {
            Nurse nurse = new Nurse();
            nurse.Id = reader.GetInt32("NurseId");
            nurse.PositionId = reader.GetInt32("PositionId");
            nurse.ModifierId = reader.GetInt32("ModifierId");
            nurse.CreatorId = reader.GetInt32("CreatorId");
            nurse.Position = new DoctorPosition()
            {
                Id = reader.GetInt32("PositionId"),
                Name = reader.GetString("PositionName"),
                Department = new Department()
                {
                    Id = reader.GetInt32("DepartmentId"),
                    Name = reader.GetString("DepartmentName"),
                },
            };
            nurse.Creator = new Admin()
            {
                Id = reader.GetInt32("CreatorAdminId")
            };

            nurse.Modifier = new Admin
            {
                Id = reader.GetInt32("ModifierAdminId")
            };
            nurse.FirstName = reader.GetString("FirstName");
            nurse.LastName = reader.GetString("LastName");
            nurse.Gender = reader.GetBoolean("Gender");
            nurse.PIN = reader.GetString("PIN");
            nurse.Email = reader.GetString("Email");
            nurse.PhoneNumber = reader.GetString("Phonenumber");
            nurse.BirthDate = reader.GetDateTime("BirthDate");
            nurse.Salary = reader.GetDecimal("Salary");
            nurse.CreationDate = reader.GetDateTime("CreationDate");
            nurse.ModifiedDate = reader.GetDateTime("ModifiedDate");
            nurse.IsDelete = reader.GetBoolean("IsDelete");

            return nurse;
        }

        private void AddParameters(SqlCommand command, Nurse nurse)
        {
            command.Parameters.AddWithValue("positionname", nurse.Position.Name);
            command.Parameters.AddWithValue("firstname", nurse.FirstName);
            command.Parameters.AddWithValue("lirstname", nurse.LastName);
            command.Parameters.AddWithValue("gender", nurse.Gender);
            command.Parameters.AddWithValue("birthdate", nurse.BirthDate);
            command.Parameters.AddWithValue("pin", nurse.PIN);
            command.Parameters.AddWithValue("email", nurse.Email);
            command.Parameters.AddWithValue("phonenumber", nurse.PhoneNumber);
            command.Parameters.AddWithValue("salary", nurse.Salary);
            command.Parameters.AddWithValue("isdelete", nurse.IsDelete);
            command.Parameters.AddWithValue("creationdate", nurse.CreationDate);
            command.Parameters.AddWithValue("modifieddate", nurse.ModifiedDate);
            command.Parameters.AddWithValue("creatorid", nurse.CreatorId);
            command.Parameters.AddWithValue("modifierid", nurse.ModifierId);
        }
    }
}
