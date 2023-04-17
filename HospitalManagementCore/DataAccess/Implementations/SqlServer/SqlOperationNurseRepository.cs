using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlOperationNurseRepository : IOperationNurseRepository
    {
        private readonly string _connectionString;
        public SqlOperationNurseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OperationNurse> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select OperationNurses.Id as OperationNurseId, Nurses.Id as NurseId, Operations.Id as OperationId,
                                   FirstName, LastName, PIN
                                   from OperationNurses 
                                   inner join Nurses on OperationNurses.NurseId = Nurses.Id
                                   inner join Operations on OperationNurses.OperationId = Operations.Id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<OperationNurse> operationNurses = new List<OperationNurse>();

                    while (reader.Read())
                    {
                        OperationNurse operationNurse = GetOperationNurse(reader);
                        operationNurses.Add(operationNurse);
                    }
                    return operationNurses;
                }
            }
        }


        public OperationNurse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(OperationNurse entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(OperationNurse entity)
        {
            throw new NotImplementedException();
        }
        private OperationNurse GetOperationNurse(SqlDataReader reader)
        {
            OperationNurse operationNurse = new OperationNurse();
            operationNurse.Id = reader.GetInt32("OperationNurseId");
            operationNurse.Nurse = new Nurse()
            {
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                PIN = reader.GetString("PIN")
            };
            operationNurse.Operation = new Operation()
            {
                Id = reader.GetInt32("OperationId")
            };
            return operationNurse;
        }
    }
}
