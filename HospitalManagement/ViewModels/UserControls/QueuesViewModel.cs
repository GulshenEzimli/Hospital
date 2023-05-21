using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class QueuesViewModel : BaseControlViewModel<QueueModel>
    {
        private readonly IControlModelService<PatientModel> _patientService;
        private readonly IControlModelService<DoctorModel> _doctorService;
        private readonly IControlModelService<ProcedureModel> _procedureService;
        public QueuesViewModel(IControlModelService<PatientModel> patientService,
                               IControlModelService<DoctorModel> doctorService,
                               IControlModelService<ProcedureModel> procedureService, 
                               IControlModelService<QueueModel> queueService,
                               ErrorDialog errorDialog) : base(queueService, errorDialog)
        {
            _patientService = patientService;
            _doctorService = doctorService;
            _procedureService = procedureService;
        }

        public override string Header => "Queues";

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
            Procedures = _procedureService.GetAll();
        }
    }
}
