using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagement.Services.Implementations
{
    public class ReceptionistService : IControlModelService<ReceptionistModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Receptionist,ReceptionistModel> _receptionistMapper;

        public ReceptionistService(IUnitOfWork unitOfWork, IControlModelMapper<Receptionist, ReceptionistModel> receptionistMapper)
        {
            _unitOfWork = unitOfWork;
            _receptionistMapper = receptionistMapper;
        }

        public bool Delete(int id)
        {
            var receptionist = _unitOfWork.ReceptionistRepository.GetById(id);

            receptionist.IsDelete = true;
            receptionist.ModifierDate = DateTime.Now;
            receptionist.Modifier = new Admin() { Id = 3 };

            return _unitOfWork.ReceptionistRepository.Update(receptionist);
        }

        public List<ReceptionistModel> GetAll()
        {
            var receptionistModels = new List<ReceptionistModel>();
            var receptionists = _unitOfWork.ReceptionistRepository.Get();
            int no = 1;

            foreach (var receptionist in receptionists)
            {
                var receptionistModel = _receptionistMapper.Map(receptionist);
                receptionistModel.No = no++;
                receptionistModels.Add(receptionistModel);
            }

            return receptionistModels;
        }

        public int Save(ReceptionistModel receptionistModel)
        {
            var toBeSavedReceptionist = _receptionistMapper.Map(receptionistModel);
            toBeSavedReceptionist.ModifierDate = DateTime.Now;
            toBeSavedReceptionist.Modifier = new Admin() { Id = 3 };

            if (toBeSavedReceptionist.Id == 0)
            {
                toBeSavedReceptionist.CreationDate = DateTime.Now;
                toBeSavedReceptionist.Creator = new Admin() { Id = 3 };
                toBeSavedReceptionist.IsDelete = false;
                return _unitOfWork.ReceptionistRepository.Insert(toBeSavedReceptionist);
            }
            else
            {
                var existingReceptionist = _unitOfWork.ReceptionistRepository.GetById(receptionistModel.Id);
                toBeSavedReceptionist.Creator = existingReceptionist.Creator;
                toBeSavedReceptionist.CreationDate = existingReceptionist.CreationDate;
                toBeSavedReceptionist.IsDelete = existingReceptionist.IsDelete;
                _unitOfWork.ReceptionistRepository.Update(toBeSavedReceptionist);
                return toBeSavedReceptionist.Id;
            }
        }

        public bool IsValid(ReceptionistModel receptionistModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(receptionistModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (receptionistModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(receptionistModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (receptionistModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 25);
                return false;
            }

            if (string.IsNullOrWhiteSpace(receptionistModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (receptionistModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrEmpty(receptionistModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (receptionistModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }

            if (string.IsNullOrWhiteSpace(receptionistModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (receptionistModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
                return false;
            }

            if (receptionistModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (receptionistModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;
        }

    }
}
