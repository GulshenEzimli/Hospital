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
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public OperationDoctorMapper(IMapperUnitOfWork mapperUnitOfWork) 
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public OperationDoctorModel Map(OperationDoctor operationDoctor)
        {
            OperationDoctorModel operationDoctorModel = new OperationDoctorModel();
            operationDoctorModel.Doctor = new DoctorModel();
            operationDoctorModel.Doctor = _mapperUnitOfWork.DoctorMapper.Map(operationDoctor.Doctor);
            return operationDoctorModel;
        }

        public OperationDoctor Map(OperationDoctorModel operationDoctorModel)
        {
            throw new NotImplementedException();
        }
    }
}
