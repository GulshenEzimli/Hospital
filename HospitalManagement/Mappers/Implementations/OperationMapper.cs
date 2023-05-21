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
    public class OperationMapper : IControlModelMapper<Operation, OperationModel>
    {
        private readonly IControlModelMapper<Patient, PatientModel> _patientMapper;
        private readonly IControlModelMapper<Room, RoomModel> _roomMapper;
        private readonly IControlModelMapper<Nurse, NurseModel> _nurseMapper;
        private readonly IControlModelMapper<Doctor, DoctorModel> _doctorMapper;
        public OperationMapper(IControlModelMapper<Patient, PatientModel> patientMapper,
                                IControlModelMapper<Room, RoomModel> roomMapper,
                                IControlModelMapper<Nurse, NurseModel> nurseMapper,
                                IControlModelMapper<Doctor, DoctorModel> doctorMapper)
        {
            _patientMapper = patientMapper;
            _roomMapper = roomMapper;
            _nurseMapper = nurseMapper;
            _doctorMapper = doctorMapper;
        }
        public OperationModel Map(Operation operation)
        {
            OperationModel operationModel = new OperationModel();
            operationModel.Id = operation.Id;
            operationModel.OperationDate = operation.OperationDate;
            operationModel.OperationCost = operation.OperationCost;
            operationModel.OperationReason = operation.OperationReason;
            operationModel.Patient = new PatientModel();
            operationModel.Patient = _patientMapper.Map(operation.Patient);
            operationModel.Room = new RoomModel();
            operationModel.Room =_roomMapper.Map(operation.Room);
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
            operation.Patient =_patientMapper.Map(operationModel.Patient);
            operation.Room = new Room();
            operation.Room = _roomMapper.Map(operationModel.Room);
            operation.Doctors = new List<Doctor>();
            foreach (DoctorModel doctorModel in operationModel.Doctors)
            {
                Doctor doctor = _doctorMapper.Map(doctorModel);
                operation.Doctors.Add(doctor);
            }
            foreach (NurseModel nurseModel in operationModel.Nurses)
            {
                Nurse nurse = _nurseMapper.Map(nurseModel);
                operation.Nurses.Add(nurse);
            }
            return operation;
        }
    }
}
