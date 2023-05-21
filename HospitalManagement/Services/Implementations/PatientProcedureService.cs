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
    public class PatientProcedureService : IControlModelService<PatientProcedureModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<PatientProcedure,PatientProcedureModel> _patientProcedureMapper;
        public PatientProcedureService(IUnitOfWork unitOfWork, IControlModelMapper<PatientProcedure, PatientProcedureModel> patientProcedureMapper)
        {
            _unitOfWork = unitOfWork;
            _patientProcedureMapper = patientProcedureMapper;
        }
        public bool Delete(int id)
        {
            return _unitOfWork.PatientProcedureRepository.Delete(id);
        }

        public List<PatientProcedureModel> GetAll()
        {
            var patientProcedures = _unitOfWork.PatientProcedureRepository.Get();
            var patientProcedureModels = new List<PatientProcedureModel>(); 
            int no = 1;
            foreach (var patientProcedure in patientProcedures)
            {
                var model = _patientProcedureMapper.Map(patientProcedure);
                model.No = no++;
                patientProcedureModels.Add(model);
            }
            return patientProcedureModels;  
        }

        public int Save(PatientProcedureModel patientProcedureModel)
        {
            var toBeSavedPatientProcedure =_patientProcedureMapper.Map(patientProcedureModel);

            if (toBeSavedPatientProcedure.Id == 0)
            {
                return _unitOfWork.PatientProcedureRepository.Insert(toBeSavedPatientProcedure);
            }
            else
            {
                _unitOfWork.PatientProcedureRepository.Update(toBeSavedPatientProcedure);
                return toBeSavedPatientProcedure.Id;
            }
        }

        public bool IsValid(PatientProcedureModel patientProcedureModel, out string message)
        {
            if (string.IsNullOrEmpty(patientProcedureModel.Patient.DisplayPatient))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Patient value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.Doctor.DisplayDoctor))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Doctor value");
                return false;
            }

            if (string.IsNullOrEmpty(patientProcedureModel.Nurse.DisplayNurse))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Nurse value");
                return false;
            }
            if (string.IsNullOrEmpty(patientProcedureModel.Procedure.DisplayProcedure))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Procedure value");
                return false;
            }

            message = null;
            return true;
        }

    }
}
