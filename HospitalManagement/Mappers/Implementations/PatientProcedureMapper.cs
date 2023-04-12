using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
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

            patientProcedure.Patient.Name = model.PatientName;
            patientProcedure.Patient.Surname = model.PatientSurname;
            patientProcedure.Patient.PIN = model.PatientPIN;


            patientProcedure.Doctor.FirstName = model.DoctorName;
            patientProcedure.Doctor.LastName = model.DoctorSurname;
            patientProcedure.Doctor.PIN = model.DoctorPIN;

            patientProcedure.Nurse.FirstName = model.NurseName;
            patientProcedure.Nurse.LastName = model.NurseSurname;
            patientProcedure.Nurse.PIN = model.NursePIN;

            patientProcedure.Procedure.Name = model.ProcedureName;
            patientProcedure.Procedure.Cost = model.Cost;
            patientProcedure.UseDate = model.UseDate;
            return patientProcedure;
        }

        public PatientProcedureModel Map(PatientProcedure patientProcedure)
        {
            PatientProcedureModel model = new PatientProcedureModel();
            model.Id = patientProcedure.Id;

            model.PatientName = patientProcedure.Patient.Name;
            model.PatientSurname = patientProcedure.Patient.Surname;
            model.PatientPIN = patientProcedure.Patient.PIN;

            model.DoctorName = patientProcedure.Doctor.FirstName;
            model.DoctorSurname = patientProcedure.Doctor.LastName;
            model.DoctorPIN = patientProcedure.Doctor.PIN;

            model.NurseName = patientProcedure.Nurse.FirstName;
            model.NurseSurname = patientProcedure.Nurse.LastName;
            model.NursePIN = patientProcedure.Nurse.PIN;

            model.ProcedureName = patientProcedure.Procedure.Name;
            model.Cost = patientProcedure.Procedure.Cost;
            model.UseDate = patientProcedure.UseDate;

            return model;
        }
    }
}
