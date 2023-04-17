using HospitalManagement.Models;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Mappers.Interfaces
{
    public interface IOperationDoctorMapper
    {
        OperationDoctorModel Map(OperationDoctor operationDoctor);
        OperationDoctor Map(OperationDoctorModel operationDoctorModel);
    }
}
