using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlQueueRepository : IQueueRepository
    {
        private readonly string _connectionString;
        public SqlQueueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from Queues where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Queue> Get()
        {
            throw new NotImplementedException();
        }

        public Queue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Queue entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Queue entity)
        {
            throw new NotImplementedException();
        }
    }
}
