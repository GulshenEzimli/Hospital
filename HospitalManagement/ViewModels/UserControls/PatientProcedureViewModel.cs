using HospitalManagement.Enums;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientProcedureViewModel : BaseControlViewModel<PatientProcedureModel>
    {
        private readonly IControlModelService<PatientModel> _patientService;
        private readonly IControlModelService<DoctorModel> _doctorService;
        private readonly IControlModelService<NurseModel> _nurseService;
        private readonly IControlModelService<ProcedureModel> _procedureService;
        public PatientProcedureViewModel(IControlModelService<PatientModel> patientService,
                                         IControlModelService<DoctorModel> doctorService,
                                         IControlModelService<NurseModel> nurseService,
                                         IControlModelService<ProcedureModel> procedureService,
                                         IControlModelService<PatientProcedureModel> patientProcedureService,
                                         ErrorDialog errorDialog) : base(patientProcedureService, errorDialog)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _nurseService = nurseService;
            _procedureService = procedureService;
        }
        public override string Header => "Patients and Procedures";
        
        private List<PatientModel> _patients;
        public List<PatientModel> Patients
        {
            get => _patients ?? (_patients = new List<PatientModel>());
            set
            {
                _patients = value;
            }
        }

        private List<DoctorModel> _doctors;
        public List<DoctorModel> Doctors
        {
            get => _doctors ?? (_doctors = new List<DoctorModel>());
            set
            {
                _doctors = value;
            }
        }

        private List<NurseModel> _nurses;
        public List<NurseModel> Nurses
        {
            get => _nurses ?? (_nurses = new List<NurseModel>());
            set
            {
                _nurses = value;
            }
        }

        private List<ProcedureModel> _procedures;
        public List<ProcedureModel> Procedures
        {
            get => _procedures ?? (_procedures = new List<ProcedureModel>());
            set
            {
                _procedures = value;
            }
        }

        public override void Load()
        {
            Patients = _patientService.GetAll();
            Doctors = _doctorService.GetAll();
            Nurses = _nurseService.GetAll();
            Procedures = _procedureService.GetAll();

        }
    }
}
