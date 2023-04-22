using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
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
            throw new NotImplementedException();
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
    }
}
