using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class NurseMapper : INurseMapper
    {
        public NurseModel Map(Nurse nurse)
        {
            NurseModel nurseModel = new NurseModel();

            nurseModel.Id = nurse.Id;
            nurseModel.FirstName = nurse.FirstName;
            nurseModel.LastName = nurse.LastName;
            nurseModel.BirthDate = nurse.BirthDate;
            nurseModel.PhoneNumber = nurse.PhoneNumber;
            nurseModel.Position = new PositionModel
            {
                Id = nurse.Position.Id,
                Name = nurse.Position.Name,
                DepartmentName = nurse.Position.Department.Name,
            };
            nurseModel.Email = nurse.Email;
            nurseModel.PIN = nurse.PIN;
            nurseModel.Salary = nurse.Salary;
            nurseModel.DepartmentName = nurse.Position.Department.Name;
            if (nurse.Gender) nurseModel.Gender[0] = nurse.Gender;
            else nurseModel.Gender[1] = !nurse.Gender;
         
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
            nurse.Position = new DoctorPosition()
            {
                Id = nurseModel.Position.Id,
                Name = nurseModel.Position.Name,
                Department = new Department()
                {
                    Name = nurseModel.Position.DepartmentName,
                }
            };
            
            nurse.Email = nurseModel.Email;
            nurse.PIN = nurseModel.PIN;
            nurse.Salary = nurseModel.Salary;
            nurse.Gender = nurseModel.Gender[0] ? true : false;

            return nurse;
        }
    }
}
