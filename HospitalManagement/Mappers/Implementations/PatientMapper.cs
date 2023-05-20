using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class PatientMapper : IPatientMapper
    {

        public PatientModel Map(Patient patient)
        {
            var patientModel = new PatientModel();
            patientModel.Id = patient.Id;
            patientModel.Name = patient.Name;
            patientModel.Surname = patient.Surname;
            patientModel.PhoneNumber = patient.PhoneNumber;
            patientModel.BirthDate = patient.BirthDate;
            patientModel.PIN = patient.PIN;
            patientModel.IsDelete = patient.IsDelete;
            patientModel.Gender = patient.Gender;
            return patientModel;
        }

        public Patient Map(PatientModel patientModel)
        {
            var patient = new Patient();
            patient.Id = patientModel.Id;
            patient.Name = patientModel.Name;
            patient.Surname = patientModel.Surname;
            patient.PhoneNumber = patientModel.PhoneNumber;
            patient.BirthDate = patientModel.BirthDate;
            patient.PIN=patientModel.PIN;
            patient.IsDelete = patientModel.IsDelete;
            patient.Gender = patientModel.Gender;
            return patient;
        }
    }
}
