using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDoctorRepository DoctorRepository => new SqlDoctorRepository(_connectionString);

        public INurseRepository NurseRepository => new SqlNurseRepository(_connectionString);

        public IOtherEmployeeRepository OtherEmployeeRepository =>new SqlOtherEmployeeRepository(_connectionString);

        public IPatientProcedureRepository PatientProcedureRepository => new SqlPatientProcedureRepository(_connectionString);

        public IReceptionistRepository ReceptionistRepository => throw new NotImplementedException();

        public IPatientRepository PatientRepository=>new SqlPatientRepository(_connectionString);

        public IProcedureRepository ProcedureRepository => new SqlProcedureRepository(_connectionString);
    }
}
