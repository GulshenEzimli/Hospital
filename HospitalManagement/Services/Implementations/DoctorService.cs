using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
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
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public DoctorService(IUnitOfWork unitOfWork, IMapperUnitOfWork mapperUnitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _mapperUnitOfWork = mapperUnitOfWork;
        }

        public bool DeleteDoctor(int id)
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
                DoctorModel doctorModel = _mapperUnitOfWork.DoctorMapper.Map(doctor);
                doctorModel.No = no++;
                doctorModels.Add(doctorModel);
            }
            return doctorModels;
        }

        public int SaveDoctor(DoctorModel doctorModel)
        {
            Doctor toBeSavedDoctor = _mapperUnitOfWork.DoctorMapper.Map(doctorModel);
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
    }
}
