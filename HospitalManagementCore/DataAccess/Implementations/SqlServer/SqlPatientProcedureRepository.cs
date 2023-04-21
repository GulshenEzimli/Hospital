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
            using(SqlConnection connection = new SqlConnection(_connectionString))
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
                string cmdText = @"select PatientProcedures.Id as PatientProceduresId,UseDate,Patients.Id as PatientId,
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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"select PatientProcedures.Id as PatientProceduresId,UseDate,Patients.Id as PatientId,
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
        }

        public int Insert(PatientProcedure patientProcedure)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"insert into PatientProcedures output inserted.Id (PatientId,DoctorId,NurseId,ProcedureId,UseDate) 
                                values((select Id from Patients where Patients.PIN=@patientPin),
                                (select Id from Doctors where Doctors.PIN=@doctorPin),
                                (select Id from Nurses where Nurses.PIN=@nursePin),
                                (select Id from Procedures where Procedures.Name=@procedureName),@useDate)";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, patientProcedure);
                    return (int) command.ExecuteScalar();
                }
            }
        }

        public bool Update(PatientProcedure patientProcedure)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"update PatientProcedures set PatientId=(select Id from Patients where Patients.PIN=@patientPin), 
                                DoctorId = (select Id from Doctors where Doctors.PIN=@doctorPin),
                                NurseId = (select Id from Nurses where Nurses.PIN=@nursePin),
                                ProcedureId=(select Id from Procedures where Procedures.Name=@procedureName), UseDate=@usedate";
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    AddParameters(command, patientProcedure);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        private PatientProcedure GetPatientProcedure(SqlDataReader reader)
        {
            PatientProcedure patientProcedure = new PatientProcedure();

            patientProcedure.Id = reader.GetInt32("PatientProceduresId");

            patientProcedure.Patient = new Patient()
            {
                Id = reader.GetInt32("PatientId"),
                Name = reader.GetString("PatientName"),
                Surname = reader.GetString("PatientSurname"),
                PIN = reader.GetString("PatientPIN"),
            };

            patientProcedure.Doctor = new Doctor()
            {
                Id = reader.GetInt32("DoctorId"),
                FirstName = reader.GetString("DoctorName"),
                LastName = reader.GetString("DoctorSurname"),
                PIN = reader.GetString("DoctorPIN"),
            };

            patientProcedure.Nurse = new Nurse()
            {
                Id = reader.GetInt32("NurseId"),
                FirstName = reader.GetString("NurseName"),
                LastName = reader.GetString("NurseSurname"),
                PIN = reader.GetString("NursePIN"),
            };
             
            patientProcedure.Procedure = new Procedure()
            {
                Id = reader.GetInt32("ProcedureId"),
                Name = reader.GetString("ProcedureName"),
                Cost = reader.GetDecimal("Cost")
            };
            patientProcedure.UseDate = reader.GetDateTime("UseDate");

            return patientProcedure;
        }
        private void AddParameters(SqlCommand command, PatientProcedure patientProcedure)
        {
            command.Parameters.AddWithValue("patientPin",patientProcedure.Patient.PIN);
            command.Parameters.AddWithValue("doctorPin",patientProcedure.Doctor.PIN);
            command.Parameters.AddWithValue("nursePin",patientProcedure.Nurse.PIN); 
            command.Parameters.AddWithValue("procedureName",patientProcedure.Procedure.Name); 
            command.Parameters.AddWithValue("useDate",patientProcedure.UseDate); 
        }
    }
}
