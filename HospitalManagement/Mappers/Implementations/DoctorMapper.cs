using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalManagement.Mappers.Implementations
{
    internal class DoctorMapper : IDoctorMapper
    {
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public DoctorMapper(IMapperUnitOfWork mapperUnitOfWork) 
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public DoctorModel Map(Doctor doctor)
        {
            DoctorModel doctorModel = new DoctorModel();
            doctorModel.Id = doctor.Id;
            doctorModel.Position = _mapperUnitOfWork.PositionMapper.Map(doctor.Position);
            doctorModel.DepartmentName = doctor.Position.Department.Name;
            doctorModel.FirstName = doctor.FirstName;
            doctorModel.LastName = doctor.LastName;
            doctorModel.Gender = doctor.Gender;
            doctorModel.BirthDate = doctor.BirthDate;
            doctorModel.PIN = doctor.PIN;
            doctorModel.Email = doctor.Email;
            doctorModel.Phonenumber = doctor.Phonenumber;
            doctorModel.Salary = doctor.Salary;
            doctorModel.IsChiefDoctor = doctor.IsChiefDoctor;

            return doctorModel;
        }

        public Doctor Map(DoctorModel doctorModel)
        {
            Doctor doctor = new Doctor();
            doctor.Id = doctorModel.Id;
            doctor.Position = _mapperUnitOfWork.PositionMapper.Map(doctorModel.Position);
            doctor.FirstName = doctorModel.FirstName;
            doctor.LastName = doctorModel.LastName;
            doctor.Gender = doctorModel.Gender;
            doctor.BirthDate = doctorModel.BirthDate;
            doctor.PIN = doctorModel.PIN;
            doctor.Email = doctorModel.Email;
            doctor.Phonenumber = doctorModel.Phonenumber;
            doctor.Salary = doctorModel.Salary;
            doctor.IsChiefDoctor = doctorModel.IsChiefDoctor;

            return doctor;
        }
    }
}
