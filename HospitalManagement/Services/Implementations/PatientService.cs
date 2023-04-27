using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientMapper _patientMapper;

        public PatientService(IUnitOfWork unitOfWork, IPatientMapper patientMapper)
        {
            _unitOfWork = unitOfWork;
            _patientMapper = patientMapper;
        }

        public bool Delete(int id)
        {

            var patient = _unitOfWork.PatientRepository.GetById(id);
            patient.IsDelete = true;
            patient.ModifiedDate=DateTime.Now;
            patient.Modifier = new Admin { Id = id };

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
    }
}
