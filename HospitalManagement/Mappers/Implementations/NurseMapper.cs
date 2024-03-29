﻿using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class NurseMapper : IControlModelMapper<Nurse, NurseModel>
    {
        private readonly IControlModelMapper<DoctorPosition, PositionModel> _positionMapper;
        public NurseMapper(IControlModelMapper<DoctorPosition, PositionModel> positionMapper)
        {
            _positionMapper = positionMapper;
        }
        public NurseModel Map(Nurse nurse)
        {
            NurseModel nurseModel = new NurseModel();

            nurseModel.Id = nurse.Id;
            nurseModel.FirstName = nurse.FirstName;
            nurseModel.LastName = nurse.LastName;
            nurseModel.BirthDate = nurse.BirthDate;
            nurseModel.PhoneNumber = nurse.PhoneNumber;
            nurseModel.Position = _positionMapper.Map(nurse.Position);
            nurseModel.Email = nurse.Email;
            nurseModel.PIN = nurse.PIN;
            nurseModel.Salary = nurse.Salary;
            nurseModel.DepartmentName = nurse.Position.Department.Name;
            nurseModel.Gender = nurse.Gender;

            return nurseModel;
        }

        public Nurse Map(NurseModel nurseModel)
        {
            Nurse nurse = new Nurse();

            nurse.Id = nurseModel.Id;
            nurse.FirstName = nurseModel.FirstName;
            nurse.LastName = nurseModel.LastName;
            nurse.BirthDate = nurseModel.BirthDate;
            nurse.PhoneNumber = nurseModel.PhoneNumber;
            nurse.Position = _positionMapper.Map(nurseModel.Position);
            nurse.Email = nurseModel.Email;
            nurse.PIN = nurseModel.PIN;
            nurse.Salary = nurseModel.Salary;
            nurse.Gender = nurseModel.Gender;

            return nurse;
        }
    }
}
