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
            patientProcedure.Doctor.PIN = model.Doctor.Substring(model.Doctor.LastIndexOf(' ') +1);

            patientProcedure.Nurse = new Nurse();;
            patientProcedure.Nurse.PIN = model.Nurse.Substring(model.Nurse.LastIndexOf(' ') +1);

            patientProcedure.Procedure = new Procedure();
            patientProcedure.Procedure.Name = model.Procedure.Substring(0,model.Procedure.LastIndexOf(' '));

            patientProcedure.UseDate = model.UseDate;
            return patientProcedure;
        }

        public PatientProcedureModel Map(PatientProcedure patientProcedure)
        {
            PatientProcedureModel patientProcedureModel = new PatientProcedureModel();
            patientProcedureModel.Id = patientProcedure.Id;
            patientProcedureModel.Patient = $"{patientProcedure.Patient.Name} {patientProcedure.Patient.Surname} {patientProcedure.Patient.PIN}";
            patientProcedureModel.Doctor = $"{patientProcedure.Doctor.FirstName} {patientProcedure.Doctor.LastName} {patientProcedure.Doctor.PIN}";
            patientProcedureModel.Nurse = $"{patientProcedure.Nurse.FirstName} {patientProcedure.Nurse.LastName} {patientProcedure.Nurse.PIN}";
            patientProcedureModel.ProcedureName = patientProcedure.Procedure.Name;
            patientProcedureModel.Cost = patientProcedure.Procedure.Cost;
            patientProcedureModel.UseDate = patientProcedure.UseDate;

            return patientProcedureModel;
        }
    }
}
