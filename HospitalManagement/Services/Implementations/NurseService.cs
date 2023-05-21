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
    public class NurseService : IControlModelService<NurseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Nurse,NurseModel> _nurseMapper;
        public NurseService(IUnitOfWork unitOfWork, IControlModelMapper<Nurse, NurseModel> nurseMapper)
        {
            _unitOfWork = unitOfWork;
            _nurseMapper = nurseMapper;
        }
        public bool Delete(int id)
        {
            
            var nurse = _unitOfWork.NurseRepository.GetById(id);

            nurse.IsDelete = true;
            nurse.ModifiedDate = DateTime.Now;
            nurse.Modifier = new Admin() { Id = 3 };

            return _unitOfWork.NurseRepository.Update(nurse);
        }

        public List<NurseModel> GetAll()
        {
            var nurseModels = new List<NurseModel>();
            var nurses = _unitOfWork.NurseRepository.Get();
            int no = 1;

            foreach (var nurse in nurses)
            {
                var nurseModel = _nurseMapper.Map(nurse);
                nurseModel.No = no++;
                nurseModels.Add(nurseModel);
            }
            
            return nurseModels;
        }

        public int Save(NurseModel nurseModel)
        {
            var toBeSavedNurse = _nurseMapper.Map(nurseModel);
            toBeSavedNurse.ModifiedDate = DateTime.Now;
            toBeSavedNurse.Modifier = new Admin() { Id = 3 };

            if (toBeSavedNurse.Id == 0)
            {
                toBeSavedNurse.CreationDate = DateTime.Now;
                toBeSavedNurse.Creator = new Admin() { Id = 3 };
                toBeSavedNurse.IsDelete = false;
                return _unitOfWork.NurseRepository.Insert(toBeSavedNurse);
            }
            else
            {
                var existingNurse = _unitOfWork.NurseRepository.GetById(nurseModel.Id);
                toBeSavedNurse.Creator = existingNurse.Creator;
                toBeSavedNurse.CreationDate = existingNurse.CreationDate;
                toBeSavedNurse.IsDelete = existingNurse.IsDelete;
                _unitOfWork.NurseRepository.Update(toBeSavedNurse);
                return toBeSavedNurse.Id;
            }
        }
        public bool IsValid(NurseModel nurseModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(nurseModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (nurseModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(nurseModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (nurseModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 25);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (nurseModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrEmpty(nurseModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (nurseModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nurseModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (nurseModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
                return false;
            }

            if (nurseModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (nurseModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;
        }

    }
}
