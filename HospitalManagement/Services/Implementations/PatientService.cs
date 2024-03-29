﻿using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class PatientService : IControlModelService<PatientModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Patient, PatientModel> _patientMapper;

        public PatientService(IUnitOfWork unitOfWork, IControlModelMapper<Patient, PatientModel> patientMapper)
        {
            _unitOfWork = unitOfWork;
            _patientMapper = patientMapper;
        }

        public bool Delete(int id)
        {

            var patient = _unitOfWork.PatientRepository.GetById(id);
            patient.IsDelete = true;
            patient.ModifiedDate=DateTime.Now;
            patient.Modifier = new Admin { Id = 1 };

            return _unitOfWork.PatientRepository.Update(patient);

        }

        public List<PatientModel> GetAll()
        {
            var patientModels = new List<PatientModel>();
            var patients = _unitOfWork.PatientRepository.Get();
            int no = 1;
            foreach (var patient in patients)
            {
                var patientModel = _patientMapper.Map(patient);
                patientModel.No = no++;
                patientModels.Add(patientModel);
            }

            return patientModels;
        }

        public int Save(PatientModel patientModel)
        {
            var toBeSavedPatient = _patientMapper.Map(patientModel);
            toBeSavedPatient.ModifiedDate = DateTime.Now;
            toBeSavedPatient.Modifier = new Admin() { Id = 3 };

            if (toBeSavedPatient.Id == 0)
            {
                toBeSavedPatient.CreationDate = DateTime.Now;
                toBeSavedPatient.Creator = new Admin() { Id = 3 };
                toBeSavedPatient.IsDelete = false;
                return  _unitOfWork.PatientRepository.Insert(toBeSavedPatient);
            }
            else
            {
                var existingPatient = _unitOfWork.PatientRepository.GetById(patientModel.Id);
                toBeSavedPatient.Creator = existingPatient.Creator;
                toBeSavedPatient.CreationDate = existingPatient.CreationDate;
                toBeSavedPatient.IsDelete = existingPatient.IsDelete;
                _unitOfWork.PatientRepository.Update(toBeSavedPatient);
                return toBeSavedPatient.Id;
            }
        }
        public bool IsValid(PatientModel patientModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(patientModel.Name))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.Surname))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if ((patientModel.PIN.Length < 7) || (patientModel.PIN.Length > 7))
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }
            if ((patientModel.PhoneNumber.Length < 13) || (patientModel.PhoneNumber.Length > 13))
            {
                message = ValidationMessageProvider.GetSpecificLength("Phonenumber", 13);
                return false;
            }
            if (patientModel.Gender == 0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Gender");
                return false;
            }

            message = null;
            return true;
        }

    }
}
