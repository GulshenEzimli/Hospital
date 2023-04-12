using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlPatientProcedureRepository : IPatientProcedureRepository
    {
        private readonly string _connectionString;
        public SqlPatientProcedureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Delete(int id)
        {
            using(SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"delete * from PatientProcedures where Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<PatientProcedure> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select PatientProcedures.Id as PatientProceduresId,Patients.Id as PatientId,
                                Patients.FirstName as PatientName,Patients.LastName as PatientSurname,
                                Patients.PIN as PatientPIN,Doctors.Id as DoctorId, Doctors.FirstName as DoctorName, 
                                Doctors.LastName as DoctorSurname,Doctors.PIN as DoctorPIN,
                                Nurses.Id as NurseId, Nurses.FirstName as NurseName,
                                Nurses.LastName as NurseSurname, Nurses.PIN as NursePIN,
                                Procedures.Id as ProcedureId,Procedures.Name as ProcedureName,Procedures.Cost as Cost
                                from PatientProcedures inner join Doctors on PatientProcedures.DoctorId = Doctors.Id
                                inner join Nurses on PatientProcedures.NurseId = Nurses.Id
                                inner join Patients on PatientProcedures.PatientId = Patients.Id
                                inner join Procedures on PatientProcedures.ProcedureId = Procedures.Id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<PatientProcedure> patientProcedures = new List<PatientProcedure>();
                    while (reader.Read())
                    {
                        PatientProcedure patientProcedure = GetPatientProcedure(reader);
                        patientProcedures.Add(patientProcedure);
                    }
                    return patientProcedures;
                }
            }
        }

        public PatientProcedure GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"select PatientProcedures.Id as PatientProceduresId,Patients.Id as PatientId,
                                Patients.FirstName as PatientName,Patients.LastName as PatientSurname,
                                Patients.PIN as PatientPIN,Doctors.Id as DoctorId, Doctors.FirstName as DoctorName, 
                                Doctors.LastName as DoctorSurname,Doctors.PIN as DoctorPIN,
                                Nurses.Id as NurseId, Nurses.FirstName as NurseName,
                                Nurses.LastName as NurseSurname, Nurses.PIN as NursePIN,
                                Procedures.Id as ProcedureId,Procedures.Name as ProcedureName,Procedures.Cost as Cost
                                from PatientProcedures inner join Doctors on PatientProcedures.DoctorId = Doctors.Id
                                inner join Nurses on PatientProcedures.NurseId = Nurses.Id
                                inner join Patients on PatientProcedures.PatientId = Patients.Id
                                inner join Procedures on PatientProcedures.ProcedureId = Procedures.Id
                                where PatientProcedures.Id = @id";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    PatientProcedure patientProcedure = GetPatientProcedure(reader);
                    return patientProcedure;
                }
            }
            throw new NotImplementedException();
        }

        public int Insert(PatientProcedure entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {

                }
            }
            throw new NotImplementedException();
        }

        public bool Update(PatientProcedure entity)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {

                }
            }
            throw new NotImplementedException();
        }

        private PatientProcedure GetPatientProcedure(SqlDataReader reader)
        {
            PatientProcedure patientProcedure = new PatientProcedure();

            patientProcedure.Id = reader.GetInt32("PatientProceduresId");

            patientProcedure.PatientId = reader.GetInt32("PatientId");
            patientProcedure.Patient = new Patient()
            {
                Id = patientProcedure.PatientId,
                Name = reader.GetString("PatientName"),
                Surname = reader.GetString("PatientSurname"),
                PIN = reader.GetString("PatientPIN"),
            };

            patientProcedure.DoctorId = reader.GetInt32("DoctorId");
            patientProcedure.Doctor = new Doctor()
            {
                Id = patientProcedure.DoctorId,
                FirstName = reader.GetString("DoctorName"),
                LastName = reader.GetString("DoctorSurname"),
                PIN = reader.GetString("DoctorPIN"),
            };

            patientProcedure.NurseId = reader.GetInt32("NurseId");
            patientProcedure.Nurse = new Nurse()
            {
                Id = patientProcedure.NurseId,
                FirstName = reader.GetString("NurseName"),
                LastName = reader.GetString("NurseSurname"),
                PIN = reader.GetString("NursePIN"),
            };

            patientProcedure.ProcedureId = reader.GetInt32("ProcedureId");
            patientProcedure.Procedure = new Procedure()
            {
                Id = patientProcedure.ProcedureId,
                Name = reader.GetString("ProcedureName"),
                Cost = reader.GetDecimal("Cost")
            };

            return patientProcedure;
        }
        private void AddParameters(SqlCommand command, PatientProcedure patientProcedure)
        {
            
        }
    }
}
