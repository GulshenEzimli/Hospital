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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class OperationsViewModel : BaseControlViewModel
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OperationsViewModel(IServiceUnitOfWork serviceUnitOfWork, ErrorDialog errorDialog) : base(errorDialog)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            AllValues = new List<OperationModel>();
            AllDoctorValues = new List<DoctorModel>();
            AllNurseValues = new List<NurseModel>();
            SetDefaultValues();
        }
        public override string Header => "Operations";

        private Situations _currentSituation;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private OperationModel _currentValue;
        public OperationModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private OperationModel _selectedValue;
        public OperationModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);

                if (value == null)
                {
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = new OperationModel();
                    CurrentValue = SelectedValue.Clone();                    
                    if(value.Doctors != null)
                    {
                        for (int i = 0; i < value.Doctors.Count; i++)
                        {
                            var doctorValue = DoctorValues.FirstOrDefault(x => x.Id == value.Doctors[i].Id);
                            if (doctorValue != null)
                            {
                                DoctorValues.Remove(doctorValue);
                            }
                        }
                    }
                    if (value.Nurses != null)
                    {
                        for (int i = 0; i < value.Nurses.Count; i++)
                        {
                            var nurseValue = NurseValues.FirstOrDefault(x => x.Id == value.Nurses[i].Id);
                            if (nurseValue != null)
                            {
                                NurseValues.Remove(nurseValue);
                            }
                        }
                    }
                    CurrentSituation = Situations.SELECTED;
                }
            }
        }

        private ObservableCollection<OperationModel> _values;
        public ObservableCollection<OperationModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<OperationModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        public List<OperationModel> AllValues { get; set; }


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



        public AddOperationCommand Add => new AddOperationCommand(this);
        public DeleteOperationCommand Delete => new DeleteOperationCommand(this, _serviceUnitOfWork);
        public EditOperationCommand Edit => new EditOperationCommand(this);
        public RejectOperationCommand Reject => new RejectOperationCommand(this);
        public SaveOperationCommand Save => new SaveOperationCommand(this, _serviceUnitOfWork);
        public RemoveDoctorCommand RemoveDoctor => new RemoveDoctorCommand(this);
        public RemoveNurseCommand RemoveNurse => new RemoveNurseCommand(this);
        public ExportExcelOperationCommand ExportExcel => new ExportExcelOperationCommand(this);


        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new OperationModel();

            SetSelectedValue(null);
        }

        private void SetSelectedValue(OperationModel operationModel)
        {
            _selectedValue = operationModel;
            OnPropertyChanged(nameof(SelectedValue));

            DoctorValues = new ObservableCollection<DoctorModel>(AllDoctorValues);
            NurseValues = new ObservableCollection<NurseModel>(AllNurseValues);
        }

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<OperationModel>(AllValues);
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                var filteredResult = AllValues.Where(x => x.OperationCost.ToString().Contains(lowerSearchText) == true ||
                                                 x.OperationReason?.ToLower().Contains(lowerSearchText) == true ||                                                 
                                                 x.OperationDate.ToString(SystemConstants.DateDisplayFormat).Contains(lowerSearchText) == true ||
                                                 x.Patient.DisplayPatient.ToLower().Contains(lowerSearchText) == true ||
                                                 x.Room.DisplayRoom.ToLower().Contains(lowerSearchText) == true ||
                                                 x.Doctors.Where(y => y.DisplayDoctor.ToLower().Contains(lowerSearchText) == true).ToList().Any() ||
                                                 x.Nurses.Where(y => y.DisplayNurse.ToLower().Contains(lowerSearchText) == true).ToList().Any()).ToList();

                Values = new ObservableCollection<OperationModel>(filteredResult);
            }
        }
    }
}
