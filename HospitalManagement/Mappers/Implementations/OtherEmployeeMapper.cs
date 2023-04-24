using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class OtherEmployeeMapper : IOtherEmployeeMapper
    {
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
            if(otherEmployee.Gender) model.Gender[0] = otherEmployee.Gender;
            else model.Gender[1] = !otherEmployee.Gender;
            //model.JobName = otherEmployee.Job.Name;

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
            otherEmployee.Gender = model.Gender[0] ? true : false;
            //otherEmployee.Job = new Job()
            //{
            //    Name = model.JobName,
            //};

            return otherEmployee;
        }
    }
}
