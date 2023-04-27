﻿using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
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
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public OperationService(IUnitOfWork unitOfWork, IMapperUnitOfWork mapperUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapperUnitOfWork = mapperUnitOfWork;
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
                OperationModel operationModel = _mapperUnitOfWork.OperationMapper.Map(operation);

                foreach (OperationDoctor operationDoctor in operationDoctors)
                {
                    if (operationDoctor.OperationId == operation.Id)
                    {
                        OperationDoctorModel operationDoctorModel = _mapperUnitOfWork.OperationDoctorMapper.Map(operationDoctor);
                        operationModel.OperationDoctors.Add(operationDoctorModel);
                    }
                }

                foreach (OperationNurse operationNurse in operationNurses)
                {
                    if (operationNurse.OperationId == operation.Id)
                    {
                        OperationNurseModel operationNurseModel = _mapperUnitOfWork.OperationNurseMapper.Map(operationNurse);
                        operationModel.OperationNurses.Add(operationNurseModel);
                    }
                }
                operationModel.No = no++;
                operationModels.Add(operationModel);
            }
            return operationModels;
        }
    }
}