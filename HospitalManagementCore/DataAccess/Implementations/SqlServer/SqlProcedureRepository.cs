﻿using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlProcedureRepository : IProcedureRepository
    {
        private readonly string _connectionString;
        public SqlProcedureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using(SqlConnection connection=new SqlConnection())
            {
                connection.Open();
                string cmdText = @"Delete from Procedures where Id=@id";
                using(SqlCommand command=new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("Id",id);
                    return command.ExecuteNonQuery()==1;
                }
            }
        }

        public List<Procedure> Get()
        {
            using(SqlConnection connection=new SqlConnection(_connectionString))
            {
                connection.Open ();
                string cmdText = @"Select * from Procedures";
                using(SqlCommand command=new SqlCommand(cmdText, connection))
                {
                    List<Procedure> procedures= new List<Procedure>();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Procedure procedure = GetProcedure(reader);
                        procedures.Add(procedure);
                    }
                    return procedures;
                }
            }
        }

        public Procedure GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select * from Procedures where Id = @id ";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Procedure procedure = GetProcedure(reader);
                    return procedure;
                }
            }
        }

        public int Insert(Procedure procedure)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Procedures values(@name,@cost)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, procedure);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Procedure procedure)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"Update Patients set Name=@name,Cost=@cost where Id=@id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, procedure);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
        #region GetProcedure
        private Procedure GetProcedure(SqlDataReader reader)
        {
            Procedure procedure = new Procedure();
            procedure.Id=reader.GetInt32("Id");
            procedure.Name = reader.GetString("Name");
            procedure.Cost = reader.GetDecimal("Cost");
            return procedure;
        }
        #endregion
        #region AddParameters
        private void AddParameters(SqlCommand command,Procedure procedure)
        {
            command.Parameters.AddWithValue("@name", procedure.Name);
            command.Parameters.AddWithValue("@cost", procedure.Cost);
        }
        #endregion
    }
}