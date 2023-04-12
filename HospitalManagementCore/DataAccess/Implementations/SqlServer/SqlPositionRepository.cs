using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlPositionRepository : IPositionRepoitory
    {
        private readonly string _connectionString;
        public SqlPositionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DoctorPosition> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select DoctorPositions.Id as PositionId, Departments.Id as DepartmentId, PositionName, DepartmentName
                                   from DoctorPositions
                                   inner join Departments on DoctorPositions.DepartmentId = Departments.Id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<DoctorPosition> positions = new List<DoctorPosition>();

                    while (reader.Read())
                    {
                        DoctorPosition position = GetPosition(reader);
                        positions.Add(position);
                    }
                    return positions;
                }
            }
        }

        public DoctorPosition GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(DoctorPosition entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DoctorPosition entity)
        {
            throw new NotImplementedException();
        }
        private DoctorPosition GetPosition(SqlDataReader reader)
        {
            DoctorPosition position = new DoctorPosition();
            position.Id = reader.GetInt32("PositionId");
            position.Name = reader.GetString("PositionName");
            position.DepartmentId = reader.GetInt32("DepartmentId");
            position.Department = new Department()
            {
                Id = reader.GetInt32("DepartmentId"),
                Name = reader.GetString("DepartmentName")
            };
            return position;
        }
    }
}
