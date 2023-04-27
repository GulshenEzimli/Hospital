using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlOperationDoctorRepository : IOperationDoctorRepository
    {
        private readonly string _connectionString;
        public SqlOperationDoctorRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OperationDoctor> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select OperationDoctors.Id as OperationDoctorId, Doctors.Id as DoctorId, Operations.Id as OperationId,
                                   FirstName, LastName, PIN, PositionId, 
                                   (select DepartmentId from DoctorPositions where DoctorPositions.Id = Doctors.PositionId) as DoctorDepartmentId
                                   from OperationDoctors 
                                   inner join Doctors on OperationDoctors.DoctorId = Doctors.Id
                                   inner join Operations on OperationDoctors.OperationId = Operations.Id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<OperationDoctor> operationDoctors = new List<OperationDoctor>();

                    while (reader.Read())
                    {
                        OperationDoctor operationDoctor = GetOperationDoctor(reader);
                        operationDoctors.Add(operationDoctor);
                    }
                    return operationDoctors;
                }
            }
        }

        public OperationDoctor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(OperationDoctor entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(OperationDoctor entity)
        {
            throw new NotImplementedException();
        }


        private OperationDoctor GetOperationDoctor(SqlDataReader reader)
        {
            OperationDoctor operationDoctor = new OperationDoctor();
            operationDoctor.Id = reader.GetInt32("OperationDoctorId");
            operationDoctor.Doctor = new Doctor()
            {
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                PIN = reader.GetString("PIN"),
                Position = new DoctorPosition() 
                {
                     Id = reader.GetInt32("PositionId"),
                     Department = new Department()
                     {
                         Id = reader.GetInt32("DoctorDepartmentId")
                     }
                }
            };
            operationDoctor.Operation = new Operation()
            {
                Id = reader.GetInt32("OperationId")
            };
            return operationDoctor;
        }
    }
}
