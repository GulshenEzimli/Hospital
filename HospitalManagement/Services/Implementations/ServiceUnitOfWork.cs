﻿using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Services.Interfaces;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Services.Implementations
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public ServiceUnitOfWork(IUnitOfWork unitOfWork, IMapperUnitOfWork mapperUnitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public INurseService nurseService =>  new NurseService(_unitOfWork, _mapperUnitOfWork.NurseMapper);
         
        public IOtherEmployeeService otherEmployeeService => new OtherEmployeeService(_unitOfWork, _mapperUnitOfWork.OtherEmployeeMapper);

        public IPatientProcedureService patientProcedureService => new PatientProcedureService(_unitOfWork, _mapperUnitOfWork.PatientProcedureMapper);
        public IDoctorService doctorService => new DoctorService(_unitOfWork, _mapperUnitOfWork);
        public IPositionService positionService => new PositionService(_unitOfWork, _mapperUnitOfWork);
    }
}