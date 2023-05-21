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
    public class PatientProcedureMapper : IControlModelMapper<PatientProcedure,PatientProcedureModel>
    {
        private readonly IControlModelMapper<Patient, PatientModel> _patientMapper;
        private readonly IControlModelMapper<Nurse, NurseModel> _nurseMapper;
        private readonly IControlModelMapper<Doctor, DoctorModel> _doctorMapper;
        private readonly IControlModelMapper<Procedure, ProcedureModel> _procedureMapper;
        public PatientProcedureMapper(IControlModelMapper<Patient, PatientModel> patientMapper,
                                        IControlModelMapper<Nurse, NurseModel> nurseMapper,
                                        IControlModelMapper<Doctor, DoctorModel> doctorMapper,
                                         IControlModelMapper<Procedure, ProcedureModel> procedureMapper)
        {
            _patientMapper = patientMapper;
            _procedureMapper = procedureMapper;
            _nurseMapper = nurseMapper;
            _doctorMapper = doctorMapper;
        }
        public PatientProcedure Map(PatientProcedureModel patientProcedureModel)
        {
            PatientProcedure patientProcedure = new PatientProcedure();
            patientProcedure.Id = patientProcedureModel.Id;
            patientProcedure.Patient =_patientMapper.Map(patientProcedureModel.Patient);
            patientProcedure.Doctor = _doctorMapper.Map(patientProcedureModel.Doctor);
            patientProcedure.Nurse = _nurseMapper.Map(patientProcedureModel.Nurse);
            patientProcedure.Procedure =_procedureMapper.Map(patientProcedureModel.Procedure);

            return patientProcedure;
        }

        public PatientProcedureModel Map(PatientProcedure patientProcedure)
        {
            PatientProcedureModel patientProcedureModel = new PatientProcedureModel();

            patientProcedureModel.Id = patientProcedure.Id;
            patientProcedureModel.Patient = new PatientModel();
            patientProcedureModel.Patient =_patientMapper.Map(patientProcedure.Patient);
            patientProcedureModel.Doctor = new DoctorModel();
            patientProcedureModel.Doctor = _doctorMapper.Map(patientProcedure.Doctor);
            patientProcedureModel.Nurse = new NurseModel();
            patientProcedureModel.Nurse = _nurseMapper.Map(patientProcedure.Nurse);
            patientProcedureModel.Procedure = new ProcedureModel();
            patientProcedureModel.Procedure = _procedureMapper.Map(patientProcedure.Procedure);
            patientProcedureModel.UseDate = patientProcedure.UseDate;

            return patientProcedureModel;
        }
    }
}
