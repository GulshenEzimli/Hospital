using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class OperationService : IControlModelService<OperationModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IControlModelMapper<Operation,OperationModel> _operationMapper;
        private readonly IControlModelMapper<Nurse, NurseModel> _nurseMapper;
        private readonly IControlModelMapper<Doctor, DoctorModel> _doctorMapper;
        public OperationService(IUnitOfWork unitOfWork, 
                                IControlModelMapper<Operation, OperationModel> operationMapper,
                                IControlModelMapper<Nurse, NurseModel> nurseMapper,
                                IControlModelMapper<Doctor, DoctorModel> doctorMapper)
        {
            _unitOfWork = unitOfWork;
            _operationMapper = operationMapper;
            _nurseMapper = nurseMapper;
            _doctorMapper = doctorMapper;
        }

        public bool Delete(int id)
        {
            Operation operation = _unitOfWork.OperationRepository.GetById(id);
            operation.IsDelete = true;
            return _unitOfWork.OperationRepository.Update(operation);
        }

        public List<OperationModel> GetAll()
        {
            List<OperationModel> operationModels = new List<OperationModel>();
            List<Operation> operations = _unitOfWork.OperationRepository.Get();
            List<OperationDoctor> operationDoctors = _unitOfWork.OperationDoctorRepository.Get();
            List<OperationNurse> operationNurses = _unitOfWork.OperationNurseRepository.Get();
            int no = 1;
            foreach (Operation operation in operations)
            {
                OperationModel operationModel = _operationMapper.Map(operation);

                foreach (OperationDoctor operationDoctor in operationDoctors)
                {
                    if (operationDoctor.OperationId == operation.Id)
                    {
                        Doctor doctor = operationDoctor.Doctor;
                        DoctorModel doctorModel = _doctorMapper.Map(doctor);
                        operationModel.Doctors.Add(doctorModel);
                    }
                }

                foreach (OperationNurse operationNurse in operationNurses)
                {
                    if (operationNurse.OperationId == operation.Id)
                    {
                        Nurse nurse = operationNurse.Nurse;
                        NurseModel nurseModel = _nurseMapper.Map(nurse);
                        operationModel.Nurses.Add(nurseModel);
                    }
                }
                operationModel.No = no++;
                operationModels.Add(operationModel);
            }
            return operationModels;
        }

        public int Save(OperationModel operationModel)
        {
            Operation toBeSavedOperation = _operationMapper.Map(operationModel);

            if (toBeSavedOperation.Id == 0)
            {
                return _unitOfWork.OperationRepository.Insert(toBeSavedOperation);
            }
            else
            {                
                _unitOfWork.OperationRepository.Update(toBeSavedOperation);
                return toBeSavedOperation.Id;
            }
        }
    }
}
