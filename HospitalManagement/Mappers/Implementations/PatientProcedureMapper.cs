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
    public class PatientProcedureMapper : IPatientProcedureMapper
    {
        private readonly IMapperUnitOfWork _mapperUnitOfWork;
        public PatientProcedureMapper(IMapperUnitOfWork mapperUnitOfWork)
        {
            _mapperUnitOfWork = mapperUnitOfWork;
        }
        public PatientProcedure Map(PatientProcedureModel patientProcedureModel)
        {
            PatientProcedure patientProcedure = new PatientProcedure();
            patientProcedure.Id = patientProcedureModel.Id;
            patientProcedure.Patient = _mapperUnitOfWork.PatientMapper.Map(patientProcedureModel.Patient);
            patientProcedure.Doctor = _mapperUnitOfWork.DoctorMapper.Map(patientProcedureModel.Doctor);
            patientProcedure.Nurse = _mapperUnitOfWork.NurseMapper.Map(patientProcedureModel.Nurse);
            patientProcedure.Procedure = _mapperUnitOfWork.ProcedureMapper.Map(patientProcedureModel.Procedure);

            return patientProcedure;
        }

        public PatientProcedureModel Map(PatientProcedure patientProcedure)
        {
            PatientProcedureModel patientProcedureModel = new PatientProcedureModel();

            patientProcedureModel.Id = patientProcedure.Id;
            patientProcedureModel.Patient = new PatientModel();
            patientProcedureModel.Patient = _mapperUnitOfWork.PatientMapper.Map(patientProcedure.Patient);
            patientProcedureModel.Doctor = new DoctorModel();
            patientProcedureModel.Doctor = _mapperUnitOfWork.DoctorMapper.Map(patientProcedure.Doctor);
            patientProcedureModel.Nurse = new NurseModel();
            patientProcedureModel.Nurse = _mapperUnitOfWork.NurseMapper.Map(patientProcedure.Nurse);
            patientProcedureModel.Procedure = new ProcedureModel();
            patientProcedureModel.Procedure = _mapperUnitOfWork.ProcedureMapper.Map(patientProcedure.Procedure);
            patientProcedureModel.UseDate = patientProcedure.UseDate;

            return patientProcedureModel;
        }
    }
}
