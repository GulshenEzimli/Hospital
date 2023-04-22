using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class PatientProcedureMapper : IPatientProcedureMapper
    {
        public PatientProcedure Map(PatientProcedureModel patientProcedureModel)
        {
            PatientProcedure patientProcedure = new PatientProcedure();
            patientProcedure.Id = patientProcedureModel.Id;
            patientProcedure.Patient = new Patient()
            {
                Id = patientProcedureModel.Patient.Id,
            };

            patientProcedure.Doctor = new Doctor()
            {
                Id= patientProcedureModel.Doctor.Id,
            };

            patientProcedure.Nurse = new Nurse()
            {
                Id = patientProcedureModel.Nurse.Id,
            };

            patientProcedure.Procedure = new Procedure()
            {
                Id = patientProcedureModel.Procedure.Id,
            };

            return patientProcedure;
        }

        public PatientProcedureModel Map(PatientProcedure patientProcedure)
        {
            PatientProcedureModel patientProcedureModel = new PatientProcedureModel();

            patientProcedureModel.Id = patientProcedure.Id;
            patientProcedureModel.Patient = new PatientModel()
            {
                Id = patientProcedure.Patient.Id,
                Name = patientProcedure.Patient.Name,
                Surname = patientProcedure.Patient.Surname,
                PIN = patientProcedure.Patient.PIN,
            };
            patientProcedureModel.Doctor = new DoctorModel()
            {
                Id = patientProcedure.Doctor.Id,
                FirstName = patientProcedure.Doctor.FirstName,
                LastName = patientProcedure.Doctor.LastName,
                PIN = patientProcedure.Doctor.PIN,
            };
            patientProcedureModel.Nurse = new NurseModel()
            {
                Id = patientProcedure.Nurse.Id,
                FirstName = patientProcedure.Nurse.FirstName,
                LastName = patientProcedure.Nurse.LastName,
                PIN = patientProcedure.Nurse.PIN,
            };
            patientProcedureModel.Procedure = new ProcedureModel()
            {
                Id = patientProcedure.Procedure.Id,
                Name = patientProcedure.Procedure.Name,
                Cost = patientProcedure.Procedure.Cost,
            };
            patientProcedureModel.UseDate = patientProcedure.UseDate;

            return patientProcedureModel;
        }
    }
}
