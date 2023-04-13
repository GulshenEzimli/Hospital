﻿using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlPatientRepository : IPatientRepository
    {
        private readonly string _connectionString;
        public SqlPatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"Delete from Patients where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("Id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Patient> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Patients where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    List<Patient> patients = new List<Patient>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Patient patient = GetPatient(reader);
                        patients.Add(patient);
                    }
                    return patients;
                }
            }
        }

        public Patient GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Patients where Id = @id and IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Patient patient = GetPatient(reader);
                    return patient;
                }
            }
        }

        public int Insert(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Patients output inserted.id values (@CreatorId,@ModifierId,
                                 @FirstName,@LastName,@Gender,@BirthDate,@PIN,@PhoneNumber,
                                 @CreationDate,@ModifiedDate,@IsDelete)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, patient);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"Update Patients set FirstName=@firstName,LastName=@lastName,
                                  Gender=@gender,BirthDate=@birthDate,PIN=@pin,Phonenumber=@phoneNumber,
                                  CreatorId=@creatorId,ModifiedId=@modifiedId,CreationDate=@creationDate,
                                  ModifiedDate=@modifiedDate,IsDelete=@isDelete where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, patient);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
        #region GetPatient
        private Patient GetPatient(SqlDataReader reader)
        {
            Patient patient = new Patient();

            patient.Id = reader.GetInt32("Id");
            patient.Name = reader.GetString("FirstName");
            patient.Surname = reader.GetString("LastName");
            patient.Gender = reader.GetBoolean("Gender");
            patient.PIN = reader.GetString("PIN");
            patient.BirthDate = reader.GetDateTime("BirthDate");
            patient.PhoneNumber = reader.GetString("Phonenumber");
            patient.CreatorId = reader.GetInt32("CreatorId");
            patient.ModifierId = reader.GetInt32("ModifierId");
            patient.CreationDate = reader.GetDateTime("CreationDate");
            patient.ModifiedDate = reader.GetDateTime("ModifiedDate");
            patient.IsDelete = reader.GetBoolean("IsDelete");

            patient.Creator = new Admin { Id = patient.CreatorId };
            patient.Modifier=new Admin { Id = patient.ModifierId };
            return patient;
        }
        #endregion
        #region AddParameters
        private void AddParameters(SqlCommand command, Patient patient)
        {
            command.Parameters.AddWithValue("@firstName", patient.Name);
            command.Parameters.AddWithValue("@lastName", patient.Surname);
            command.Parameters.AddWithValue("@gender", patient.Gender);
            command.Parameters.AddWithValue("@birthDate", patient.BirthDate);
            command.Parameters.AddWithValue("@phoneNumber", patient.PhoneNumber);
            command.Parameters.AddWithValue("@pin", patient.PIN);
            command.Parameters.AddWithValue("@creatorId", patient.CreatorId);
            command.Parameters.AddWithValue("@modifierId", patient.ModifierId);
            command.Parameters.AddWithValue("@creationDate", patient.CreationDate);
            command.Parameters.AddWithValue("@modifiedDate", patient.ModifiedDate);
            command.Parameters.AddWithValue("@isDelete", patient.IsDelete);
        }
        #endregion
    }
}