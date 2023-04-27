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
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public OperationNurseMapper(IMapperUnitOfWork mapperUnitOfWork) 
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public OperationNurseModel Map(OperationNurse operationNurse)
        {
            OperationNurseModel operationNurseModel = new OperationNurseModel();
            operationNurseModel.Nurse = new NurseModel();
            operationNurseModel.Nurse = _mapperUnitOfWork.NurseMapper.Map(operationNurse.Nurse);
            return operationNurseModel;
        }

        public OperationNurse Map(OperationNurseModel operationNurseModel)
        {
            throw new NotImplementedException();
        }
    }
}
