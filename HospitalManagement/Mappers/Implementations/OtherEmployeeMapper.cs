using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class OtherEmployeeMapper : IControlModelMapper<OtherEmployee, OtherEmployeeModel>
    {
        private readonly IControlModelMapper<Job, JobModel> _jobMapper;
        public OtherEmployeeMapper(IControlModelMapper<Job, JobModel> jobMapper)
        {
            _jobMapper = jobMapper;
        }
        public OtherEmployeeModel Map(OtherEmployee otherEmployee)
        {
            OtherEmployeeModel model= new OtherEmployeeModel();

            model.Id = otherEmployee.Id;
            model.FirstName = otherEmployee.FirstName;
            model.LastName = otherEmployee.LastName;
            model.Email = otherEmployee.Email;
            model.Salary = otherEmployee.Salary;
            model.PhoneNumber = otherEmployee.PhoneNumber; 
            model.BirthDate = otherEmployee.BirthDate;
            model.PIN = otherEmployee.PIN;
            model.Gender = otherEmployee.Gender;
            model.Job = _jobMapper.Map(otherEmployee.Job);
            return model;
        }

        public OtherEmployee Map(OtherEmployeeModel model)
        {
            OtherEmployee otherEmployee = new OtherEmployee();

            otherEmployee.Id = model.Id;
            otherEmployee.FirstName = model.FirstName;
            otherEmployee.LastName = model.LastName;
            otherEmployee.Email = model.Email;
            otherEmployee.Salary = model.Salary;
            otherEmployee.PhoneNumber = model.PhoneNumber;
            otherEmployee.BirthDate = model.BirthDate;
            otherEmployee.PIN = model.PIN;
            otherEmployee.Gender = model.Gender;
            otherEmployee.Job = _jobMapper.Map(model.Job);
            
            return otherEmployee;
        }
    }
}
