using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlDoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString;
        public SqlDoctorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from Doctors where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Doctor> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select Doctors.Id as DoctorId, DoctorPositions.Id as PositionId, Departments.Id as DepartmentId, CreatorId, ModifierId, FirstName, LastName, Gender,
                                   BirthDate, PIN, Email, Phonenumber, Salary, IsChiefDoctor, CreationDate, ModifiedDate, IsDelete, PositionName, DepartmentName
                                   from Doctors 
                                   inner join DoctorPositions on Doctors.PositionId = DoctorPositions.Id
                                   inner join Departments on DoctorPositions.DepartmentId = Departments.Id where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Doctor> doctors = new List<Doctor>();

                    while (reader.Read())
                    {
                        Doctor doctor = GetDoctor(reader);
                        doctors.Add(doctor);
                    }
                    return doctors;
                }
            }
        }

        public Doctor GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select Doctors.Id as DoctorId, DoctorPositions.Id as PositionId, Departments.Id as DepartmentId, CreatorId, ModifierId, FirstName, LastName, Gender,
                                   BirthDate, PIN, Email, Phonenumber, Salary, IsChiefDoctor, CreationDate, ModifiedDate, IsDelete, PositionName, DepartmentName
                                   from Doctors 
                                   inner join DoctorPositions on Doctors.PositionId = DoctorPositions.Id
                                   inner join Departments on DoctorPositions.DepartmentId = Departments.Id where Id = @id and IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Doctor doctor = GetDoctor(reader);
                    return doctor;
                }
            }
        }

        public int Insert(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"insert into Doctors output inserted.id 
                                   values(@id, @creatorid, @modifierid, @positionid = select Id from DoctorPositions where PositionName = @positionname,
                                   @firstname, @lastname, @gender, @birthdate, @pin, @email, @phonenumber, @salary, @ischiefdoctor, 
                                   @creationdate, @modifieddate, @isdelete)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, doctor);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"update Doctors set PositionId=@positionid, FirstName=@firstname, LastName=@lastname,
                                 Gender=@gender, BirthDate=@birthdate, PIN=@pin, Email=@email, PhoneNumber=@phonenumber,
                                 Salary=@salary, IsChiefDoctor= @ischiefdoctor, IsDelete=@isdelete, CreationDate=@creationdate, ModifiedDate=@modifieddate,
                                 CreatorId=@creatorid, ModifierId=@modifierid where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, doctor);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
        private Doctor GetDoctor(SqlDataReader reader)
        {
            Doctor doctor = new Doctor();
            doctor.Id = reader.GetInt32("DoctorId");
            doctor.Position = new DoctorPosition();
            doctor.Position.Id = reader.GetInt32("PositionId");
            doctor.Position.Name = reader.GetString("PositionName");
            doctor.Position.Department = new Department();
            doctor.Position.Department.Id = reader.GetInt32("DepartmentId");
            doctor.Position.Department.Name = reader.GetString("DepartmentName");
            doctor.ModifierId = reader.GetInt32("ModifierId");
            doctor.CreatorId = reader.GetInt32("CreatorId");
            doctor.FirstName = reader.GetString("FirstName");
            doctor.LastName = reader.GetString("LastName");
            doctor.Gender = reader.GetBoolean("Gender");
            doctor.PIN = reader.GetString("PIN");
            doctor.Email = reader.GetString("Email");
            doctor.Phonenumber = reader.GetString("Phonenumber");
            doctor.BirthDate = reader.GetDateTime("BirthDate");
            doctor.Salary = reader.GetDecimal("Salary");
            doctor.CreationDate = reader.GetDateTime("CreationDate");
            doctor.ModifiedDate = reader.GetDateTime("ModifiedDate");
            doctor.IsDelete = reader.GetBoolean("IsDelete");
            doctor.IsChiefDoctor = reader.GetBoolean("IsChiefDoctor");

            // TODO Admin datas

            return doctor;
        }
        private void AddParameters(SqlCommand command, Doctor doctor)
        {
            command.Parameters.AddWithValue("id", doctor.Id);
            command.Parameters.AddWithValue("positionname", doctor.Position.Name);
            command.Parameters.AddWithValue("firstname", doctor.FirstName);
            command.Parameters.AddWithValue("lirstname", doctor.LastName);
            command.Parameters.AddWithValue("gender", doctor.Gender);
            command.Parameters.AddWithValue("birthdate", doctor.BirthDate);
            command.Parameters.AddWithValue("pin", doctor.PIN);
            command.Parameters.AddWithValue("email", doctor.Email);
            command.Parameters.AddWithValue("phonenumber", doctor.Phonenumber);
            command.Parameters.AddWithValue("salary", doctor.Salary);
            command.Parameters.AddWithValue("isdelete", doctor.IsDelete);
            command.Parameters.AddWithValue("ischiefdoctor", doctor.IsChiefDoctor);
            command.Parameters.AddWithValue("creationdate", doctor.CreationDate);
            command.Parameters.AddWithValue("modifieddate", doctor.ModifiedDate);
            command.Parameters.AddWithValue("creatorid", doctor.CreatorId);
            command.Parameters.AddWithValue("modifierid", doctor.ModifierId);
        }
    }
}
