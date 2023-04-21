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
        public PatientProcedure Map(PatientProcedureModel model)
        {
            PatientProcedure patientProcedure = new PatientProcedure();
            patientProcedure.Id = model.Id;
            patientProcedure.Patient = new Patient();
            patientProcedure.Patient.PIN = model.Patient.Substring(model.Patient.LastIndexOf(' ') + 1);

            patientProcedure.Doctor = new Doctor();
            patientProcedure.Doctor.PIN = model.Doctor.Substring(model.Doctor.LastIndexOf(' ') + 1);

            patientProcedure.Nurse = new Nurse(); ;
            patientProcedure.Nurse.PIN = model.Nurse.Substring(model.Nurse.LastIndexOf(' ') + 1);

            patientProcedure.Procedure = new Procedure();
            patientProcedure.Procedure.Name = model.Procedure.Substring(0, model.Procedure.LastIndexOf(' '));

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
                LastName= patientProcedure.Nurse.LastName,
                PIN= patientProcedure.Nurse.PIN,
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
