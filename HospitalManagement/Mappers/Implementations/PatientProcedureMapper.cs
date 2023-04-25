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
            //patientProcedureModel.Patient = new PatientModel()
            //{
            //    Id = patientProcedure.Patient.Id,
            //    Name = patientProcedure.Patient.Name,
            //    Surname = patientProcedure.Patient.Surname,
            //    PIN = patientProcedure.Patient.PIN,
            //};
            //patientProcedureModel.Doctor = new DoctorModel()
            //{
            //    Id = patientProcedure.Doctor.Id,
            //    FirstName = patientProcedure.Doctor.FirstName,
            //    LastName = patientProcedure.Doctor.LastName,
            //    PIN = patientProcedure.Doctor.PIN,
            //};
            //patientProcedureModel.Nurse = new NurseModel()
            //{
            //    Id = patientProcedure.Nurse.Id,
            //    FirstName = patientProcedure.Nurse.FirstName,
            //    LastName = patientProcedure.Nurse.LastName,
            //    PIN = patientProcedure.Nurse.PIN,
            //};
            //patientProcedureModel.Procedure = new ProcedureModel()
            //{
            //    Id = patientProcedure.Procedure.Id,
            //    Name = patientProcedure.Procedure.Name,
            //    Cost = patientProcedure.Procedure.Cost,
            //};

            PatientProcedureModel patientProcedureModel = new PatientProcedureModel();

            patientProcedureModel.Id = patientProcedure.Id;
            patientProcedureModel.Patient = _mapperUnitOfWork.PatientMapper.Map(patientProcedure.Patient);
            patientProcedureModel.Doctor = _mapperUnitOfWork.DoctorMapper.Map(patientProcedure.Doctor);
            patientProcedureModel.Nurse = _mapperUnitOfWork.NurseMapper.Map(patientProcedure.Nurse);
            patientProcedureModel.Procedure = _mapperUnitOfWork.ProcedureMapper.Map(patientProcedure.Procedure);
            patientProcedureModel.UseDate = patientProcedure.UseDate;

            return patientProcedureModel;
        }
    }
}
