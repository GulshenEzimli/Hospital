using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
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
    public class OtherEmployeeService : IControlModelService<OtherEmployeeModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        public OtherEmployeeService(IUnitOfWork unitOfWork, IOtherEmployeeMapper otherEmployeeMapper)
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
    }
}
