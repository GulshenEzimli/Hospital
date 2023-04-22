using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlReceptionistRepository : IReceptionistRepository
    {
        private string _connectionString;
        public SqlReceptionistRepository( string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection= new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"Deleted * from Receptionist where Id=@id";
                using (SqlCommand command= new SqlCommand(cmdText,connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }
      

        public List<Receptionist> Get()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";
                using(SqlCommand command= new SqlCommand( cmdText,connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Receptionist> receptionists = new List<Receptionist>();

                    while (reader.Read())
                    {
                        Receptionist receptionist = GetReceptionist(reader);
                        receptionists.Add(receptionist);
                    }
                    return receptionists;
                    
                    // yadindan cixir bax 
                }
            }
        }

        public Receptionist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Receptionist entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Receptionist entity)
        {
            throw new NotImplementedException();
        }

        private Receptionist GetReceptionist(SqlDataReader reader)
        {
            Receptionist receptionist = new Receptionist();

            receptionist.Id = reader.GetInt32("ReceptionistId");
            receptionist.FirstName= reader.GetString("FirstName");
            receptionist.LastName = reader.GetString("LastName");
            receptionist.Gender = reader.GetBoolean("Gender");
            receptionist.PIN = reader.GetString("PIN");
            receptionist.Email=reader.GetString("Email");
            receptionist.PhoneNumber = reader.GetString("PhoneNumber");
            receptionist.BirthDate = reader.GetDateTime("BirthDate");
            receptionist.Salary = reader.GetDecimal("Salary");
            receptionist.CreationDate = reader.GetDateTime("CreationDate");
            receptionist.ModifierDate = reader.GetDateTime("ModifierDate");
            receptionist.IsDelete = reader.GetBoolean("IsDeleted");


            receptionist.Job = new Job()
            {
                Id = reader.GetInt32("JobId"),
                Name = reader.GetString("JobName")
            };

            receptionist.Creator = new Admin()
            {
                Id = reader.GetInt32("CreatorId")
            };
            receptionist.Modifier = new Admin()
            {
                Id = reader.GetInt32("ModifierId")
            };
            
            return receptionist;
          
        }
    }
}
