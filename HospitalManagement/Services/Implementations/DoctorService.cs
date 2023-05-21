using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
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
    public class DoctorService : IControlModelService<DoctorModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Doctor,DoctorModel> _doctorMapper;
        public DoctorService(IUnitOfWork unitOfWork, IControlModelMapper<Doctor, DoctorModel> doctorMapper) 
        {
            _unitOfWork = unitOfWork;
            _doctorMapper = doctorMapper;
        }

        public bool Delete(int id)
        {
            Doctor doctor = _unitOfWork.DoctorRepository.GetById(id);
            doctor.IsDelete = true;
            doctor.ModifiedDate = DateTime.Now;
            doctor.Modifier = new Admin { Id = Kernel.Admin.Id };
            return _unitOfWork.DoctorRepository.Update(doctor);
        }

        public List<DoctorModel> GetAll()
        {
            List<DoctorModel> doctorModels = new List<DoctorModel>(); 
            List<Doctor> doctors = _unitOfWork.DoctorRepository.Get();
            int no = 1;
            foreach (Doctor doctor in doctors)
            {
                DoctorModel doctorModel = _doctorMapper.Map(doctor);
                doctorModel.No = no++;
                doctorModels.Add(doctorModel);
            }
            return doctorModels;
        }

        public int Save(DoctorModel doctorModel)
        {
            Doctor toBeSavedDoctor =_doctorMapper.Map(doctorModel);
            toBeSavedDoctor.ModifiedDate = DateTime.Now;
            toBeSavedDoctor.Modifier = new Admin() { Id = Kernel.Admin.Id };

            if (toBeSavedDoctor.Id == 0)
            {
                toBeSavedDoctor.CreationDate = DateTime.Now;
                toBeSavedDoctor.Creator = new Admin() { Id = Kernel.Admin.Id };
                return _unitOfWork.DoctorRepository.Insert(toBeSavedDoctor);
            }
            else
            {
                Doctor existingDoctor = _unitOfWork.DoctorRepository.GetById(doctorModel.Id);
                toBeSavedDoctor.CreationDate = existingDoctor.CreationDate;
                toBeSavedDoctor.Creator = existingDoctor.Creator;
                _unitOfWork.DoctorRepository.Update(toBeSavedDoctor);
                return toBeSavedDoctor.Id;
            }
        }
        public bool IsValid(DoctorModel doctorModel, out string message)
        {
            if (string.IsNullOrWhiteSpace(doctorModel.FirstName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Name");
                return false;
            }
            if (doctorModel.FirstName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Name", 26);
                return false;
            }
            if (doctorModel.FirstName.Length < 3)
            {
                message = ValidationMessageProvider.GetMinLengthMessage("Name", 2);
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctorModel.LastName))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Surname");
                return false;
            }
            if (doctorModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Surname", 26);
                return false;
            }
            if (doctorModel.LastName.Length > 25)
            {
                message = ValidationMessageProvider.GetMinLengthMessage("Surname", 2);
                return false;
            }

            if (doctorModel.Gender == 0)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Gender");
                return false;
            }

            if (string.IsNullOrEmpty(doctorModel.PIN))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PIN");
                return false;
            }
            if (doctorModel.PIN.Length != 7)
            {
                message = ValidationMessageProvider.GetSpecificLength("PIN", 7);
                return false;
            }
            foreach (char item in doctorModel.PIN)
            {
                if (item < 48 || (item > 57 && item < 65) || (item > 90 && item < 97) || item > 122)
                {
                    message = ValidationMessageProvider.GetCorrectMessage("Pin");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(doctorModel.Email))
            {
                message = ValidationMessageProvider.GetRequiredMessage("Email");
                return false;
            }
            if (doctorModel.Email.Length > 50)
            {
                message = ValidationMessageProvider.GetMaxLengthMessage("Email", 50);
                return false;
            }

            if (string.IsNullOrWhiteSpace(doctorModel.Phonenumber))
            {
                message = ValidationMessageProvider.GetRequiredMessage("PhoneNumber");
                return false;
            }
            if (doctorModel.Phonenumber.Length != 13)
            {
                message = ValidationMessageProvider.GetSpecificLength("PhoneNumber", 13);
                return false;
            }

            if (doctorModel.Salary < 0)
            {
                message = ValidationMessageProvider.GetSalaryMessage();
                return false;
            }
            if (doctorModel.Salary > 10000)
            {
                message = ValidationMessageProvider.GetSalaryMessage(10000);
                return false;
            }
            if (doctorModel.Position == null)
            {
                message = ValidationMessageProvider.GetRequiredMessage("Position");
                return false;
            }

            message = null;
            return true;
        }

    }
}
