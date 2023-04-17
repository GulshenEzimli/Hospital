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
    public class OperationNurseMapper : IOperationNurseMapper
    {
        public OperationNurseModel Map(OperationNurse operationNurse)
        {
            OperationNurseModel operationNurseModel = new OperationNurseModel();
            operationNurseModel.NurseName = operationNurse.Nurse.FirstName;
            operationNurseModel.NurseSurname = operationNurse.Nurse.LastName;
            operationNurseModel.NursePIN = operationNurse.Nurse.PIN;
            return operationNurseModel;
        }

        public OperationNurse Map(OperationNurseModel operationNurseModel)
        {
            throw new NotImplementedException();
        }
    }
}
