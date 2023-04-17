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
        public OperationModel Map(OperationDoctor operationDoctor, OperationModel operationModel)
        {
            DoctorModel doctorModel = new DoctorModel();
            doctorModel.FirstName = operationDoctor.Doctor.FirstName;
            doctorModel.LastName = operationDoctor.Doctor.LastName;
            doctorModel.PIN = operationDoctor.Doctor.PIN;
            operationModel.OperationDoctors.Add(doctorModel);
            return operationModel;
        }
        public OperationModel Map(OperationNurse operationNurse, OperationModel operationModel)
        {
            NurseModel nurseModel = new NurseModel();
            nurseModel.FirstName = operationNurse.Nurse.FirstName;
            nurseModel.LastName = operationNurse.Nurse.LastName;
            nurseModel.PIN = operationNurse.Nurse.PIN;
            operationModel.OperationNurses.Add(nurseModel);
            return operationModel;
        }

        public Operation Map(OperationModel operationModel)
        {
            throw new NotImplementedException();
        }
    }
}
