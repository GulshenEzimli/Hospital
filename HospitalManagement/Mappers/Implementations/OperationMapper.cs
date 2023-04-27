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
    public class OperationMapper : IOperationMapper
    {
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public OperationMapper(IMapperUnitOfWork mapperUnitOfWork) 
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public OperationModel Map(Operation operation)
        {
            OperationModel operationModel = new OperationModel();
            operationModel.Id = operation.Id;
            operationModel.OperationDate = operation.OperationDate;
            operationModel.OperationCost = operation.OperationCost;
            operationModel.OperationReason = operation.OperationReason;
            operationModel.Patient = new PatientModel();
            operationModel.Patient = _mapperUnitOfWork.PatientMapper.Map(operation.Patient);
            //operationModel.Room = new RoomModel();
            //operationModel.Room = _mapperUnitOfWork.DoctorMapper.Map(patientProcedure.Doctor);
            return operationModel;
        }

        public Operation Map(OperationModel operationModel)
        {
            throw new NotImplementedException();
        }
    }
}
