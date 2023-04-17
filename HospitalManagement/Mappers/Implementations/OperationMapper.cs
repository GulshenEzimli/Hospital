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
        public OperationModel Map(Operation operation)
        {
            OperationModel operationModel = new OperationModel();
            operationModel.Id = operation.Id;
            operationModel.OperationDate = operation.OperationDate;
            operationModel.OperationCost = operation.OperationCost;
            operationModel.OperationReason = operation.OperationReason;
            operationModel.PatientName = operation.Patient.Name;
            operationModel.PatientSurname = operation.Patient.Surname;
            operationModel.PatientPIN = operation.Patient.PIN;
            operationModel.PatientPhoneNumber = operation.Patient.PhoneNumber;
            operationModel.RoomNumber = operation.Room.Number;
            operationModel.RoomFloor = operation.Room.BlockFloor;
            operationModel.RoomType = operation.Room.Type;
            return operationModel;
        }

        public Operation Map(OperationModel operationModel)
        {
            throw new NotImplementedException();
        }
    }
}
