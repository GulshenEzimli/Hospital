using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IOperationMapper
    {
        OperationModel Map(Operation operation);
        OperationModel Map(OperationDoctor operationDoctor, OperationModel operationModel);
        OperationModel Map(OperationNurse operationNurse, OperationModel operationModel);
        Operation Map(OperationModel operationModel);
    }
}
