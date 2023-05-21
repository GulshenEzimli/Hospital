using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models.Implementations;
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
    }
}
