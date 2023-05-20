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
            operationModel.Room = new RoomModel();
            operationModel.Room = _mapperUnitOfWork.RoomMapper.Map(operation.Room);
            return operationModel;
        }

        public Operation Map(OperationModel operationModel)
        {
            Operation operation = new Operation();
            operation.Id = operationModel.Id;
            operation.OperationDate = operationModel.OperationDate;
            operation.OperationCost = operationModel.OperationCost;
            operation.OperationReason = operationModel.OperationReason;
            operation.Patient = new Patient();
            operation.Patient = _mapperUnitOfWork.PatientMapper.Map(operationModel.Patient);
            operation.Room = new Room();
            operation.Room = _mapperUnitOfWork.RoomMapper.Map(operationModel.Room);
            operation.Doctors = new List<Doctor>();
            foreach (DoctorModel doctorModel in operationModel.Doctors)
            {
                Doctor doctor = _mapperUnitOfWork.DoctorMapper.Map(doctorModel);
                operation.Doctors.Add(doctor);
            }
            foreach (NurseModel nurseModel in operationModel.Nurses)
            {
                Nurse nurse = _mapperUnitOfWork.NurseMapper.Map(nurseModel);
                operation.Nurses.Add(nurse);
            }
            return operation;
        }
    }
}
