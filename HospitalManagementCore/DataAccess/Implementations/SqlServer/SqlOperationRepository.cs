using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlOperationRepository : IOperationRepository
    {
        private readonly string _connectionString;
        public SqlOperationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Operation> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select Operations.Id as OperationId, Patients.Id as PatientId, Rooms.Id as RoomId, OperationDate, OperationCost, OperationReason,
                                   CreatorId, ModifierId, Gender, BirthDate, PhoneNumber, CreationDate, ModifiedDate, IsDelete, FirstName, LastName, PIN, 
                                   Number, BlockFloor, IsAvailable, Type
                                   from Operations 
                                   inner join Patients on Operations.PatientId = Patients.Id
                                   inner join Rooms on Operations.RoomId = Rooms.Id where IsDelete = 0";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Operation> operations = new List<Operation>();

                    while (reader.Read())
                    {
                        Operation operation = GetOperation(reader);
                        operations.Add(operation);
                    }
                    return operations;
                }
            }
        }
        public Operation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Operation entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Operation entity)
        {
            throw new NotImplementedException();
        }

        private Operation GetOperation(SqlDataReader reader)
        {
            Operation operation = new Operation();
            operation.Id = reader.GetInt32("OperationId");
            operation.OperationDate = reader.GetDateTime("OperationDate");
            operation.OperationCost = reader.GetDecimal("OperationCost");
            operation.OperationReason = reader.GetString("OperationReason");
            operation.Patient = new Patient()
            {
                Id = reader.GetInt32("PatientId"),
                Creator = new Admin()
                {
                    Id = reader.GetInt32("CreatorId")
                },
                Modifier = new Admin()
                {
                    Id = reader.GetInt32("ModifierId")
                },
                Gender= reader.GetBoolean("Gender"),
                BirthDate= reader.GetDateTime("BirthDate"),
                Name = reader.GetString("FirstName"),
                Surname = reader.GetString("LastName"),
                PIN = reader.GetString("PIN"),
                PhoneNumber = reader.GetString("PhoneNumber"),
                CreationDate= reader.GetDateTime("CreationDate"),
                ModifiedDate= reader.GetDateTime("ModifiedDate"),
                IsDelete= reader.GetBoolean("IsDelete")
            };
            operation.Room = new Room()
            {
                Id = reader.GetInt32("RoomId"),
                Number = reader.GetInt32("Number"),
                BlockFloor = reader.GetInt32("BlockFloor"),
                Type = reader.GetByte("Type"),
                IsAvailable = reader.GetBoolean("IsAvailable")
            };
            return operation;
        }
    }
}
