using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Implementations
{
    public class ReceptionistMapper : IControlModelMapper<Receptionist,ReceptionistModel>
    {
        public ReceptionistModel Map(Receptionist receptionist)
        {
            ReceptionistModel receptionistModel = new ReceptionistModel();

            receptionistModel.Id = receptionist.Id;
            receptionistModel.FirstName = receptionist.FirstName;
            receptionistModel.LastName = receptionist.LastName;
            receptionistModel.BirthDate = receptionist.BirthDate;
            receptionistModel.PhoneNumber = receptionist.PhoneNumber;
            receptionistModel.JobName = receptionist.Job.Name;
            receptionistModel.Email = receptionist.Email;
            receptionistModel.PIN = receptionist.PIN;
            receptionistModel.Salary = receptionist.Salary;
            receptionistModel.JobName = receptionist.Job.Name;
            if (receptionist.Gender) receptionistModel.Gender[0] = receptionist.Gender;
            else receptionistModel.Gender[1] = !receptionist.Gender;

            return receptionistModel;
        }

        public Receptionist Map(ReceptionistModel receptionistModel)
        {
            Receptionist receptionist = new Receptionist();


            receptionist.Id = receptionistModel.Id;
            receptionist.FirstName = receptionistModel.FirstName;
            receptionist.LastName = receptionistModel.LastName;
            receptionist.BirthDate = receptionistModel.BirthDate;
            receptionist.PhoneNumber = receptionistModel.PhoneNumber;
            receptionist.Job = new Job();
            receptionist.Job.Name = receptionistModel.JobName;
            receptionist.Email = receptionistModel.Email;
            receptionist.PIN = receptionistModel.PIN;
            receptionist.Salary = receptionistModel.Salary;
            receptionist.Gender = receptionistModel.Gender[0] ? true : false;

            return receptionist;
        }
    }
    
}
