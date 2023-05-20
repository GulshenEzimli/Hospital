using DocumentFormat.OpenXml.Spreadsheet;
using HospitalManagement.Commands.Doctors;
using HospitalManagement.Commands.Operations;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class OperationsViewModel : BaseControlViewModel<OperationModel>
    {
        private readonly IControlModelService<PatientModel> _patientService;
        private readonly IControlModelService<RoomModel> _roomService;
        private readonly IControlModelService<DoctorModel> _doctorService;
        private readonly IControlModelService<NurseModel> _nurseService;
        public OperationsViewModel(IControlModelService<PatientModel> patientService,
                                   IControlModelService<RoomModel> roomService,
                                   IControlModelService<DoctorModel> doctorService,
                                   IControlModelService<NurseModel> nurseService,
                                   IControlModelService<OperationModel> operationService,
                                   ErrorDialog errorDialog) : base(operationService, errorDialog)
        {            
            _patientService = patientService;
            _roomService = roomService;
            _doctorService = doctorService;
            _nurseService = nurseService;
            AllDoctorValues = new List<DoctorModel>();
            AllNurseValues = new List<NurseModel>();
        }
        public override string Header => "Operations";

        private List<PatientModel> _patientValues;
        public List<PatientModel> PatientValues
        {
            get => _patientValues ?? (_patientValues = new List<PatientModel>());
            set
            {
                _patientValues = value;
            }
        }

        private List<RoomModel> _roomValues;
        public List<RoomModel> RoomValues
        {
            get => _roomValues ?? (_roomValues = new List<RoomModel>());
            set
            {
                _roomValues = value;
            }
        }

        private ObservableCollection<DoctorModel> _doctorValues;
        public ObservableCollection<DoctorModel> DoctorValues
        {
            get => _doctorValues ?? (_doctorValues = new ObservableCollection<DoctorModel>());
            set
            {
                _doctorValues = value;
                OnPropertyChanged(nameof(DoctorValues));
            }
        }

        public List<DoctorModel> AllDoctorValues { get; set; }

        private DoctorModel _selectedDoctor;
        public DoctorModel SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {               
                _selectedDoctor = value;
                OnPropertyChanged(nameof(SelectedDoctor));

                if (value == null)
                    return;

                CurrentValue.Doctors.Add(value);
                DoctorValues.Remove(value);
            }
        }

        private ObservableCollection<NurseModel> _nurseValues;
        public ObservableCollection<NurseModel> NurseValues
        {
            get => _nurseValues ?? (_nurseValues = new ObservableCollection<NurseModel>());
            set
            {
                _nurseValues = value;
                OnPropertyChanged(nameof(NurseValues));
            }
        }

        public List<NurseModel> AllNurseValues { get; set; }

        private NurseModel _selectedNurse;
        public NurseModel SelectedNurse
        {
            get => _selectedNurse;
            set
            {
                _selectedNurse = value;
                OnPropertyChanged(nameof(SelectedNurse));

                if (value == null)
                    return;

                CurrentValue.Nurses.Add(value);
                NurseValues.Remove(value);
            }
        }

        public override void OnSelectedValueChanged()
        {
            if (SelectedValue == null)
            {
                DoctorValues = new ObservableCollection<DoctorModel>(AllDoctorValues);
                NurseValues = new ObservableCollection<NurseModel>(AllNurseValues);
            }
            else
            {
                var doctors = AllDoctorValues.Where(x => SelectedValue.Doctors.Select(d => d.Id).ToList().Contains(x.Id) == false);
                DoctorValues = new ObservableCollection<DoctorModel>(doctors);

                var nurses = AllNurseValues.Where(x => SelectedValue.Nurses.Select(n => n.Id).ToList().Contains(x.Id) == false);
                NurseValues = new ObservableCollection<NurseModel>(nurses);
            }
        }

        public override void Load()
        {
            List<PatientModel> patients = _patientService.GetAll();
            PatientValues = new List<PatientModel>(patients);

            List<RoomModel> rooms = _roomService.GetAll();
            RoomValues = new List<RoomModel>(rooms);

            var doctors = _doctorService.GetAll();
            AllDoctorValues = doctors;
            DoctorValues = new ObservableCollection<DoctorModel>(doctors);

            var nurses = _nurseService.GetAll();
            AllNurseValues = nurses;
            NurseValues = new ObservableCollection<NurseModel>(nurses);
        }
    }
}
