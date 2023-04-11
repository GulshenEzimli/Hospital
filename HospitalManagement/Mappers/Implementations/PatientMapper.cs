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
    public class PatientMapper : IPatientMapper
    {

        public PatientModel Map(Patient patient)
        {
            var patientModel = new PatientModel();
            patientModel.Id = patient.Id;
            patientModel.Name = patient.Name;
            patientModel.Surname = patient.Surname;
            patientModel.PhoneNumber = patient.PhoneNumber;
            patientModel.Gender = patient.Gender ;
            patientModel.BirthDate = patient.BirthDate;
            patientModel.PIN = patient.PIN;
            return patientModel;
        }

        public Patient Map(PatientModel patientModel)
        {
            var patient = new Patient();
            patient.Id = patientModel.Id;
            patient.Name = patientModel.Name;
            patient.Surname = patientModel.Surname;
            patient.PhoneNumber = patientModel.PhoneNumber;
            patient.Gender = patientModel.Gender;
            patient.BirthDate = patientModel.BirthDate;
            patient.PIN=patientModel.PIN;

            return patient;
        }
    }
}
