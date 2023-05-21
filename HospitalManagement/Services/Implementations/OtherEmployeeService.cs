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
    public class OtherEmployeeService : IControlModelService<OtherEmployeeModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<OtherEmployee,OtherEmployeeModel> _otherEmployeeMapper;
        public OtherEmployeeService(IUnitOfWork unitOfWork, IControlModelMapper<OtherEmployee, OtherEmployeeModel> otherEmployeeMapper)
        {
            _unitOfWork = unitOfWork;
            _otherEmployeeMapper = otherEmployeeMapper;
        }
        public bool Delete(int id)
        {
            var otherEmployee = _unitOfWork.OtherEmployeeRepository.GetById(id);

            otherEmployee.IsDelete = true;
            otherEmployee.ModifiedDate = DateTime.Now;
            otherEmployee.Modifier = new Admin() { Id = 3 };

            return _unitOfWork.OtherEmployeeRepository.Update(otherEmployee);
        }

        public List<OtherEmployeeModel> GetAll()
        {
            var otherEmployees = _unitOfWork.OtherEmployeeRepository.Get();
            var otherEmployeeModels = new List<OtherEmployeeModel>();
            int no = 1;
            foreach (var otherEmployee in otherEmployees)
            {
                var model = _otherEmployeeMapper.Map(otherEmployee);
                model.No = no++;
                otherEmployeeModels.Add(model);
            }
            return otherEmployeeModels;
        }

        public int Save(OtherEmployeeModel otherEmployeeModel)
        {
            var toBeSavedOtherEmployee = _otherEmployeeMapper.Map(otherEmployeeModel);

            toBeSavedOtherEmployee.ModifiedDate = DateTime.Now;
            toBeSavedOtherEmployee.Modifier = new Admin() { Id = 3 };

            if (toBeSavedOtherEmployee.Id == 0)
            {
                toBeSavedOtherEmployee.CreationDate = DateTime.Now;
                toBeSavedOtherEmployee.Creator = new Admin() { Id = 3 };
                toBeSavedOtherEmployee.IsDelete = false;
                return _unitOfWork.OtherEmployeeRepository.Insert(toBeSavedOtherEmployee);
            }
            else
            {
                var existingOtherEmployee = _unitOfWork.OtherEmployeeRepository.GetById(otherEmployeeModel.Id);
                toBeSavedOtherEmployee.CreationDate = existingOtherEmployee.CreationDate;
                toBeSavedOtherEmployee.Creator = existingOtherEmployee.Creator;
                toBeSavedOtherEmployee.IsDelete = existingOtherEmployee.IsDelete;
                _unitOfWork.OtherEmployeeRepository.Update(toBeSavedOtherEmployee);
                return toBeSavedOtherEmployee.Id;
            }
        }
        public bool IsValid(OtherEmployeeModel otherEmployeeModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (otherEmployeeModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (otherEmployeeModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 25);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.PhoneNumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (otherEmployeeModel.PhoneNumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (otherEmployeeModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }
            if (string.IsNullOrWhiteSpace(otherEmployeeModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (otherEmployeeModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
                return false;
            }
            if (otherEmployeeModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (otherEmployeeModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }

            message = null;
            return true;

        }

    }
}
