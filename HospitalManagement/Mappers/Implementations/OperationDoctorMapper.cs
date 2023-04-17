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
    public class OperationDoctorMapper : IOperationDoctorMapper
    {
        public OperationDoctorModel Map(OperationDoctor operationDoctor)
        {
            OperationDoctorModel operationDoctorModel = new OperationDoctorModel();
            operationDoctorModel.DoctorName = operationDoctor.Doctor.FirstName;
            operationDoctorModel.DoctorSurname = operationDoctor.Doctor.LastName;
            operationDoctorModel.DoctorPIN = operationDoctor.Doctor.PIN;
            return operationDoctorModel;
        }

        public OperationDoctor Map(OperationDoctorModel operationDoctorModel)
        {
            throw new NotImplementedException();
        }
    }
}
